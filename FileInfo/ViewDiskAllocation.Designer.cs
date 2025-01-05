namespace FileInfo
{
    partial class ViewDiskAllocation
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewDiskAllocation));
            this.diskPicture = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.driveCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.TextBox();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Button();
            this.saveImageBtn = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.diskPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // diskPicture
            // 
            this.diskPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diskPicture.BackColor = System.Drawing.Color.Black;
            this.diskPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("diskPicture.BackgroundImage")));
            this.diskPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.diskPicture.Location = new System.Drawing.Point(28, 49);
            this.diskPicture.Margin = new System.Windows.Forms.Padding(0);
            this.diskPicture.Name = "diskPicture";
            this.diskPicture.Size = new System.Drawing.Size(1024, 512);
            this.diskPicture.TabIndex = 0;
            this.diskPicture.TabStop = false;
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.Location = new System.Drawing.Point(977, 577);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // driveCombo
            // 
            this.driveCombo.BackColor = System.Drawing.Color.Navy;
            this.driveCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.driveCombo.ForeColor = System.Drawing.Color.White;
            this.driveCombo.FormattingEnabled = true;
            this.driveCombo.Location = new System.Drawing.Point(119, 15);
            this.driveCombo.Name = "driveCombo";
            this.driveCombo.Size = new System.Drawing.Size(76, 21);
            this.driveCombo.TabIndex = 2;
            this.toolTip.SetToolTip(this.driveCombo, "Select Drive to Display");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Disk Drive:";
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(32, 580);
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Size = new System.Drawing.Size(934, 22);
            this.status.TabIndex = 5;
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshBtn.BackgroundImage")));
            this.refreshBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.ForeColor = System.Drawing.Color.White;
            this.refreshBtn.Location = new System.Drawing.Point(201, 6);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 37);
            this.refreshBtn.TabIndex = 6;
            this.refreshBtn.Text = "Refresh";
            this.toolTip.SetToolTip(this.refreshBtn, "Refresh Cluster Allocation Image ");
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.title.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title.BackgroundImage")));
            this.title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(363, 3);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(689, 40);
            this.title.TabIndex = 7;
            this.title.Text = "Disk Cluster Allocation";
            this.title.UseVisualStyleBackColor = true;
            // 
            // saveImageBtn
            // 
            this.saveImageBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("saveImageBtn.BackgroundImage")));
            this.saveImageBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveImageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveImageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveImageBtn.ForeColor = System.Drawing.Color.White;
            this.saveImageBtn.Location = new System.Drawing.Point(282, 6);
            this.saveImageBtn.Name = "saveImageBtn";
            this.saveImageBtn.Size = new System.Drawing.Size(75, 37);
            this.saveImageBtn.TabIndex = 8;
            this.saveImageBtn.Text = "SaveAs";
            this.toolTip.SetToolTip(this.saveImageBtn, "Save Screen As Image");
            this.saveImageBtn.UseVisualStyleBackColor = true;
            this.saveImageBtn.Click += new System.EventHandler(this.saveImageBtn_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Png|*.png|Jpeg|*.jpg|Any|*";
            this.saveFileDialog.Title = "Save Screen Image";
            // 
            // ViewDiskAllocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1078, 612);
            this.Controls.Add(this.saveImageBtn);
            this.Controls.Add(this.title);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.driveCombo);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.diskPicture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewDiskAllocation";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FileInfo - ViewDiskAllocation";
            ((System.ComponentModel.ISupportInitialize)(this.diskPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox diskPicture;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.ComboBox driveCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox status;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button title;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button saveImageBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}