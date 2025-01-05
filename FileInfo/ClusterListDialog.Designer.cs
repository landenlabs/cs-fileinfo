namespace FileInfo
{
    partial class ClusterListDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clusterView = new System.Windows.Forms.ListView();
            this.col1 = new System.Windows.Forms.ColumnHeader();
            this.col2Len = new System.Windows.Forms.ColumnHeader();
            this.col3Cluster = new System.Windows.Forms.ColumnHeader();
            this.closeBtn = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clusterView
            // 
            this.clusterView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clusterView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1,
            this.col2Len,
            this.col3Cluster});
            this.clusterView.FullRowSelect = true;
            this.clusterView.GridLines = true;
            this.clusterView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.clusterView.Location = new System.Drawing.Point(12, 41);
            this.clusterView.Name = "clusterView";
            this.clusterView.Size = new System.Drawing.Size(213, 466);
            this.clusterView.TabIndex = 0;
            this.clusterView.UseCompatibleStateImageBehavior = false;
            this.clusterView.View = System.Windows.Forms.View.Details;
            // 
            // col1
            // 
            this.col1.Text = "";
            this.col1.Width = 0;
            // 
            // col2Len
            // 
            this.col2Len.Text = "Len";
            this.col2Len.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col2Len.Width = 100;
            // 
            // col3Cluster
            // 
            this.col3Cluster.Text = "Cluster";
            this.col3Cluster.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col3Cluster.Width = 100;
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.Location = new System.Drawing.Point(152, 520);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(73, 22);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.title.BackColor = System.Drawing.Color.Gainsboro;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(213, 21);
            this.title.TabIndex = 2;
            this.title.Text = "Cluster List";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClusterListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 554);
            this.Controls.Add(this.title);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.clusterView);
            this.Name = "ClusterListDialog";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FileInfo - File Cluster List";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView clusterView;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ColumnHeader col2Len;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.ColumnHeader col3Cluster;
        private System.Windows.Forms.Label title;
    }
}