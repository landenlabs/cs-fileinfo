using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static FileInfo.OpenHandles;
using System;
using System.Runtime.InteropServices;


namespace FileInfo
{
    /// <summary>
    /// Collect open handles.  Code found on sysInternals website.
    // /http://forum.sysinternals.com/forum_posts.asp?TID=17533
    /// 
    /// Used in FileInfo project by Dennis Lang 2009
    /// https://landenlabs.com/
    /// 
    /// </summary>
    class OpenHandles
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern uint ZwQuerySystemInformation(SYSTEM_INFORMATION_CLASS SystemInformationClass, 
            IntPtr SystemInformation, int SystemInformationLength, out int ReturnLength);

        public enum SYSTEM_INFORMATION_CLASS : int
        {
            SystemBasicInformation,
            SystemProcessorInformation,
            SystemPerformanceInformation,
            SystemTimeOfDayInformation,
            SystemNotImplemented1,
            SystemProcessesAndThreadsInformation,
            SystemCallCounts,
            SystemConfigurationInformation,
            SystemProcessorTimes,
            SystemGlobalFlag,
            SystemNotImplemented2,
            SystemModuleInformation,
            SystemLockInformation,
            SystemNotImplemented3,
            SystemNotImplemented4,
            SystemNotImplemented5,
            SystemHandleInformation
            // there's more but it would make the post too long...
        }

        //  http://msdn.microsoft.com/en-us/library/ms973190.aspx
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_HANDLE_INFORMATION
        {   // sizeof 16 for XP32 and 24 bytes for XP64
            public Int32 ProcessId;
            public byte ObjectTypeNumber;
            public byte Flags;              // 1 = PROTECT_FROM_CLOSE, 2 = INHERIT
            public short Handle;
            public IntPtr Object;           // 4 or 8 byte field.
            public Int32 GrantedAccess;
            // pad with 4 bytes for xp64
        }
        static  int hndSize = IntPtr.Size;    // 8 for xp64 and 4 for xp32

        public const uint STATUS_INFO_LENGTH_MISMATCH = 0xc0000004;


		public static SYSTEM_HANDLE_INFORMATION[] EnumHandles() {
			int retLength = 0;
			int allocLength = 0x10000; // Start with a larger buffer (64KB)
			IntPtr data = Marshal.AllocHGlobal(allocLength);

			try {
				// 1. Loop until buffer is large enough
				uint status;
				while ((status = ZwQuerySystemInformation(SYSTEM_INFORMATION_CLASS.SystemHandleInformation, data, allocLength, out retLength)) == STATUS_INFO_LENGTH_MISMATCH) {
					allocLength = retLength > allocLength ? retLength : allocLength * 2;
					// Reallocate to the new size. Free and reallocate to avoid leaking if ReAllocHGlobal fails
					Marshal.FreeHGlobal(data);
					data = Marshal.AllocHGlobal(allocLength);
				}

				if (status != 0) // STATUS_SUCCESS
					return Array.Empty<SYSTEM_HANDLE_INFORMATION>();

				// Use the returned length when available to bound parsing
				int bytesAvailable = retLength > 0 ? retLength : allocLength;

				// 2. Read the count (Use 32-bit read to avoid a malformed huge value)
				int reportedCount = 0;
				try { reportedCount = Marshal.ReadInt32(data); } catch { reportedCount = 0; }

				if (reportedCount < 0) reportedCount = 0;

				int structSize = Marshal.SizeOf(typeof(SYSTEM_HANDLE_INFORMATION));
				int maxPossible = (bytesAvailable - IntPtr.Size) / structSize;
				if (maxPossible < 0) maxPossible = 0;
				int count = Math.Min(reportedCount, maxPossible);

				var handles = new List<SYSTEM_HANDLE_INFORMATION>(count > 0 ? count : Math.Max(16, maxPossible));

				long baseAddr = data.ToInt64();
				long offset = IntPtr.Size; // Skip the handle count header

				for (int i = 0; i < count; i++) {
					if (offset + structSize > bytesAvailable)
						break; // avoid reading past buffer

					IntPtr entryPtr = new IntPtr(baseAddr + offset);
					var entry = (SYSTEM_HANDLE_INFORMATION)Marshal.PtrToStructure(entryPtr, typeof(SYSTEM_HANDLE_INFORMATION));
					handles.Add(entry);
					offset += structSize;
				}

				return handles.ToArray();
			}
			finally {
				// Use finally to ensure memory is freed even if an exception occurs
				Marshal.FreeHGlobal(data);
			}
		}

		[DllImport("kernel32.dll", SetLastError = true)]
        static extern int DuplicateHandle(int hSourceProcessHandle, int hSourceHandle,
                int hTargetProcessHandle, ref int lpTargetHandle,
                int dwDesiredAccess, int bInheritHandle, int dwOptions);

        [Flags]
        public enum DuplicateOptions : uint
        {
            DUPLICATE_CLOSE_SOURCE = (0x00000001),// Closes the source handle. This occurs regardless of any error status returned.
            DUPLICATE_SAME_ACCESS = (0x00000002), //Ignores the dwDesiredAccess parameter. The duplicate handle has the same access as the source handle.
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct StatusBlock
        {
            public UInt64 v1;
            public UInt64 v2;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FILE_NAME_INFORMATION 
        {
          public UInt64     FileNameLength;
          public Char       FileName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct UNICODE_STRING
        {
            public UInt16 Length;
            public UInt16 MaximumLength;
            public IntPtr pBuffer;
        }

        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern uint ZwQueryInformationFile(int hnd, IntPtr StatusBlock, IntPtr FILE_NAME_INFORMATION, 
            int FileInfoLength, int code);


        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern uint ZwQueryObject(int hnd, int code, IntPtr FILE_NAME_INFORMATION,
            int FileInfoLength, ref int ReturnLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(int handle);

        /// <summary>
        /// Return Description of handle.
        /// Note: only some handle object types are supported (Directory, Key, File, ...)
        /// </summary>
        /// <param name="pid">Process Id of handle owner</param>
        /// <param name="handle">Handle number</param>
        /// <param name="objectTypeNumber">Object number of handle (See ObjectTypeDescription()) </param>
        /// <returns>true string has description, false string has error</returns>
        public static bool HandleDescription(int pid, int handle, int objectTypeNumber, out string description)
        {
            description = string.Empty;
            bool result = false;

            // In order to query a handle, we need to convert it from the owners number scheme to 
            // our number scheme by duplicating the handle. Some handles cannot be duplicated.
            if (objectTypeNumber > 30 || objectTypeNumber < 0)
                objectTypeNumber = 0;

            switch (objectTypeNumber)
            {
                case 1: //type1 
                // case 2: //Directory 
                // case 3: //SymbolicLink 
                case 4: //Token 
                case 5: //Process 
                case 6: //Thread 
                case 7: //Job 
                case 8: //type8 
                case 9: //Event 
                case 10: //type10 
                // case 11: //Mutant 
                case 12: //type12 
                case 13: //Semaphore 
                case 14: //Timer 
                case 15: //type15 
                // case 16: //KeyedEvent 
                // case 17: //WindowStn 
                // case 18: //Desktop 
                // case 19: //Section 
                // case 20: //Registry 
                case 21: //Port 
                case 22: //type22 
                case 23: //type23 
                case 24: //type24 
                case 25: //type25 
                case 26: //type26 
                case 27: //IoComplete       
                // case 28: //File 
                case 29: //WmiGuid 
                case 30: // ????
                    return false;   // cannot dup, return 
            }

            Process pidProc = Process.GetProcessById(pid);
            Process ourProc = Process.GetCurrentProcess();

            int ourHandle = 0;
            IntPtr dataPtr = IntPtr.Zero;
            IntPtr statusBlock = IntPtr.Zero;
            const int READ_CONTROL = 0x00020000;
            const int STANDARD_RIGHTS_READ = READ_CONTROL;

            try
            {
                int status1 = DuplicateHandle(pidProc.Handle.ToInt32(), handle, ourProc.Handle.ToInt32(),
                    ref ourHandle, STANDARD_RIGHTS_READ, 0, 0);
                if (status1 == 1 && ourHandle > 0)
                {
                    int fileInfoSize = 512;             // guess at max query response size.
                    dataPtr = Marshal.AllocHGlobal(512);
                    uint status2;
                    int returnSize = 0;

                    if (objectTypeNumber != 28)     // use QueryObject for non-files handles
                    {
                        status2 = ZwQueryObject(ourHandle, 1, dataPtr, fileInfoSize, ref returnSize);
                        if (status2 == 0)
                        {
                            int filenameLength = Marshal.ReadInt16(dataPtr);
                            if (filenameLength > 0)
                            {
                                int offset = IntPtr.Size * 2;
                                string fn = Marshal.PtrToStringUni(new IntPtr(dataPtr.ToInt32() + offset));
                                description = fn.Substring(0, filenameLength / 2);
                                result = true;
                            }
                        }
                    }
                    else
                    {
                        // Use specialized QueryInformationFile for file handles.
                        statusBlock = Marshal.AllocHGlobal(8);
                        int FileNameInformation = 9;        // enum to query filename

                        status2 = ZwQueryInformationFile(ourHandle, statusBlock, dataPtr,
                                fileInfoSize, FileNameInformation);
                        if (status2 == 0)
                        {
                            int filenameLength = Marshal.ReadInt32(dataPtr);
                            if (filenameLength > 0)
                            {
                                string fn = Marshal.PtrToStringUni(new IntPtr(dataPtr.ToInt32() + 4));
                                description = fn.Substring(0, filenameLength / 2);
                                result = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                description = ee.Message;
            }
            finally
            {
                Marshal.FreeHGlobal(dataPtr);
                Marshal.FreeHGlobal(statusBlock);
                CloseHandle(ourHandle);
            }

            return result;
        }


        /// <summary>
        /// Convert object type number to a string.
        /// </summary>
        /// <param name="objTypeNumber"></param>
        /// <returns></returns>
        public static string ObjectTypeDescription(int objTypeNumber)
        {
            string resultName = string.Empty;

			/*
			// Windows 7 ? 
            switch (objTypeNumber)
            {
                case 1:  return  "type1";
                case 2:  return  "Directory";
                case 3:  return  "SymbolicLink";
                case 4:  return  "Token";
                case 5:  return  "Process";
                case 6:  return  "Thread";
                case 7:  return  "Job";
                case 8:  return  "type8";
                case 9:  return  "Event";
                case 10:  return  "type10";
                case 11:  return  "Mutant";
                case 12:  return  "type12";
                case 13:  return  "Semaphore";
                case 14:  return  "Timer";
                case 15:  return  "type15";
                case 16:  return  "KeyedEvent";
                case 17:  return  "WindowStn";
                case 18:  return  "Desktop";
                case 19:  return  "Section";
                case 20:  return  "Registry";
                case 21:  return  "Port";
                case 22:  return  "type22";
                case 23:  return  "type23";
                case 24:  return  "type24";
                case 25:  return  "type25";
                case 26:  return  "type26";
                case 27:  return  "IoComplete";
                case 28:  return  "File";
                case 29:  return  "WmiGuid";
                case 30:  return  "Obj_30";
                case 31:  return  "Obj_31";
                case 32:  return  "Obj_32";
                case 33:  return  "Obj_33";
                case 34:  return  "Obj_34";
                case 35:  return  "Obj_35";
                case 36:  return  "Obj_36";
            }
			*/


			// https://github.com/FuzzySecurity/PSKernel-Primitives/blob/master/Get-Handles.ps1
			// 	$OSVersion = [Version](Get-WmiObject Win32_OperatingSystem).Version
			// 	$OSMajorMinor = "$($OSVersion.Major).$($OSVersion.Minor)"

			// Windows 10.0
			switch (objTypeNumber)
			{
				case 1: return "type1";
				case 2: return "Type";
				case 3: return "Directory";
				case 4: return "SymbolicLink";
				case 5: return "Token";
				case 6: return "Job";
				case 7: return "Process";
				case 8: return "Thread";
				case 9: return "Partition";
				case 10: return "UserApcReserve";
				case 11: return "IoCompletionReserve";
				case 12: return "ActivityReference";
				case 13: return "PsSiloContextPaged";
				case 14: return "PsSiloContextNonPaged";
				case 15: return "DebugObject";
				case 16: return "Event";
				case 17: return "Mutant";
				case 18: return "Callback";
				case 19: return "Semaphore";
				case 20: return "Timer";
				case 21: return "IRTimer";
				case 22: return "Profile";
				case 23: return "KeyedEvent";
				case 24: return "WindowStation";
				case 25: return "Desktop";
				case 26: return "Composition";
				case 27: return "RawInputManager";
				case 28: return "CoreMessaging";
				case 29: return "TpWorkerFactory";
				case 30: return "Adapter";
			 case 31: return "Controller";
				case 32: return "Device";
				case 33: return "Driver";
				case 34: return "IoCompletion";
				case 35: return "WaitCompletionPacket";
				case 36: return "File";
				case 37: return "TmTm";
				case 38: return "TmTx";
				case 39: return "TmRm";
				case 40: return "TmEn";
				case 41: return "Section";
				case 42: return "Session";
				case 43: return "Key";
				case 44: return "RegistryTransaction";
				case 45: return "ALPC Port";
				case 46: return "EnergyTracker";
				case 47: return "PowerRequest";
				case 48: return "WmiGuid";
				case 49: return "EtwRegistration";
				case 50: return "EtwSessionDemuxEntry";
				case 51: return "EtwConsumer";
				case 52: return "DmaAdapter";
				case 53: return "DmaDomain";
				case 54: return "PcwObject";
				case 55: return "FilterConnectionPort";
				case 56: return "FilterCommunicationPort";
				case 57: return "NdisCmState";
				case 58: return "DxgkSharedResource";
				case 59: return "DxgkSharedSyncObject";
				case 60: return "DxgkSharedSwapChainObject";
				case 61: return "DxgkDisplayManagerObject";
				case 62: return "DxgkCurrentDxgProcessObject";
				case 63: return "DxgkSharedProtectedSessionObject";
				case 64: return "DxgkSharedBundleObject";
				case 65: return "VRegConfigurationContext";

				case 66: return "Obj_66";
				case 67: return "Obj_67";
				case 68: return "Obj_68";
				case 69: return "Obj_69";
			}
            return resultName;
        }


    }
}
