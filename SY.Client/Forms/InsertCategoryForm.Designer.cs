namespace SY.Client.Forms
{
    partial class InsertCategoryForm
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
            this.btinsertCustom = new System.Windows.Forms.Button();
            this.bt_insert = new System.Windows.Forms.Button();
            this.panel_top = new System.Windows.Forms.Panel();
            this.l_dah = new System.Windows.Forms.Label();
            this.panel_left = new System.Windows.Forms.Panel();
            this.timer_dah = new System.Windows.Forms.Timer(this.components);
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
            this.panel.Size = new System.Drawing.Size(715, 446);
            this.panel.TabIndex = 0;
            // 
            // panel_center
            // 
            this.panel_center.AutoScroll = true;
            this.panel_center.Controls.Add(this.tablePannel);
            this.panel_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_center.Location = new System.Drawing.Point(44, 53);
            this.panel_center.Name = "panel_center";
            this.panel_center.Size = new System.Drawing.Size(651, 331);
            this.panel_center.TabIndex = 4;
            // 
            // tablePannel
            // 
            this.tablePannel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
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
            this.panel_right.Location = new System.Drawing.Point(695, 53);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(20, 331);
            this.panel_right.TabIndex = 3;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.btinsertCustom);
            this.panel_bottom.Controls.Add(this.bt_insert);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(44, 384);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(671, 62);
            this.panel_bottom.TabIndex = 2;
            // 
            // btinsertCustom
            // 
            this.btinsertCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btinsertCustom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btinsertCustom.Location = new System.Drawing.Point(472, 18);
            this.btinsertCustom.Name = "btinsertCustom";
            this.btinsertCustom.Size = new System.Drawing.Size(98, 32);
            this.btinsertCustom.TabIndex = 13;
            this.btinsertCustom.Text = "插入布局";
            this.btinsertCustom.UseVisualStyleBackColor = true;
            this.btinsertCustom.Click += new System.EventHandler(this.btinsertCustom_Click);
            // 
            // bt_insert
            // 
            this.bt_insert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_insert.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_insert.Location = new System.Drawing.Point(576, 18);
            this.bt_insert.Name = "bt_insert";
            this.bt_insert.Size = new System.Drawing.Size(75, 32);
            this.bt_insert.TabIndex = 0;
            this.bt_insert.Text = "插入";
            this.bt_insert.UseVisualStyleBackColor = true;
            this.bt_insert.Click += new System.EventHandler(this.bt_insert_Click);
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.l_dah);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(44, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(671, 53);
            this.panel_top.TabIndex = 1;
            // 
            // l_dah
            // 
            this.l_dah.AutoSize = true;
            this.l_dah.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_dah.Location = new System.Drawing.Point(4, 18);
            this.l_dah.Name = "l_dah";
            this.l_dah.Size = new System.Drawing.Size(56, 16);
            this.l_dah.TabIndex = 1;
            this.l_dah.Text = "label1";
            // 
            // panel_left
            // 
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(44, 446);
            this.panel_left.TabIndex = 0;
            // 
            // timer_dah
            // 
            this.timer_dah.Tick += new System.EventHandler(this.timer_dah_Tick);
            // 
            // InsertCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(715, 446);
            this.Controls.Add(this.panel);
            this.Name = "InsertCategoryForm";
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
        private System.Windows.Forms.Button bt_insert;
        private System.Windows.Forms.Button btinsertCustom;
        private System.Windows.Forms.Label l_dah;
        private System.Windows.Forms.Timer timer_dah;
    }
}