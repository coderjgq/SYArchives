namespace SY.Client.Forms
{
    partial class ImportForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel_all = new System.Windows.Forms.Panel();
            this.panel_centre = new System.Windows.Forms.Panel();
            this.lb_total = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_state = new System.Windows.Forms.Label();
            this.rtb_error = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_insert = new System.Windows.Forms.Button();
            this.panel_right = new System.Windows.Forms.Panel();
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.panel_top = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flesh = new System.Windows.Forms.Timer(this.components);
            this.panel_all.SuspendLayout();
            this.panel_centre.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_all
            // 
            this.panel_all.Controls.Add(this.panel_centre);
            this.panel_all.Controls.Add(this.panel_right);
            this.panel_all.Controls.Add(this.panel_left);
            this.panel_all.Controls.Add(this.panel_bottom);
            this.panel_all.Controls.Add(this.panel_top);
            this.panel_all.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_all.Location = new System.Drawing.Point(0, 0);
            this.panel_all.Name = "panel_all";
            this.panel_all.Size = new System.Drawing.Size(871, 567);
            this.panel_all.TabIndex = 0;
            // 
            // panel_centre
            // 
            this.panel_centre.Controls.Add(this.lb_total);
            this.panel_centre.Controls.Add(this.label6);
            this.panel_centre.Controls.Add(this.label4);
            this.panel_centre.Controls.Add(this.lb_state);
            this.panel_centre.Controls.Add(this.rtb_error);
            this.panel_centre.Controls.Add(this.label3);
            this.panel_centre.Controls.Add(this.bt_insert);
            this.panel_centre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_centre.Location = new System.Drawing.Point(374, 62);
            this.panel_centre.Name = "panel_centre";
            this.panel_centre.Size = new System.Drawing.Size(487, 495);
            this.panel_centre.TabIndex = 4;
            // 
            // lb_total
            // 
            this.lb_total.AutoSize = true;
            this.lb_total.Location = new System.Drawing.Point(70, 56);
            this.lb_total.Name = "lb_total";
            this.lb_total.Size = new System.Drawing.Size(41, 12);
            this.lb_total.TabIndex = 7;
            this.lb_total.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "记录总数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "异常信息：";
            // 
            // lb_state
            // 
            this.lb_state.AutoSize = true;
            this.lb_state.Location = new System.Drawing.Point(70, 83);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(41, 12);
            this.lb_state.TabIndex = 4;
            this.lb_state.Text = "label5";
            // 
            // rtb_error
            // 
            this.rtb_error.Location = new System.Drawing.Point(8, 145);
            this.rtb_error.Name = "rtb_error";
            this.rtb_error.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtb_error.Size = new System.Drawing.Size(473, 263);
            this.rtb_error.TabIndex = 2;
            this.rtb_error.Text = "";
            this.rtb_error.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "执行状态：";
            // 
            // bt_insert
            // 
            this.bt_insert.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_insert.Location = new System.Drawing.Point(6, 6);
            this.bt_insert.Name = "bt_insert";
            this.bt_insert.Size = new System.Drawing.Size(79, 28);
            this.bt_insert.TabIndex = 0;
            this.bt_insert.Text = "入库";
            this.bt_insert.UseVisualStyleBackColor = true;
            this.bt_insert.Click += new System.EventHandler(this.bt_insert_Click);
            // 
            // panel_right
            // 
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(861, 62);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(10, 495);
            this.panel_right.TabIndex = 3;
            // 
            // panel_left
            // 
            this.panel_left.AutoScroll = true;
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 62);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(374, 495);
            this.panel_left.TabIndex = 2;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 557);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(871, 10);
            this.panel_bottom.TabIndex = 1;
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.label2);
            this.panel_top.Controls.Add(this.label1);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(871, 62);
            this.panel_top.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(186, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Excel字段";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(39, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据库字段";
            // 
            // flesh
            // 
            this.flesh.Tick += new System.EventHandler(this.flesh_Tick);
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 567);
            this.Controls.Add(this.panel_all);
            this.Name = "ImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入";
            this.panel_all.ResumeLayout(false);
            this.panel_centre.ResumeLayout(false);
            this.panel_centre.PerformLayout();
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_all;
        private System.Windows.Forms.Panel panel_centre;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_insert;
        private System.Windows.Forms.RichTextBox rtb_error;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_state;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_total;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer flesh;
    }
}

