namespace SY.Client.Forms
{
    partial class LoginForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.bt_login = new System.Windows.Forms.Button();
            this.panel_top = new System.Windows.Forms.Panel();
            this.bt_set = new System.Windows.Forms.Label();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.panel_bottom_bottom = new System.Windows.Forms.Panel();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_top.SuspendLayout();
            this.panel_bottom.SuspendLayout();
            this.panel_bottom_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "密  码";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(78, 55);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(168, 21);
            this.txtPwd.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "用户名";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(78, 16);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(168, 21);
            this.txtUserName.TabIndex = 6;
            // 
            // bt_login
            // 
            this.bt_login.Location = new System.Drawing.Point(171, 88);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(75, 23);
            this.bt_login.TabIndex = 10;
            this.bt_login.Text = "登录";
            this.bt_login.UseVisualStyleBackColor = true;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.button1);
            this.panel_top.Controls.Add(this.bt_set);
            this.panel_top.Controls.Add(this.bt_login);
            this.panel_top.Controls.Add(this.txtUserName);
            this.panel_top.Controls.Add(this.label2);
            this.panel_top.Controls.Add(this.label1);
            this.panel_top.Controls.Add(this.txtPwd);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(292, 130);
            this.panel_top.TabIndex = 11;
            // 
            // bt_set
            // 
            this.bt_set.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_set.Location = new System.Drawing.Point(250, 89);
            this.bt_set.Name = "bt_set";
            this.bt_set.Size = new System.Drawing.Size(17, 22);
            this.bt_set.TabIndex = 2;
            this.bt_set.Text = "︾";
            this.bt_set.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bt_set.Click += new System.EventHandler(this.bt_set_Click);
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.panel_bottom_bottom);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bottom.Location = new System.Drawing.Point(0, 130);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(292, 106);
            this.panel_bottom.TabIndex = 13;
            // 
            // panel_bottom_bottom
            // 
            this.panel_bottom_bottom.Controls.Add(this.tb_ip);
            this.panel_bottom_bottom.Controls.Add(this.label3);
            this.panel_bottom_bottom.Controls.Add(this.label4);
            this.panel_bottom_bottom.Controls.Add(this.tb_port);
            this.panel_bottom_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bottom_bottom.Location = new System.Drawing.Point(0, 0);
            this.panel_bottom_bottom.Name = "panel_bottom_bottom";
            this.panel_bottom_bottom.Size = new System.Drawing.Size(292, 106);
            this.panel_bottom_bottom.TabIndex = 1;
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(78, 20);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(168, 21);
            this.tb_ip.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "端口号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "服务器IP";
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(78, 59);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(168, 21);
            this.tb_port.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 236);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.panel_top);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.panel_bottom.ResumeLayout(false);
            this.panel_bottom_bottom.ResumeLayout(false);
            this.panel_bottom_bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Panel panel_bottom_bottom;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label bt_set;
        private System.Windows.Forms.Button button1;
    }
}