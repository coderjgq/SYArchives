namespace SY.Client.Forms.Attach
{
    partial class AttachQueryForm
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
            this.panel_top = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel_right = new System.Windows.Forms.Panel();
            this.panel_center = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_center_bottom_bottom = new System.Windows.Forms.Panel();
            this.panel_center_bottom_bottom_top = new System.Windows.Forms.Panel();
            this.tablePannel = new System.Windows.Forms.TableLayoutPanel();
            this.panel_center_bottom_bottom_bottom = new System.Windows.Forms.Panel();
            this.bt_insert = new System.Windows.Forms.Button();
            this.panel_center_bottom_top = new System.Windows.Forms.Panel();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.panel_center_top = new System.Windows.Forms.Panel();
            this.panel_center_top_bottom = new System.Windows.Forms.Panel();
            this.btLastPage = new System.Windows.Forms.Button();
            this.btNextPage = new System.Windows.Forms.Button();
            this.bt_query = new System.Windows.Forms.Button();
            this.tbPageSize = new System.Windows.Forms.TextBox();
            this.panel_center_top_top = new System.Windows.Forms.Panel();
            this.tlp_query = new System.Windows.Forms.TableLayoutPanel();
            this.timer_dah = new System.Windows.Forms.Timer(this.components);
            this.panel_bottom.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel_center.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_center_bottom_bottom.SuspendLayout();
            this.panel_center_bottom_bottom_top.SuspendLayout();
            this.panel_center_bottom_bottom_bottom.SuspendLayout();
            this.panel_center_bottom_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.panel_center_top.SuspendLayout();
            this.panel_center_top_bottom.SuspendLayout();
            this.panel_center_top_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(1038, 10);
            this.panel_top.TabIndex = 0;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.statusStrip);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 739);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(1038, 26);
            this.panel_bottom.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 4);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1038, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(73, 17);
            this.toolStripStatusLabel1.Text = "statusLabel";
            // 
            // panel_left
            // 
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 10);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(10, 729);
            this.panel_left.TabIndex = 2;
            // 
            // panel_right
            // 
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(1028, 10);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(10, 729);
            this.panel_right.TabIndex = 3;
            // 
            // panel_center
            // 
            this.panel_center.Controls.Add(this.panel1);
            this.panel_center.Controls.Add(this.panel_center_top);
            this.panel_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_center.Location = new System.Drawing.Point(10, 10);
            this.panel_center.Name = "panel_center";
            this.panel_center.Size = new System.Drawing.Size(1018, 729);
            this.panel_center.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_center_bottom_bottom);
            this.panel1.Controls.Add(this.panel_center_bottom_top);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 580);
            this.panel1.TabIndex = 3;
            // 
            // panel_center_bottom_bottom
            // 
            this.panel_center_bottom_bottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_center_bottom_bottom.Controls.Add(this.panel_center_bottom_bottom_top);
            this.panel_center_bottom_bottom.Controls.Add(this.panel_center_bottom_bottom_bottom);
            this.panel_center_bottom_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_center_bottom_bottom.Location = new System.Drawing.Point(0, 192);
            this.panel_center_bottom_bottom.Name = "panel_center_bottom_bottom";
            this.panel_center_bottom_bottom.Size = new System.Drawing.Size(1018, 388);
            this.panel_center_bottom_bottom.TabIndex = 3;
            // 
            // panel_center_bottom_bottom_top
            // 
            this.panel_center_bottom_bottom_top.AutoScroll = true;
            this.panel_center_bottom_bottom_top.Controls.Add(this.tablePannel);
            this.panel_center_bottom_bottom_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_center_bottom_bottom_top.Location = new System.Drawing.Point(0, 0);
            this.panel_center_bottom_bottom_top.Name = "panel_center_bottom_bottom_top";
            this.panel_center_bottom_bottom_top.Size = new System.Drawing.Size(1016, 343);
            this.panel_center_bottom_bottom_top.TabIndex = 5;
            // 
            // tablePannel
            // 
            this.tablePannel.ColumnCount = 2;
            this.tablePannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePannel.Location = new System.Drawing.Point(5, 5);
            this.tablePannel.Name = "tablePannel";
            this.tablePannel.RowCount = 2;
            this.tablePannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePannel.Size = new System.Drawing.Size(200, 100);
            this.tablePannel.TabIndex = 0;
            // 
            // panel_center_bottom_bottom_bottom
            // 
            this.panel_center_bottom_bottom_bottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_center_bottom_bottom_bottom.Controls.Add(this.bt_insert);
            this.panel_center_bottom_bottom_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_center_bottom_bottom_bottom.Location = new System.Drawing.Point(0, 343);
            this.panel_center_bottom_bottom_bottom.Name = "panel_center_bottom_bottom_bottom";
            this.panel_center_bottom_bottom_bottom.Size = new System.Drawing.Size(1016, 43);
            this.panel_center_bottom_bottom_bottom.TabIndex = 4;
            // 
            // bt_insert
            // 
            this.bt_insert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_insert.Location = new System.Drawing.Point(924, 11);
            this.bt_insert.Name = "bt_insert";
            this.bt_insert.Size = new System.Drawing.Size(75, 23);
            this.bt_insert.TabIndex = 26;
            this.bt_insert.Text = "录入主表";
            this.bt_insert.UseVisualStyleBackColor = true;
            this.bt_insert.Click += new System.EventHandler(this.bt_insert_Click);
            // 
            // panel_center_bottom_top
            // 
            this.panel_center_bottom_top.AutoScroll = true;
            this.panel_center_bottom_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_center_bottom_top.Controls.Add(this.dgv_result);
            this.panel_center_bottom_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_center_bottom_top.Location = new System.Drawing.Point(0, 0);
            this.panel_center_bottom_top.Name = "panel_center_bottom_top";
            this.panel_center_bottom_top.Size = new System.Drawing.Size(1018, 192);
            this.panel_center_bottom_top.TabIndex = 2;
            // 
            // dgv_result
            // 
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_result.Location = new System.Drawing.Point(0, 0);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.RowTemplate.Height = 23;
            this.dgv_result.Size = new System.Drawing.Size(1016, 190);
            this.dgv_result.TabIndex = 0;
            this.dgv_result.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_result_CellDoubleClick);
            // 
            // panel_center_top
            // 
            this.panel_center_top.AutoScroll = true;
            this.panel_center_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_center_top.Controls.Add(this.panel_center_top_bottom);
            this.panel_center_top.Controls.Add(this.panel_center_top_top);
            this.panel_center_top.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel_center_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_center_top.Location = new System.Drawing.Point(0, 0);
            this.panel_center_top.Name = "panel_center_top";
            this.panel_center_top.Size = new System.Drawing.Size(1018, 149);
            this.panel_center_top.TabIndex = 0;
            // 
            // panel_center_top_bottom
            // 
            this.panel_center_top_bottom.Controls.Add(this.btLastPage);
            this.panel_center_top_bottom.Controls.Add(this.btNextPage);
            this.panel_center_top_bottom.Controls.Add(this.bt_query);
            this.panel_center_top_bottom.Controls.Add(this.tbPageSize);
            this.panel_center_top_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_center_top_bottom.Location = new System.Drawing.Point(0, 115);
            this.panel_center_top_bottom.Name = "panel_center_top_bottom";
            this.panel_center_top_bottom.Size = new System.Drawing.Size(1016, 32);
            this.panel_center_top_bottom.TabIndex = 1;
            // 
            // btLastPage
            // 
            this.btLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btLastPage.Location = new System.Drawing.Point(877, 6);
            this.btLastPage.Name = "btLastPage";
            this.btLastPage.Size = new System.Drawing.Size(35, 23);
            this.btLastPage.TabIndex = 27;
            this.btLastPage.Text = "<<";
            this.btLastPage.UseVisualStyleBackColor = true;
            this.btLastPage.Click += new System.EventHandler(this.btLastPage_Click);
            // 
            // btNextPage
            // 
            this.btNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNextPage.Location = new System.Drawing.Point(918, 6);
            this.btNextPage.Name = "btNextPage";
            this.btNextPage.Size = new System.Drawing.Size(35, 23);
            this.btNextPage.TabIndex = 28;
            this.btNextPage.Text = ">>";
            this.btNextPage.UseVisualStyleBackColor = true;
            this.btNextPage.Click += new System.EventHandler(this.btNextPage_Click);
            // 
            // bt_query
            // 
            this.bt_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_query.Location = new System.Drawing.Point(791, 6);
            this.bt_query.Name = "bt_query";
            this.bt_query.Size = new System.Drawing.Size(75, 23);
            this.bt_query.TabIndex = 25;
            this.bt_query.Text = "查询";
            this.bt_query.UseVisualStyleBackColor = true;
            this.bt_query.Click += new System.EventHandler(this.bt_query_Click);
            // 
            // tbPageSize
            // 
            this.tbPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPageSize.Location = new System.Drawing.Point(959, 6);
            this.tbPageSize.Name = "tbPageSize";
            this.tbPageSize.Size = new System.Drawing.Size(52, 21);
            this.tbPageSize.TabIndex = 26;
            this.tbPageSize.Text = "5";
            this.tbPageSize.TextChanged += new System.EventHandler(this.tbPageSize_TextChanged);
            // 
            // panel_center_top_top
            // 
            this.panel_center_top_top.Controls.Add(this.tlp_query);
            this.panel_center_top_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_center_top_top.Location = new System.Drawing.Point(0, 0);
            this.panel_center_top_top.Name = "panel_center_top_top";
            this.panel_center_top_top.Size = new System.Drawing.Size(1016, 147);
            this.panel_center_top_top.TabIndex = 0;
            // 
            // tlp_query
            // 
            this.tlp_query.ColumnCount = 2;
            this.tlp_query.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_query.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_query.Location = new System.Drawing.Point(5, 5);
            this.tlp_query.Name = "tlp_query";
            this.tlp_query.RowCount = 2;
            this.tlp_query.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_query.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_query.Size = new System.Drawing.Size(131, 34);
            this.tlp_query.TabIndex = 1;
            // 
            // AttachQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 765);
            this.Controls.Add(this.panel_center);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.panel_top);
            this.Name = "AttachQueryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AttachQueryForm";
            this.panel_bottom.ResumeLayout(false);
            this.panel_bottom.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel_center.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_center_bottom_bottom.ResumeLayout(false);
            this.panel_center_bottom_bottom_top.ResumeLayout(false);
            this.panel_center_bottom_bottom_bottom.ResumeLayout(false);
            this.panel_center_bottom_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.panel_center_top.ResumeLayout(false);
            this.panel_center_top_bottom.ResumeLayout(false);
            this.panel_center_top_bottom.PerformLayout();
            this.panel_center_top_top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Panel panel_center;
        private System.Windows.Forms.Panel panel_center_bottom_top;
        private System.Windows.Forms.Panel panel_center_top;
        private System.Windows.Forms.TableLayoutPanel tlp_query;
        private System.Windows.Forms.Button btNextPage;
        private System.Windows.Forms.Button btLastPage;
        private System.Windows.Forms.TextBox tbPageSize;
        private System.Windows.Forms.Button bt_query;
        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.Panel panel_center_top_bottom;
        private System.Windows.Forms.Panel panel_center_top_top;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_center_bottom_bottom;
        private System.Windows.Forms.Timer timer_dah;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel_center_bottom_bottom_bottom;
        private System.Windows.Forms.Panel panel_center_bottom_bottom_top;
        private System.Windows.Forms.TableLayoutPanel tablePannel;
        private System.Windows.Forms.Button bt_insert;
    }
}