namespace SY.Client.Forms
{
    partial class ReminderForm
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
            this.bt_deleteColumn = new System.Windows.Forms.Button();
            this.bt_addColumn = new System.Windows.Forms.Button();
            this.lb_allColumnDescriptions = new System.Windows.Forms.ListBox();
            this.tb_category = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_default = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.tb_reminder = new System.Windows.Forms.TextBox();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_reminders = new System.Windows.Forms.ListBox();
            this.lb_reminderColumnDescriptions = new System.Windows.Forms.ListBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.bt_deleteColumn);
            this.panel.Controls.Add(this.bt_addColumn);
            this.panel.Controls.Add(this.lb_allColumnDescriptions);
            this.panel.Controls.Add(this.tb_category);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.tb_default);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.bt_save);
            this.panel.Controls.Add(this.bt_delete);
            this.panel.Controls.Add(this.bt_add);
            this.panel.Controls.Add(this.tb_reminder);
            this.panel.Controls.Add(this.tb_description);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.lb_reminders);
            this.panel.Controls.Add(this.lb_reminderColumnDescriptions);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(657, 388);
            this.panel.TabIndex = 0;
            // 
            // bt_deleteColumn
            // 
            this.bt_deleteColumn.Location = new System.Drawing.Point(126, 167);
            this.bt_deleteColumn.Name = "bt_deleteColumn";
            this.bt_deleteColumn.Size = new System.Drawing.Size(75, 23);
            this.bt_deleteColumn.TabIndex = 14;
            this.bt_deleteColumn.Text = "<<";
            this.bt_deleteColumn.UseVisualStyleBackColor = true;
            this.bt_deleteColumn.Click += new System.EventHandler(this.bt_deleteColumn_Click);
            // 
            // bt_addColumn
            // 
            this.bt_addColumn.Location = new System.Drawing.Point(126, 117);
            this.bt_addColumn.Name = "bt_addColumn";
            this.bt_addColumn.Size = new System.Drawing.Size(75, 23);
            this.bt_addColumn.TabIndex = 13;
            this.bt_addColumn.Text = ">>";
            this.bt_addColumn.UseVisualStyleBackColor = true;
            this.bt_addColumn.Click += new System.EventHandler(this.bt_addColumn_Click);
            // 
            // lb_allColumnDescriptions
            // 
            this.lb_allColumnDescriptions.FormattingEnabled = true;
            this.lb_allColumnDescriptions.ItemHeight = 12;
            this.lb_allColumnDescriptions.Location = new System.Drawing.Point(12, 0);
            this.lb_allColumnDescriptions.Name = "lb_allColumnDescriptions";
            this.lb_allColumnDescriptions.Size = new System.Drawing.Size(105, 388);
            this.lb_allColumnDescriptions.TabIndex = 12;
            // 
            // tb_category
            // 
            this.tb_category.Location = new System.Drawing.Point(536, 11);
            this.tb_category.Name = "tb_category";
            this.tb_category.ReadOnly = true;
            this.tb_category.Size = new System.Drawing.Size(100, 21);
            this.tb_category.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(489, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "分类号：";
            // 
            // tb_default
            // 
            this.tb_default.Location = new System.Drawing.Point(386, 219);
            this.tb_default.Multiline = true;
            this.tb_default.Name = "tb_default";
            this.tb_default.Size = new System.Drawing.Size(257, 39);
            this.tb_default.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "默认值：";
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(570, 358);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 7;
            this.bt_save.Text = "保 存";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(451, 328);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 6;
            this.bt_delete.Text = "删 除";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(570, 328);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 5;
            this.bt_add.Text = "添 加";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // tb_reminder
            // 
            this.tb_reminder.Location = new System.Drawing.Point(320, 277);
            this.tb_reminder.Multiline = true;
            this.tb_reminder.Name = "tb_reminder";
            this.tb_reminder.Size = new System.Drawing.Size(325, 42);
            this.tb_reminder.TabIndex = 4;
            // 
            // tb_description
            // 
            this.tb_description.Location = new System.Drawing.Point(379, 11);
            this.tb_description.Name = "tb_description";
            this.tb_description.ReadOnly = true;
            this.tb_description.Size = new System.Drawing.Size(100, 21);
            this.tb_description.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "字段描述：";
            // 
            // lb_reminders
            // 
            this.lb_reminders.FormattingEnabled = true;
            this.lb_reminders.ItemHeight = 12;
            this.lb_reminders.Location = new System.Drawing.Point(320, 51);
            this.lb_reminders.Name = "lb_reminders";
            this.lb_reminders.Size = new System.Drawing.Size(325, 148);
            this.lb_reminders.TabIndex = 1;
            // 
            // lb_reminderColumnDescriptions
            // 
            this.lb_reminderColumnDescriptions.FormattingEnabled = true;
            this.lb_reminderColumnDescriptions.ItemHeight = 12;
            this.lb_reminderColumnDescriptions.Location = new System.Drawing.Point(207, 0);
            this.lb_reminderColumnDescriptions.Name = "lb_reminderColumnDescriptions";
            this.lb_reminderColumnDescriptions.Size = new System.Drawing.Size(105, 388);
            this.lb_reminderColumnDescriptions.TabIndex = 0;
            this.lb_reminderColumnDescriptions.SelectedIndexChanged += new System.EventHandler(this.lb_columnNames_SelectedIndexChanged);
            // 
            // ReminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 388);
            this.Controls.Add(this.panel);
            this.Name = "ReminderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置提示信息";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ListBox lb_reminderColumnDescriptions;
        private System.Windows.Forms.TextBox tb_description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_reminders;
        private System.Windows.Forms.TextBox tb_reminder;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.TextBox tb_category;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_default;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lb_allColumnDescriptions;
        private System.Windows.Forms.Button bt_addColumn;
        private System.Windows.Forms.Button bt_deleteColumn;
    }
}