namespace SY.Client.Forms
{
    partial class CategoryManagerForm
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
            this.panel_center = new System.Windows.Forms.Panel();
            this.tv = new System.Windows.Forms.TreeView();
            this.panel_right = new System.Windows.Forms.Panel();
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.bt_flesh = new System.Windows.Forms.Button();
            this.bt_modify = new System.Windows.Forms.Button();
            this.btDeleteCategory = new System.Windows.Forms.Button();
            this.btAddCategory = new System.Windows.Forms.Button();
            this.panel_top = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.panel_center.SuspendLayout();
            this.panel_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.panel_center);
            this.panel.Controls.Add(this.panel_right);
            this.panel.Controls.Add(this.panel_left);
            this.panel.Controls.Add(this.panel_bottom);
            this.panel.Controls.Add(this.panel_top);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(292, 285);
            this.panel.TabIndex = 0;
            // 
            // panel_center
            // 
            this.panel_center.Controls.Add(this.tv);
            this.panel_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_center.Location = new System.Drawing.Point(10, 10);
            this.panel_center.Name = "panel_center";
            this.panel_center.Size = new System.Drawing.Size(272, 207);
            this.panel_center.TabIndex = 4;
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(272, 207);
            this.tv.TabIndex = 1;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // panel_right
            // 
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(282, 10);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(10, 207);
            this.panel_right.TabIndex = 3;
            // 
            // panel_left
            // 
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 10);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(10, 207);
            this.panel_left.TabIndex = 2;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.bt_flesh);
            this.panel_bottom.Controls.Add(this.bt_modify);
            this.panel_bottom.Controls.Add(this.btDeleteCategory);
            this.panel_bottom.Controls.Add(this.btAddCategory);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 217);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(292, 68);
            this.panel_bottom.TabIndex = 1;
            // 
            // bt_flesh
            // 
            this.bt_flesh.Location = new System.Drawing.Point(223, 21);
            this.bt_flesh.Name = "bt_flesh";
            this.bt_flesh.Size = new System.Drawing.Size(53, 25);
            this.bt_flesh.TabIndex = 4;
            this.bt_flesh.Text = "刷新";
            this.bt_flesh.UseVisualStyleBackColor = true;
            this.bt_flesh.Click += new System.EventHandler(this.bt_flesh_Click);
            // 
            // bt_modify
            // 
            this.bt_modify.Location = new System.Drawing.Point(85, 21);
            this.bt_modify.Name = "bt_modify";
            this.bt_modify.Size = new System.Drawing.Size(53, 25);
            this.bt_modify.TabIndex = 3;
            this.bt_modify.Text = "修改";
            this.bt_modify.UseVisualStyleBackColor = true;
            this.bt_modify.Click += new System.EventHandler(this.bt_modify_Click);
            // 
            // btDeleteCategory
            // 
            this.btDeleteCategory.Location = new System.Drawing.Point(154, 21);
            this.btDeleteCategory.Name = "btDeleteCategory";
            this.btDeleteCategory.Size = new System.Drawing.Size(53, 25);
            this.btDeleteCategory.TabIndex = 2;
            this.btDeleteCategory.Text = "删除";
            this.btDeleteCategory.UseVisualStyleBackColor = true;
            this.btDeleteCategory.Click += new System.EventHandler(this.btDeleteCategory_Click);
            // 
            // btAddCategory
            // 
            this.btAddCategory.Location = new System.Drawing.Point(16, 21);
            this.btAddCategory.Name = "btAddCategory";
            this.btAddCategory.Size = new System.Drawing.Size(53, 25);
            this.btAddCategory.TabIndex = 1;
            this.btAddCategory.Text = "添加";
            this.btAddCategory.UseVisualStyleBackColor = true;
            this.btAddCategory.Click += new System.EventHandler(this.btAddCategory_Click);
            // 
            // panel_top
            // 
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(292, 10);
            this.panel_top.TabIndex = 0;
            // 
            // CategoryManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 285);
            this.Controls.Add(this.panel);
            this.Name = "CategoryManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "分类管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CategoryManagerForm_FormClosing);
            this.panel.ResumeLayout(false);
            this.panel_center.ResumeLayout(false);
            this.panel_bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_center;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.Button btAddCategory;
        private System.Windows.Forms.Button btDeleteCategory;
        private System.Windows.Forms.Button bt_modify;
        private System.Windows.Forms.Button bt_flesh;
    }
}