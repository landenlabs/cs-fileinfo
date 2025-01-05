using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileInfo
{
    /// <summary>
    /// Dialog with listview.
    /// Display file information and cluster allocation list.
    /// 
    /// Author: Dennis Lang 2009
    /// https://landenlabs.com/
    /// 
    /// </summary>
    public partial class ClusterListDialog : Form
    {
        public ClusterListDialog()
        {
            InitializeComponent();
        }

        public ListView View
        {
            get { return this.clusterView; }
            set { this.clusterView = value; }
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            this.clusterView.Columns[1].Width =
            this.clusterView.Columns[2].Width =
            this.clusterView.Width / 2;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
