namespace SY.Client.Forms.User
{
    partial class ViewUserPermissionForm
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
            this.角色权限 = new System.Windows.Forms.Button();
            this.用户权限 = new System.Windows.Forms.Button();
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
            this.panel_bottom.Controls.Add(this.角色权限);
            this.panel_bottom.Controls.Add(this.用户权限);
            this.panel_bottom.Controls.Add(this.bt_sure);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 259);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(420, 39);
            this.panel_bottom.TabIndex = 1;
            // 
            // 角色权限
            // 
            this.角色权限.Location = new System.Drawing.Point(201, 8);
            this.角色权限.Name = "角色权限";
            this.角色权限.Size = new System.Drawing.Size(75, 23);
            this.角色权限.TabIndex = 4;
            this.角色权限.Text = "角色权限";
            this.角色权限.UseVisualStyleBackColor = true;
            this.角色权限.Click += new System.EventHandler(this.角色权限_Click);
            // 
            // 用户权限
            // 
            this.用户权限.Location = new System.Drawing.Point(106, 8);
            this.用户权限.Name = "用户权限";
            this.用户权限.Size = new System.Drawing.Size(75, 23);
            this.用户权限.TabIndex = 3;
            this.用户权限.Text = "用户权限";
            this.用户权限.UseVisualStyleBackColor = true;
            this.用户权限.Click += new System.EventHandler(this.用户权限_Click);
            // 
            // bt_sure
            // 
            this.bt_sure.Location = new System.Drawing.Point(335, 8);
            this.bt_sure.Name = "bt_sure";
            this.bt_sure.Size = new System.Drawing.Size(75, 23);
            this.bt_sure.TabIndex = 0;
            this.bt_sure.Text = "保存";
            this.bt_sure.UseVisualStyleBackColor = true;
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
            // ViewUserPermissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 298);
            this.Controls.Add(this.panel_center);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.panel_top);
            this.Name = "ViewUserPermissionForm";
            this.Text = "查看所有权限";
            this.panel_bottom.ResumeLayout(false);
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
        private System.Windows.Forms.Button 角色权限;
        private System.Windows.Forms.Button 用户权限;
    }
}