namespace SY.Client.Forms.User
{
    partial class UserManagerForm
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
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel_right = new System.Windows.Forms.Panel();
            this.panel_center = new System.Windows.Forms.Panel();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.panel_center_bottom = new System.Windows.Forms.Panel();
            this.查看所有权限 = new System.Windows.Forms.Button();
            this.bt_allocateRight = new System.Windows.Forms.Button();
            this.分配角色 = new System.Windows.Forms.Button();
            this.修改 = new System.Windows.Forms.Button();
            this.删除用户 = new System.Windows.Forms.Button();
            this.添加用户 = new System.Windows.Forms.Button();
            this.panel_center.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.panel_center_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(641, 10);
            this.panel_top.TabIndex = 0;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 409);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(641, 10);
            this.panel_bottom.TabIndex = 2;
            // 
            // panel_left
            // 
            this.panel_left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 10);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(10, 399);
            this.panel_left.TabIndex = 3;
            // 
            // panel_right
            // 
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(631, 10);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(10, 399);
            this.panel_right.TabIndex = 4;
            // 
            // panel_center
            // 
            this.panel_center.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_center.Controls.Add(this.dgv_result);
            this.panel_center.Controls.Add(this.panel_center_bottom);
            this.panel_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_center.Location = new System.Drawing.Point(10, 10);
            this.panel_center.Name = "panel_center";
            this.panel_center.Size = new System.Drawing.Size(621, 399);
            this.panel_center.TabIndex = 5;
            // 
            // dgv_result
            // 
            this.dgv_result.AllowUserToAddRows = false;
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_result.Location = new System.Drawing.Point(0, 0);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.RowTemplate.Height = 23;
            this.dgv_result.Size = new System.Drawing.Size(619, 353);
            this.dgv_result.TabIndex = 6;
            // 
            // panel_center_bottom
            // 
            this.panel_center_bottom.Controls.Add(this.查看所有权限);
            this.panel_center_bottom.Controls.Add(this.bt_allocateRight);
            this.panel_center_bottom.Controls.Add(this.分配角色);
            this.panel_center_bottom.Controls.Add(this.修改);
            this.panel_center_bottom.Controls.Add(this.删除用户);
            this.panel_center_bottom.Controls.Add(this.添加用户);
            this.panel_center_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_center_bottom.Location = new System.Drawing.Point(0, 353);
            this.panel_center_bottom.Name = "panel_center_bottom";
            this.panel_center_bottom.Size = new System.Drawing.Size(619, 44);
            this.panel_center_bottom.TabIndex = 5;
            // 
            // 查看所有权限
            // 
            this.查看所有权限.Location = new System.Drawing.Point(478, 11);
            this.查看所有权限.Name = "查看所有权限";
            this.查看所有权限.Size = new System.Drawing.Size(89, 23);
            this.查看所有权限.TabIndex = 5;
            this.查看所有权限.Text = "查看所有权限";
            this.查看所有权限.UseVisualStyleBackColor = true;
            this.查看所有权限.Click += new System.EventHandler(this.查看所有权限_Click);
            // 
            // bt_allocateRight
            // 
            this.bt_allocateRight.Location = new System.Drawing.Point(372, 11);
            this.bt_allocateRight.Name = "bt_allocateRight";
            this.bt_allocateRight.Size = new System.Drawing.Size(89, 23);
            this.bt_allocateRight.TabIndex = 4;
            this.bt_allocateRight.Text = "分配用户权限";
            this.bt_allocateRight.UseVisualStyleBackColor = true;
            this.bt_allocateRight.Click += new System.EventHandler(this.bt_allocateRight_Click);
            // 
            // 分配角色
            // 
            this.分配角色.Location = new System.Drawing.Point(281, 11);
            this.分配角色.Name = "分配角色";
            this.分配角色.Size = new System.Drawing.Size(75, 23);
            this.分配角色.TabIndex = 3;
            this.分配角色.Text = "分配角色";
            this.分配角色.UseVisualStyleBackColor = true;
            this.分配角色.Click += new System.EventHandler(this.分配角色_Click);
            // 
            // 修改
            // 
            this.修改.Location = new System.Drawing.Point(190, 11);
            this.修改.Name = "修改";
            this.修改.Size = new System.Drawing.Size(75, 23);
            this.修改.TabIndex = 2;
            this.修改.Text = "修改";
            this.修改.UseVisualStyleBackColor = true;
            this.修改.Click += new System.EventHandler(this.修改_Click);
            // 
            // 删除用户
            // 
            this.删除用户.Location = new System.Drawing.Point(99, 11);
            this.删除用户.Name = "删除用户";
            this.删除用户.Size = new System.Drawing.Size(75, 23);
            this.删除用户.TabIndex = 1;
            this.删除用户.Text = "删除用户";
            this.删除用户.UseVisualStyleBackColor = true;
            this.删除用户.Click += new System.EventHandler(this.删除用户_Click);
            // 
            // 添加用户
            // 
            this.添加用户.Location = new System.Drawing.Point(8, 11);
            this.添加用户.Name = "添加用户";
            this.添加用户.Size = new System.Drawing.Size(75, 23);
            this.添加用户.TabIndex = 0;
            this.添加用户.Text = "添加用户";
            this.添加用户.UseVisualStyleBackColor = true;
            this.添加用户.Click += new System.EventHandler(this.添加用户_Click);
            // 
            // UserManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 419);
            this.Controls.Add(this.panel_center);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.panel_top);
            this.Name = "UserManagerForm";
            this.Text = "用户管理";
            this.panel_center.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.panel_center_bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Panel panel_center;
        private System.Windows.Forms.Panel panel_center_bottom;
        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.Button 添加用户;
        private System.Windows.Forms.Button 分配角色;
        private System.Windows.Forms.Button 修改;
        private System.Windows.Forms.Button 删除用户;
        private System.Windows.Forms.Button bt_allocateRight;
        private System.Windows.Forms.Button 查看所有权限;
    }
}