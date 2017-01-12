namespace SY.Client.Forms
{
    partial class ResultOrderForm
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
            this.bt_down = new System.Windows.Forms.Button();
            this.bt_up = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_sure = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.panel_right = new System.Windows.Forms.Panel();
            this.panel_right_bottom = new System.Windows.Forms.Panel();
            this.lb_display = new System.Windows.Forms.ListBox();
            this.panel_right_top = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel_left_bottom = new System.Windows.Forms.Panel();
            this.lb_unDisplay = new System.Windows.Forms.ListBox();
            this.panel_left_top = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.panel_middle.SuspendLayout();
            this.panel_right.SuspendLayout();
            this.panel_right_bottom.SuspendLayout();
            this.panel_right_top.SuspendLayout();
            this.panel_left.SuspendLayout();
            this.panel_left_bottom.SuspendLayout();
            this.panel_left_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.panel_middle);
            this.panel.Controls.Add(this.panel_right);
            this.panel.Controls.Add(this.panel_left);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(632, 396);
            this.panel.TabIndex = 0;
            // 
            // panel_middle
            // 
            this.panel_middle.Controls.Add(this.bt_down);
            this.panel_middle.Controls.Add(this.bt_up);
            this.panel_middle.Controls.Add(this.bt_exit);
            this.panel_middle.Controls.Add(this.bt_sure);
            this.panel_middle.Controls.Add(this.bt_delete);
            this.panel_middle.Controls.Add(this.bt_add);
            this.panel_middle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_middle.Location = new System.Drawing.Point(271, 0);
            this.panel_middle.Name = "panel_middle";
            this.panel_middle.Size = new System.Drawing.Size(108, 396);
            this.panel_middle.TabIndex = 2;
            // 
            // bt_down
            // 
            this.bt_down.Location = new System.Drawing.Point(15, 233);
            this.bt_down.Name = "bt_down";
            this.bt_down.Size = new System.Drawing.Size(75, 23);
            this.bt_down.TabIndex = 5;
            this.bt_down.Text = "下移";
            this.bt_down.UseVisualStyleBackColor = true;
            this.bt_down.Click += new System.EventHandler(this.bt_down_Click);
            // 
            // bt_up
            // 
            this.bt_up.Location = new System.Drawing.Point(15, 199);
            this.bt_up.Name = "bt_up";
            this.bt_up.Size = new System.Drawing.Size(75, 23);
            this.bt_up.TabIndex = 4;
            this.bt_up.Text = "上移";
            this.bt_up.UseVisualStyleBackColor = true;
            this.bt_up.Click += new System.EventHandler(this.bt_up_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(15, 335);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 3;
            this.bt_exit.Text = "退出";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_sure
            // 
            this.bt_sure.Location = new System.Drawing.Point(15, 299);
            this.bt_sure.Name = "bt_sure";
            this.bt_sure.Size = new System.Drawing.Size(75, 23);
            this.bt_sure.TabIndex = 2;
            this.bt_sure.Text = "确定";
            this.bt_sure.UseVisualStyleBackColor = true;
            this.bt_sure.Click += new System.EventHandler(this.bt_sure_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(15, 139);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 1;
            this.bt_delete.Text = "<<";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(15, 100);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 0;
            this.bt_add.Text = ">>";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // panel_right
            // 
            this.panel_right.Controls.Add(this.panel_right_bottom);
            this.panel_right.Controls.Add(this.panel_right_top);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(379, 0);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(253, 396);
            this.panel_right.TabIndex = 1;
            // 
            // panel_right_bottom
            // 
            this.panel_right_bottom.Controls.Add(this.lb_display);
            this.panel_right_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right_bottom.Location = new System.Drawing.Point(0, 35);
            this.panel_right_bottom.Name = "panel_right_bottom";
            this.panel_right_bottom.Size = new System.Drawing.Size(253, 361);
            this.panel_right_bottom.TabIndex = 1;
            // 
            // lb_display
            // 
            this.lb_display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_display.FormattingEnabled = true;
            this.lb_display.ItemHeight = 12;
            this.lb_display.Location = new System.Drawing.Point(0, 0);
            this.lb_display.Name = "lb_display";
            this.lb_display.Size = new System.Drawing.Size(253, 361);
            this.lb_display.TabIndex = 0;
            // 
            // panel_right_top
            // 
            this.panel_right_top.Controls.Add(this.label2);
            this.panel_right_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_right_top.Location = new System.Drawing.Point(0, 0);
            this.panel_right_top.Name = "panel_right_top";
            this.panel_right_top.Size = new System.Drawing.Size(253, 35);
            this.panel_right_top.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "显示字段";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_left
            // 
            this.panel_left.Controls.Add(this.panel_left_bottom);
            this.panel_left.Controls.Add(this.panel_left_top);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(271, 396);
            this.panel_left.TabIndex = 0;
            // 
            // panel_left_bottom
            // 
            this.panel_left_bottom.Controls.Add(this.lb_unDisplay);
            this.panel_left_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_left_bottom.Location = new System.Drawing.Point(0, 35);
            this.panel_left_bottom.Name = "panel_left_bottom";
            this.panel_left_bottom.Size = new System.Drawing.Size(271, 361);
            this.panel_left_bottom.TabIndex = 1;
            // 
            // lb_unDisplay
            // 
            this.lb_unDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_unDisplay.FormattingEnabled = true;
            this.lb_unDisplay.ItemHeight = 12;
            this.lb_unDisplay.Location = new System.Drawing.Point(0, 0);
            this.lb_unDisplay.Name = "lb_unDisplay";
            this.lb_unDisplay.Size = new System.Drawing.Size(271, 361);
            this.lb_unDisplay.TabIndex = 0;
            // 
            // panel_left_top
            // 
            this.panel_left_top.Controls.Add(this.label1);
            this.panel_left_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_left_top.Location = new System.Drawing.Point(0, 0);
            this.panel_left_top.Name = "panel_left_top";
            this.panel_left_top.Size = new System.Drawing.Size(271, 35);
            this.panel_left_top.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "未显示字段";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResultOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 396);
            this.Controls.Add(this.panel);
            this.Name = "ResultOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "结果排序";
            this.panel.ResumeLayout(false);
            this.panel_middle.ResumeLayout(false);
            this.panel_right.ResumeLayout(false);
            this.panel_right_bottom.ResumeLayout(false);
            this.panel_right_top.ResumeLayout(false);
            this.panel_left.ResumeLayout(false);
            this.panel_left_bottom.ResumeLayout(false);
            this.panel_left_top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel_middle;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_right_bottom;
        private System.Windows.Forms.Panel panel_right_top;
        private System.Windows.Forms.Panel panel_left_bottom;
        private System.Windows.Forms.Panel panel_left_top;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.ListBox lb_display;
        private System.Windows.Forms.ListBox lb_unDisplay;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_sure;
        private System.Windows.Forms.Button bt_down;
        private System.Windows.Forms.Button bt_up;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}