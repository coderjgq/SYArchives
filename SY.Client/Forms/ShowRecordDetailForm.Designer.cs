namespace SY.Client.Forms
{
    partial class ShowRecordDetailForm
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
            this.components = new System.ComponentModel.Container();
            this.panel = new System.Windows.Forms.Panel();
            this.panel_center = new System.Windows.Forms.Panel();
            this.tablePannel = new System.Windows.Forms.TableLayoutPanel();
            this.panel_right = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.bt_showRecordCustom = new System.Windows.Forms.Button();
            this.panel_top = new System.Windows.Forms.Panel();
            this.panel_left = new System.Windows.Forms.Panel();
            this.timer_dah = new System.Windows.Forms.Timer(this.components);
            this.l_dah = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.panel_center.SuspendLayout();
            this.panel_bottom.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.panel_center);
            this.panel.Controls.Add(this.panel_right);
            this.panel.Controls.Add(this.panel_bottom);
            this.panel.Controls.Add(this.panel_top);
            this.panel.Controls.Add(this.panel_left);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1202, 704);
            this.panel.TabIndex = 0;
            // 
            // panel_center
            // 
            this.panel_center.AutoScroll = true;
            this.panel_center.Controls.Add(this.tablePannel);
            this.panel_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_center.Location = new System.Drawing.Point(44, 53);
            this.panel_center.Name = "panel_center";
            this.panel_center.Size = new System.Drawing.Size(1138, 589);
            this.panel_center.TabIndex = 4;
            // 
            // tablePannel
            // 
            this.tablePannel.ColumnCount = 2;
            this.tablePannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePannel.Location = new System.Drawing.Point(8, 6);
            this.tablePannel.Name = "tablePannel";
            this.tablePannel.RowCount = 2;
            this.tablePannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePannel.Size = new System.Drawing.Size(200, 100);
            this.tablePannel.TabIndex = 0;
            // 
            // panel_right
            // 
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(1182, 53);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(20, 589);
            this.panel_right.TabIndex = 3;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.bt_showRecordCustom);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(44, 642);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(1158, 62);
            this.panel_bottom.TabIndex = 2;
            // 
            // bt_showRecordCustom
            // 
            this.bt_showRecordCustom.Location = new System.Drawing.Point(1048, 18);
            this.bt_showRecordCustom.Name = "bt_showRecordCustom";
            this.bt_showRecordCustom.Size = new System.Drawing.Size(98, 23);
            this.bt_showRecordCustom.TabIndex = 13;
            this.bt_showRecordCustom.Text = "显示布局";
            this.bt_showRecordCustom.UseVisualStyleBackColor = true;
            this.bt_showRecordCustom.Click += new System.EventHandler(this.btinsertCustom_Click);
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.l_dah);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(44, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(1158, 53);
            this.panel_top.TabIndex = 1;
            // 
            // panel_left
            // 
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(44, 704);
            this.panel_left.TabIndex = 0;
            // 
            // timer_dah
            // 
            this.timer_dah.Tick += new System.EventHandler(this.timer_dah_Tick);
            // 
            // l_dah
            // 
            this.l_dah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_dah.AutoSize = true;
            this.l_dah.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_dah.Location = new System.Drawing.Point(386, 23);
            this.l_dah.Name = "l_dah";
            this.l_dah.Size = new System.Drawing.Size(75, 19);
            this.l_dah.TabIndex = 2;
            this.l_dah.Text = "label1";
            this.l_dah.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShowRecordDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1202, 704);
            this.Controls.Add(this.panel);
            this.Name = "ShowRecordDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "录入";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel.ResumeLayout(false);
            this.panel_center.ResumeLayout(false);
            this.panel_bottom.ResumeLayout(false);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Panel panel_center;
        private System.Windows.Forms.TableLayoutPanel tablePannel;
        private System.Windows.Forms.Button bt_showRecordCustom;
        private System.Windows.Forms.Timer timer_dah;
        private System.Windows.Forms.Label l_dah;
    }
}