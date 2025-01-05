using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;


namespace FileInfo
{
    /// <summary>
    /// Display Process list in a ListView
    /// Author: Dennis Lang 2009
    /// https://landenlabs.com/
    /// 
    /// </summary>
    class ListViewProcesses
    {
        ListView procView;
        List<ListViewItem> deadList = new List<ListViewItem>();
        List<ListViewItem> bornList = new List<ListViewItem>();

        public ListView View
        {
            get { return this.procView; }
            set { this.procView = value; }
        }

        private ListViewItem FindViewItem(ListView.ListViewItemCollection items, string want, int subFld)
        {
            foreach (ListViewItem item in items)
            {
                if (item.SubItems[subFld].Text == want)
                    return item;
            }

            return null;
        }

        // Not used 
        private void EnumModules(Process process)
        {
            ProcessModuleCollection myModules = process.Modules;
            for (int j = 0; j < myModules.Count; j++)
            {
                // Console.WriteLine(myModules[j].ModuleName + "\t" + 
                //     myModules[j].EntryPointAddress.ToString("X") + "\t" + 
                //    myModules[j].FileVersionInfo.FileVersion);
            }
        }

        /// <summary>
        /// Update view with latest process list. 
        /// Draw new entries in GREEN and died entries in RED. 
        /// </summary>
        public void UpdateView(ListView view)
        {
            procView = view;
            procView.BeginUpdate();

            try
            {
                Process[] myProcesses = Process.GetProcesses();
                List<int> viewPid = new List<int>();

                bornList.Clear();
                foreach (ListViewItem item in deadList)
                {
                    procView.Items.Remove(item);
                }
                deadList.Clear();

                for (int i = 0; i < myProcesses.Length; i++)
                {
                    ListViewItem item = FindViewItem(procView.Items, myProcesses[i].Id.ToString(), pIdCol);
                    if (item == null)
                    {
                        item = AddProc(i, myProcesses[i]);
                        item.BackColor = Color.LightGreen;
                        bornList.Add(item);
                    }
                    else
                    {
                        UpdateProcView(item, i, myProcesses[i]);
                        item.BackColor = Color.White;
                    }

                    viewPid.Add((int)item.Tag);
                }

                foreach (ListViewItem item in procView.Items)
                {
                    int ix = (int)item.Tag;
                    if (viewPid.Find(delegate(int t) { return ix == t; }) != ix)
                    {
                        item.BackColor = Color.LightPink;
                        deadList.Add(item);
                    }
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            this.procView.EndUpdate();
        }

        /// View Column layout;
        const int pNumCol = 1;
        const int pIdCol = 2;
        const int pNameCol = 3;
        const int pStartTmCol = 4;
        const int pTotalTmCol = 5;
        const int pUserTmCol = 6;
        const int pPrivCol = 7;
        const int pWorkCol = 8;
        const int pWkPeakCol = 9;
        const int pVirtCol = 10;
        const int pVrPeakCol = 11;
        const int pPagedCol = 12;
        const int pPgPeakCol = 13;
        const int pHandlesCol = 14;
        const int pThreadsCol = 15;
        const int pModulesCol = 16;
        const int pLastCol = 17;

        List<int> sysPidList = new List<int>();

        private ListViewItem AddProc(int i, Process process)
        {
            ListViewItem item = this.procView.Items.Add("");
            for (int col = 0; col < pLastCol; col++)
                item.SubItems.Add("");

            UpdateProcView(item, i, process);
            return item;
        }

        string ToString(long memSize)
        {
            const long KB = 1024;
            const long MB = KB * KB;

            return ((double)memSize / MB).ToString("F2") + " MB";
        }

        void SetColumn(ListViewItem.ListViewSubItem subItem, long val)
        {
            subItem.Text = ToString(val);
            subItem.Tag = val;
        }

        private void UpdateProcView(ListViewItem item, int i, Process process)
        {
            item.SubItems[pIdCol].Text = process.Id.ToString();     // 2
            item.SubItems[pIdCol].Tag = process.Id;
            item.Tag = process.Id;
            item.SubItems[pNameCol].Text = process.ProcessName;

            int pid = process.Id;
            if (sysPidList.Find(delegate(int t) { return pid == t; }) == pid)
            {
                return;
            }

            int p = process.BasePriority;
            try
            {
                item.SubItems[pStartTmCol].Text = (process.StartTime.ToString("G"));
                item.SubItems[pTotalTmCol].Text = (process.TotalProcessorTime.TotalMinutes.ToString("F3"));
                item.SubItems[pUserTmCol].Text = (process.UserProcessorTime.TotalMinutes.ToString("F3"));
            } catch {}

            try
            {
                //  item.SubItems.Add(process.NonpagedSystemMemorySize64.ToString());
                //  item.SubItems.Add(process.PagedSystemMemorySize64.ToString());

                SetColumn(item.SubItems[pPrivCol], process.PrivateMemorySize64);
             
                SetColumn(item.SubItems[pWorkCol], process.WorkingSet64);
                SetColumn(item.SubItems[pWkPeakCol], process.PeakWorkingSet64);

                SetColumn(item.SubItems[pVirtCol], process.VirtualMemorySize64);
                SetColumn(item.SubItems[pVrPeakCol], process.PeakVirtualMemorySize64);

                SetColumn(item.SubItems[pPagedCol], process.PagedMemorySize64);
                SetColumn(item.SubItems[pPgPeakCol], process.PeakPagedMemorySize64);

                item.SubItems[pHandlesCol].Text = (process.HandleCount.ToString());
                item.SubItems[pThreadsCol].Text = (
                    process.Threads != null ?
                    process.Threads.Count.ToString() : "0");

                if (process.ProcessName != "System")
                {
                    try
                    {
                        item.SubItems[pModulesCol].Text = (
                           process.Modules != null ?
                           process.Modules.Count.ToString() : "0");
                    }
                    catch { }
                }
            }
            catch
            {
                // clear fields.
                sysPidList.Add(process.Id);
            }
        }
    }
}
