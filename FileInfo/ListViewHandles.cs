using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

using System.Threading;

namespace FileInfo
{
    /// <summary>
    /// Present OpenHandle list in a ListView
    /// Author: Dennis Lang 2009
    /// https://landenlabs.com/
    /// 
    /// </summary>
    class ListViewHandles
    {
        public enum ViewHndGroup { eNoGroup, ePidGroup, eObjectGroup };

        private ListView hndView;
        private bool abort;

        public ListView View
        {
            get { return this.hndView; }
            set { this.hndView = value; }
        }

        // Part of update uses a background thread. Set abort to stop thread.
        public void Abort() { this.abort = true; }
       

        OpenHandles.SYSTEM_HANDLE_INFORMATION[] handles;
        SortedList<int, string> pidList;

        struct HandleInfo
        {
            public OpenHandles.SYSTEM_HANDLE_INFORMATION handle;
            public string desc;
            public string error;
        }
        SortedList<int, SortedList<int, HandleInfo>> pidHndDescList;

        static AutoResetEvent threadEvent;

        /// <summary>
        ///  Background thread does the slow and painful work of collecting handle information
        ///  and converting it to descriptions
        /// </summary>
        public void ThreadBgWorker()
        {
            // Grab handles
            handles = OpenHandles.EnumHandles();

            // Convert handles to descriptions (this may be slow)
            foreach (OpenHandles.SYSTEM_HANDLE_INFORMATION handle in handles)
            {
                if (this.abort)
                    break;

                int pid = handle.ProcessId;

                if (pid < 0)
                    System.Diagnostics.Debug.WriteLine("Bad pid=" + pid.ToString());

                if (pidList.ContainsKey(pid))
                {
                    SortedList<int, HandleInfo> hndFileList;
                    if (pidHndDescList.TryGetValue(pid, out hndFileList) == false)
                    {
                        hndFileList = new SortedList<int, HandleInfo>();
                        pidHndDescList.Add(pid, hndFileList);
                    }

                    try
                    {
                        HandleInfo hndInfo = new HandleInfo();
                        hndInfo.handle = handle;
                        hndInfo.desc = string.Empty;

                        string desc;
                        if (OpenHandles.HandleDescription(handle.ProcessId, handle.Handle, handle.ObjectTypeNumber, out desc))
                            hndInfo.desc = desc;
                        else
                            hndInfo.error = desc;   

                        hndFileList.Add(handle.Handle, hndInfo);
                    }
                    catch (Exception ee)
                    {
                        Console.WriteLine("Handle description error:" + ee.Message);
                    }
                }
            }

            threadEvent.Set();
        }

        public void UpdateView(ListView view, TextBox status,
            SortedList<int, string> _pidList, 
            Dictionary<int, bool> showObjDict,
            ViewHndGroup viewGroup,
            bool hideIfNoDesc)
        {
            if (_pidList.Count == 0)
            {
                // Nothing to do, so exit
                view.Items.Clear();
                status.Text = "No handles - Please select a running process to examine";
                return;
            }

            view.Enabled = false;

            // Collect handles and handle descriptions in a background thread
            this.pidHndDescList = new SortedList<int, SortedList<int, HandleInfo>>();
            this.pidList = _pidList;

            this.abort = false;

            Thread threadHnd = new Thread(new ThreadStart(this.ThreadBgWorker));
            threadEvent = new AutoResetEvent(false);
            threadHnd.Start();

            DateTime now = DateTime.Now;
            // Calling DoEvents is dangerous
            while (!threadEvent.WaitOne(0) && !this.abort)
            {
                Application.DoEvents();

                // Allow a few seconods to collect info.
                if ((DateTime.Now - now).Seconds > 2)
                    break;
            }

            status.Text = string.Empty;

            if (!threadHnd.Join(5000))
            {
                Abort();
                if (!threadHnd.Join(100))
                {
                    threadHnd.Abort();
                    if (!abort)
                        status.Text += " Handle collection Timed out, only partial list available. ";
                }
            }

            if (abort)
            {
                // User aborted, so clear list and return.
                status.Text += " Aborted by user. ";
                // return;
            }

            // Fill list view with handle info
            hndView = view;
            hndView.BeginUpdate();
            hndView.Items.Clear();
            hndView.Groups.Clear();

            SortedList<byte, ListViewGroup> objGroup = new SortedList<byte, ListViewGroup>();

            foreach (int pid in pidList.Keys)
            {
                string procName = pidList[pid];
                ListViewGroup grp = null;
                if (viewGroup == ViewHndGroup.ePidGroup)
                    grp = hndView.Groups.Add(pid.ToString(), procName);

                SortedList<int, HandleInfo> hndDescList;
                if (this.pidHndDescList.TryGetValue(pid, out hndDescList))         
                {
                    foreach (int hnd in hndDescList.Keys)
                    {
                        HandleInfo hndInfo = hndDescList[hnd];
                        if (showObjDict[0] == true || (showObjDict.ContainsKey(hndInfo.handle.ObjectTypeNumber) && 
							showObjDict[hndInfo.handle.ObjectTypeNumber] == true))
                        {
                            if (hideIfNoDesc == false || hndInfo.desc.Length != 0)
                            {
                                ListViewItem item = AddProc(hndInfo, procName);

                                if (viewGroup == ViewHndGroup.eObjectGroup)
                                {
                                    if (objGroup.TryGetValue(hndInfo.handle.ObjectTypeNumber, out grp) == false)
                                    {
                                        byte objTypeNum = hndInfo.handle.ObjectTypeNumber;
                                        grp = hndView.Groups.Add(objTypeNum.ToString(), OpenHandles.ObjectTypeDescription(objTypeNum));
                                        objGroup.Add(objTypeNum, grp);
                                    }
                                }
                                item.Group = grp;
                            }
                        }
                    }
                }
            }

            this.hndView.EndUpdate();
            this.hndView.Enabled = true;

            status.Text += hndView.Items.Count.ToString() +
                      " handles for process: " + pidList.First().Value;
            if (pidList.Count > 1)
                status.Text += " ...";
        }

        private ListViewItem AddProc(HandleInfo hndInfo, string procName)
        {
            ListViewItem item = this.hndView.Items.Add("");

            const int hLastCol = 6;
            for (int col = 0; col < hLastCol; col++)
                item.SubItems.Add("");

            try
            {
                item.SubItems[1].Text = hndInfo.handle.ProcessId.ToString();
                item.SubItems[2].Text = procName;
                item.SubItems[3].Text = hndInfo.handle.Handle.ToString();
                item.SubItems[4].Text = OpenHandles.ObjectTypeDescription(hndInfo.handle.ObjectTypeNumber);
                if (hndInfo.error == null || hndInfo.error.Length == 0)
                {
                    item.SubItems[5].Text = hndInfo.desc;
                    item.SubItems[5].BackColor = item.BackColor;
                }
                else
                {
                    item.UseItemStyleForSubItems = false;
                    item.SubItems[5].Text = hndInfo.error;
                    item.SubItems[5].BackColor = Color.FromArgb(255, 220, 220);
                }
            }
            catch (Exception ex)
            {
                item.SubItems[2].Text = procName;
            }

            return item;
        }
    }
}
