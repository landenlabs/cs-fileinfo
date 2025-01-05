using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileInfo
{
    public partial class HelpDialog : Form
    {
        public HelpDialog(Stream htmlStream)
        {
            InitializeComponent();
            this.titleBg.Parent = this.titleBar;
            this.title.Parent = this.titleBg;
            this.title.Location = new Point(1, 1);

            // get a reference to the current assembly
            this.webBrowser.DocumentStream = htmlStream;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            this.titleBg.Location = new Point(
                (this.titleBar.Width - this.titleBg.Width) / 2,
                this.titleBg.Location.Y);

            base.OnResizeEnd(e);
        }
    }
}
