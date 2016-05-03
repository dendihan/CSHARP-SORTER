namespace yprfj
{
    partial class Formmain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formmain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.业务操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActGetData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ActMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ActIn = new System.Windows.Forms.ToolStripMenuItem();
            this.数据查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ActQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ActEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.ActAlert = new System.Windows.Forms.ToolStripMenuItem();
            this.ActRole123 = new System.Windows.Forms.ToolStripMenuItem();
            this.ActRole = new System.Windows.Forms.ToolStripMenuItem();
            this.ActUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ActPermission = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ActProper = new System.Windows.Forms.ToolStripMenuItem();
            this.ActParam = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ActHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.业务操作ToolStripMenuItem,
            this.数据查询ToolStripMenuItem,
            this.ActRole123,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1082, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 业务操作ToolStripMenuItem
            // 
            this.业务操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActGetData,
            this.toolStripSeparator1,
            this.ActMonitor,
            this.toolStripSeparator2,
            this.ActIn});
            this.业务操作ToolStripMenuItem.Name = "业务操作ToolStripMenuItem";
            this.业务操作ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.业务操作ToolStripMenuItem.Text = "业务操作";
            // 
            // ActGetData
            // 
            this.ActGetData.Name = "ActGetData";
            this.ActGetData.Size = new System.Drawing.Size(152, 24);
            this.ActGetData.Text = "数据获取";
            this.ActGetData.Click += new System.EventHandler(this.ActGetData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // ActMonitor
            // 
            this.ActMonitor.Name = "ActMonitor";
            this.ActMonitor.Size = new System.Drawing.Size(152, 24);
            this.ActMonitor.Text = "分拣监控";
            this.ActMonitor.Click += new System.EventHandler(this.ActMonitor_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // ActIn
            // 
            this.ActIn.Name = "ActIn";
            this.ActIn.Size = new System.Drawing.Size(152, 24);
            this.ActIn.Text = "入口管理";
            this.ActIn.Click += new System.EventHandler(this.ActIn_Click);
            // 
            // 数据查询ToolStripMenuItem
            // 
            this.数据查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActOut,
            this.toolStripSeparator3,
            this.ActQuery,
            this.toolStripSeparator4,
            this.ActEvent,
            this.ActAlert});
            this.数据查询ToolStripMenuItem.Name = "数据查询ToolStripMenuItem";
            this.数据查询ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.数据查询ToolStripMenuItem.Text = "数据查询";
            this.数据查询ToolStripMenuItem.Click += new System.EventHandler(this.数据查询ToolStripMenuItem_Click);
            // 
            // ActOut
            // 
            this.ActOut.Name = "ActOut";
            this.ActOut.Size = new System.Drawing.Size(138, 24);
            this.ActOut.Text = "出口管理";
            this.ActOut.Click += new System.EventHandler(this.ActOut_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(135, 6);
            // 
            // ActQuery
            // 
            this.ActQuery.Name = "ActQuery";
            this.ActQuery.Size = new System.Drawing.Size(138, 24);
            this.ActQuery.Text = "数据统计";
            this.ActQuery.Click += new System.EventHandler(this.数据统计ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(135, 6);
            // 
            // ActEvent
            // 
            this.ActEvent.Name = "ActEvent";
            this.ActEvent.Size = new System.Drawing.Size(138, 24);
            this.ActEvent.Text = "事件日志";
            this.ActEvent.Click += new System.EventHandler(this.ActEvent_Click);
            // 
            // ActAlert
            // 
            this.ActAlert.Name = "ActAlert";
            this.ActAlert.Size = new System.Drawing.Size(138, 24);
            this.ActAlert.Text = "报警信息";
            this.ActAlert.Click += new System.EventHandler(this.ActAlert_Click);
            // 
            // ActRole123
            // 
            this.ActRole123.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActRole,
            this.ActUser,
            this.ActPermission,
            this.toolStripSeparator5,
            this.ActProper,
            this.ActParam,
            this.toolStripSeparator6,
            this.ActHelp});
            this.ActRole123.Name = "ActRole123";
            this.ActRole123.Size = new System.Drawing.Size(81, 24);
            this.ActRole123.Text = "后台管理";
            // 
            // ActRole
            // 
            this.ActRole.Name = "ActRole";
            this.ActRole.Size = new System.Drawing.Size(138, 24);
            this.ActRole.Text = "角色管理";
            this.ActRole.Click += new System.EventHandler(this.ActRole_Click);
            // 
            // ActUser
            // 
            this.ActUser.Name = "ActUser";
            this.ActUser.Size = new System.Drawing.Size(138, 24);
            this.ActUser.Text = "用户管理";
            this.ActUser.Click += new System.EventHandler(this.ActUser_Click);
            // 
            // ActPermission
            // 
            this.ActPermission.Name = "ActPermission";
            this.ActPermission.Size = new System.Drawing.Size(138, 24);
            this.ActPermission.Text = "权限管理";
            this.ActPermission.Click += new System.EventHandler(this.ActPermission_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(135, 6);
            // 
            // ActProper
            // 
            this.ActProper.Name = "ActProper";
            this.ActProper.Size = new System.Drawing.Size(138, 24);
            this.ActProper.Text = "出口特征";
            this.ActProper.Click += new System.EventHandler(this.ActProper_Click);
            // 
            // ActParam
            // 
            this.ActParam.Name = "ActParam";
            this.ActParam.Size = new System.Drawing.Size(138, 24);
            this.ActParam.Text = "参数设置";
            this.ActParam.Click += new System.EventHandler(this.ActParam_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(135, 6);
            // 
            // ActHelp
            // 
            this.ActHelp.Name = "ActHelp";
            this.ActHelp.Size = new System.Drawing.Size(138, 24);
            this.ActHelp.Text = "维护指引";
            this.ActHelp.Click += new System.EventHandler(this.维护指引ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "0.bmp");
            this.imageList1.Images.SetKeyName(1, "1.bmp");
            this.imageList1.Images.SetKeyName(2, "2.bmp");
            this.imageList1.Images.SetKeyName(3, "3.bmp");
            this.imageList1.Images.SetKeyName(4, "4.bmp");
            this.imageList1.Images.SetKeyName(5, "5.bmp");
            this.imageList1.Images.SetKeyName(6, "6.bmp");
            this.imageList1.Images.SetKeyName(7, "7.bmp");
            this.imageList1.Images.SetKeyName(8, "8.bmp");
            this.imageList1.Images.SetKeyName(9, "9.bmp");
            this.imageList1.Images.SetKeyName(10, "10.bmp");
            this.imageList1.Images.SetKeyName(11, "11.bmp");
            this.imageList1.Images.SetKeyName(12, "12.bmp");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel8});
            this.statusStrip1.Location = new System.Drawing.Point(0, 726);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1082, 29);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 24);
            this.toolStripStatusLabel1.Text = "IP地址";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(171, 24);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(69, 24);
            this.toolStripStatusLabel3.Text = "登入人员";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(171, 24);
            this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(69, 24);
            this.toolStripStatusLabel5.Text = "登入时间";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(171, 24);
            this.toolStripStatusLabel6.Text = "toolStripStatusLabel6";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(54, 24);
            this.toolStripStatusLabel7.Text = "版本号";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(62, 24);
            this.toolStripStatusLabel8.Text = "Rev3.0";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(74, 698);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(71, 88);
            this.toolStripButton1.Text = "数据获取";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(71, 88);
            this.toolStripButton2.Text = "分拣监控";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(71, 88);
            this.toolStripButton3.Text = "入口管理";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(71, 88);
            this.toolStripButton4.Text = "出口管理";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(71, 88);
            this.toolStripButton5.Text = "数据统计";
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // Formmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::yprfj.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1082, 755);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Formmain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "宁波亿普瑞物流信息管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Frommain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 业务操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ActGetData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ActMonitor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ActIn;
        private System.Windows.Forms.ToolStripMenuItem 数据查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ActOut;
        private System.Windows.Forms.ToolStripMenuItem ActQuery;
        private System.Windows.Forms.ToolStripMenuItem ActEvent;
        private System.Windows.Forms.ToolStripMenuItem ActAlert;
        private System.Windows.Forms.ToolStripMenuItem ActRole123;
        private System.Windows.Forms.ToolStripMenuItem ActRole;
        private System.Windows.Forms.ToolStripMenuItem ActUser;
        private System.Windows.Forms.ToolStripMenuItem ActPermission;
        private System.Windows.Forms.ToolStripMenuItem ActProper;
        private System.Windows.Forms.ToolStripMenuItem ActParam;
        private System.Windows.Forms.ToolStripMenuItem ActHelp;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
          }
}

