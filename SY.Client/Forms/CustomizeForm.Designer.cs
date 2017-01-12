namespace SY.Client.Forms
{
    partial class CustomizeForm
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
            this.tableLayOut = new System.Windows.Forms.TableLayoutPanel();
            this.bt_addRow = new System.Windows.Forms.Button();
            this.bt_deleteRow = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_mergeState = new System.Windows.Forms.Button();
            this.bt_merge = new System.Windows.Forms.Button();
            this.bt_break = new System.Windows.Forms.Button();
            this.panel_top = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.panel_top.SuspendLayout();
            this.panel_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayOut
            // 
            this.tableLayOut.AutoScroll = true;
            this.tableLayOut.ColumnCount = 2;
            this.tableLayOut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayOut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayOut.Location = new System.Drawing.Point(12, 12);
            this.tableLayOut.Name = "tableLayOut";
            this.tableLayOut.RowCount = 2;
            this.tableLayOut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayOut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayOut.Size = new System.Drawing.Size(101, 72);
            this.tableLayOut.TabIndex = 0;
            // 
            // bt_addRow
            // 
            this.bt_addRow.Location = new System.Drawing.Point(305, 17);
            this.bt_addRow.Name = "bt_addRow";
            this.bt_addRow.Size = new System.Drawing.Size(75, 23);
            this.bt_addRow.TabIndex = 2;
            this.bt_addRow.Text = "增加行";
            this.bt_addRow.UseVisualStyleBackColor = true;
            this.bt_addRow.Click += new System.EventHandler(this.bt_addRow_Click);
            // 
            // bt_deleteRow
            // 
            this.bt_deleteRow.Location = new System.Drawing.Point(305, 46);
            this.bt_deleteRow.Name = "bt_deleteRow";
            this.bt_deleteRow.Size = new System.Drawing.Size(75, 23);
            this.bt_deleteRow.TabIndex = 4;
            this.bt_deleteRow.Text = "删除行";
            this.bt_deleteRow.UseVisualStyleBackColor = true;
            this.bt_deleteRow.Click += new System.EventHandler(this.bt_deleteRow_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(305, 75);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 5;
            this.bt_save.Text = "保存设置";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_mergeState
            // 
            this.bt_mergeState.Location = new System.Drawing.Point(163, 17);
            this.bt_mergeState.Name = "bt_mergeState";
            this.bt_mergeState.Size = new System.Drawing.Size(102, 23);
            this.bt_mergeState.TabIndex = 6;
            this.bt_mergeState.Text = "字段选择状态";
            this.bt_mergeState.UseVisualStyleBackColor = true;
            this.bt_mergeState.Click += new System.EventHandler(this.bt_mergeState_Click);
            // 
            // bt_merge
            // 
            this.bt_merge.Location = new System.Drawing.Point(202, 46);
            this.bt_merge.Name = "bt_merge";
            this.bt_merge.Size = new System.Drawing.Size(63, 23);
            this.bt_merge.TabIndex = 7;
            this.bt_merge.Text = "合并";
            this.bt_merge.UseVisualStyleBackColor = true;
            this.bt_merge.Click += new System.EventHandler(this.bt_merge_Click_1);
            // 
            // bt_break
            // 
            this.bt_break.Location = new System.Drawing.Point(202, 75);
            this.bt_break.Name = "bt_break";
            this.bt_break.Size = new System.Drawing.Size(63, 23);
            this.bt_break.TabIndex = 8;
            this.bt_break.Text = "打散";
            this.bt_break.UseVisualStyleBackColor = true;
            this.bt_break.Click += new System.EventHandler(this.bt_break_Click);
            // 
            // panel_top
            // 
            this.panel_top.AutoScroll = true;
            this.panel_top.Controls.Add(this.tableLayOut);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(423, 404);
            this.panel_top.TabIndex = 9;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.bt_addRow);
            this.panel_bottom.Controls.Add(this.bt_deleteRow);
            this.panel_bottom.Controls.Add(this.bt_save);
            this.panel_bottom.Controls.Add(this.bt_break);
            this.panel_bottom.Controls.Add(this.bt_mergeState);
            this.panel_bottom.Controls.Add(this.bt_merge);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bottom.Location = new System.Drawing.Point(0, 404);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(423, 108);
            this.panel_bottom.TabIndex = 10;
            // 
            // CustomizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 512);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.panel_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自定义";
            this.panel_top.ResumeLayout(false);
            this.panel_bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayOut;
        private System.Windows.Forms.Button bt_addRow;
        private System.Windows.Forms.Button bt_deleteRow;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_mergeState;
        private System.Windows.Forms.Button bt_merge;
        private System.Windows.Forms.Button bt_break;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_bottom;
    }
}