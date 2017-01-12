namespace SY.Client.Forms
{
    partial class QueryCategoryForm
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
            this.panel = new System.Windows.Forms.Panel();
            this.panel_middle = new System.Windows.Forms.Panel();
            this.panel_middle_bottom = new System.Windows.Forms.Panel();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.panel_middle_bottom_up = new System.Windows.Forms.Panel();
            this.btNextPage = new System.Windows.Forms.Button();
            this.btLastPage = new System.Windows.Forms.Button();
            this.tbPageSize = new System.Windows.Forms.TextBox();
            this.bt_query = new System.Windows.Forms.Button();
            this.panel_middle_top = new System.Windows.Forms.Panel();
            this.tlp_query = new System.Windows.Forms.TableLayoutPanel();
            this.panel_right = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.l_status = new System.Windows.Forms.Label();
            this.panel_top = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.tsmi_file = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_set = new System.Windows.Forms.ToolStripMenuItem();
            this.结果排序 = new System.Windows.Forms.ToolStripMenuItem();
            this.查询条件排序 = new System.Windows.Forms.ToolStripMenuItem();
            this.插入排序 = new System.Windows.Forms.ToolStripMenuItem();
            this.字段录入提示 = new System.Windows.Forms.ToolStripMenuItem();
            this.附表详细信息排序 = new System.Windows.Forms.ToolStripMenuItem();
            this.附表查询条件排序 = new System.Windows.Forms.ToolStripMenuItem();
            this.附表查询结果排序 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_handle = new System.Windows.Forms.ToolStripMenuItem();
            this.批量导入 = new System.Windows.Forms.ToolStripMenuItem();
            this.录入数据 = new System.Windows.Forms.ToolStripMenuItem();
            this.输出模板 = new System.Windows.Forms.ToolStripMenuItem();
            this.修改分类信息 = new System.Windows.Forms.ToolStripMenuItem();
            this.修改字段属性 = new System.Windows.Forms.ToolStripMenuItem();
            this.添加字段 = new System.Windows.Forms.ToolStripMenuItem();
            this.附表查询导入 = new System.Windows.Forms.ToolStripMenuItem();
            this.附表批量导入 = new System.Windows.Forms.ToolStripMenuItem();
            this.附表输出模板 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_tool = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_window = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_help = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_admin = new System.Windows.Forms.ToolStripMenuItem();
            this.分类管理 = new System.Windows.Forms.ToolStripMenuItem();
            this.角色管理 = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel_left_left = new System.Windows.Forms.Panel();
            this.tv = new System.Windows.Forms.TreeView();
            this.panel_left_left_top = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_left_right = new System.Windows.Forms.Panel();
            this.btLeftHiden = new System.Windows.Forms.Button();
            this.importPath = new System.Windows.Forms.OpenFileDialog();
            this.exportTemplatePath = new System.Windows.Forms.FolderBrowserDialog();
            this.panel.SuspendLayout();
            this.panel_middle.SuspendLayout();
            this.panel_middle_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.panel_middle_bottom_up.SuspendLayout();
            this.panel_middle_top.SuspendLayout();
            this.panel_bottom.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.menu.SuspendLayout();
            this.panel_left.SuspendLayout();
            this.panel_left_left.SuspendLayout();
            this.panel_left_left_top.SuspendLayout();
            this.panel_left_right.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.panel_middle);
            this.panel.Controls.Add(this.panel_right);
            this.panel.Controls.Add(this.panel_bottom);
            this.panel.Controls.Add(this.panel_top);
            this.panel.Controls.Add(this.panel_left);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1924, 971);
            this.panel.TabIndex = 0;
            // 
            // panel_middle
            // 
            this.panel_middle.Controls.Add(this.panel_middle_bottom);
            this.panel_middle.Controls.Add(this.panel_middle_top);
            this.panel_middle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_middle.Location = new System.Drawing.Point(217, 36);
            this.panel_middle.Name = "panel_middle";
            this.panel_middle.Size = new System.Drawing.Size(1651, 906);
            this.panel_middle.TabIndex = 4;
            // 
            // panel_middle_bottom
            // 
            this.panel_middle_bottom.Controls.Add(this.dgv_result);
            this.panel_middle_bottom.Controls.Add(this.panel_middle_bottom_up);
            this.panel_middle_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_middle_bottom.Location = new System.Drawing.Point(0, 349);
            this.panel_middle_bottom.Name = "panel_middle_bottom";
            this.panel_middle_bottom.Size = new System.Drawing.Size(1651, 557);
            this.panel_middle_bottom.TabIndex = 1;
            // 
            // dgv_result
            // 
            this.dgv_result.AllowUserToAddRows = false;
            this.dgv_result.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_result.Location = new System.Drawing.Point(0, 42);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.ReadOnly = true;
            this.dgv_result.RowTemplate.Height = 23;
            this.dgv_result.Size = new System.Drawing.Size(1651, 515);
            this.dgv_result.TabIndex = 3;
            this.dgv_result.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_result_CellDoubleClick);
            // 
            // panel_middle_bottom_up
            // 
            this.panel_middle_bottom_up.Controls.Add(this.btNextPage);
            this.panel_middle_bottom_up.Controls.Add(this.btLastPage);
            this.panel_middle_bottom_up.Controls.Add(this.tbPageSize);
            this.panel_middle_bottom_up.Controls.Add(this.bt_query);
            this.panel_middle_bottom_up.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_middle_bottom_up.Location = new System.Drawing.Point(0, 0);
            this.panel_middle_bottom_up.Name = "panel_middle_bottom_up";
            this.panel_middle_bottom_up.Size = new System.Drawing.Size(1651, 42);
            this.panel_middle_bottom_up.TabIndex = 2;
            // 
            // btNextPage
            // 
            this.btNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNextPage.Location = new System.Drawing.Point(1535, 7);
            this.btNextPage.Name = "btNextPage";
            this.btNextPage.Size = new System.Drawing.Size(41, 27);
            this.btNextPage.TabIndex = 24;
            this.btNextPage.Text = ">>";
            this.btNextPage.UseVisualStyleBackColor = true;
            this.btNextPage.Click += new System.EventHandler(this.btNextPage_Click);
            // 
            // btLastPage
            // 
            this.btLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btLastPage.Location = new System.Drawing.Point(1488, 7);
            this.btLastPage.Name = "btLastPage";
            this.btLastPage.Size = new System.Drawing.Size(41, 27);
            this.btLastPage.TabIndex = 23;
            this.btLastPage.Text = "<<";
            this.btLastPage.UseVisualStyleBackColor = true;
            this.btLastPage.Click += new System.EventHandler(this.btLastPage_Click);
            // 
            // tbPageSize
            // 
            this.tbPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPageSize.Location = new System.Drawing.Point(1583, 7);
            this.tbPageSize.Name = "tbPageSize";
            this.tbPageSize.Size = new System.Drawing.Size(60, 23);
            this.tbPageSize.TabIndex = 21;
            this.tbPageSize.Text = "5";
            this.tbPageSize.TextChanged += new System.EventHandler(this.tbPageSize_TextChanged);
            // 
            // bt_query
            // 
            this.bt_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_query.Location = new System.Drawing.Point(1387, 7);
            this.bt_query.Name = "bt_query";
            this.bt_query.Size = new System.Drawing.Size(87, 27);
            this.bt_query.TabIndex = 0;
            this.bt_query.Text = "查询";
            this.bt_query.UseVisualStyleBackColor = true;
            this.bt_query.Click += new System.EventHandler(this.bt_query_Click);
            // 
            // panel_middle_top
            // 
            this.panel_middle_top.AutoScroll = true;
            this.panel_middle_top.Controls.Add(this.tlp_query);
            this.panel_middle_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_middle_top.Location = new System.Drawing.Point(0, 0);
            this.panel_middle_top.Name = "panel_middle_top";
            this.panel_middle_top.Size = new System.Drawing.Size(1651, 349);
            this.panel_middle_top.TabIndex = 0;
            // 
            // tlp_query
            // 
            this.tlp_query.ColumnCount = 2;
            this.tlp_query.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_query.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_query.Location = new System.Drawing.Point(17, 7);
            this.tlp_query.Name = "tlp_query";
            this.tlp_query.RowCount = 2;
            this.tlp_query.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_query.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_query.Size = new System.Drawing.Size(233, 117);
            this.tlp_query.TabIndex = 0;
            // 
            // panel_right
            // 
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(1868, 36);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(56, 906);
            this.panel_right.TabIndex = 3;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.l_status);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(217, 942);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(1707, 29);
            this.panel_bottom.TabIndex = 2;
            // 
            // l_status
            // 
            this.l_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.l_status.AutoSize = true;
            this.l_status.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_status.Location = new System.Drawing.Point(1441, 7);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(41, 12);
            this.l_status.TabIndex = 0;
            this.l_status.Text = "状态：";
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.menu);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(217, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(1707, 36);
            this.panel_top.TabIndex = 1;
            // 
            // menu
            // 
            this.menu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_file,
            this.tsmi_edit,
            this.tsmi_set,
            this.tsmi_handle,
            this.tsmi_tool,
            this.tsmi_window,
            this.tsmi_help,
            this.tsmi_admin});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1707, 29);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // tsmi_file
            // 
            this.tsmi_file.Name = "tsmi_file";
            this.tsmi_file.Size = new System.Drawing.Size(44, 21);
            this.tsmi_file.Text = "文件";
            // 
            // tsmi_edit
            // 
            this.tsmi_edit.Name = "tsmi_edit";
            this.tsmi_edit.Size = new System.Drawing.Size(44, 21);
            this.tsmi_edit.Text = "编辑";
            // 
            // tsmi_set
            // 
            this.tsmi_set.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.结果排序,
            this.查询条件排序,
            this.插入排序,
            this.字段录入提示,
            this.附表详细信息排序,
            this.附表查询条件排序,
            this.附表查询结果排序});
            this.tsmi_set.Name = "tsmi_set";
            this.tsmi_set.Size = new System.Drawing.Size(44, 21);
            this.tsmi_set.Text = "设置";
            // 
            // 结果排序
            // 
            this.结果排序.Name = "结果排序";
            this.结果排序.Size = new System.Drawing.Size(172, 22);
            this.结果排序.Text = "结果排序";
            this.结果排序.Click += new System.EventHandler(this.结果排序_Click);
            // 
            // 查询条件排序
            // 
            this.查询条件排序.Name = "查询条件排序";
            this.查询条件排序.Size = new System.Drawing.Size(172, 22);
            this.查询条件排序.Text = "查询条件排序";
            this.查询条件排序.Click += new System.EventHandler(this.查询条件排序_Click);
            // 
            // 插入排序
            // 
            this.插入排序.Name = "插入排序";
            this.插入排序.Size = new System.Drawing.Size(172, 22);
            this.插入排序.Text = "插入排序";
            this.插入排序.Click += new System.EventHandler(this.插入排序_Click);
            // 
            // 字段录入提示
            // 
            this.字段录入提示.Name = "字段录入提示";
            this.字段录入提示.Size = new System.Drawing.Size(172, 22);
            this.字段录入提示.Text = "字段录入提示";
            this.字段录入提示.Click += new System.EventHandler(this.字段录入提示ToolStripMenuItem_Click);
            // 
            // 附表详细信息排序
            // 
            this.附表详细信息排序.Name = "附表详细信息排序";
            this.附表详细信息排序.Size = new System.Drawing.Size(172, 22);
            this.附表详细信息排序.Text = "附表详细信息排序";
            this.附表详细信息排序.Click += new System.EventHandler(this.详细信息显示排序ToolStripMenuItem_Click);
            // 
            // 附表查询条件排序
            // 
            this.附表查询条件排序.Name = "附表查询条件排序";
            this.附表查询条件排序.Size = new System.Drawing.Size(172, 22);
            this.附表查询条件排序.Text = "附表查询条件排序";
            this.附表查询条件排序.Click += new System.EventHandler(this.附表查询条件排序ToolStripMenuItem_Click);
            // 
            // 附表查询结果排序
            // 
            this.附表查询结果排序.Name = "附表查询结果排序";
            this.附表查询结果排序.Size = new System.Drawing.Size(172, 22);
            this.附表查询结果排序.Text = "附表查询结果排序";
            this.附表查询结果排序.Click += new System.EventHandler(this.附表查询结果排序ToolStripMenuItem_Click);
            // 
            // tsmi_handle
            // 
            this.tsmi_handle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.批量导入,
            this.录入数据,
            this.输出模板,
            this.修改分类信息,
            this.修改字段属性,
            this.添加字段,
            this.附表查询导入,
            this.附表批量导入,
            this.附表输出模板});
            this.tsmi_handle.Name = "tsmi_handle";
            this.tsmi_handle.Size = new System.Drawing.Size(44, 21);
            this.tsmi_handle.Text = "操作";
            // 
            // 批量导入
            // 
            this.批量导入.Name = "批量导入";
            this.批量导入.Size = new System.Drawing.Size(148, 22);
            this.批量导入.Text = "批量导入";
            this.批量导入.Click += new System.EventHandler(this.导入数据_Click);
            // 
            // 录入数据
            // 
            this.录入数据.Name = "录入数据";
            this.录入数据.Size = new System.Drawing.Size(148, 22);
            this.录入数据.Text = "录入数据";
            this.录入数据.Click += new System.EventHandler(this.插入数据_Click);
            // 
            // 输出模板
            // 
            this.输出模板.Name = "输出模板";
            this.输出模板.Size = new System.Drawing.Size(148, 22);
            this.输出模板.Text = "输出模板";
            this.输出模板.Click += new System.EventHandler(this.输出模板_Click);
            // 
            // 修改分类信息
            // 
            this.修改分类信息.Name = "修改分类信息";
            this.修改分类信息.Size = new System.Drawing.Size(148, 22);
            this.修改分类信息.Text = "修改分类信息";
            this.修改分类信息.Click += new System.EventHandler(this.修改分类信息ToolStripMenuItem_Click);
            // 
            // 修改字段属性
            // 
            this.修改字段属性.Name = "修改字段属性";
            this.修改字段属性.Size = new System.Drawing.Size(148, 22);
            this.修改字段属性.Text = "修改字段属性";
            this.修改字段属性.Click += new System.EventHandler(this.修改字段属性ToolStripMenuItem_Click);
            // 
            // 添加字段
            // 
            this.添加字段.Name = "添加字段";
            this.添加字段.Size = new System.Drawing.Size(148, 22);
            this.添加字段.Text = "添加字段";
            this.添加字段.Click += new System.EventHandler(this.添加字段ToolStripMenuItem_Click);
            // 
            // 附表查询导入
            // 
            this.附表查询导入.Name = "附表查询导入";
            this.附表查询导入.Size = new System.Drawing.Size(148, 22);
            this.附表查询导入.Text = "附表查询导入";
            this.附表查询导入.Click += new System.EventHandler(this.附表导入ToolStripMenuItem_Click);
            // 
            // 附表批量导入
            // 
            this.附表批量导入.Name = "附表批量导入";
            this.附表批量导入.Size = new System.Drawing.Size(148, 22);
            this.附表批量导入.Text = "附表批量导入";
            this.附表批量导入.Click += new System.EventHandler(this.附表批量导入ToolStripMenuItem_Click);
            // 
            // 附表输出模板
            // 
            this.附表输出模板.Name = "附表输出模板";
            this.附表输出模板.Size = new System.Drawing.Size(148, 22);
            this.附表输出模板.Text = "附表输出模板";
            this.附表输出模板.Click += new System.EventHandler(this.附表输出模板ToolStripMenuItem_Click);
            // 
            // tsmi_tool
            // 
            this.tsmi_tool.Name = "tsmi_tool";
            this.tsmi_tool.Size = new System.Drawing.Size(44, 21);
            this.tsmi_tool.Text = "工具";
            // 
            // tsmi_window
            // 
            this.tsmi_window.Name = "tsmi_window";
            this.tsmi_window.Size = new System.Drawing.Size(44, 21);
            this.tsmi_window.Text = "窗口";
            // 
            // tsmi_help
            // 
            this.tsmi_help.Name = "tsmi_help";
            this.tsmi_help.Size = new System.Drawing.Size(44, 21);
            this.tsmi_help.Text = "帮助";
            // 
            // tsmi_admin
            // 
            this.tsmi_admin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.分类管理,
            this.角色管理,
            this.用户管理});
            this.tsmi_admin.Name = "tsmi_admin";
            this.tsmi_admin.Size = new System.Drawing.Size(68, 21);
            this.tsmi_admin.Text = "系统管理";
            // 
            // 分类管理
            // 
            this.分类管理.Name = "分类管理";
            this.分类管理.Size = new System.Drawing.Size(124, 22);
            this.分类管理.Text = "分类管理";
            this.分类管理.Click += new System.EventHandler(this.分类管理ToolStripMenuItem_Click);
            // 
            // 角色管理
            // 
            this.角色管理.Name = "角色管理";
            this.角色管理.Size = new System.Drawing.Size(124, 22);
            this.角色管理.Text = "角色管理";
            this.角色管理.Click += new System.EventHandler(this.角色管理_Click);
            // 
            // 用户管理
            // 
            this.用户管理.Name = "用户管理";
            this.用户管理.Size = new System.Drawing.Size(124, 22);
            this.用户管理.Text = "用户管理";
            this.用户管理.Click += new System.EventHandler(this.用户管理ToolStripMenuItem_Click);
            // 
            // panel_left
            // 
            this.panel_left.Controls.Add(this.panel_left_left);
            this.panel_left.Controls.Add(this.panel_left_right);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(217, 971);
            this.panel_left.TabIndex = 0;
            // 
            // panel_left_left
            // 
            this.panel_left_left.Controls.Add(this.tv);
            this.panel_left_left.Controls.Add(this.panel_left_left_top);
            this.panel_left_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_left_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left_left.Name = "panel_left_left";
            this.panel_left_left.Size = new System.Drawing.Size(200, 971);
            this.panel_left_left.TabIndex = 2;
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv.Location = new System.Drawing.Point(0, 36);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(200, 935);
            this.tv.TabIndex = 0;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // panel_left_left_top
            // 
            this.panel_left_left_top.Controls.Add(this.label1);
            this.panel_left_left_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_left_left_top.Location = new System.Drawing.Point(0, 0);
            this.panel_left_left_top.Name = "panel_left_left_top";
            this.panel_left_left_top.Size = new System.Drawing.Size(200, 36);
            this.panel_left_left_top.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "分类";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_left_right
            // 
            this.panel_left_right.Controls.Add(this.btLeftHiden);
            this.panel_left_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_left_right.Location = new System.Drawing.Point(200, 0);
            this.panel_left_right.Name = "panel_left_right";
            this.panel_left_right.Size = new System.Drawing.Size(17, 971);
            this.panel_left_right.TabIndex = 1;
            // 
            // btLeftHiden
            // 
            this.btLeftHiden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btLeftHiden.Location = new System.Drawing.Point(0, 0);
            this.btLeftHiden.Name = "btLeftHiden";
            this.btLeftHiden.Size = new System.Drawing.Size(17, 971);
            this.btLeftHiden.TabIndex = 0;
            this.btLeftHiden.Text = "<";
            this.btLeftHiden.UseVisualStyleBackColor = true;
            this.btLeftHiden.Click += new System.EventHandler(this.btLeftHiden_Click);
            // 
            // importPath
            // 
            this.importPath.FileName = "openFileDialog1";
            // 
            // QueryCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 971);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menu;
            this.Name = "QueryCategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QueryCategoryForm_FormClosing);
            this.Load += new System.EventHandler(this.QueryCategoryForm_Load);
            this.panel.ResumeLayout(false);
            this.panel_middle.ResumeLayout(false);
            this.panel_middle_bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.panel_middle_bottom_up.ResumeLayout(false);
            this.panel_middle_bottom_up.PerformLayout();
            this.panel_middle_top.ResumeLayout(false);
            this.panel_bottom.ResumeLayout(false);
            this.panel_bottom.PerformLayout();
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel_left.ResumeLayout(false);
            this.panel_left_left.ResumeLayout(false);
            this.panel_left_left_top.ResumeLayout(false);
            this.panel_left_right.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_middle;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_middle_bottom;
        private System.Windows.Forms.Panel panel_middle_top;
        private System.Windows.Forms.TableLayoutPanel tlp_query;
        private System.Windows.Forms.Button bt_query;
        private System.Windows.Forms.Panel panel_middle_bottom_up;
        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.TextBox tbPageSize;
        private System.Windows.Forms.Button btNextPage;
        private System.Windows.Forms.Button btLastPage;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit;
        private System.Windows.Forms.ToolStripMenuItem tsmi_set;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tool;
        private System.Windows.Forms.ToolStripMenuItem tsmi_window;
        private System.Windows.Forms.ToolStripMenuItem tsmi_help;
        private System.Windows.Forms.Panel panel_left_right;
        private System.Windows.Forms.Button btLeftHiden;
        private System.Windows.Forms.Panel panel_left_left;
        private System.Windows.Forms.OpenFileDialog importPath;
        private System.Windows.Forms.FolderBrowserDialog exportTemplatePath;
        private System.Windows.Forms.ToolStripMenuItem tsmi_admin;
        private System.Windows.Forms.ToolStripMenuItem 角色管理;
        private System.Windows.Forms.ToolStripMenuItem 结果排序;
        private System.Windows.Forms.ToolStripMenuItem 查询条件排序;
        private System.Windows.Forms.ToolStripMenuItem tsmi_handle;
        private System.Windows.Forms.ToolStripMenuItem 批量导入;
        private System.Windows.Forms.ToolStripMenuItem 录入数据;
        private System.Windows.Forms.ToolStripMenuItem 输出模板;
        private System.Windows.Forms.ToolStripMenuItem 插入排序;
        private System.Windows.Forms.ToolStripMenuItem 修改分类信息;
        private System.Windows.Forms.ToolStripMenuItem 修改字段属性;
        private System.Windows.Forms.ToolStripMenuItem 添加字段;
        private System.Windows.Forms.ToolStripMenuItem 分类管理;
        private System.Windows.Forms.ToolStripMenuItem 用户管理;
        private System.Windows.Forms.ToolStripMenuItem 字段录入提示;
        private System.Windows.Forms.Panel panel_left_left_top;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_status;
        private System.Windows.Forms.ToolStripMenuItem 附表详细信息排序;
        private System.Windows.Forms.ToolStripMenuItem 附表查询条件排序;
        private System.Windows.Forms.ToolStripMenuItem 附表查询导入;
        private System.Windows.Forms.ToolStripMenuItem 附表查询结果排序;
        private System.Windows.Forms.ToolStripMenuItem 附表批量导入;
        private System.Windows.Forms.ToolStripMenuItem 附表输出模板;
    }
}