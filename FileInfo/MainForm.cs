using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
// using System.Net;
using Microsoft.Win32;


namespace FileInfo
{
    /// <summary>
    /// Display and log information about files.
    /// Author: Dennis Lang 2009
    /// https://landenlabs.com/
    /// 
    /// </summary>
    public partial class MainForm : Form
    {
        // Main view objects
        ListViewProcesses ListViewProcesses = new ListViewProcesses();
        ListViewHandles ListViewHandles = new ListViewHandles();
        PrintListView printListView = new PrintListView();

        // Logging stuff
        string procLogFilename = "FileInfoProc.csv";
        TextWriter procLogWriter;
        UInt32 procLogLine = 0;

        string hndLogFilename = "FileInfoHnd.csv";
        TextWriter hndLogWriter;
        UInt32 hndLogLine = 0;

        // Special helper objects
        ListViewHandles.ViewHndGroup viewHndGroup = ListViewHandles.ViewHndGroup.eNoGroup;
        List<int> procPidLogList = new List<int>();
        Dictionary<int, bool> hndShowObjDict = new Dictionary<int, bool>();
        string logOnStr = "Log";
        const int procColLog = 17;

        FsInfoDialog fsInfoDialog = new FsInfoDialog();

        public MainForm()
        {
            InitializeComponent();

            this.Text = ProductNameAndVersion();
            this.title.Text = ProductNameAndVersion() + " DLang 2009";

            this.hndNoGrpBtn.Tag = ListViewHandles.ViewHndGroup.eNoGroup;
            this.hndPidGrpBtn.Tag = ListViewHandles.ViewHndGroup.ePidGroup;
            this.hndObjGrpBtn.Tag = ListViewHandles.ViewHndGroup.eObjectGroup;
            AddHndShowButtons();

            ListViewProcesses.UpdateView(this.procView);
            ListViewProcesses.UpdateView(this.procView);    // update twice to get colors correct.

            this.procClock.Text = NowTimeString();
            this.hndClock.Text = NowTimeString();

            // Default to autoUpdate off, was auto update every, 5 seconds
            this.procAutoUpdBtn.Checked = false;
            // procFileMenu_Click(procAutoUpdBtn, EventArgs.Empty);
            // procUpdRate_Click(proc5secBtn, EventArgs.Empty);

            procTimer.Start();
            handleTimer.Start();

            this.procView.ListViewItemSorter = new ListViewColumnSorter(ListViewColumnSorter.SortDataType.eAuto);
            this.handleView.ListViewItemSorter = new ListViewColumnSorter(ListViewColumnSorter.SortDataType.eAuto);


        }

        protected override void OnResizeBegin(EventArgs e)
        {
            this.procView.BeginUpdate();
            this.handleView.BeginUpdate();

            base.OnResizeBegin(e);
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            this.procView.EndUpdate();
            this.handleView.EndUpdate();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string ProductNameAndVersion()
        {
            string appName = Application.ProductName;
            string appVern = Application.ProductVersion;
            return appName + "V" + appVern.Substring(0, 3); //  Get part of versoin string "n.n"
        }

        string PrintTitle()
        {
            return string.Format("{0}     "
                    , this.Text
                    // , DateTime.Now.ToString("G")
                    // , Dns.GetHostName()
                    // , System.Environment.UserName
                    // , System.Environment.OSVersion.ToString()
                    );
        }

        private void About_Click(object sender, EventArgs e)
        {
            About about = new About(this);
            about.Text = "About - " + ProductNameAndVersion();
            about.Show();
        }

        private void FileSysInfo_Click(object sender, EventArgs e)
        {
            fsInfoDialog.Show();
        }

        private void diskClusterBtn_Click(object sender, EventArgs e)
        {
            ViewDiskAllocation viewDiskAllocation = new ViewDiskAllocation();
            viewDiskAllocation.Show();
        }

        /// <summary>
        /// Return Now Time string as hh:mm:ss
        /// </summary>
        private string NowTimeString()
        {
            return DateTime.Now.ToString("T", DateTimeFormatInfo.InvariantInfo); 
        }

        /// <summary>
        /// Column header click fires sort.
        /// Supports two tier sorting.
        /// </summary>
        private void ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView listView = sender as ListView;
            ListViewColumnSorter sorter = listView.ListViewItemSorter as ListViewColumnSorter;
            if (sorter == null)
                return;

            if (listView.Groups.Count != 0)
                MessageBox.Show("Sorting does not work when in 'Group' mode");

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == sorter.SortColumn1)
            {
                // Reverse the current sort direction for this column.
                if (sorter.Order1 == SortOrder.Ascending)
                    sorter.Order1 = SortOrder.Descending;
                else
                    sorter.Order1 = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.SortColumn2 = sorter.SortColumn1;
                sorter.Order2 = sorter.Order1;
                sorter.SortColumn1 = e.Column;
                sorter.Order1 = SortOrder.Ascending;
            }

            // Clear old arrows and set new arrow
            foreach (ColumnHeader colHdr in listView.Columns)
                colHdr.ImageIndex = -1;

            if (sorter.SortColumn1 != sorter.SortColumn2)
                listView.Columns[sorter.SortColumn2].ImageIndex = (sorter.Order2 == SortOrder.Ascending) ? 2 : 3;

            listView.Columns[sorter.SortColumn1].ImageIndex = (sorter.Order1 == SortOrder.Ascending) ? 0 : 1;

            // Perform the sort with these new sort options.
            if (listView != null)
                listView.Sort();
        }


        #region ==== Process Menu/Buttons

        /// <summary>
        /// Update Process View List drawing new entries in GREEN and dead in RED.
        /// </summary>
        private void UpdateProcessView()
        {
            procRefreshBtn.Image = global::FileInfo.Properties.Resources.green24;
            Application.DoEvents();     // This is dangerous to do !!!

            System.Collections.IComparer sorter = this.procView.ListViewItemSorter;
            this.procView.ListViewItemSorter = null;
            ListViewProcesses.UpdateView(this.procView);
            this.procView.ListViewItemSorter = sorter;
            this.procView.Sort();

            // Restore 'log' state
            foreach (int pid in procPidLogList)
            {
                ListViewItem[] items = procView.Items.Find(pid.ToString(), false);
                if (items != null && items.Length != 0)
                    items[0].SubItems[procColLog].Text = logOnStr;
            }

            this.procStatus.Text = this.procView.Items.Count.ToString() + " processes";
            this.procClock.Text = NowTimeString();

            procRefreshBtn.Image = procAutoUpdBtn.Checked ?
                      global::FileInfo.Properties.Resources.yellow24 :
                      global::FileInfo.Properties.Resources.red24;

            if (this.procLogWriter != null)
            {
                LogProcess();
            }
        }

        /// <summary>
        /// Log all or marked proocesses to disk log file.
        /// </summary>
        private void LogProcess()
        {
            string txtLine = string.Empty;
            if ((procLogLine % 50) == 0)
            {
                // Output column header ever few lines.
                txtLine += "Date, Time";
                foreach (ColumnHeader ch in procView.Columns)
                {
                    if (txtLine.Length != 0)
                        txtLine += ",";
                    txtLine += ch.Text + " ";
                }
                procLogWriter.WriteLine(txtLine);
            }

            foreach (ListViewItem item in procView.Items)
            {
                int pid = (int)item.Tag;
                if (pid == 0)
                    continue;   // ignore pid 0 (idle process)

                if (procPidLogList.Count == 0 ||
                    procPidLogList.Find(delegate(int t) { return pid == t; }) == pid)
                {
                    txtLine = string.Empty;

                    txtLine += DateTime.Now.ToShortDateString();
                    txtLine += ", ";
                    txtLine += NowTimeString();

                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        if (txtLine.Length != 0)
                            txtLine += ",";
                        if (subItem.Tag != null && subItem.Tag is long)
                            txtLine += ((long)subItem.Tag).ToString();  // use raw value
                        else
                            txtLine += subItem.Text.Replace(',', ';') + " ";
                    }

                    procLogWriter.WriteLine(txtLine);
                    procLogLine++;
                }
            }

            procStatus.Text = procLogLine.ToString() + " lines,  Log file " + procLogFilename;
        }

        /// <summary>
        /// Button press to force refresh
        /// </summary>
        private void procRefreshBtn_Click(object sender, EventArgs e)
        {
            UpdateProcessView();    
        }

        /// <summary>
        /// Toggle log column value
        /// </summary>
        private void procView_Click(object sender, EventArgs e)
        {
            Point p = this.procView.PointToClient(System.Windows.Forms.Control.MousePosition);
            ListViewItem itemAt = this.procView.GetItemAt(p.X, p.Y);
            if (itemAt != null)
            {
                if (itemAt.SubItems[procColLog].Bounds.Contains(p))
                {
                    bool off = (itemAt.SubItems[procColLog].Text == string.Empty);
                    off = !off;
                    itemAt.SubItems[procColLog].Text = off ? string.Empty : logOnStr;

                    int pid = (int)itemAt.Tag;
                    if (off)
                        procPidLogList.Remove(pid);
                    else
                        procPidLogList.Add(pid);
                }
            }
        }

        private void procTimer_Tick(object sender, EventArgs e)
        {
            if (this.procAutoUpdBtn.Checked)
            {
                UpdateProcessView();
            }
        }

        private void procUpdRate_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            foreach (ToolStripDropDownItem item in dropMenu.Items)
                item.Image = Properties.Resources.check_off;

            dropItem.Image = Properties.Resources.check_on;

            if ((int)dropItem.Tag > 0)
            {
                procTimer.Interval = 1000 * (int)dropItem.Tag;
                procAutoUpdBtn.Checked = true;
                procFileMenu_Click(procAutoUpdBtn, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("TODO - prompt for custom log interval");
            }
        }

        private void procView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateHandleView();
        }
 
        private void procFileMenu_Click(object sender, EventArgs e)
        {
            string text = (sender is ToolStripItem) ?
               ((ToolStripItem)sender).Text :
               ((ToolStripDropDownItem)sender).Text;

            switch (text)
            {
                case "AutoSize Columns":
                    this.procView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    this.procView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
                    break;

                case "Auto Update":
                    // procRefreshBtn.ForeColor = procAutoUpdBtn.Checked ? Color.Green : Color.Red;
                    procRefreshBtn.Image = procAutoUpdBtn.Checked ? 
                        global::FileInfo.Properties.Resources.yellow24 :
                        global::FileInfo.Properties.Resources.red24;
                    break;

                case "Auto Log":
                    if (procAutoLogBtn.Checked == false)
                    {
                        if (procLogWriter != null)
                            procLogWriter.Close();
                        procLogWriter = null;
                        procStatus.Text = "Logging disabled";
                        procLogMenu.ForeColor = Color.White;
                    }
                    else
                    {
                        try
                        {
                            procLogWriter = new StreamWriter(procLogFilename, true);
                            procStatus.Text = "Logging to file:" + procLogFilename;
                            procLogMenu.ForeColor = Color.Green;
                        }
                        catch { procStatus.Text = "Unable to start logging to file:" + procLogFilename; }
                    }
                    break;

                case "Log File...":
                    if (this.logFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            procLogWriter = new StreamWriter(logFileDialog.FileName, true);
                            procLogFilename = logFileDialog.FileName;
                            procAutoLogBtn.Checked = true;
                        }
                        catch { procStatus.Text = "Unable to start logging to file:" + procLogFilename; }

                    }
                    break;

                case "Log":
                    if (procLogWriter == null)
                    {
                        try
                        {
                            procLogWriter = new StreamWriter(procLogFilename, true);
                            LogProcess();
                            procLogWriter = null;
                        }
                        catch (Exception ee)
                        {
                            procStatus.Text = ee.Message + ", Failed to log to file:" + procLogFilename;
                        }
                    }
                    else
                    {
                        LogProcess();
                    }
                    break;

                case "Open log file":
                    System.Diagnostics.Process.Start(procLogFilename);
                    procStatus.Text = procLogFilename;
                    break;

                case "Export...":
                    ListViewExt.Export(this.procView);
                    break;
                case "Print Setup":
                case "Print Setup...":
                    printListView.PageSetup();
                    break;
                case "Preview":
                case "Print Preview...":
                    printListView.PrintPreview(this, this.procView, PrintTitle()+"Process List");
                    break;
                case "Print":
                case "Print...":
                    printListView.Print(this, this.procView, PrintTitle()+"Process List");
                    break;
            }
        }
        #endregion

        #region ==== Handle Menu/Buttons

        private void handleTimer_Tick(object sender, EventArgs e)
        {
            if (this.hndAutoUpdBtn.Checked)
            {
                UpdateHandleView();
            }
        }

        bool isUpdatingHandle = false;

        private void UpdateHandleView()
        {
            if (isUpdatingHandle)
            {
                ListViewHandles.Abort();
                return;
            }

            isUpdatingHandle = true;
            this.Cursor = Cursors.WaitCursor;
            hndRefreshBtn.Image = global::FileInfo.Properties.Resources.green24;
            hndRefreshBtn.Text = "Abort";

            SortedList<int, string> pidList = new SortedList<int, string>();

            foreach (ListViewItem procItem in this.procView.SelectedItems)
            {
                int pid = (int)procItem.SubItems[2].Tag;
                pidList.Add(pid, procItem.SubItems[3].Text);
            }

            if (pidList.Count != 0)
            {
                System.Collections.IComparer sorter = this.handleView.ListViewItemSorter;
                this.handleView.ListViewItemSorter = null;
                this.handleStatus.Text = "Handle inquire in progress...";

                // This method will use a background thread and allow events to fire.
                ListViewHandles.UpdateView(this.handleView, this.handleStatus,
                        pidList, this.hndShowObjDict, this.viewHndGroup, hndHideNoDescBtn.Checked);

                this.handleView.ListViewItemSorter = sorter;
                this.handleView.Sort();
                this.hndClock.Text = NowTimeString();
                this.handleLabel.Text = (pidList.Count == 1) ? pidList.First() + " Handles" : "Open Handles";
                this.Text = "(" + this.handleView.Items.Count.ToString() + ")" + ProductNameAndVersion();
            }
            else
            {
                this.handleStatus.Text = "Please select one or more processes";
                this.handleLabel.Text = "Open Handles";
                this.Text = ProductNameAndVersion();
            }

            if (this.hndLogWriter != null)
            {
                LogHandle();
            }

            hndRefreshBtn.Text = "Refresh";
            hndRefreshBtn.Image = hndAutoUpdBtn.Checked ?
                     global::FileInfo.Properties.Resources.yellow24 :
                     global::FileInfo.Properties.Resources.red24;
            this.Cursor = Cursors.Default;

            isUpdatingHandle = false;
        }

        private void LogHandle()
        {
            string txtLine = string.Empty;
            if ((hndLogLine % 50) == 0)
            {
                txtLine += "Date, Time";
                foreach (ColumnHeader ch in handleView.Columns)
                {
                    if (txtLine.Length != 0)
                        txtLine += ",";
                    txtLine += ch.Text + " ";
                }
                hndLogWriter.WriteLine(txtLine);
            }

            foreach (ListViewItem item in handleView.Items)
            {
                txtLine = string.Empty;
                txtLine += DateTime.Now.ToShortDateString();
                txtLine += ", ";
                txtLine += NowTimeString();

                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (txtLine.Length != 0)
                        txtLine += ",";
                    txtLine += subItem.Text.Replace(',', ';');
                }

                hndLogWriter.WriteLine(txtLine);
                hndLogLine++;
            }

            handleStatus.Text = hndLogLine.ToString() + " lines, Log file:" + hndLogFilename;
        }

        private void hndUpdRate_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            foreach (object obj in dropMenu.Items)
            {
                if (obj is ToolStripDropDownItem)
                {
                    ToolStripDropDownItem item = (ToolStripDropDownItem)obj; 
                    item.Image = Properties.Resources.check_off;
                }
            }

            dropItem.Image = Properties.Resources.check_on;

            if ((int)dropItem.Tag > 0)
            {
                handleTimer.Interval = 1000 * (int)dropItem.Tag;
                hndAutoUpdBtn.Checked = true;
                hndFileMenu_Click(hndAutoUpdBtn, EventArgs.Empty);
            }
            else
            {
                // TODO - prompt for interval.
            }

            // dropMenu.OwnerItem.Text = dropItem.Text;
            // dropMenu.OwnerItem.Image = dropItem.Image;
        }

        private void hndRefreshBtn_Click(object sender, EventArgs e)
        {
            UpdateHandleView();
        }

        private void hndFileMenu_Click(object sender, EventArgs e)
        {
            string text = (sender is ToolStripItem) ?
               ((ToolStripItem)sender).Text :
               ((ToolStripDropDownItem)sender).Text;

            switch (text)
            {
                case "Auto Update":
                    // hndRefreshBtn.ForeColor = hndAutoUpdBtn.Checked ? Color.Green : Color.Red;
                    hndRefreshBtn.Image = hndAutoUpdBtn.Checked ?  
                        global::FileInfo.Properties.Resources.yellow24 :
                        global::FileInfo.Properties.Resources.red24;
                    break;

                case "Auto Log":
                    if (hndAutoLogBtn.Checked == false)
                    {
                        hndLogWriter = null;
                        handleStatus.Text = "Logging disabled";
                        hndLogMenu.ForeColor = Color.White;
                    }
                    else
                    {
                        try
                        {
                            hndLogWriter = new StreamWriter(hndLogFilename, true);
                            handleStatus.Text = "Logging to file:" + hndLogFilename;
                            hndLogMenu.ForeColor = Color.Green;
                        }
                        catch { handleStatus.Text = "Unable to start logging to file:" + hndLogFilename; }
                    }
                    break;

                case "Log File...":
                    if (this.logFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            hndLogWriter = new StreamWriter(logFileDialog.FileName, true);
                            hndLogFilename = logFileDialog.FileName;
                            handleStatus.Text = "Logging to file:" + hndLogFilename;
                            hndAutoLogBtn.Checked = true;
                        }
                        catch { handleStatus.Text = "Unable to start logging to file:" + hndLogFilename; }
                    }
                    break;
                case "Log":
                    if (hndLogWriter == null)
                    {
                        try
                        {
                            hndLogWriter = new StreamWriter(hndLogFilename, true);
                            LogHandle();
                            hndLogWriter = null;
                        }
                        catch (Exception ee)
                        {
                            handleStatus.Text = ee.Message + ", Failed to log to file:" + hndLogFilename;
                        }
                    }
                    else
                    {
                        LogHandle();
                    }
                    break;

                case "Open log file":
                    System.Diagnostics.Process.Start(hndLogFilename);
                    handleStatus.Text = hndLogFilename;
                    break;

                case "Export...":
                    ListViewExt.Export(this.handleView);
                    break;
                case "Print Setup":
                case "Print Setup...":
                    printListView.PageSetup();
                    break;
                case "Preview":
                case "Print Preview...":
                    printListView.PrintPreview(this, this.handleView, PrintTitle()+"Handle List");
                    break;
                case "Print":
                case "Print...":
                    printListView.Print(this, this.handleView, PrintTitle()+"Handle List");
                    break;
            }
        }


        private void hndGrpBtn_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            foreach (ToolStripDropDownItem item in dropMenu.Items)
                item.Image = Properties.Resources.check_off;

            dropItem.Image = Properties.Resources.check_on;
            if (viewHndGroup != (ListViewHandles.ViewHndGroup)dropItem.Tag)
            {
                viewHndGroup = (ListViewHandles.ViewHndGroup)dropItem.Tag;
                UpdateHandleView();
            }
        }

        private void hndShowAllBtn_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            System.Windows.Forms.ToolStripMenuItem button = (System.Windows.Forms.ToolStripMenuItem)dropItem;

            if (dropItem.Text == "All" && button.Checked)
            {
                foreach (ToolStripDropDownItem item in dropMenu.Items)
                {
                    item.Image = Properties.Resources.check_off;
                    System.Windows.Forms.ToolStripMenuItem itemBtn = 
                        (System.Windows.Forms.ToolStripMenuItem)item;
                    itemBtn.Checked = false;
					if (itemBtn.Tag != null)
					{
						hndShowObjDict[(int)itemBtn.Tag] = false;
					}
                }
            }
            else
            {
                this.hndShowObjDict[0] = false;
                this.hndShowAllBtn.Checked = false;
                this.hndShowAllBtn.Image = Properties.Resources.check_off;
            }

			if (button.Tag != null)
			{
				hndShowObjDict[(int)button.Tag] = button.Checked;
			}
            dropItem.Image = button.Checked ? Properties.Resources.check_on : Properties.Resources.check_off;
            UpdateHandleView();
        }

        /// <summary>
        ///  Add view show filter buttons
        /// </summary>
        private void AddHndShowButtons()
        {
            hndShowObjDict.Add(0, true);

            string objNumStr;
            for (int objNum = 1; (objNumStr = OpenHandles.ObjectTypeDescription(objNum)) != string.Empty; objNum++)
            {
                System.Windows.Forms.ToolStripMenuItem showBtn;
                showBtn = new System.Windows.Forms.ToolStripMenuItem();
                showBtn.Text = objNumStr;
                showBtn.Tag = objNum;
                showBtn.Image = Properties.Resources.check_off;
                showBtn.Click += new System.EventHandler(this.hndShowAllBtn_Click);
                showBtn.CheckOnClick = true;
                showBtn.CheckState = System.Windows.Forms.CheckState.Unchecked;
                hndShowObjDict.Add(objNum, false);

                this.filterToolStripMenuItem.DropDownItems.Add(showBtn);
            }
        }

        private void hndPopupBtn_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            switch (dropItem.Text)
            {
                case "AutoSize Columns":
                    this.handleView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    this.handleView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
                    return;
            }

            // Point p = this.handleView.PointToClient(System.Windows.Forms.Control.MousePosition);
            // ListViewItem itemAt = this.handleView.GetItemAt(p.X, p.Y);
            if (this.handleView.SelectedItems.Count != 0)
            {
                ListViewItem item = this.handleView.SelectedItems[0];

                string objType = item.SubItems[4].Text;
                string desc = item.SubItems[5].Text;

                switch (dropItem.Text)
                {
                    case "File - Explorer":
                        if (objType == "File" || objType == "Directory")
                        {
                            System.Diagnostics.Debug.WriteLine("Explorer " + desc);
                            string dir = Path.GetDirectoryName(desc);
                            if (System.Diagnostics.Process.Start("explorer.exe", dir).HasExited)
                                MessageBox.Show("Failed to start explorer on dir of " + desc);
                            else
                                MessageBox.Show(desc);
                        }
                        break;
                    case "File - Cmd":
                        if (objType == "File" || objType == "Directory")
                        {
                            System.Diagnostics.Debug.WriteLine("cmd " + desc);

                            string dir = Path.GetDirectoryName(desc);
                            System.Diagnostics.Process.Start("cmd.exe", "/k cd \"" + dir + "\"");
                            MessageBox.Show(desc);
                        }
                        break;
                    case "Key - RegEdit":
                        if (objType == "Registry")
                        {
                            string prefix = @"\REGISTRY\";
                            if (desc.StartsWith(prefix))
                                desc = desc.Substring(prefix.Length);
                            if (desc.StartsWith("MACHINE"))
                                desc = "LOCAL_" + desc;

                            // Preset last place RegEdit visited to our registry section
                            RegistryKey regEditKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Applets\Regedit");
                            regEditKey.SetValue("LastKey", @"My Computer\HKEY_" + desc);
                            regEditKey.Close();

                            // Launch RegEdit which will default at the last place it was (our stuff).
                            System.Diagnostics.Process.Start("regedit.exe");
                            MessageBox.Show("RegEdit " + desc);
                        }
                        break;
                }
            }
        }

        // Toggle hide description check box and update view.
        private void hndHideNoDescBtn_Click(object sender, EventArgs e)
        {
            this.hndHideNoDescBtn.Image = this.hndHideNoDescBtn.Checked ?
                    Properties.Resources.check_on :
                    Properties.Resources.check_off;
            UpdateHandleView();
        }


        private void fileMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.handleView.SelectedItems[0];

            string objType = item.SubItems[4].Text;
            string filePath = item.SubItems[5].Text;

            if (objType == "File")
            {
                // Currently this does not appear to work as expect.
                ViewDiskAllocation viewDiskAllocation = new ViewDiskAllocation(filePath);
                viewDiskAllocation.Show();
            }
        }

        #endregion

        #region ==== Resize viewer
        private Size startPos = Size.Empty;

        private void resize_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.startPos != Size.Empty)
            {
                Size newPos = new Size(Control.MousePosition.X, Control.MousePosition.Y);
                this.Size = this.Size - (this.startPos - newPos);
                this.startPos = newPos;
            }
        }

        private void resize_MouseDown(object sender, MouseEventArgs e)
        {
            this.startPos = new Size(Control.MousePosition.X, Control.MousePosition.Y);
            this.Cursor = Cursors.SizeNWSE;
        }

        private void resize_MouseUp(object sender, MouseEventArgs e)
        {
            resize_MouseLeave(sender, e);
        }

        private void resize_MouseLeave(object sender, EventArgs e)
        {
            this.startPos = Size.Empty;
            this.Cursor = Cursors.Default;
        }
        private void resize_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeNWSE;
        }

        #endregion

       

    }
}
