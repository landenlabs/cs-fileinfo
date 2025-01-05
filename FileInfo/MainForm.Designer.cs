namespace FileInfo
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.procStatus = new System.Windows.Forms.TextBox();
			this.procView = new System.Windows.Forms.ListView();
			this.col0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_start = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_totTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_userTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_privMem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_work = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_wkPeak = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_virt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_virtPeakSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_paged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_pagedPeak = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_handles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_Threads = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_Modules = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_log = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.sortImages = new System.Windows.Forms.ImageList(this.components);
			this.procToolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
			this.procAutoUpdBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.updateRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.prooc1secBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.proc5secBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.proc1minBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.proc5minBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.proc1hourBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.procCustomBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.procAutoLogBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.procLogFileBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.procLogOpenBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.procExpBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			this.printSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.procRefreshBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.procClock = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.procLabel = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.procExportMenu = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.procLogMenu = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.procPrintMenu = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
			this.procPreviewMenu = new System.Windows.Forms.ToolStripButton();
			this.resizePanel = new System.Windows.Forms.Panel();
			this.handleStatus = new System.Windows.Forms.TextBox();
			this.closeBtn = new System.Windows.Forms.Button();
			this.handleView = new System.Windows.Forms.ListView();
			this.colH0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colH_pid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_procName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colH_handle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colH_object = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.hndPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.hndPopupAutoSizeBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hndPopupExplorerBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hndPopupCmdBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hndPopupRegEditBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.fileMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.handleToolStrip = new System.Windows.Forms.ToolStrip();
			this.hndViewBtn = new System.Windows.Forms.ToolStripSplitButton();
			this.hndHideNoDescBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hndShowAllBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.groupByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hndNoGrpBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hndPidGrpBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hndObjGrpBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
			this.hndAutoUpdBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hndRateBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hnd1secBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hnd5secBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hnd1minBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hnd5minBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hnd1hourBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hndCustomBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.hndAutoLogBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hndLogFileBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.openLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hndExportBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
			this.hndPrSetBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hndPrPreviewBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.hndPrBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.hndRefreshBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.hndClock = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.handleLabel = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.hndExportMenu = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.hndLogMenu = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.hndPrintMenu = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
			this.hndPreviewMenu = new System.Windows.Forms.ToolStripLabel();
			this.procTimer = new System.Windows.Forms.Timer(this.components);
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.logFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.handleTimer = new System.Windows.Forms.Timer(this.components);
			this.mainToolStrip = new System.Windows.Forms.ToolStrip();
			this.diskDetailBtn = new System.Windows.Forms.ToolStripButton();
			this.fsInfoBtn = new System.Windows.Forms.ToolStripButton();
			this.title = new System.Windows.Forms.ToolStripLabel();
			this.diskClusterBtn = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.procToolStrip.SuspendLayout();
			this.hndPopupMenu.SuspendLayout();
			this.handleToolStrip.SuspendLayout();
			this.mainToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.Blue;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 71);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.splitContainer1.Panel1MinSize = 0;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(1068, 558);
			this.splitContainer1.SplitterDistance = 0;
			this.splitContainer1.TabIndex = 1;
			// 
			// splitContainer2
			// 
			this.splitContainer2.BackColor = System.Drawing.Color.Black;
			this.splitContainer2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer2.BackgroundImage")));
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
			this.splitContainer2.Panel1.Controls.Add(this.procStatus);
			this.splitContainer2.Panel1.Controls.Add(this.procView);
			this.splitContainer2.Panel1.Controls.Add(this.procToolStrip);
			this.splitContainer2.Panel1MinSize = 0;
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.splitContainer2.Panel2.Controls.Add(this.resizePanel);
			this.splitContainer2.Panel2.Controls.Add(this.handleStatus);
			this.splitContainer2.Panel2.Controls.Add(this.closeBtn);
			this.splitContainer2.Panel2.Controls.Add(this.handleView);
			this.splitContainer2.Panel2.Controls.Add(this.handleToolStrip);
			this.splitContainer2.Panel2MinSize = 0;
			this.splitContainer2.Size = new System.Drawing.Size(1064, 558);
			this.splitContainer2.SplitterDistance = 335;
			this.splitContainer2.SplitterWidth = 10;
			this.splitContainer2.TabIndex = 0;
			// 
			// procStatus
			// 
			this.procStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.procStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.procStatus.Location = new System.Drawing.Point(1, 315);
			this.procStatus.Margin = new System.Windows.Forms.Padding(0);
			this.procStatus.Name = "procStatus";
			this.procStatus.ReadOnly = true;
			this.procStatus.Size = new System.Drawing.Size(1063, 20);
			this.procStatus.TabIndex = 2;
			// 
			// procView
			// 
			this.procView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.procView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col0,
            this.col1,
            this.col_id,
            this.col_name,
            this.col_start,
            this.col_totTime,
            this.col_userTime,
            this.col_privMem,
            this.col_work,
            this.col_wkPeak,
            this.col_virt,
            this.col_virtPeakSize,
            this.col_paged,
            this.col_pagedPeak,
            this.col_handles,
            this.col_Threads,
            this.col_Modules,
            this.col_log});
			this.procView.FullRowSelect = true;
			this.procView.GridLines = true;
			this.procView.HideSelection = false;
			this.procView.Location = new System.Drawing.Point(0, 25);
			this.procView.Margin = new System.Windows.Forms.Padding(0);
			this.procView.Name = "procView";
			this.procView.Size = new System.Drawing.Size(1064, 290);
			this.procView.SmallImageList = this.sortImages;
			this.procView.TabIndex = 1;
			this.procView.UseCompatibleStateImageBehavior = false;
			this.procView.View = System.Windows.Forms.View.Details;
			this.procView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnClick);
			this.procView.SelectedIndexChanged += new System.EventHandler(this.procView_SelectedIndexChanged);
			this.procView.Click += new System.EventHandler(this.procView_Click);
			// 
			// col0
			// 
			this.col0.Text = "-";
			this.col0.Width = 0;
			// 
			// col1
			// 
			this.col1.Text = "#";
			this.col1.Width = 0;
			// 
			// col_id
			// 
			this.col_id.Text = "ProcId";
			this.col_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.col_id.Width = 47;
			// 
			// col_name
			// 
			this.col_name.Text = "Name";
			this.col_name.Width = 130;
			// 
			// col_start
			// 
			this.col_start.Text = "Start";
			this.col_start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.col_start.Width = 150;
			// 
			// col_totTime
			// 
			this.col_totTime.Text = "TotalTm";
			this.col_totTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// col_userTime
			// 
			this.col_userTime.Text = "UserTm";
			this.col_userTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// col_privMem
			// 
			this.col_privMem.Text = "PrivateMem";
			this.col_privMem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// col_work
			// 
			this.col_work.Text = "WorkSet";
			this.col_work.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// col_wkPeak
			// 
			this.col_wkPeak.Text = "WorkSet (Peak)";
			this.col_wkPeak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// col_virt
			// 
			this.col_virt.Text = "Virtual Size";
			this.col_virt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// col_virtPeakSize
			// 
			this.col_virtPeakSize.Text = "Virtual (Peak) Size";
			this.col_virtPeakSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// col_paged
			// 
			this.col_paged.Text = "Paged Size";
			this.col_paged.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// col_pagedPeak
			// 
			this.col_pagedPeak.Text = "Paged (Peak) Size";
			this.col_pagedPeak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// col_handles
			// 
			this.col_handles.Text = "Handles";
			this.col_handles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// col_Threads
			// 
			this.col_Threads.Text = "#Threads";
			this.col_Threads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// col_Modules
			// 
			this.col_Modules.Text = "#Modules";
			this.col_Modules.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// col_log
			// 
			this.col_log.Text = "Log";
			// 
			// sortImages
			// 
			this.sortImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("sortImages.ImageStream")));
			this.sortImages.TransparentColor = System.Drawing.Color.Transparent;
			this.sortImages.Images.SetKeyName(0, "upBW.png");
			this.sortImages.Images.SetKeyName(1, "downBW.png");
			this.sortImages.Images.SetKeyName(2, "up2BW.png");
			this.sortImages.Images.SetKeyName(3, "down2BW.png");
			// 
			// procToolStrip
			// 
			this.procToolStrip.BackColor = System.Drawing.Color.SteelBlue;
			this.procToolStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("procToolStrip.BackgroundImage")));
			this.procToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.procToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.procToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripSeparator10,
            this.toolStripSplitButton1,
            this.toolStripSeparator8,
            this.procRefreshBtn,
            this.toolStripSeparator5,
            this.procClock,
            this.toolStripSeparator6,
            this.procLabel,
            this.toolStripSeparator2,
            this.procExportMenu,
            this.toolStripSeparator7,
            this.procLogMenu,
            this.toolStripSeparator9,
            this.procPrintMenu,
            this.toolStripSeparator17,
            this.procPreviewMenu});
			this.procToolStrip.Location = new System.Drawing.Point(0, 0);
			this.procToolStrip.Name = "procToolStrip";
			this.procToolStrip.Size = new System.Drawing.Size(1064, 25);
			this.procToolStrip.Stretch = true;
			this.procToolStrip.TabIndex = 0;
			this.procToolStrip.Text = "toolStrip2";
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.AutoSize = false;
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(40, 22);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSplitButton1
			// 
			this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.procAutoUpdBtn,
            this.updateRateToolStripMenuItem,
            this.toolStripSeparator15,
            this.procAutoLogBtn,
            this.procLogFileBtn,
            this.procLogOpenBtn,
            this.procExpBtn,
            this.toolStripSeparator16,
            this.printSetupToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.printToolStripMenuItem1});
			this.toolStripSplitButton1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripSplitButton1.ForeColor = System.Drawing.Color.White;
			this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
			this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton1.Name = "toolStripSplitButton1";
			this.toolStripSplitButton1.Size = new System.Drawing.Size(43, 22);
			this.toolStripSplitButton1.Text = "File";
			this.toolStripSplitButton1.ToolTipText = "Update, log, export and print";
			// 
			// procAutoUpdBtn
			// 
			this.procAutoUpdBtn.CheckOnClick = true;
			this.procAutoUpdBtn.Name = "procAutoUpdBtn";
			this.procAutoUpdBtn.Size = new System.Drawing.Size(161, 22);
			this.procAutoUpdBtn.Text = "Auto Update";
			this.procAutoUpdBtn.Click += new System.EventHandler(this.procFileMenu_Click);
			// 
			// updateRateToolStripMenuItem
			// 
			this.updateRateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prooc1secBtn,
            this.proc5secBtn,
            this.proc1minBtn,
            this.proc5minBtn,
            this.proc1hourBtn,
            this.procCustomBtn});
			this.updateRateToolStripMenuItem.Name = "updateRateToolStripMenuItem";
			this.updateRateToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.updateRateToolStripMenuItem.Text = "Update  Rate";
			// 
			// prooc1secBtn
			// 
			this.prooc1secBtn.Name = "prooc1secBtn";
			this.prooc1secBtn.Size = new System.Drawing.Size(127, 22);
			this.prooc1secBtn.Tag = 1;
			this.prooc1secBtn.Text = "1 Second";
			this.prooc1secBtn.Click += new System.EventHandler(this.procUpdRate_Click);
			// 
			// proc5secBtn
			// 
			this.proc5secBtn.Checked = true;
			this.proc5secBtn.CheckState = System.Windows.Forms.CheckState.Checked;
			this.proc5secBtn.Name = "proc5secBtn";
			this.proc5secBtn.Size = new System.Drawing.Size(127, 22);
			this.proc5secBtn.Tag = 5;
			this.proc5secBtn.Text = "5 Second";
			this.proc5secBtn.Click += new System.EventHandler(this.procUpdRate_Click);
			// 
			// proc1minBtn
			// 
			this.proc1minBtn.Name = "proc1minBtn";
			this.proc1minBtn.Size = new System.Drawing.Size(127, 22);
			this.proc1minBtn.Tag = 60;
			this.proc1minBtn.Text = "1 Minute";
			this.proc1minBtn.Click += new System.EventHandler(this.procUpdRate_Click);
			// 
			// proc5minBtn
			// 
			this.proc5minBtn.Name = "proc5minBtn";
			this.proc5minBtn.Size = new System.Drawing.Size(127, 22);
			this.proc5minBtn.Tag = 300;
			this.proc5minBtn.Text = "5 Minute";
			this.proc5minBtn.Click += new System.EventHandler(this.procUpdRate_Click);
			// 
			// proc1hourBtn
			// 
			this.proc1hourBtn.Name = "proc1hourBtn";
			this.proc1hourBtn.Size = new System.Drawing.Size(127, 22);
			this.proc1hourBtn.Tag = 3600;
			this.proc1hourBtn.Text = "Hourly";
			this.proc1hourBtn.Click += new System.EventHandler(this.procUpdRate_Click);
			// 
			// procCustomBtn
			// 
			this.procCustomBtn.Enabled = false;
			this.procCustomBtn.Name = "procCustomBtn";
			this.procCustomBtn.Size = new System.Drawing.Size(127, 22);
			this.procCustomBtn.Tag = -1;
			this.procCustomBtn.Text = "Custom";
			this.procCustomBtn.Click += new System.EventHandler(this.procUpdRate_Click);
			// 
			// toolStripSeparator15
			// 
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(158, 6);
			// 
			// procAutoLogBtn
			// 
			this.procAutoLogBtn.CheckOnClick = true;
			this.procAutoLogBtn.Name = "procAutoLogBtn";
			this.procAutoLogBtn.Size = new System.Drawing.Size(161, 22);
			this.procAutoLogBtn.Text = "Auto Log";
			this.procAutoLogBtn.Click += new System.EventHandler(this.procFileMenu_Click);
			// 
			// procLogFileBtn
			// 
			this.procLogFileBtn.Name = "procLogFileBtn";
			this.procLogFileBtn.Size = new System.Drawing.Size(161, 22);
			this.procLogFileBtn.Text = "Log File...";
			this.procLogFileBtn.Click += new System.EventHandler(this.procFileMenu_Click);
			// 
			// procLogOpenBtn
			// 
			this.procLogOpenBtn.Name = "procLogOpenBtn";
			this.procLogOpenBtn.Size = new System.Drawing.Size(161, 22);
			this.procLogOpenBtn.Text = "Open log file";
			this.procLogOpenBtn.ToolTipText = "Open Log file with default application";
			this.procLogOpenBtn.Click += new System.EventHandler(this.procFileMenu_Click);
			// 
			// procExpBtn
			// 
			this.procExpBtn.Name = "procExpBtn";
			this.procExpBtn.Size = new System.Drawing.Size(161, 22);
			this.procExpBtn.Text = "Export...";
			this.procExpBtn.Click += new System.EventHandler(this.procFileMenu_Click);
			// 
			// toolStripSeparator16
			// 
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new System.Drawing.Size(158, 6);
			// 
			// printSetupToolStripMenuItem
			// 
			this.printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
			this.printSetupToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.printSetupToolStripMenuItem.Text = "Print Setup...";
			this.printSetupToolStripMenuItem.Click += new System.EventHandler(this.procFileMenu_Click);
			// 
			// printPreviewToolStripMenuItem
			// 
			this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
			this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.printPreviewToolStripMenuItem.Text = "Print Preview...";
			this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.procFileMenu_Click);
			// 
			// printToolStripMenuItem1
			// 
			this.printToolStripMenuItem1.Name = "printToolStripMenuItem1";
			this.printToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
			this.printToolStripMenuItem1.Text = "Print...";
			this.printToolStripMenuItem1.Click += new System.EventHandler(this.procFileMenu_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// procRefreshBtn
			// 
			this.procRefreshBtn.AutoToolTip = false;
			this.procRefreshBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.procRefreshBtn.ForeColor = System.Drawing.Color.White;
			this.procRefreshBtn.Image = global::FileInfo.Properties.Resources.red24;
			this.procRefreshBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.procRefreshBtn.Name = "procRefreshBtn";
			this.procRefreshBtn.Size = new System.Drawing.Size(71, 22);
			this.procRefreshBtn.Text = "Refresh";
			this.procRefreshBtn.ToolTipText = "Refresh  Process Display";
			this.procRefreshBtn.Click += new System.EventHandler(this.procRefreshBtn_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// procClock
			// 
			this.procClock.AutoSize = false;
			this.procClock.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.procClock.ForeColor = System.Drawing.Color.White;
			this.procClock.Name = "procClock";
			this.procClock.Size = new System.Drawing.Size(70, 22);
			this.procClock.Text = "88:88:88";
			this.procClock.ToolTipText = "Time of last Process update";
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// procLabel
			// 
			this.procLabel.AutoSize = false;
			this.procLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.procLabel.ForeColor = System.Drawing.Color.White;
			this.procLabel.Name = "procLabel";
			this.procLabel.Size = new System.Drawing.Size(500, 22);
			this.procLabel.Text = "Process List";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// procExportMenu
			// 
			this.procExportMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.procExportMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.procExportMenu.ForeColor = System.Drawing.Color.White;
			this.procExportMenu.Image = global::FileInfo.Properties.Resources.expoort;
			this.procExportMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.procExportMenu.Margin = new System.Windows.Forms.Padding(0);
			this.procExportMenu.Name = "procExportMenu";
			this.procExportMenu.Size = new System.Drawing.Size(75, 25);
			this.procExportMenu.Text = "Export...";
			this.procExportMenu.ToolTipText = "Export process list to disk file as csv";
			this.procExportMenu.Click += new System.EventHandler(this.procFileMenu_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
			// 
			// procLogMenu
			// 
			this.procLogMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.procLogMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.procLogMenu.ForeColor = System.Drawing.Color.White;
			this.procLogMenu.Image = ((System.Drawing.Image)(resources.GetObject("procLogMenu.Image")));
			this.procLogMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.procLogMenu.Name = "procLogMenu";
			this.procLogMenu.Size = new System.Drawing.Size(31, 22);
			this.procLogMenu.Text = "Log";
			this.procLogMenu.ToolTipText = "Save current list to log file";
			this.procLogMenu.Click += new System.EventHandler(this.procFileMenu_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
			// 
			// procPrintMenu
			// 
			this.procPrintMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.procPrintMenu.ForeColor = System.Drawing.Color.White;
			this.procPrintMenu.Image = global::FileInfo.Properties.Resources.print;
			this.procPrintMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.procPrintMenu.Name = "procPrintMenu";
			this.procPrintMenu.Size = new System.Drawing.Size(53, 22);
			this.procPrintMenu.Text = "Print";
			this.procPrintMenu.ToolTipText = "Print Process List";
			this.procPrintMenu.Click += new System.EventHandler(this.procFileMenu_Click);
			// 
			// toolStripSeparator17
			// 
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
			// 
			// procPreviewMenu
			// 
			this.procPreviewMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.procPreviewMenu.ForeColor = System.Drawing.Color.White;
			this.procPreviewMenu.Image = global::FileInfo.Properties.Resources.printPreview;
			this.procPreviewMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.procPreviewMenu.Name = "procPreviewMenu";
			this.procPreviewMenu.Size = new System.Drawing.Size(72, 22);
			this.procPreviewMenu.Text = "Preview";
			this.procPreviewMenu.ToolTipText = "Preview printing process list";
			this.procPreviewMenu.Click += new System.EventHandler(this.procFileMenu_Click);
			// 
			// resizePanel
			// 
			this.resizePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.resizePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
			this.resizePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resizePanel.BackgroundImage")));
			this.resizePanel.Location = new System.Drawing.Point(1041, 191);
			this.resizePanel.Margin = new System.Windows.Forms.Padding(0);
			this.resizePanel.Name = "resizePanel";
			this.resizePanel.Size = new System.Drawing.Size(22, 22);
			this.resizePanel.TabIndex = 4;
			this.resizePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resize_MouseDown);
			this.resizePanel.MouseEnter += new System.EventHandler(this.resize_MouseEnter);
			this.resizePanel.MouseLeave += new System.EventHandler(this.resize_MouseLeave);
			this.resizePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.resize_MouseMove);
			this.resizePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resize_MouseUp);
			// 
			// handleStatus
			// 
			this.handleStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.handleStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(165)))), ((int)(((byte)(176)))));
			this.handleStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.handleStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.handleStatus.Location = new System.Drawing.Point(3, 194);
			this.handleStatus.Margin = new System.Windows.Forms.Padding(0);
			this.handleStatus.Name = "handleStatus";
			this.handleStatus.ReadOnly = true;
			this.handleStatus.Size = new System.Drawing.Size(956, 15);
			this.handleStatus.TabIndex = 2;
			// 
			// closeBtn
			// 
			this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
			this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.closeBtn.Location = new System.Drawing.Point(964, 189);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(75, 23);
			this.closeBtn.TabIndex = 3;
			this.closeBtn.Text = "Close";
			this.closeBtn.UseVisualStyleBackColor = false;
			this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
			// 
			// handleView
			// 
			this.handleView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.handleView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colH0,
            this.colH_pid,
            this.col_procName,
            this.colH_handle,
            this.colH_object,
            this.col_desc});
			this.handleView.ContextMenuStrip = this.hndPopupMenu;
			this.handleView.FullRowSelect = true;
			this.handleView.GridLines = true;
			this.handleView.HideSelection = false;
			this.handleView.Location = new System.Drawing.Point(0, 25);
			this.handleView.Margin = new System.Windows.Forms.Padding(0);
			this.handleView.Name = "handleView";
			this.handleView.Size = new System.Drawing.Size(1064, 165);
			this.handleView.SmallImageList = this.sortImages;
			this.handleView.TabIndex = 1;
			this.handleView.UseCompatibleStateImageBehavior = false;
			this.handleView.View = System.Windows.Forms.View.Details;
			this.handleView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnClick);
			// 
			// colH0
			// 
			this.colH0.Text = "-";
			this.colH0.Width = 0;
			// 
			// colH_pid
			// 
			this.colH_pid.Text = "ProcId";
			this.colH_pid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// col_procName
			// 
			this.col_procName.Text = "ProcName";
			this.col_procName.Width = 111;
			// 
			// colH_handle
			// 
			this.colH_handle.Text = "Handle";
			this.colH_handle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colH_object
			// 
			this.colH_object.Text = "Object";
			this.colH_object.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colH_object.Width = 73;
			// 
			// col_desc
			// 
			this.col_desc.Text = "Description";
			this.col_desc.Width = 724;
			// 
			// hndPopupMenu
			// 
			this.hndPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hndPopupAutoSizeBtn,
            this.hndPopupExplorerBtn,
            this.hndPopupCmdBtn,
            this.hndPopupRegEditBtn,
            this.fileMapToolStripMenuItem});
			this.hndPopupMenu.Name = "hndPopupMenu";
			this.hndPopupMenu.Size = new System.Drawing.Size(172, 114);
			// 
			// hndPopupAutoSizeBtn
			// 
			this.hndPopupAutoSizeBtn.Name = "hndPopupAutoSizeBtn";
			this.hndPopupAutoSizeBtn.Size = new System.Drawing.Size(171, 22);
			this.hndPopupAutoSizeBtn.Text = "AutoSize Columns";
			this.hndPopupAutoSizeBtn.Click += new System.EventHandler(this.hndPopupBtn_Click);
			// 
			// hndPopupExplorerBtn
			// 
			this.hndPopupExplorerBtn.Name = "hndPopupExplorerBtn";
			this.hndPopupExplorerBtn.Size = new System.Drawing.Size(171, 22);
			this.hndPopupExplorerBtn.Text = "File - Explorer";
			this.hndPopupExplorerBtn.Click += new System.EventHandler(this.hndPopupBtn_Click);
			// 
			// hndPopupCmdBtn
			// 
			this.hndPopupCmdBtn.Name = "hndPopupCmdBtn";
			this.hndPopupCmdBtn.Size = new System.Drawing.Size(171, 22);
			this.hndPopupCmdBtn.Text = "File - Cmd";
			this.hndPopupCmdBtn.Click += new System.EventHandler(this.hndPopupBtn_Click);
			// 
			// hndPopupRegEditBtn
			// 
			this.hndPopupRegEditBtn.Name = "hndPopupRegEditBtn";
			this.hndPopupRegEditBtn.Size = new System.Drawing.Size(171, 22);
			this.hndPopupRegEditBtn.Text = "Key - RegEdit";
			this.hndPopupRegEditBtn.Click += new System.EventHandler(this.hndPopupBtn_Click);
			// 
			// fileMapToolStripMenuItem
			// 
			this.fileMapToolStripMenuItem.Name = "fileMapToolStripMenuItem";
			this.fileMapToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.fileMapToolStripMenuItem.Text = "File - Map";
			this.fileMapToolStripMenuItem.Click += new System.EventHandler(this.fileMapToolStripMenuItem_Click);
			// 
			// handleToolStrip
			// 
			this.handleToolStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("handleToolStrip.BackgroundImage")));
			this.handleToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.handleToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.handleToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator14,
            this.hndViewBtn,
            this.toolStripSplitButton2,
            this.toolStripSeparator3,
            this.hndRefreshBtn,
            this.toolStripSeparator1,
            this.hndClock,
            this.toolStripSeparator4,
            this.handleLabel,
            this.toolStripSeparator11,
            this.hndExportMenu,
            this.toolStripSeparator12,
            this.hndLogMenu,
            this.toolStripSeparator13,
            this.hndPrintMenu,
            this.toolStripSeparator20,
            this.hndPreviewMenu});
			this.handleToolStrip.Location = new System.Drawing.Point(0, 0);
			this.handleToolStrip.Name = "handleToolStrip";
			this.handleToolStrip.Size = new System.Drawing.Size(1064, 25);
			this.handleToolStrip.TabIndex = 0;
			this.handleToolStrip.Text = "toolStrip3";
			// 
			// hndViewBtn
			// 
			this.hndViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.hndViewBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hndHideNoDescBtn,
            this.filterToolStripMenuItem,
            this.groupByToolStripMenuItem});
			this.hndViewBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hndViewBtn.ForeColor = System.Drawing.Color.White;
			this.hndViewBtn.Image = ((System.Drawing.Image)(resources.GetObject("hndViewBtn.Image")));
			this.hndViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.hndViewBtn.Name = "hndViewBtn";
			this.hndViewBtn.Size = new System.Drawing.Size(63, 22);
			this.hndViewBtn.Text = "View...";
			// 
			// hndHideNoDescBtn
			// 
			this.hndHideNoDescBtn.CheckOnClick = true;
			this.hndHideNoDescBtn.Name = "hndHideNoDescBtn";
			this.hndHideNoDescBtn.Size = new System.Drawing.Size(194, 22);
			this.hndHideNoDescBtn.Text = "Hide if no description";
			this.hndHideNoDescBtn.Click += new System.EventHandler(this.hndHideNoDescBtn_Click);
			// 
			// filterToolStripMenuItem
			// 
			this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hndShowAllBtn});
			this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
			this.filterToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.filterToolStripMenuItem.Text = "Limit objects to";
			// 
			// hndShowAllBtn
			// 
			this.hndShowAllBtn.Checked = true;
			this.hndShowAllBtn.CheckOnClick = true;
			this.hndShowAllBtn.CheckState = System.Windows.Forms.CheckState.Checked;
			this.hndShowAllBtn.Name = "hndShowAllBtn";
			this.hndShowAllBtn.Size = new System.Drawing.Size(88, 22);
			this.hndShowAllBtn.Text = "All";
			this.hndShowAllBtn.Click += new System.EventHandler(this.hndShowAllBtn_Click);
			// 
			// groupByToolStripMenuItem
			// 
			this.groupByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hndNoGrpBtn,
            this.hndPidGrpBtn,
            this.hndObjGrpBtn});
			this.groupByToolStripMenuItem.Name = "groupByToolStripMenuItem";
			this.groupByToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.groupByToolStripMenuItem.Text = "Group By";
			// 
			// hndNoGrpBtn
			// 
			this.hndNoGrpBtn.Checked = true;
			this.hndNoGrpBtn.CheckState = System.Windows.Forms.CheckState.Checked;
			this.hndNoGrpBtn.Name = "hndNoGrpBtn";
			this.hndNoGrpBtn.Size = new System.Drawing.Size(149, 22);
			this.hndNoGrpBtn.Text = "No Group";
			this.hndNoGrpBtn.Click += new System.EventHandler(this.hndGrpBtn_Click);
			// 
			// hndPidGrpBtn
			// 
			this.hndPidGrpBtn.Name = "hndPidGrpBtn";
			this.hndPidGrpBtn.Size = new System.Drawing.Size(149, 22);
			this.hndPidGrpBtn.Text = "Pid Group";
			this.hndPidGrpBtn.Click += new System.EventHandler(this.hndGrpBtn_Click);
			// 
			// hndObjGrpBtn
			// 
			this.hndObjGrpBtn.Name = "hndObjGrpBtn";
			this.hndObjGrpBtn.Size = new System.Drawing.Size(149, 22);
			this.hndObjGrpBtn.Text = "Object Group";
			this.hndObjGrpBtn.Click += new System.EventHandler(this.hndGrpBtn_Click);
			// 
			// toolStripSeparator14
			// 
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSplitButton2
			// 
			this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hndAutoUpdBtn,
            this.hndRateBtn,
            this.toolStripSeparator18,
            this.hndAutoLogBtn,
            this.hndLogFileBtn,
            this.openLogFileToolStripMenuItem,
            this.hndExportBtn,
            this.toolStripSeparator19,
            this.hndPrSetBtn,
            this.hndPrPreviewBtn,
            this.hndPrBtn});
			this.toolStripSplitButton2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripSplitButton2.ForeColor = System.Drawing.Color.White;
			this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
			this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton2.Name = "toolStripSplitButton2";
			this.toolStripSplitButton2.Size = new System.Drawing.Size(43, 22);
			this.toolStripSplitButton2.Text = "File";
			this.toolStripSplitButton2.ToolTipText = "Update, log, export and print";
			// 
			// hndAutoUpdBtn
			// 
			this.hndAutoUpdBtn.CheckOnClick = true;
			this.hndAutoUpdBtn.Name = "hndAutoUpdBtn";
			this.hndAutoUpdBtn.Size = new System.Drawing.Size(161, 22);
			this.hndAutoUpdBtn.Text = "Auto Update";
			this.hndAutoUpdBtn.Click += new System.EventHandler(this.hndFileMenu_Click);
			// 
			// hndRateBtn
			// 
			this.hndRateBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hnd1secBtn,
            this.hnd5secBtn,
            this.hnd1minBtn,
            this.hnd5minBtn,
            this.hnd1hourBtn,
            this.hndCustomBtn});
			this.hndRateBtn.Name = "hndRateBtn";
			this.hndRateBtn.Size = new System.Drawing.Size(161, 22);
			this.hndRateBtn.Text = "Update  Rate";
			// 
			// hnd1secBtn
			// 
			this.hnd1secBtn.Name = "hnd1secBtn";
			this.hnd1secBtn.Size = new System.Drawing.Size(127, 22);
			this.hnd1secBtn.Tag = 1;
			this.hnd1secBtn.Text = "1 Second";
			this.hnd1secBtn.Click += new System.EventHandler(this.hndUpdRate_Click);
			// 
			// hnd5secBtn
			// 
			this.hnd5secBtn.Checked = true;
			this.hnd5secBtn.CheckState = System.Windows.Forms.CheckState.Checked;
			this.hnd5secBtn.Name = "hnd5secBtn";
			this.hnd5secBtn.Size = new System.Drawing.Size(127, 22);
			this.hnd5secBtn.Tag = 5;
			this.hnd5secBtn.Text = "5 Second";
			this.hnd5secBtn.Click += new System.EventHandler(this.hndUpdRate_Click);
			// 
			// hnd1minBtn
			// 
			this.hnd1minBtn.Name = "hnd1minBtn";
			this.hnd1minBtn.Size = new System.Drawing.Size(127, 22);
			this.hnd1minBtn.Tag = 60;
			this.hnd1minBtn.Text = "1 Minute";
			this.hnd1minBtn.Click += new System.EventHandler(this.hndUpdRate_Click);
			// 
			// hnd5minBtn
			// 
			this.hnd5minBtn.Name = "hnd5minBtn";
			this.hnd5minBtn.Size = new System.Drawing.Size(127, 22);
			this.hnd5minBtn.Tag = 500;
			this.hnd5minBtn.Text = "5 Minute";
			this.hnd5minBtn.Click += new System.EventHandler(this.hndUpdRate_Click);
			// 
			// hnd1hourBtn
			// 
			this.hnd1hourBtn.Name = "hnd1hourBtn";
			this.hnd1hourBtn.Size = new System.Drawing.Size(127, 22);
			this.hnd1hourBtn.Tag = 3600;
			this.hnd1hourBtn.Text = "Hourly";
			this.hnd1hourBtn.Click += new System.EventHandler(this.hndUpdRate_Click);
			// 
			// hndCustomBtn
			// 
			this.hndCustomBtn.Enabled = false;
			this.hndCustomBtn.Name = "hndCustomBtn";
			this.hndCustomBtn.Size = new System.Drawing.Size(127, 22);
			this.hndCustomBtn.Tag = -1;
			this.hndCustomBtn.Text = "Custom";
			this.hndCustomBtn.Click += new System.EventHandler(this.hndUpdRate_Click);
			// 
			// toolStripSeparator18
			// 
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new System.Drawing.Size(158, 6);
			// 
			// hndAutoLogBtn
			// 
			this.hndAutoLogBtn.CheckOnClick = true;
			this.hndAutoLogBtn.Name = "hndAutoLogBtn";
			this.hndAutoLogBtn.Size = new System.Drawing.Size(161, 22);
			this.hndAutoLogBtn.Text = "Auto Log";
			this.hndAutoLogBtn.Click += new System.EventHandler(this.hndFileMenu_Click);
			// 
			// hndLogFileBtn
			// 
			this.hndLogFileBtn.Name = "hndLogFileBtn";
			this.hndLogFileBtn.Size = new System.Drawing.Size(161, 22);
			this.hndLogFileBtn.Text = "Log File...";
			this.hndLogFileBtn.Click += new System.EventHandler(this.hndFileMenu_Click);
			// 
			// openLogFileToolStripMenuItem
			// 
			this.openLogFileToolStripMenuItem.Name = "openLogFileToolStripMenuItem";
			this.openLogFileToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.openLogFileToolStripMenuItem.Text = "Open log file";
			this.openLogFileToolStripMenuItem.Click += new System.EventHandler(this.hndFileMenu_Click);
			// 
			// hndExportBtn
			// 
			this.hndExportBtn.Name = "hndExportBtn";
			this.hndExportBtn.Size = new System.Drawing.Size(161, 22);
			this.hndExportBtn.Text = "Export...";
			this.hndExportBtn.Click += new System.EventHandler(this.hndFileMenu_Click);
			// 
			// toolStripSeparator19
			// 
			this.toolStripSeparator19.Name = "toolStripSeparator19";
			this.toolStripSeparator19.Size = new System.Drawing.Size(158, 6);
			// 
			// hndPrSetBtn
			// 
			this.hndPrSetBtn.Name = "hndPrSetBtn";
			this.hndPrSetBtn.Size = new System.Drawing.Size(161, 22);
			this.hndPrSetBtn.Text = "Print Setup...";
			this.hndPrSetBtn.Click += new System.EventHandler(this.hndFileMenu_Click);
			// 
			// hndPrPreviewBtn
			// 
			this.hndPrPreviewBtn.Name = "hndPrPreviewBtn";
			this.hndPrPreviewBtn.Size = new System.Drawing.Size(161, 22);
			this.hndPrPreviewBtn.Text = "Print Preview...";
			this.hndPrPreviewBtn.Click += new System.EventHandler(this.hndFileMenu_Click);
			// 
			// hndPrBtn
			// 
			this.hndPrBtn.Name = "hndPrBtn";
			this.hndPrBtn.Size = new System.Drawing.Size(161, 22);
			this.hndPrBtn.Text = "Print...";
			this.hndPrBtn.Click += new System.EventHandler(this.hndFileMenu_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// hndRefreshBtn
			// 
			this.hndRefreshBtn.AutoSize = false;
			this.hndRefreshBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hndRefreshBtn.ForeColor = System.Drawing.Color.White;
			this.hndRefreshBtn.Image = global::FileInfo.Properties.Resources.red24;
			this.hndRefreshBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.hndRefreshBtn.Name = "hndRefreshBtn";
			this.hndRefreshBtn.Size = new System.Drawing.Size(75, 22);
			this.hndRefreshBtn.Text = "Refresh";
			this.hndRefreshBtn.ToolTipText = "Refresh Open Handles List";
			this.hndRefreshBtn.Click += new System.EventHandler(this.hndRefreshBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// hndClock
			// 
			this.hndClock.AutoSize = false;
			this.hndClock.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hndClock.ForeColor = System.Drawing.Color.White;
			this.hndClock.Name = "hndClock";
			this.hndClock.Size = new System.Drawing.Size(70, 22);
			this.hndClock.Text = "88:88:88";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// handleLabel
			// 
			this.handleLabel.AutoSize = false;
			this.handleLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.handleLabel.ForeColor = System.Drawing.Color.White;
			this.handleLabel.Name = "handleLabel";
			this.handleLabel.Size = new System.Drawing.Size(500, 22);
			this.handleLabel.Text = "Open Handles";
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
			// 
			// hndExportMenu
			// 
			this.hndExportMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hndExportMenu.ForeColor = System.Drawing.Color.White;
			this.hndExportMenu.Image = global::FileInfo.Properties.Resources.expoort;
			this.hndExportMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.hndExportMenu.Name = "hndExportMenu";
			this.hndExportMenu.Size = new System.Drawing.Size(75, 22);
			this.hndExportMenu.Text = "Export...";
			this.hndExportMenu.ToolTipText = "Export handle list to disk file as csv";
			this.hndExportMenu.Click += new System.EventHandler(this.hndFileMenu_Click);
			// 
			// toolStripSeparator12
			// 
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
			// 
			// hndLogMenu
			// 
			this.hndLogMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.hndLogMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hndLogMenu.ForeColor = System.Drawing.Color.White;
			this.hndLogMenu.Image = ((System.Drawing.Image)(resources.GetObject("hndLogMenu.Image")));
			this.hndLogMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.hndLogMenu.Name = "hndLogMenu";
			this.hndLogMenu.Size = new System.Drawing.Size(31, 22);
			this.hndLogMenu.Text = "Log";
			this.hndLogMenu.ToolTipText = "Save current list to log file";
			this.hndLogMenu.Click += new System.EventHandler(this.hndFileMenu_Click);
			// 
			// toolStripSeparator13
			// 
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
			// 
			// hndPrintMenu
			// 
			this.hndPrintMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hndPrintMenu.ForeColor = System.Drawing.Color.White;
			this.hndPrintMenu.Image = global::FileInfo.Properties.Resources.print;
			this.hndPrintMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.hndPrintMenu.Name = "hndPrintMenu";
			this.hndPrintMenu.Size = new System.Drawing.Size(53, 22);
			this.hndPrintMenu.Text = "Print";
			this.hndPrintMenu.ToolTipText = "Print Handle List";
			this.hndPrintMenu.Click += new System.EventHandler(this.hndFileMenu_Click);
			// 
			// toolStripSeparator20
			// 
			this.toolStripSeparator20.Name = "toolStripSeparator20";
			this.toolStripSeparator20.Size = new System.Drawing.Size(6, 25);
			// 
			// hndPreviewMenu
			// 
			this.hndPreviewMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hndPreviewMenu.ForeColor = System.Drawing.Color.White;
			this.hndPreviewMenu.Image = global::FileInfo.Properties.Resources.printPreview;
			this.hndPreviewMenu.Name = "hndPreviewMenu";
			this.hndPreviewMenu.Size = new System.Drawing.Size(68, 22);
			this.hndPreviewMenu.Text = "Preview";
			this.hndPreviewMenu.ToolTipText = "Preview printing handle list";
			this.hndPreviewMenu.Click += new System.EventHandler(this.hndFileMenu_Click);
			// 
			// procTimer
			// 
			this.procTimer.Interval = 1000;
			this.procTimer.Tick += new System.EventHandler(this.procTimer_Tick);
			// 
			// exportFileDialog
			// 
			this.exportFileDialog.Filter = "csv|*.csv|txt|*.txt|Any|*.*";
			this.exportFileDialog.Title = "Export FileInfo List";
			// 
			// logFileDialog
			// 
			this.logFileDialog.Filter = "csv|*.csv|text|*.txt|Any|*.*";
			this.logFileDialog.Title = "Log FileInfo ";
			// 
			// handleTimer
			// 
			this.handleTimer.Interval = 1000;
			this.handleTimer.Tick += new System.EventHandler(this.handleTimer_Tick);
			// 
			// mainToolStrip
			// 
			this.mainToolStrip.BackColor = System.Drawing.Color.Transparent;
			this.mainToolStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainToolStrip.BackgroundImage")));
			this.mainToolStrip.CanOverflow = false;
			this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diskDetailBtn,
            this.fsInfoBtn,
            this.title,
            this.diskClusterBtn});
			this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
			this.mainToolStrip.Name = "mainToolStrip";
			this.mainToolStrip.Size = new System.Drawing.Size(1068, 71);
			this.mainToolStrip.Stretch = true;
			this.mainToolStrip.TabIndex = 0;
			this.mainToolStrip.Text = "toolStrip1";
			// 
			// diskDetailBtn
			// 
			this.diskDetailBtn.AutoSize = false;
			this.diskDetailBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.diskDetailBtn.Image = ((System.Drawing.Image)(resources.GetObject("diskDetailBtn.Image")));
			this.diskDetailBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.diskDetailBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.diskDetailBtn.Name = "diskDetailBtn";
			this.diskDetailBtn.Size = new System.Drawing.Size(64, 64);
			this.diskDetailBtn.ToolTipText = "About Author and Program information.";
			this.diskDetailBtn.Click += new System.EventHandler(this.About_Click);
			// 
			// fsInfoBtn
			// 
			this.fsInfoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fsInfoBtn.Image = ((System.Drawing.Image)(resources.GetObject("fsInfoBtn.Image")));
			this.fsInfoBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.fsInfoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fsInfoBtn.Name = "fsInfoBtn";
			this.fsInfoBtn.Size = new System.Drawing.Size(68, 68);
			this.fsInfoBtn.ToolTipText = "Display File System Details";
			this.fsInfoBtn.Click += new System.EventHandler(this.FileSysInfo_Click);
			// 
			// title
			// 
			this.title.AutoSize = false;
			this.title.BackColor = System.Drawing.Color.Transparent;
			this.title.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title.BackgroundImage")));
			this.title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.title.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.title.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.title.ForeColor = System.Drawing.Color.Red;
			this.title.Name = "title";
			this.title.Size = new System.Drawing.Size(400, 64);
			this.title.Text = "FileInfo v1.1 - DLang 2009";
			this.title.Click += new System.EventHandler(this.About_Click);
			// 
			// diskClusterBtn
			// 
			this.diskClusterBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.diskClusterBtn.Image = ((System.Drawing.Image)(resources.GetObject("diskClusterBtn.Image")));
			this.diskClusterBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.diskClusterBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.diskClusterBtn.Name = "diskClusterBtn";
			this.diskClusterBtn.Size = new System.Drawing.Size(68, 68);
			this.diskClusterBtn.Text = "toolStripButton1";
			this.diskClusterBtn.ToolTipText = "Display Disk Cluster Allocation Map";
			this.diskClusterBtn.Click += new System.EventHandler(this.diskClusterBtn_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1068, 629);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.mainToolStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "FileInfo - DLang - v1.0";
			this.toolTip.SetToolTip(this, "Display Open Handles");
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			this.splitContainer2.ResumeLayout(false);
			this.procToolStrip.ResumeLayout(false);
			this.procToolStrip.PerformLayout();
			this.hndPopupMenu.ResumeLayout(false);
			this.handleToolStrip.ResumeLayout(false);
			this.handleToolStrip.PerformLayout();
			this.mainToolStrip.ResumeLayout(false);
			this.mainToolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView procView;
        private System.Windows.Forms.ColumnHeader col0;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ColumnHeader col_id;
        private System.Windows.Forms.ColumnHeader col_name;
        private System.Windows.Forms.ColumnHeader col_start;
        private System.Windows.Forms.ColumnHeader col_totTime;
        private System.Windows.Forms.ColumnHeader col_userTime;
        private System.Windows.Forms.ToolStrip procToolStrip;
        private System.Windows.Forms.TextBox handleStatus;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.ColumnHeader col_privMem;
        private System.Windows.Forms.ColumnHeader col_work;
        private System.Windows.Forms.ColumnHeader col_wkPeak;
        private System.Windows.Forms.ColumnHeader col_virt;
        private System.Windows.Forms.ColumnHeader col_virtPeakSize;
        private System.Windows.Forms.ColumnHeader col_paged;
        private System.Windows.Forms.ColumnHeader col_pagedPeak;
        private System.Windows.Forms.ColumnHeader col_handles;
        private System.Windows.Forms.ColumnHeader col_Threads;
        private System.Windows.Forms.ColumnHeader col_Modules;
        private System.Windows.Forms.ToolStripButton procRefreshBtn;
        private System.Windows.Forms.Timer procTimer;
        private System.Windows.Forms.ToolStripLabel procClock;
        private System.Windows.Forms.ToolStripLabel procLabel;
        private System.Windows.Forms.ListView handleView;
        private System.Windows.Forms.ColumnHeader colH0;
        private System.Windows.Forms.ColumnHeader colH_pid;
        private System.Windows.Forms.ColumnHeader colH_handle;
        private System.Windows.Forms.ColumnHeader colH_object;
        private System.Windows.Forms.ToolStrip handleToolStrip;
        private System.Windows.Forms.ToolStripLabel handleLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton hndRefreshBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel hndClock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ColumnHeader col_procName;
        private System.Windows.Forms.ColumnHeader col_desc;
        private System.Windows.Forms.ToolStripButton diskDetailBtn;
        private System.Windows.Forms.ToolStripLabel title;
        private System.Windows.Forms.TextBox procStatus;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton procExportMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton procPreviewMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton procPrintMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton hndExportMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripLabel hndPreviewMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton hndPrintMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ColumnHeader col_log;
        private System.Windows.Forms.ImageList sortImages;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem procLogFileBtn;
        private System.Windows.Forms.ToolStripMenuItem procAutoLogBtn;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem updateRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procAutoUpdBtn;
        private System.Windows.Forms.ToolStripMenuItem prooc1secBtn;
        private System.Windows.Forms.ToolStripMenuItem proc5secBtn;
        private System.Windows.Forms.ToolStripMenuItem proc1minBtn;
        private System.Windows.Forms.ToolStripMenuItem proc5minBtn;
        private System.Windows.Forms.ToolStripMenuItem proc1hourBtn;
        private System.Windows.Forms.ToolStripMenuItem procCustomBtn;
        private System.Windows.Forms.ToolStripMenuItem procExpBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem hndAutoUpdBtn;
        private System.Windows.Forms.ToolStripMenuItem hndRateBtn;
        private System.Windows.Forms.ToolStripMenuItem hnd1secBtn;
        private System.Windows.Forms.ToolStripMenuItem hnd5secBtn;
        private System.Windows.Forms.ToolStripMenuItem hnd1minBtn;
        private System.Windows.Forms.ToolStripMenuItem hnd5minBtn;
        private System.Windows.Forms.ToolStripMenuItem hnd1hourBtn;
        private System.Windows.Forms.ToolStripMenuItem hndCustomBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripMenuItem hndAutoLogBtn;
        private System.Windows.Forms.ToolStripMenuItem hndLogFileBtn;
        private System.Windows.Forms.ToolStripMenuItem hndExportBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripMenuItem hndPrSetBtn;
        private System.Windows.Forms.ToolStripMenuItem hndPrPreviewBtn;
        private System.Windows.Forms.ToolStripMenuItem hndPrBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.SaveFileDialog exportFileDialog;
        private System.Windows.Forms.SaveFileDialog logFileDialog;
        private System.Windows.Forms.Timer handleTimer;
        private System.Windows.Forms.ToolStripSplitButton hndViewBtn;
        private System.Windows.Forms.ToolStripMenuItem hndNoGrpBtn;
        private System.Windows.Forms.ToolStripMenuItem hndPidGrpBtn;
        private System.Windows.Forms.ToolStripMenuItem hndObjGrpBtn;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hndShowAllBtn;
        private System.Windows.Forms.ToolStripButton fsInfoBtn;
        private System.Windows.Forms.ContextMenuStrip hndPopupMenu;
        private System.Windows.Forms.ToolStripMenuItem hndPopupAutoSizeBtn;
        private System.Windows.Forms.ToolStripMenuItem hndPopupExplorerBtn;
        private System.Windows.Forms.ToolStripMenuItem hndPopupCmdBtn;
        private System.Windows.Forms.ToolStripMenuItem hndPopupRegEditBtn;
        private System.Windows.Forms.ToolStripButton diskClusterBtn;
        private System.Windows.Forms.ToolStripMenuItem hndHideNoDescBtn;
        private System.Windows.Forms.Panel resizePanel;
        private System.Windows.Forms.ToolStripMenuItem fileMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupByToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton procLogMenu;
        private System.Windows.Forms.ToolStripButton hndLogMenu;
        private System.Windows.Forms.ToolStripMenuItem procLogOpenBtn;
        private System.Windows.Forms.ToolStripMenuItem openLogFileToolStripMenuItem;
    }
}

