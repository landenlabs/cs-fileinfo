using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;


namespace FileInfo
{
    /// <summary>
    /// Display disk (and file) cluster allocation map.
    /// Author: Dennis Lang 2009
    /// https://landenlabs.com/
    /// 
    /// </summary>
    public partial class ViewDiskAllocation : Form
    {
        /// <summary>
        /// View disk cluster allocation (utilization) as an image.
        /// </summary>
        public ViewDiskAllocation()
        {
            InitializeComponent();

            DriveInfo[] diList = DriveInfo.GetDrives();
            foreach (DriveInfo di in diList)
            {
                if (di.DriveType == DriveType.Fixed)
                {
                    this.driveCombo.Items.Add(di.Name.Split(Path.DirectorySeparatorChar)[0]);
                }
            }

            this.driveCombo.SelectedItem = this.driveCombo.Items[0];
        }

        /// <summary>
        /// View disk allocation (utilization) with file allocation in overlay.
        /// </summary>
        public ViewDiskAllocation(string filepath)
        {
            InitializeComponent();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filepath);
            string device = fileInfo.DirectoryName.Split(Path.DirectorySeparatorChar)[0];
            this.driveCombo.Items.Add(device);
            this.driveCombo.SelectedItem = this.driveCombo.Items[0];

            RefreshDriveAllocationImage(device);
            HighLightFileAllocation(filepath);
        }

        /// <summary>
        /// Make grid squares in overlay to divide area by quarters.
        /// </summary>
        private void MakeGrid()
        {
            Size size = diskPicture.DisplayRectangle.Size;

            int w = size.Width;
            int h = size.Height;
            Bitmap topImage = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(topImage);
            for (int y = 0; y < h; y += h / 4)
            {
                g.DrawLine(Pens.Black, new Point(0, y), new Point(w, y));
                g.DrawLine(Pens.White, new Point(0, y + 1), new Point(w, y + 1));
            }
            for (int x = 0; x < w; x += w / 4)
            {
                g.DrawLine(Pens.Black, new Point(x, 0), new Point(x, h));
                g.DrawLine(Pens.White, new Point(x + 1, 0), new Point(x + 1, h));
            }
            g.Flush();

            this.diskPicture.Image = topImage;
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            string device = this.driveCombo.SelectedItem.ToString();
            RefreshDriveAllocationImage(device);
        }

        // Keep copy of some stuff so resize/refresh can regenerate material.
        string m_filepath = string.Empty;
        ClusterListDialog m_clusterDialog = new ClusterListDialog();

        /// <summary>
        /// Draw file allocation in overlay image as small circles.
        /// </summary>
        private void HighLightFileAllocation(string filepath)
        {
            try
            {
                Array vcn_lcn = FileSysInfo.GetFileMap(filepath);

                int len0 = vcn_lcn.GetLength(0);
                int len1 = vcn_lcn.GetLength(1);

                Graphics g = Graphics.FromImage(diskPicture.Image);
                int bgW = diskPicture.BackgroundImage.Width;
                int bgH = diskPicture.BackgroundImage.Height;
                int dspW = diskPicture.Image.Width;
                int dspH = diskPicture.Image.Height;
                double xScale = (double)dspW / bgW;
                double yScale = (double)dspH / bgH;

                Int64 prevVcn = 0;
                Point firstP = Point.Empty;
                Point lastP = Point.Empty;

                m_clusterDialog.View.Items.Clear();

                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filepath);
                ListViewItem item;
                item = m_clusterDialog.View.Items.Add("");
                item.SubItems.Add("Name:");
                item.SubItems.Add(fileInfo.Name);
                item = m_clusterDialog.View.Items.Add("");
                item.SubItems.Add("Size:");
                item.SubItems.Add(fileInfo.Length.ToString());
                item = m_clusterDialog.View.Items.Add("");
                item = m_clusterDialog.View.Items.Add("");
                item.SubItems.Add("Length");
                item.SubItems.Add("Cluster#");

                int dia = 4;

                for (int x = 0; x < len0; x++)
                {
                    // for (int y = 0; y < len1; y++)
                    Int64 vcn = (Int64)vcn_lcn.GetValue(x, 0);
                    Int64 lcn = (Int64)vcn_lcn.GetValue(x, 1);
                    Int64 len = vcn - prevVcn;
                    prevVcn = vcn;

                    if (lcn > 0)
                    {
                        item = this.m_clusterDialog.View.Items.Add("");
                        item.SubItems.Add(len.ToString());
                        item.SubItems.Add(lcn.ToString());

                        if (len > 1024*1024)
                            len = 1;    // truncate length, it is probably corrupt

                        int lastPixel = -1;
                        while (len-- > 0)
                        {
                            int pixel = (int)(lcn / clusterPerPixel);
                            vcn++;
                            lcn++;

                            if (pixel != lastPixel)
                            {
                                lastPixel = pixel;
                                lastP = new Point((int)((pixel % bgW) * xScale), (int)((pixel / bgW) * yScale));
                                if (firstP == Point.Empty)
                                    firstP = lastP;

                                // g.DrawLine(Pens.Lavender, lastP, lastP);
                                g.DrawEllipse(Pens.White, lastP.X - dia / 2, lastP.Y - dia / 2, dia, dia);
                            }
                        }
                    }
                }

                // Mark start and end of allocation chain
                dia = 20;
                g.DrawEllipse(Pens.Orange, firstP.X - dia / 2, firstP.Y - dia / 2, dia, dia);
                g.DrawEllipse(Pens.Orange, lastP.X - dia / 2, lastP.Y - dia / 2, dia, dia);

                g.Flush();
                diskPicture.Refresh();

                // Update title
                string fn = Path.GetFileName(filepath);
                if (fn.Length != 0)
                    this.title.Text = fn;

                this.status.Text = string.Format("FileSize:{0}  {1}", fileInfo.Length, filepath);

                m_clusterDialog.Show(this);
                m_filepath = filepath;
            }
            catch (Exception ee)
            {
                this.status.Text = ee.Message + ", Failed to highlight allocation of file:" + filepath;
            }
        }

        private void RefreshDriveAllocationImage(string device)
        {
            this.status.Text = "Building disk cluster allocation image for drive " + device;

            this.Cursor = Cursors.WaitCursor;
          
            MakeDriveAllocationImage(device);
            if (diskPicture.Image == null || diskPicture.Image.Size != diskPicture.DisplayRectangle.Size)
                MakeGrid();

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Help resize by hiding overlay, regenerate overlay, unhide.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);
            this.diskPicture.Image = null;
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);

            // Remake grid and optionally file allocation
            MakeGrid();
            if (m_filepath != string.Empty)
                HighLightFileAllocation(m_filepath);
        }

        /// <summary>
        /// Make an image with each pixel colorized based on its associated cluster utilization.
        /// </summary>
        uint clusterPerPixel = 64;
        private void MakeDriveAllocationImage(string device)
        {
            Size size = diskPicture.DisplayRectangle.Size;

            Bitmap bmImage = new Bitmap(size.Width, size.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            diskPicture.BackgroundImage = bmImage;
            diskPicture.Refresh();

            ColorPalette colorPalette = bmImage.Palette;
            colorPalette.Entries[0] = Color.FromArgb(255, 0, 0, 0);
            for (int clrIdx = 1; clrIdx < 64; clrIdx++)
                colorPalette.Entries[clrIdx] = Color.FromArgb(255, clrIdx*4, clrIdx*4, 0);
            for (int clrIdx = 64; clrIdx < 128; clrIdx++)
                colorPalette.Entries[clrIdx] = Color.FromArgb(255, 0, clrIdx * 2, 0);
            for (int clrIdx = 128; clrIdx < 192; clrIdx++)
                colorPalette.Entries[clrIdx] = Color.FromArgb(255, 0, 0,clrIdx);
            for (int clrIdx = 192; clrIdx < 256; clrIdx++)
                colorPalette.Entries[clrIdx] = Color.FromArgb(255, clrIdx, 0, 0);
            bmImage.Palette = colorPalette;

            BitArray bitArray;
            uint freeClusterCnt = 0;

            try
            {
                bitArray = FileSysInfo.GetVolumeMap(device);
                int imageSize = bmImage.Width * bmImage.Height;
                clusterPerPixel = (uint)Math.Ceiling((double)bitArray.Length / imageSize);

                if (bitArray.Length > imageSize)
                {
                    byte[] pixels = new byte[imageSize];

                    uint imgIdx = 0;
                    for (uint bitIdx = 0; bitIdx < bitArray.Length; bitIdx += clusterPerPixel)
                    {
                        uint pixelCnt = 0;
                        uint clsIdx = bitIdx;
                        uint clsEnd = Math.Min((uint)bitArray.Length, clsIdx + clusterPerPixel);
                        uint numCls = clsEnd - clsIdx;
                        while (clsIdx < clsEnd)
                        {
                            if (bitArray[(int)clsIdx++])
                                pixelCnt++;
                        }

                        freeClusterCnt += numCls - pixelCnt;
                        if (numCls > 0)
                        {
                            // byte pixelVal = (byte)(Math.Round(pixelCnt * 8.0 / numCls) * 32 - 1);
                            byte pixelVal = (byte)(pixelCnt * 255 / numCls);
                            pixels[imgIdx] = pixelVal;
                        }

                        imgIdx++;
                    }

                    int row = 0;
                    for (int h = 0; h < bmImage.Height; h++)
                    {
                        for (int x = bmImage.Width - 10; x < bmImage.Width; x++)
                        {
                            pixels[row + x] = (byte)(h * 255 / bmImage.Height);
                        }
                        row += bmImage.Width;
                    }
                    BitmapData bmpData = bmImage.LockBits(
                          new Rectangle(0, 0, bmImage.Width, bmImage.Height),
                          ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

                    Marshal.Copy(pixels, 0, bmpData.Scan0, imageSize);
                    bmImage.UnlockBits(bmpData);
                    long usedPercent = (bitArray.Length - freeClusterCnt) * 100 / bitArray.Length;
                    long freePercent = freeClusterCnt * 100 / bitArray.Length;
                    this.status.Text = string.Format("Disk Clusters:{0} Used:{1}% Free:{2}% Cluster/Pixel:{3}",
                            bitArray.Length, usedPercent, freePercent, clusterPerPixel);
                }
                else
                {
                    // TODO - deal with disk cluster size smaller than image.
                    for (int idx = 0; idx < bitArray.Length; idx++)
                    {

                    }
                }
            }
            catch (Exception ee)
            {
                status.Text = "Failed, error=" + ee.Message;
            }

            diskPicture.BackgroundImage = bmImage;
            diskPicture.Refresh();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Capture image of dialog (screen shot)
        /// </summary>
        /// <returns></returns>
        private Image MakeScreenImage()
        {
            Rectangle rect = this.Bounds;

            int color = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat pFormat;

            switch (color)
            {
                case 8:
                case 16:
                    pFormat = PixelFormat.Format16bppRgb565;
                    break;

                case 24:
                    pFormat = PixelFormat.Format24bppRgb;
                    break;

                case 32:
                    pFormat = PixelFormat.Format32bppArgb;
                    break;

                default:
                    pFormat = PixelFormat.Format32bppArgb;
                    break;
            }

            Application.DoEvents();
            Image image = new Bitmap(rect.Width, rect.Height, pFormat);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);

            return image;
        }


        private void saveImageBtn_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.MakeScreenImage().Save(this.saveFileDialog.FileName);
                    this.status.Text = "Save screen to image:" + this.saveFileDialog.FileName;
                }
                catch (Exception ee)
                {
                    this.status.Text = ee.Message + ", Failed to save image to:" + this.saveFileDialog.FileName;
                }
            }
        }

    }
}
