namespace SY.Client.Forms
{
    partial class SelectReminderForm
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
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel_right = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.panel_center = new System.Windows.Forms.Panel();
            this.bt_select = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_down = new System.Windows.Forms.Button();
            this.bt_up = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.dgv_reminder = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reminder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_add = new System.Windows.Forms.Button();
            this.panel_center.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_reminder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(517, 10);
            this.panel_top.TabIndex = 0;
            // 
            // panel_left
            // 
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 10);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(10, 341);
            this.panel_left.TabIndex = 1;
            // 
            // panel_right
            // 
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(507, 10);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(10, 341);
            this.panel_right.TabIndex = 2;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(10, 341);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(497, 10);
            this.panel_bottom.TabIndex = 3;
            // 
            // panel_center
            // 
            this.panel_center.Controls.Add(this.bt_select);
            this.panel_center.Controls.Add(this.bt_delete);
            this.panel_center.Controls.Add(this.bt_down);
            this.panel_center.Controls.Add(this.bt_up);
            this.panel_center.Controls.Add(this.bt_save);
            this.panel_center.Controls.Add(this.dgv_reminder);
            this.panel_center.Controls.Add(this.bt_add);
            this.panel_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_center.Location = new System.Drawing.Point(10, 10);
            this.panel_center.Name = "panel_center";
            this.panel_center.Size = new System.Drawing.Size(497, 331);
            this.panel_center.TabIndex = 4;
            // 
            // bt_select
            // 
            this.bt_select.Location = new System.Drawing.Point(392, 289);
            this.bt_select.Name = "bt_select";
            this.bt_select.Size = new System.Drawing.Size(75, 23);
            this.bt_select.TabIndex = 7;
            this.bt_select.Text = "选中";
            this.bt_select.UseVisualStyleBackColor = true;
            this.bt_select.Click += new System.EventHandler(this.bt_select_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(392, 101);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 6;
            this.bt_delete.Text = "删除";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_down
            // 
            this.bt_down.Location = new System.Drawing.Point(392, 205);
            this.bt_down.Name = "bt_down";
            this.bt_down.Size = new System.Drawing.Size(75, 23);
            this.bt_down.TabIndex = 5;
            this.bt_down.Text = "下移";
            this.bt_down.UseVisualStyleBackColor = true;
            this.bt_down.Click += new System.EventHandler(this.bt_down_Click);
            // 
            // bt_up
            // 
            this.bt_up.Location = new System.Drawing.Point(392, 176);
            this.bt_up.Name = "bt_up";
            this.bt_up.Size = new System.Drawing.Size(75, 23);
            this.bt_up.TabIndex = 4;
            this.bt_up.Text = "上移";
            this.bt_up.UseVisualStyleBackColor = true;
            this.bt_up.Click += new System.EventHandler(this.bt_up_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(392, 245);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 3;
            this.bt_save.Text = "保存";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // dgv_reminder
            // 
            this.dgv_reminder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_reminder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.reminder,
            this.code});
            this.dgv_reminder.Location = new System.Drawing.Point(6, 37);
            this.dgv_reminder.Name = "dgv_reminder";
            this.dgv_reminder.RowHeadersVisible = false;
            this.dgv_reminder.RowTemplate.Height = 23;
            this.dgv_reminder.Size = new System.Drawing.Size(380, 275);
            this.dgv_reminder.TabIndex = 2;
            this.dgv_reminder.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_reminder_CellEndEdit);
            // 
            // number
            // 
            this.number.HeaderText = "序号";
            this.number.Name = "number";
            this.number.Width = 70;
            // 
            // reminder
            // 
            this.reminder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reminder.HeaderText = "提示";
            this.reminder.Name = "reminder";
            // 
            // code
            // 
            this.code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.code.HeaderText = "代码";
            this.code.Name = "code";
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(392, 72);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 1;
            this.bt_add.Text = "添加";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // SelectReminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 351);
            this.Controls.Add(this.panel_center);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel_top);
            this.Name = "SelectReminderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择提示";
            this.panel_center.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_reminder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Panel panel_center;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.DataGridView dgv_reminder;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_down;
        private System.Windows.Forms.Button bt_up;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn reminder;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_select;
    }
}