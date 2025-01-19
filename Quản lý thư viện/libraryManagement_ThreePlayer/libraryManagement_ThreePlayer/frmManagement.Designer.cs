namespace libraryManagement_ThreePlayer
{
    partial class frmManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagement));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnPhieu = new System.Windows.Forms.Button();
            this.btnTools = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnSystems = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelChucVu = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMaxmize = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDesktop = new System.Windows.Forms.Panel();
            this.SystemMenu = new RJCodeAdvance.RJControls.RJDropdownMenu(this.components);
            this.loginMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ManagerMenu = new RJCodeAdvance.RJControls.RJDropdownMenu(this.components);
            this.btnBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAuthors = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReaders = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStaffs = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenres = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenu = new RJCodeAdvance.RJControls.RJDropdownMenu(this.components);
            this.btnBookTools = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAuthorTools = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReaderTools = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStaffTools = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBorrowTools = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTheLoaiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.PhieuMenu = new RJCodeAdvance.RJControls.RJDropdownMenu(this.components);
            this.btnMuon = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTra = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPhat = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMenu.SuspendLayout();
            this.menu.SuspendLayout();
            this.pnlTitleBar.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SystemMenu.SuspendLayout();
            this.ManagerMenu.SuspendLayout();
            this.ToolsMenu.SuspendLayout();
            this.PhieuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.pnlMenu.Controls.Add(this.btnPhieu);
            this.pnlMenu.Controls.Add(this.btnTools);
            this.pnlMenu.Controls.Add(this.button1);
            this.pnlMenu.Controls.Add(this.panel1);
            this.pnlMenu.Controls.Add(this.btnManager);
            this.pnlMenu.Controls.Add(this.btnSystems);
            this.pnlMenu.Controls.Add(this.menu);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 555);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnPhieu
            // 
            this.btnPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhieu.FlatAppearance.BorderSize = 0;
            this.btnPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhieu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnPhieu.Image")));
            this.btnPhieu.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPhieu.Location = new System.Drawing.Point(0, 310);
            this.btnPhieu.Name = "btnPhieu";
            this.btnPhieu.Size = new System.Drawing.Size(200, 50);
            this.btnPhieu.TabIndex = 4;
            this.btnPhieu.Tag = "Phiếu      ";
            this.btnPhieu.Text = "   Phiếu      ";
            this.btnPhieu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPhieu.UseVisualStyleBackColor = true;
            this.btnPhieu.Click += new System.EventHandler(this.btnPhieu_Click);
            // 
            // btnTools
            // 
            this.btnTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTools.FlatAppearance.BorderSize = 0;
            this.btnTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTools.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTools.Image = ((System.Drawing.Image)(resources.GetObject("btnTools.Image")));
            this.btnTools.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTools.Location = new System.Drawing.Point(0, 260);
            this.btnTools.Name = "btnTools";
            this.btnTools.Size = new System.Drawing.Size(200, 50);
            this.btnTools.TabIndex = 5;
            this.btnTools.Tag = "Công cụ   ";
            this.btnTools.Text = "   Công cụ   ";
            this.btnTools.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTools.UseVisualStyleBackColor = true;
            this.btnTools.Click += new System.EventHandler(this.btnTools_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(0, 485);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 50);
            this.button1.TabIndex = 4;
            this.button1.Tag = "Cài đặt  ";
            this.button1.Text = "   Cài đặt  ";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 535);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 20);
            this.panel1.TabIndex = 3;
            // 
            // btnManager
            // 
            this.btnManager.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManager.FlatAppearance.BorderSize = 0;
            this.btnManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManager.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManager.Image = ((System.Drawing.Image)(resources.GetObject("btnManager.Image")));
            this.btnManager.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnManager.Location = new System.Drawing.Point(0, 210);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(200, 50);
            this.btnManager.TabIndex = 2;
            this.btnManager.Tag = "Quản lý   ";
            this.btnManager.Text = "   Quản lý   ";
            this.btnManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManager.UseVisualStyleBackColor = true;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // btnSystems
            // 
            this.btnSystems.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSystems.FlatAppearance.BorderSize = 0;
            this.btnSystems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystems.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSystems.Image = ((System.Drawing.Image)(resources.GetObject("btnSystems.Image")));
            this.btnSystems.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSystems.Location = new System.Drawing.Point(0, 160);
            this.btnSystems.Name = "btnSystems";
            this.btnSystems.Size = new System.Drawing.Size(200, 50);
            this.btnSystems.TabIndex = 1;
            this.btnSystems.Tag = "Hệ thống ";
            this.btnSystems.Text = "   Hệ thống ";
            this.btnSystems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSystems.UseVisualStyleBackColor = true;
            this.btnSystems.Click += new System.EventHandler(this.btnSystems_Click);
            // 
            // menu
            // 
            this.menu.Controls.Add(this.btnMenu);
            this.menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(200, 160);
            this.menu.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(200, 55);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.Tag = "Menu";
            this.btnMenu.Text = "   Menu";
            this.btnMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlTitleBar.Controls.Add(this.panel4);
            this.pnlTitleBar.Controls.Add(this.panel3);
            this.pnlTitleBar.Controls.Add(this.panel2);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(200, 0);
            this.pnlTitleBar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(934, 55);
            this.pnlTitleBar.TabIndex = 1;
            this.pnlTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelUserName);
            this.panel4.Controls.Add(this.labelChucVu);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(527, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(245, 55);
            this.panel4.TabIndex = 0;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.Location = new System.Drawing.Point(3, 5);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelUserName.Size = new System.Drawing.Size(186, 19);
            this.labelUserName.TabIndex = 6;
            this.labelUserName.Text = "[##] Chưa đăng nhập";
            // 
            // labelChucVu
            // 
            this.labelChucVu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChucVu.AutoSize = true;
            this.labelChucVu.BackColor = System.Drawing.Color.Transparent;
            this.labelChucVu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChucVu.Location = new System.Drawing.Point(3, 31);
            this.labelChucVu.Name = "labelChucVu";
            this.labelChucVu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelChucVu.Size = new System.Drawing.Size(144, 19);
            this.labelChucVu.TabIndex = 4;
            this.labelChucVu.Text = "Chức vụ: Không có";
            this.labelChucVu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnMinimize);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnMaxmize);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(772, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(162, 55);
            this.panel3.TabIndex = 0;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.BackgroundImage")));
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(32, 6);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(40, 25);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Tomato;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(116, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMaxmize
            // 
            this.btnMaxmize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaxmize.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnMaxmize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMaxmize.BackgroundImage")));
            this.btnMaxmize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMaxmize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaxmize.FlatAppearance.BorderSize = 0;
            this.btnMaxmize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxmize.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMaxmize.Location = new System.Drawing.Point(74, 6);
            this.btnMaxmize.Name = "btnMaxmize";
            this.btnMaxmize.Size = new System.Drawing.Size(40, 25);
            this.btnMaxmize.TabIndex = 1;
            this.btnMaxmize.UseVisualStyleBackColor = false;
            this.btnMaxmize.Click += new System.EventHandler(this.btnMaxmize_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 55);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "QUẢN LÝ THƯ VIỆN";
            // 
            // pnlDesktop
            // 
            this.pnlDesktop.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktop.Location = new System.Drawing.Point(200, 55);
            this.pnlDesktop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDesktop.Name = "pnlDesktop";
            this.pnlDesktop.Size = new System.Drawing.Size(934, 500);
            this.pnlDesktop.TabIndex = 2;
            // 
            // SystemMenu
            // 
            this.SystemMenu.BackColor = System.Drawing.SystemColors.Control;
            this.SystemMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SystemMenu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemMenu.IsMainMenu = false;
            this.SystemMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginMenu,
            this.logoutMenu});
            this.SystemMenu.MenuItemHeight = 50;
            this.SystemMenu.MenuItemTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SystemMenu.Name = "SystemMenu";
            this.SystemMenu.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.SystemMenu.ShowImageMargin = false;
            this.SystemMenu.Size = new System.Drawing.Size(131, 52);
            // 
            // loginMenu
            // 
            this.loginMenu.Name = "loginMenu";
            this.loginMenu.Size = new System.Drawing.Size(130, 24);
            this.loginMenu.Text = "Đăng nhập";
            this.loginMenu.Click += new System.EventHandler(this.loginMenu_Click);
            // 
            // logoutMenu
            // 
            this.logoutMenu.Name = "logoutMenu";
            this.logoutMenu.Size = new System.Drawing.Size(130, 24);
            this.logoutMenu.Text = "Đăng xuất";
            this.logoutMenu.Click += new System.EventHandler(this.logoutMenu_Click);
            // 
            // ManagerMenu
            // 
            this.ManagerMenu.BackColor = System.Drawing.SystemColors.Control;
            this.ManagerMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ManagerMenu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManagerMenu.IsMainMenu = false;
            this.ManagerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBooks,
            this.btnAuthors,
            this.btnReaders,
            this.btnStaffs,
            this.btnGenres});
            this.ManagerMenu.MenuItemHeight = 50;
            this.ManagerMenu.MenuItemTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ManagerMenu.Name = "SystemMenu";
            this.ManagerMenu.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ManagerMenu.ShowImageMargin = false;
            this.ManagerMenu.Size = new System.Drawing.Size(125, 124);
            // 
            // btnBooks
            // 
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Size = new System.Drawing.Size(124, 24);
            this.btnBooks.Text = "Sách";
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // btnAuthors
            // 
            this.btnAuthors.Name = "btnAuthors";
            this.btnAuthors.Size = new System.Drawing.Size(124, 24);
            this.btnAuthors.Text = "Tác giả";
            this.btnAuthors.Click += new System.EventHandler(this.btnAuthors_Click);
            // 
            // btnReaders
            // 
            this.btnReaders.Name = "btnReaders";
            this.btnReaders.Size = new System.Drawing.Size(124, 24);
            this.btnReaders.Text = "Độc giả";
            this.btnReaders.Click += new System.EventHandler(this.btnReaders_Click);
            // 
            // btnStaffs
            // 
            this.btnStaffs.Name = "btnStaffs";
            this.btnStaffs.Size = new System.Drawing.Size(124, 24);
            this.btnStaffs.Text = "Nhân viên";
            this.btnStaffs.Click += new System.EventHandler(this.btnStaffs_Click);
            // 
            // btnGenres
            // 
            this.btnGenres.Name = "btnGenres";
            this.btnGenres.Size = new System.Drawing.Size(124, 24);
            this.btnGenres.Text = "Thể loại";
            this.btnGenres.Click += new System.EventHandler(this.btnGenres_Click);
            // 
            // ToolsMenu
            // 
            this.ToolsMenu.BackColor = System.Drawing.SystemColors.Control;
            this.ToolsMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ToolsMenu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolsMenu.IsMainMenu = false;
            this.ToolsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBookTools,
            this.btnAuthorTools,
            this.btnReaderTools,
            this.btnStaffTools,
            this.btnBorrowTools,
            this.btnReturn,
            this.btnTheLoaiTools});
            this.ToolsMenu.MenuItemHeight = 50;
            this.ToolsMenu.MenuItemTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ToolsMenu.Name = "SystemMenu";
            this.ToolsMenu.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ToolsMenu.ShowImageMargin = false;
            this.ToolsMenu.Size = new System.Drawing.Size(125, 172);
            this.ToolsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ToolsMenu_Opening);
            // 
            // btnBookTools
            // 
            this.btnBookTools.Name = "btnBookTools";
            this.btnBookTools.Size = new System.Drawing.Size(124, 24);
            this.btnBookTools.Text = "Sách";
            this.btnBookTools.Click += new System.EventHandler(this.btnBookTools_Click);
            // 
            // btnAuthorTools
            // 
            this.btnAuthorTools.Name = "btnAuthorTools";
            this.btnAuthorTools.Size = new System.Drawing.Size(124, 24);
            this.btnAuthorTools.Text = "Tác giả";
            this.btnAuthorTools.Click += new System.EventHandler(this.btnAuthorTools_Click);
            // 
            // btnReaderTools
            // 
            this.btnReaderTools.Name = "btnReaderTools";
            this.btnReaderTools.Size = new System.Drawing.Size(124, 24);
            this.btnReaderTools.Text = "Độc giả";
            this.btnReaderTools.Click += new System.EventHandler(this.btnReaderTools_Click);
            // 
            // btnStaffTools
            // 
            this.btnStaffTools.Name = "btnStaffTools";
            this.btnStaffTools.Size = new System.Drawing.Size(124, 24);
            this.btnStaffTools.Text = "Nhân viên";
            this.btnStaffTools.Click += new System.EventHandler(this.btnStaffTools_Click);
            // 
            // btnBorrowTools
            // 
            this.btnBorrowTools.Name = "btnBorrowTools";
            this.btnBorrowTools.Size = new System.Drawing.Size(124, 24);
            this.btnBorrowTools.Text = "Mượn";
            this.btnBorrowTools.Click += new System.EventHandler(this.btnBorrowTools_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(124, 24);
            this.btnReturn.Text = "Trả";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnTheLoaiTools
            // 
            this.btnTheLoaiTools.Name = "btnTheLoaiTools";
            this.btnTheLoaiTools.Size = new System.Drawing.Size(124, 24);
            this.btnTheLoaiTools.Text = "Thể loại";
            this.btnTheLoaiTools.Click += new System.EventHandler(this.btnTheLoaiTools_Click);
            // 
            // PhieuMenu
            // 
            this.PhieuMenu.BackColor = System.Drawing.SystemColors.Control;
            this.PhieuMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PhieuMenu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhieuMenu.IsMainMenu = false;
            this.PhieuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMuon,
            this.btnTra,
            this.btnPhat});
            this.PhieuMenu.MenuItemHeight = 50;
            this.PhieuMenu.MenuItemTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PhieuMenu.Name = "SystemMenu";
            this.PhieuMenu.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.PhieuMenu.ShowImageMargin = false;
            this.PhieuMenu.Size = new System.Drawing.Size(94, 76);
            // 
            // btnMuon
            // 
            this.btnMuon.Name = "btnMuon";
            this.btnMuon.Size = new System.Drawing.Size(93, 24);
            this.btnMuon.Text = "Mượn";
            this.btnMuon.Click += new System.EventHandler(this.btnMuon_Click);
            // 
            // btnTra
            // 
            this.btnTra.Name = "btnTra";
            this.btnTra.Size = new System.Drawing.Size(93, 24);
            this.btnTra.Text = "Trả";
            this.btnTra.Click += new System.EventHandler(this.btnTra_Click);
            // 
            // btnPhat
            // 
            this.btnPhat.Name = "btnPhat";
            this.btnPhat.Size = new System.Drawing.Size(93, 24);
            this.btnPhat.Text = "Phạt";
            // 
            // frmManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 555);
            this.Controls.Add(this.pnlDesktop);
            this.Controls.Add(this.pnlTitleBar);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManagement";
            this.Load += new System.EventHandler(this.frmManagement_Load);
            this.SizeChanged += new System.EventHandler(this.frmManagement_SizeChanged);
            this.Resize += new System.EventHandler(this.frmManagement_Resize);
            this.pnlMenu.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.pnlTitleBar.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.SystemMenu.ResumeLayout(false);
            this.ManagerMenu.ResumeLayout(false);
            this.ToolsMenu.ResumeLayout(false);
            this.PhieuMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Panel pnlDesktop;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaxmize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSystems;
        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Button btnMenu;
        private RJCodeAdvance.RJControls.RJDropdownMenu SystemMenu;
        private System.Windows.Forms.ToolStripMenuItem loginMenu;
        private System.Windows.Forms.ToolStripMenuItem logoutMenu;
        private System.Windows.Forms.Button btnManager;
        private RJCodeAdvance.RJControls.RJDropdownMenu ManagerMenu;
        private System.Windows.Forms.ToolStripMenuItem btnBooks;
        private System.Windows.Forms.ToolStripMenuItem btnAuthors;
        private System.Windows.Forms.ToolStripMenuItem btnReaders;
        private System.Windows.Forms.ToolStripMenuItem btnStaffs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTools;
        private RJCodeAdvance.RJControls.RJDropdownMenu ToolsMenu;
        private System.Windows.Forms.ToolStripMenuItem btnBookTools;
        private System.Windows.Forms.ToolStripMenuItem btnAuthorTools;
        private System.Windows.Forms.ToolStripMenuItem btnReaderTools;
        private System.Windows.Forms.ToolStripMenuItem btnStaffTools;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelChucVu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button btnPhieu;
        private RJCodeAdvance.RJControls.RJDropdownMenu PhieuMenu;
        private System.Windows.Forms.ToolStripMenuItem btnMuon;
        private System.Windows.Forms.ToolStripMenuItem btnBorrowTools;
        private System.Windows.Forms.ToolStripMenuItem btnTra;
        private System.Windows.Forms.ToolStripMenuItem btnPhat;
        private System.Windows.Forms.ToolStripMenuItem btnGenres;
        private System.Windows.Forms.ToolStripMenuItem btnReturn;
        private System.Windows.Forms.ToolStripMenuItem btnTheLoaiTools;
    }
}