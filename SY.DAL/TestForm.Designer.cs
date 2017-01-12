namespace SY.DAL
{
    partial class TestForm
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
            this.bt_test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_test
            // 
            this.bt_test.Location = new System.Drawing.Point(76, 113);
            this.bt_test.Name = "bt_test";
            this.bt_test.Size = new System.Drawing.Size(75, 23);
            this.bt_test.TabIndex = 0;
            this.bt_test.Text = "测试";
            this.bt_test.UseVisualStyleBackColor = true;
            this.bt_test.Click += new System.EventHandler(this.bt_test_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.bt_test);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_test;
    }
}