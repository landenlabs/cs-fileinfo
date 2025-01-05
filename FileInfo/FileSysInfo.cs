using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Diagnostics;
using System.Collections;
using System.Runtime.InteropServices;

using System.Reflection;


namespace FileInfo
{
    /// <summary>
    /// General File System Information routines.
    /// 
    /// Author: Dennis Lang 2009
    /// https://landenlabs.com/
    /// 
    /// </summary>
    class FileSysInfo
    {
        //  The following code was derived from information provided by these links.
        //
        //  http://blogs.msdn.com/jeffrey_wall/archive/2004/09/13/229137.aspx
        //  http://www.google.com/search?hl=en&lr=&q=DeviceIoControl+c%23
        //
        // CreateFile constants
        //
        const uint FILE_SHARE_READ = 0x00000001;
        const uint FILE_SHARE_WRITE = 0x00000002;
        const uint FILE_SHARE_DELETE = 0x00000004;
        const uint FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
        const uint OPEN_EXISTING = 3;

        const uint GENERIC_READ = (0x80000000);
        const uint GENERIC_WRITE = (0x40000000);

        const uint FILE_FLAG_NO_BUFFERING = 0x20000000;
        const uint FILE_READ_ATTRIBUTES = (0x0080);
        const uint FILE_WRITE_ATTRIBUTES = 0x0100;
        const uint ERROR_INSUFFICIENT_BUFFER = 122;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int DeviceIoControl(
            IntPtr hDevice,
            uint dwIoControlCode,
            IntPtr lpInBuffer,
            uint nInBufferSize,
            [Out] IntPtr lpOutBuffer,
            uint nOutBufferSize,
            ref uint lpBytesReturned,
            IntPtr lpOverlapped);

        // ex   @"\\.\PhysicalDrive0"
        // ex   @"\\.\c:"
        static private IntPtr OpenVolume(string DeviceName)
        {
            IntPtr hDevice;
            hDevice = CreateFile(
                @"\\.\" + DeviceName,
                GENERIC_READ|GENERIC_WRITE,
                FILE_SHARE_READ | FILE_SHARE_WRITE,
                IntPtr.Zero,
                OPEN_EXISTING,
                0,
                IntPtr.Zero);
            if ((int)hDevice == -1)
            {
                throw new Exception(Marshal.GetLastWin32Error().ToString());
            }
            return hDevice;
        }

        static private IntPtr OpenFile(string path)
        {
            IntPtr hFile;
            hFile = CreateFile(
                        path,
                        FILE_READ_ATTRIBUTES | FILE_WRITE_ATTRIBUTES,
                        FILE_SHARE_READ | FILE_SHARE_WRITE,
                        IntPtr.Zero,
                        OPEN_EXISTING,
                        0,
                        IntPtr.Zero);
            if ((int)hFile == -1)
            {
                throw new Exception(Marshal.GetLastWin32Error().ToString());
            }
            return hFile;
        }

        #region ==== DiskFreeSpace
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
           out ulong lpFreeBytesAvailable,
           out ulong lpTotalNumberOfBytes,
           out ulong lpTotalNumberOfFreeBytes);

            // string device = driveLetter + ":\\";
        // return GetDiskFreeSpaceEx(device, out freeBytesAvail, out totalNumOfBytes, out totalNumOfFreeBytes);
        #endregion


        #region ==== File System Statistics
        [StructLayout(LayoutKind.Sequential)]
        public struct FILESYSTEM_STATISTICS
        {
            public UInt16 FileSystemType;
            public UInt16 Version;
                   UInt32 SizeOfCompleteStructure;
            public UInt32 UserFileReads;
            public UInt32 UserFileReadBytes;
            public UInt32 UserDiskReads;
            public UInt32 UserFileWrites;
            public UInt32 UserFileWriteBytes;
            public UInt32 UserDiskWrites;
            public UInt32 MetaDataReads;
            public UInt32 MetaDataReadBytes;
            public UInt32 MetaDataDiskReads;
            public UInt32 MetaDataWrites;
            public UInt32 MetaDataWriteBytes;
            public UInt32 MetaDataDiskWrites;
        };

        public static void Merge(ref FILESYSTEM_STATISTICS inOut1, FILESYSTEM_STATISTICS in2)
        {
            inOut1.UserFileReads       +=  in2.UserFileReads;
            inOut1.UserFileReadBytes   +=  in2.UserFileReadBytes;
            inOut1.UserDiskReads       +=  in2.UserDiskReads;
            inOut1.UserFileWrites      +=  in2.UserFileWrites;
            inOut1.UserFileWriteBytes  +=  in2.UserFileWriteBytes;
            inOut1.UserDiskWrites      +=  in2.UserDiskWrites;
            inOut1.MetaDataReads       +=  in2.MetaDataReads;
            inOut1.MetaDataReadBytes   +=  in2.MetaDataReadBytes;
            inOut1.MetaDataDiskReads   +=  in2.MetaDataDiskReads;
            inOut1.MetaDataWrites      +=  in2.MetaDataWrites;
            inOut1.MetaDataWriteBytes  +=  in2.MetaDataWriteBytes;
            inOut1.MetaDataDiskWrites  +=  in2.MetaDataDiskWrites;
        }

        /// <summary>
        /// Reflect list into a list of names and values stored in a dictionary.
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetDictionary(NTFS_STATISTICS inObj)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            Type objectType1 = inObj.GetType();
            FieldInfo[] fldList1 = objectType1.GetFields();
            int cnt = fldList1.Count();

            for (int idx = 0; idx < cnt; idx++)
            {
                FieldInfo fld1 = fldList1[idx];
                object fld1Obj = fld1.GetValue(inObj);

                if (fld1Obj != null)
                {
                    Type t1 = fld1Obj.GetType();

                    if (t1.IsNestedPublic)
                    {
                        //  ReflectUpdList(fldObj, true, listView, f0 + "[]", bgColor);
                    }
                    else
                    {
                        dict.Add(fld1.Name, fld1Obj);
                    }
                }
            }

            return dict;
        }

        /// <summary>
        /// return merge (sum) of  values from identical keys.
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="in2"></param>
        /// <returns></returns>
        public static Dictionary<string, object> Merge(Dictionary<string, object>in1, Dictionary<string, object>in2)
        {
            Dictionary<string, object> merged = new Dictionary<string, object>();

            foreach (string key in in1.Keys)
            {
                object obj1 = in1[key];
                object obj2 = in2[key];
                Type objectType1 = obj1.GetType();
                Type objectType2 = obj2.GetType();

                if (obj1 is UInt16)
                {
                    UInt32 sum = (UInt16)obj1 + (UInt32)(UInt16)obj2;
                    merged.Add(key, (UInt16)sum);
                }
                else if (obj1 is UInt32)
                {
                    UInt32 sum = (UInt32)obj1 + (UInt32)obj2;
                    merged.Add(key, sum);
                }
                else
                {
                    // just pass obj1 to output list.
                    merged.Add(key, obj1);
                }
            }

            return merged;
        }

        [StructLayout(LayoutKind.Sequential)]
        public  struct NTFS_STATISTICS 
        {
            UInt32 LogFileFullExceptions;
            UInt32 OtherExceptions;

            //
            // Other meta data io's
            //

            public UInt32 MftReads;
            public UInt32 MftReadBytes;
            public UInt32 MftWrites;
            public UInt32 MftWriteBytes;

            [StructLayout(LayoutKind.Sequential)]
            public struct MftWritesUserLevel
            {
                public UInt16   Write;
                public UInt16 Create;
                public UInt16 SetInfo;
                public UInt16 Flush;
            }
            public MftWritesUserLevel mftWritesUserLevel;

            public UInt16 MftWritesFlushForLogFileFull;
            public UInt16 MftWritesLazyWriter;
            public UInt16 MftWritesUserRequest;

            public UInt32 Mft2Writes;
            public UInt32 Mft2WriteBytes;

            public MftWritesUserLevel mft2WritesUserLevel;

            UInt16   Mft2WritesFlushForLogFileFull;
            public UInt16 Mft2WritesLazyWriter;
            public UInt16 Mft2WritesUserRequest;

            public UInt32 RootIndexReads;
            public UInt32 RootIndexReadBytes;
            public UInt32 RootIndexWrites;
            public UInt32 RootIndexWriteBytes;

            public UInt32 BitmapReads;
            public UInt32 BitmapReadBytes;
            public UInt32 BitmapWrites;
            public UInt32 BitmapWriteBytes;

            public UInt16 BitmapWritesFlushForLogFileFull;
            public UInt16 BitmapWritesLazyWriter;
            public UInt16 BitmapWritesUserRequest;

            [StructLayout(LayoutKind.Sequential)]
            public struct BitmapWritesUserLevel
            {
                public UInt16 Write;
                public UInt16 Create;
                public UInt16 SetInfo;
            }
            public BitmapWritesUserLevel bitmapWritesUserLevel;

            public UInt32 MftBitmapReads;
            public UInt32 MftBitmapReadBytes;
            public UInt32 MftBitmapWrites;
            public UInt32 MftBitmapWriteBytes;

            public UInt16 MftBitmapWritesFlushForLogFileFull;
            public UInt16 MftBitmapWritesLazyWriter;
            public UInt16 MftBitmapWritesUserRequest;

            public MftWritesUserLevel mftBitmapWritesUserLevel;

            public UInt32 UserIndexReads;
            public UInt32 UserIndexReadBytes;
            public UInt32 UserIndexWrites;
            public UInt32 UserIndexWriteBytes;

            //
            // Additions for NT 5.0
            //

            public UInt32 LogFileReads;
            public UInt32 LogFileReadBytes;
            public UInt32 LogFileWrites;
            public UInt32 LogFileWriteBytes;

            [StructLayout(LayoutKind.Sequential)]
            struct Allocate
            {
                public UInt32 Calls;                // number of individual calls to allocate clusters
                public UInt32 Clusters;             // number of clusters allocated
                public UInt32 Hints;                // number of times a hint was specified

                public UInt32 RunsReturned;         // number of runs used to satisify all the requests

                public UInt32 HintsHonored;         // number of times the hint was useful
                public UInt32 HintsClusters;        // number of clusters allocated via the hint
                public UInt32 Cache;                // number of times the cache was useful other than the hint
                public UInt32 CacheClusters;        // number of clusters allocated via the cache other than the hint
                public UInt32 CacheMiss;            // number of times the cache wasn't useful
                public UInt32 CacheMissClusters;    // number of clusters allocated without the cache
            } 
            Allocate allocate;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FS_stats 
        {
            public FILESYSTEM_STATISTICS fs;
            public NTFS_STATISTICS ntfs;
            // UInt32[12] filler;
            // DWORDLONG ForceSizeAndAlignment[32];  // pad to a multiple of 64 bytes
        };

        /// <summary>
        /// Return array of FS_stats  statistics for drive.
        /// </summary>
        /// <param name="drive"></param>
        /// <returns>FS_stats[]</returns>
        static public FS_stats[] GetFileSystemStatistics(string drive)
        {
            //   \\.\c:   or c:\
            string device = drive;
            IntPtr hDevice = IntPtr.Zero;
            IntPtr pAlloc = IntPtr.Zero;

            try
            {
                hDevice = CreateFile(device, FILE_READ_ATTRIBUTES, 7, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero);

                FS_stats fsStats = new FS_stats();
                int fsStatsSize = Marshal.SizeOf(fsStats);
                int fsStatsSize64 = (fsStatsSize + 63) / 64 * 64;
                int fsStatsTotalSize = fsStatsSize64 * 12;

                pAlloc = Marshal.AllocHGlobal(fsStatsTotalSize);
                IntPtr pDest = pAlloc;
                uint returnSize = 0;

                int status = DeviceIoControl(
                    hDevice,
                    FSConstants.FSCTL_FILESYSTEM_GET_STATISTICS,
                    IntPtr.Zero,
                    0,
                    pDest,
                    (uint)fsStatsTotalSize,
                    ref returnSize,
                    IntPtr.Zero);

                int err = Marshal.GetLastWin32Error();

                if (status == 0)
                {
                   throw new Exception(err.ToString());
                }

                int numStats = (int)returnSize / fsStatsSize64;
                FS_stats[] fsStatList = new FS_stats[numStats];
                IntPtr fsPtr = new IntPtr(pAlloc.ToInt64());

                for (int fsIdx = 0; fsIdx < numStats; fsIdx++)
                {
                    fsStatList[fsIdx] = (FS_stats)Marshal.PtrToStructure(fsPtr, typeof(FS_stats));
                    fsPtr = new IntPtr(fsPtr.ToInt64() + fsStatsSize64);
                }

                return fsStatList;
            }
            finally
            {
                CloseHandle(hDevice);
                hDevice = IntPtr.Zero;

                Marshal.FreeHGlobal(pAlloc);
                pAlloc = IntPtr.Zero;
            }
        }

        #endregion


        #region ==== System Info
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern void GetSystemInfo(SYSTEM_INFO Info);

        [StructLayout(LayoutKind.Sequential)]
        public class SYSTEM_INFO
        {
        public Int16 ProcessorArchitecture;
        public Int16 Reserved;
        public Int32 PageSize;

        public IntPtr MinAppAddress;
        public IntPtr MaxAppAddress;
        public IntPtr ActiveProcMask;

        public Int32 NumberOfProcessor;
        public Int32 ProcessorType;
        public Int32 AllocGranulirity;

        public Int16 ProcessorLevel;
        public Int16 ProcessorRevision;
        }

        #endregion


        #region ==== Disk Cache Info
        public enum DISK_CACHE_RETENTION_PRIORITY
        {
            EqualPriority,
            KeepPrefetchedData,
            KeepReadData
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DISK_CACHE_INFORMATION 
        {
            public byte ParametersSavable;
            public byte ReadCacheEnabled;
            public byte WriteCacheEnabled;
            // public byte filler1;
            public UInt32 /* DISK_CACHE_RETENTION_PRIORITY */ ReadRetentionPriority;
            public UInt32 /* DISK_CACHE_RETENTION_PRIORITY */ WriteRetentionPriority;
            public UInt16 DisablePrefetchTransferLength;
            public byte PrefetchScalar;
            // public byte filler2;

            [StructLayout(LayoutKind.Sequential)]
            public struct ScalarPrefetch
            {
                public UInt16 Minimum;
                public UInt16 Maximum;
                public UInt16 MaximumBlocks;
            }
            public ScalarPrefetch scalarPrefetch;
        }

        static public DISK_CACHE_INFORMATION GetDiskCacheInformation(int physicalDrive)
        {
            // \\.\PhysicalDrive0
            //   \\.\c:   or c:\
            string device = string.Format(@"\\.\PhysicalDrive{0}", physicalDrive);
            IntPtr hDevice = IntPtr.Zero;
            IntPtr pAlloc = IntPtr.Zero;

            try
            {
                hDevice = CreateFile(device, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero);

                DISK_CACHE_INFORMATION diskCacheInfo = new DISK_CACHE_INFORMATION();
                int cacheInfoSize = Marshal.SizeOf(diskCacheInfo);
                // int cacheInfoSize64 = (cacheInfoSize + 63) / 64 * 64;

                pAlloc = Marshal.AllocHGlobal(cacheInfoSize);
                IntPtr pDest = pAlloc;
                uint returnSize = 0;
                uint ioctl = FSConstants.IOCTL_DISK_GET_CACHE_INFORMATION;

                int status = DeviceIoControl(
                    hDevice,
                    FSConstants.IOCTL_DISK_GET_CACHE_INFORMATION,
                    IntPtr.Zero,
                    0,
                    pDest,
                    (uint)cacheInfoSize,
                    ref returnSize,
                    IntPtr.Zero);

                if (status == 0)
                {
                    string errMsg = Marshal.GetLastWin32Error().ToString();
                    throw new Exception(errMsg);
                }

                diskCacheInfo = (DISK_CACHE_INFORMATION)Marshal.PtrToStructure(pAlloc, typeof(DISK_CACHE_INFORMATION));

                return diskCacheInfo;
            }
            finally
            {
                CloseHandle(hDevice);
                hDevice = IntPtr.Zero;

                Marshal.FreeHGlobal(pAlloc);
                pAlloc = IntPtr.Zero;
            }
        }
        #endregion

        #region ==== Disk Performance

        [StructLayout(LayoutKind.Sequential) ]
        public unsafe struct DISK_PERFORMANCE 
        {
          public Int64 BytesRead;
          public Int64 BytesWritten;
          public Int64 ReadTime;
          public Int64 WriteTime;
          public Int64 IdleTime;
          public UInt32 ReadCount;
          public UInt32 WriteCount;
          public UInt32 QueueDepth;
          public UInt32 SplitCount;
          public Int64 QueryTime;
          public UInt32 StorageDeviceNumber;
          public fixed char StorageManagerName[8];     
        }

        static public DISK_PERFORMANCE GetDiskPerformance(int physicalDrive)
        {
            // \\.\PhysicalDrive0
            //   \\.\c:   or c:\
            string device = string.Format(@"\\.\PhysicalDrive{0}", physicalDrive);
            IntPtr hDevice = IntPtr.Zero;
            IntPtr pAlloc = IntPtr.Zero;

            try
            {
                hDevice = CreateFile(device, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero);

                DISK_PERFORMANCE diskPerformance = new DISK_PERFORMANCE();

                int diskPerfSize = Marshal.SizeOf(diskPerformance);
                // int cacheInfoSize64 = (cacheInfoSize + 63) / 64 * 64;

                pAlloc = Marshal.AllocHGlobal(diskPerfSize);
                IntPtr pDest = pAlloc;
                uint returnSize = 0;
                uint ioctl = FSConstants.IOCTL_DISK_GET_CACHE_INFORMATION;

                int status = DeviceIoControl(
                    hDevice,
                    FSConstants.IOCTL_DISK_PERFORMANCE,
                    IntPtr.Zero,
                    0,
                    pDest,
                    (uint)diskPerfSize,
                    ref returnSize,
                    IntPtr.Zero);

                int err = Marshal.GetLastWin32Error();

                if (status == 0)
                {
                    string errMsg = err.ToString();
                    throw new Exception(errMsg);
                }

                diskPerformance = (DISK_PERFORMANCE)Marshal.PtrToStructure(pAlloc, typeof(DISK_PERFORMANCE));

                return diskPerformance;
            }
            finally
            {
                CloseHandle(hDevice);
                hDevice = IntPtr.Zero;

                Marshal.FreeHGlobal(pAlloc);
                pAlloc = IntPtr.Zero;
            }
        }

        #endregion


        /// <summary>
        /// Get cluster usage for a device
        /// </summary>
        /// <param name="DeviceName">use "c:"</param>
        /// <returns>a bitarray for each cluster</returns>
        static public BitArray GetVolumeMap(string DeviceName)
        {
            IntPtr pBitmap = IntPtr.Zero;
            IntPtr hDevice = IntPtr.Zero;

            try
            {
                hDevice = OpenVolume(DeviceName);

                Int64 startingLCN = 0;          // starting logical cluster number.
                uint SLCN_size = (uint)Marshal.SizeOf(startingLCN);

                GCHandle handle = GCHandle.Alloc(startingLCN, GCHandleType.Pinned);
                IntPtr pSLCN = handle.AddrOfPinnedObject();

                // Assumes max drive size is 2 TB.

                // alloc off more than enough for my machine
                // 64 megs == 67,108,864 bytes == 536,870,912 bits == cluster count
                // NTFS 4k clusters == 2,147,483,648 k of storage == 2,097,152 megs == 2048 gig disk storage
                uint bitmapSize = 1024 * 1024 * 64; // 1024 bytes == 1k * 1024 == 1 meg * 64 == 64 megs

                uint returnSize = 0;
                pBitmap = Marshal.AllocHGlobal((int)bitmapSize);
                IntPtr pDstBitmap = pBitmap;

                int status = DeviceIoControl(
                    hDevice,
                    FSConstants.FSCTL_GET_VOLUME_BITMAP,
                    pSLCN,
                    SLCN_size,
                    pDstBitmap,
                    bitmapSize,
                    ref returnSize,
                    IntPtr.Zero);

                if (status == 0)
                {
                    int err = Marshal.GetLastWin32Error();
                    throw new Exception(err.ToString());
                }
                handle.Free();

                /*
                object returned was...
                  typedef struct 
                  {
                   LARGE_INTEGER StartingLcn;
                   LARGE_INTEGER BitmapSize;
                   BYTE Buffer[1];
                  } VOLUME_BITMAP_BUFFER, *PVOLUME_BITMAP_BUFFER;
                */
                Int64 StartingLcn = (Int64)Marshal.PtrToStructure(pDstBitmap, typeof(Int64));

                Debug.Assert(StartingLcn == 0);

                pDstBitmap = (IntPtr)((Int64)pDstBitmap + 8);
                Int64 BitmapSize = (Int64)Marshal.PtrToStructure(pDstBitmap, typeof(Int64));

                Int32 byteSize = (int)(BitmapSize / 8);
                byteSize++; // round up - even with no remainder

                IntPtr BitmapBegin = (IntPtr)((Int64)pDstBitmap + 8);

                byte[] byteArr = new byte[byteSize];

                Marshal.Copy(BitmapBegin, byteArr, 0, (Int32)byteSize);

                BitArray retVal = new BitArray(byteArr);
                retVal.Length = (int)BitmapSize; // truncate to exact cluster count
                return retVal;
            }
            finally
            {
                CloseHandle(hDevice);
                hDevice = IntPtr.Zero;

                Marshal.FreeHGlobal(pBitmap);
                pBitmap = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Returns a 2*number of extents array, the vcn and the lcn as pairs.
        /// </summary>
        /// <param name="path">file to get the map for ex: "c:\windows\explorer.exe" </param>
        /// <returns>An array of [virtual cluster, physical cluster (-1=emtpy)]</returns>
        static public Array GetFileMap(string path)
        {
            IntPtr hFile = IntPtr.Zero;
            IntPtr pAlloc = IntPtr.Zero;

            try
            {
                hFile = OpenFile(path);

                Int64 startingLCN = 0;          // starting logical cluster number.
                uint SLCN_size = (uint)Marshal.SizeOf(startingLCN);

                GCHandle handle = GCHandle.Alloc(startingLCN, GCHandleType.Pinned);
                IntPtr pSLCN = handle.AddrOfPinnedObject();

                uint dstSize = 1024 * 1024 * 64; // 1024 bytes == 1k * 1024 == 1 meg * 64 == 64 megs

                uint returnSize = 0;
                pAlloc = Marshal.AllocHGlobal((int)dstSize);
                IntPtr pDest = pAlloc;
                int status  = DeviceIoControl(
                    hFile,
                    FSConstants.FSCTL_GET_RETRIEVAL_POINTERS,
                    pSLCN,
                    SLCN_size,
                    pDest,
                    dstSize,
                    ref returnSize,
                    IntPtr.Zero);

                int err = Marshal.GetLastWin32Error();
                System.Diagnostics.Debug.WriteLine("File map err=" + err.ToString());

                if (status == 0)
                {
                    throw new Exception(err.ToString());
                }

                handle.Free();

                /*
                 returned back one of...
                 
                 typedef struct RETRIEVAL_POINTERS_BUFFER 
                 {  
                 UInt32 ExtentCount;  
                 Int64 StartingVcn;  
                    struct 
                    {
                       Int64 NextVcn;
                       Int64 Lcn;
                    } Extents[1];
                 }
                 
                */

                Int32 ExtentCount = (Int32)Marshal.PtrToStructure(pDest, typeof(Int32));

                pDest = (IntPtr)((Int64)pDest + 4);
                pDest = (IntPtr)((Int64)pDest + 4);   // pad to 8 byte boundary
                Int64 StartingVcn = (Int64)Marshal.PtrToStructure(pDest, typeof(Int64));
                Debug.Assert(StartingVcn == 0);

                pDest = (IntPtr)((Int64)pDest + 8);
                // now pDest points at an array of pairs of Int64s.
                Array retVal = Array.CreateInstance(typeof(Int64), new int[2] { ExtentCount, 2 });

                for (int i = 0; i < ExtentCount; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Int64 v = (Int64)Marshal.PtrToStructure(pDest, typeof(Int64));
                        retVal.SetValue(v, new int[2] { i, j });
                        pDest = (IntPtr)((Int64)pDest + 8);
                    }
                }

                return retVal;
            }
            finally
            {
                CloseHandle(hFile);
                hFile = IntPtr.Zero;

                Marshal.FreeHGlobal(pAlloc);
                pAlloc = IntPtr.Zero;
            }
        }


        /// <summary>
        /// Constants lifted from winioctl.h from platform sdk
        /// </summary>
        internal class FSConstants
        {
            const uint FILE_DEVICE_FILE_SYSTEM = 0x00000009;

            const uint METHOD_NEITHER = 3;
            const uint METHOD_BUFFERED = 0;

            const uint FILE_ANY_ACCESS = 0;
            const uint FILE_SPECIAL_ACCESS = FILE_ANY_ACCESS;

            public static uint FSCTL_GET_VOLUME_BITMAP = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 27, METHOD_NEITHER, FILE_ANY_ACCESS);
            public static uint FSCTL_GET_RETRIEVAL_POINTERS = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 28, METHOD_NEITHER, FILE_ANY_ACCESS);
            public static uint FSCTL_MOVE_FILE = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 29, METHOD_BUFFERED, FILE_SPECIAL_ACCESS);

            public const int FSCTL_FILESYSTEM_GET_STATISTICS = 0x00090060;
            public const int FSCTL_GET_NTFS_VOLUME_DATA      = 0x00090064;
            public const int FSCTL_GET_NTFS_FILE_RECORD      = 0x00090068;
            // public const int FSCTL_GET_VOLUME_BITMAP         = 0x0009006f;
            // public const int FSCTL_GET_RETRIEVAL_POINTERS    = 0x00090073;


            const uint FILE_DEVICE_MASS_STORAGE = 45;
            const uint IOCTL_STORAGE_BASE = FILE_DEVICE_MASS_STORAGE;

            const uint FILE_DEVICE_DISK	= 7;
            const uint FILE_DEVICE_DISK_FILE_SYSTEM	= 8;
            const uint IOCTL_DISK_BASE = FILE_DEVICE_DISK;

            const uint FILE_READ_ACCESS	= 0x00000001;
            const uint FILE_WRITE_ACCESS = 0x00000002;

            public static uint IOCTL_DISK_GET_DRIVE_GEOMETRY = CTL_CODE(IOCTL_DISK_BASE,0,METHOD_BUFFERED, FILE_ANY_ACCESS);
            public static uint IOCTL_DISK_GET_PARTITION_INFO = CTL_CODE(IOCTL_DISK_BASE,1,METHOD_BUFFERED,FILE_READ_ACCESS);
            public static uint IOCTL_DISK_SET_PARTITION_INFO = CTL_CODE(IOCTL_DISK_BASE,2,METHOD_BUFFERED,FILE_READ_ACCESS|FILE_WRITE_ACCESS);
            public static uint IOCTL_DISK_GET_DRIVE_LAYOUT	= CTL_CODE(IOCTL_DISK_BASE,3,METHOD_BUFFERED,FILE_READ_ACCESS);
            public static uint IOCTL_DISK_SET_DRIVE_LAYOUT = CTL_CODE(IOCTL_DISK_BASE,4,METHOD_BUFFERED,FILE_READ_ACCESS|FILE_WRITE_ACCESS);
            public static uint IOCTL_DISK_VERIFY = CTL_CODE(IOCTL_DISK_BASE,5,METHOD_BUFFERED,FILE_ANY_ACCESS);
            public static uint IOCTL_DISK_FORMAT_TRACKS = CTL_CODE(IOCTL_DISK_BASE,6,METHOD_BUFFERED,FILE_READ_ACCESS|FILE_WRITE_ACCESS);
            public static uint IOCTL_DISK_REASSIGN_BLOCKS = CTL_CODE(IOCTL_DISK_BASE,7,METHOD_BUFFERED,FILE_READ_ACCESS|FILE_WRITE_ACCESS);
            public static uint IOCTL_DISK_PERFORMANCE = CTL_CODE(IOCTL_DISK_BASE,8,METHOD_BUFFERED,FILE_ANY_ACCESS);
            public static uint IOCTL_DISK_IS_WRITABLE = CTL_CODE(IOCTL_DISK_BASE,9,METHOD_BUFFERED,FILE_ANY_ACCESS);
            public static uint IOCTL_DISK_LOGGING = CTL_CODE(IOCTL_DISK_BASE,10,METHOD_BUFFERED,FILE_ANY_ACCESS);
            public static uint IOCTL_DISK_GET_PARTITION_INFO_EX = CTL_CODE(IOCTL_DISK_BASE,0x12,METHOD_BUFFERED,FILE_ANY_ACCESS);
            public static uint IOCTL_DISK_SET_PARTITION_INFO_EX = CTL_CODE(IOCTL_DISK_BASE,0x13,METHOD_BUFFERED,FILE_READ_ACCESS | FILE_WRITE_ACCESS);
            public static uint IOCTL_DISK_GET_DRIVE_LAYOUT_EX = CTL_CODE(IOCTL_DISK_BASE,0x14,METHOD_BUFFERED,FILE_ANY_ACCESS);
            public static uint IOCTL_DISK_SET_DRIVE_LAYOUT_EX = CTL_CODE(IOCTL_DISK_BASE,0x15,METHOD_BUFFERED,FILE_READ_ACCESS | FILE_WRITE_ACCESS);
            public static uint IOCTL_DISK_PERFORMANCE_OFF = CTL_CODE(IOCTL_DISK_BASE,0x18,METHOD_BUFFERED,FILE_ANY_ACCESS);
            public static uint IOCTL_DISK_GET_DRIVE_GEOMETRY_EX = CTL_CODE(IOCTL_DISK_BASE,0x28,METHOD_BUFFERED,FILE_ANY_ACCESS);
            public static uint IOCTL_DISK_GROW_PARTITION = CTL_CODE(IOCTL_DISK_BASE,0x34,METHOD_BUFFERED,FILE_READ_ACCESS | FILE_WRITE_ACCESS);
            public static uint IOCTL_DISK_GET_CACHE_INFORMATION = CTL_CODE(IOCTL_DISK_BASE,0x35,METHOD_BUFFERED,FILE_READ_ACCESS);
            public static uint IOCTL_DISK_SET_CACHE_INFORMATION = CTL_CODE(IOCTL_DISK_BASE,0x36,METHOD_BUFFERED,FILE_READ_ACCESS | FILE_WRITE_ACCESS);


            static uint CTL_CODE(uint DeviceType, uint Function, uint Method, uint Access)
            {
                return ((DeviceType) << 16) | ((Access) << 14) | ((Function) << 2) | (Method);
            }
        }
    }
}
