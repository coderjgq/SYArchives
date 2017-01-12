namespace SY.Client.Forms.User
{
    partial class RoleManagerForm
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
            this.dgv_role = new System.Windows.Forms.DataGridView();
            this.panel_center_bottom = new System.Windows.Forms.Panel();
            this.bt_allocate = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.panel_center.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_role)).BeginInit();
            this.panel_center_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(362, 10);
            this.panel_top.TabIndex = 0;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 295);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(362, 10);
            this.panel_bottom.TabIndex = 1;
            // 
            // panel_left
            // 
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 10);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(10, 285);
            this.panel_left.TabIndex = 2;
            // 
            // panel_right
            // 
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(352, 10);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(10, 285);
            this.panel_right.TabIndex = 3;
            // 
            // panel_center
            // 
            this.panel_center.Controls.Add(this.dgv_role);
            this.panel_center.Controls.Add(this.panel_center_bottom);
            this.panel_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_center.Location = new System.Drawing.Point(10, 10);
            this.panel_center.Name = "panel_center";
            this.panel_center.Size = new System.Drawing.Size(342, 285);
            this.panel_center.TabIndex = 4;
            // 
            // dgv_role
            // 
            this.dgv_role.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_role.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_role.Location = new System.Drawing.Point(0, 0);
            this.dgv_role.Name = "dgv_role";
            this.dgv_role.RowTemplate.Height = 23;
            this.dgv_role.Size = new System.Drawing.Size(342, 241);
            this.dgv_role.TabIndex = 1;
            // 
            // panel_center_bottom
            // 
            this.panel_center_bottom.Controls.Add(this.bt_allocate);
            this.panel_center_bottom.Controls.Add(this.bt_delete);
            this.panel_center_bottom.Controls.Add(this.bt_add);
            this.panel_center_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_center_bottom.Location = new System.Drawing.Point(0, 241);
            this.panel_center_bottom.Name = "panel_center_bottom";
            this.panel_center_bottom.Size = new System.Drawing.Size(342, 44);
            this.panel_center_bottom.TabIndex = 0;
            // 
            // bt_allocate
            // 
            this.bt_allocate.Location = new System.Drawing.Point(195, 10);
            this.bt_allocate.Name = "bt_allocate";
            this.bt_allocate.Size = new System.Drawing.Size(75, 23);
            this.bt_allocate.TabIndex = 2;
            this.bt_allocate.Text = "分配权限";
            this.bt_allocate.UseVisualStyleBackColor = true;
            this.bt_allocate.Click += new System.EventHandler(this.bt_allocate_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(102, 10);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 1;
            this.bt_delete.Text = "删除角色";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(6, 10);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 0;
            this.bt_add.Text = "添加角色";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // RoleManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 305);
            this.Controls.Add(this.panel_center);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.panel_top);
            this.Name = "RoleManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色管理";
            this.panel_center.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_role)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv_role;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_allocate;
    }
}