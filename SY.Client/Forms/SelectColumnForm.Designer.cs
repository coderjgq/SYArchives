namespace SY.Client.Forms
{
    partial class SelectColumnForm
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
            this.cb_columns = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cb_columns
            // 
            this.cb_columns.FormattingEnabled = true;
            this.cb_columns.Location = new System.Drawing.Point(35, 12);
            this.cb_columns.Name = "cb_columns";
            this.cb_columns.Size = new System.Drawing.Size(121, 20);
            this.cb_columns.TabIndex = 0;
            this.cb_columns.SelectedIndexChanged += new System.EventHandler(this.cb_columns_SelectedIndexChanged);
            // 
            // SelectColumnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 57);
            this.Controls.Add(this.cb_columns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectColumnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择字段";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_columns;
    }
}