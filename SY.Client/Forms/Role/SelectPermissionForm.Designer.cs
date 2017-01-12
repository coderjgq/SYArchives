namespace SY.Client.Forms.User
{
    partial class SelectPermissionForm
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
            this.panel_top = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.bt_exit = new System.Windows.Forms.Button();
            this.cb_selectAll = new System.Windows.Forms.CheckBox();
            this.bt_sure = new System.Windows.Forms.Button();
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel_right = new System.Windows.Forms.Panel();
            this.panel_center = new System.Windows.Forms.Panel();
            this.dgv_permission = new System.Windows.Forms.DataGridView();
            this.panel_bottom.SuspendLayout();
            this.panel_center.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_permission)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(420, 10);
            this.panel_top.TabIndex = 0;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.bt_exit);
            this.panel_bottom.Controls.Add(this.cb_selectAll);
            this.panel_bottom.Controls.Add(this.bt_sure);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 259);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(420, 39);
            this.panel_bottom.TabIndex = 1;
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(232, 8);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 2;
            this.bt_exit.Text = "退出";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // cb_selectAll
            // 
            this.cb_selectAll.AutoSize = true;
            this.cb_selectAll.Location = new System.Drawing.Point(23, 11);
            this.cb_selectAll.Name = "cb_selectAll";
            this.cb_selectAll.Size = new System.Drawing.Size(48, 16);
            this.cb_selectAll.TabIndex = 1;
            this.cb_selectAll.Text = "全选";
            this.cb_selectAll.UseVisualStyleBackColor = true;
            this.cb_selectAll.CheckedChanged += new System.EventHandler(this.cb_selectAll_CheckedChanged);
            // 
            // bt_sure
            // 
            this.bt_sure.Location = new System.Drawing.Point(335, 8);
            this.bt_sure.Name = "bt_sure";
            this.bt_sure.Size = new System.Drawing.Size(75, 23);
            this.bt_sure.TabIndex = 0;
            this.bt_sure.Text = "保存";
            this.bt_sure.UseVisualStyleBackColor = true;
            this.bt_sure.Click += new System.EventHandler(this.bt_sure_Click);
            // 
            // panel_left
            // 
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 10);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(10, 249);
            this.panel_left.TabIndex = 2;
            // 
            // panel_right
            // 
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(410, 10);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(10, 249);
            this.panel_right.TabIndex = 3;
            // 
            // panel_center
            // 
            this.panel_center.Controls.Add(this.dgv_permission);
            this.panel_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_center.Location = new System.Drawing.Point(10, 10);
            this.panel_center.Name = "panel_center";
            this.panel_center.Size = new System.Drawing.Size(400, 249);
            this.panel_center.TabIndex = 4;
            // 
            // dgv_permission
            // 
            this.dgv_permission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_permission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_permission.Location = new System.Drawing.Point(0, 0);
            this.dgv_permission.Name = "dgv_permission";
            this.dgv_permission.RowHeadersVisible = false;
            this.dgv_permission.RowTemplate.Height = 23;
            this.dgv_permission.Size = new System.Drawing.Size(400, 249);
            this.dgv_permission.TabIndex = 0;
            // 
            // SelectPermissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 298);
            this.Controls.Add(this.panel_center);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.panel_top);
            this.Name = "SelectPermissionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择模块";
            this.panel_bottom.ResumeLayout(false);
            this.panel_bottom.PerformLayout();
            this.panel_center.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_permission)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Panel panel_center;
        private System.Windows.Forms.Button bt_sure;
        private System.Windows.Forms.DataGridView dgv_permission;
        private System.Windows.Forms.CheckBox cb_selectAll;
        private System.Windows.Forms.Button bt_exit;
    }
}