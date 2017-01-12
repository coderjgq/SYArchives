using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using HostService.Services;
using SY.Client.Forms.User;
using SY.Client.Forms.Attach;
using SY.Client.Forms.Access;
namespace SY.Client.Forms
{
    public partial class LoginForm : Form
    {
        public static string LOGIN_USER_NAME = "";

        private String configPath = System.Environment.CurrentDirectory + "\\config.xml";
        
        private int hideSize = 0;

        private string config = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            ServerProxy.IP = tb_ip.Text;
            ServerProxy.PORT = tb_port.Text;
            if (!ServerProxy.CheckConnect())
            {
                MessageBox.Show("服务器连接不成功");
                return;
            }
            Login();
        }

        private void Login()
        {
            string userName = this.txtUserName.Text.Trim();
            string password = (this.txtPwd.Text.Trim());
            //string password = MD5Util.GeneratePassword(this.txtPwd.Text.Trim());
            string result = ServerProxy.GetProxy().UserLogin(userName, password);
            if (result == "SUCCESS")
            {
                AccessControl.InitUserPermissions(userName);
                new QueryCategoryForm(this).Show();
                UpdateConfig();
                LoginForm.LOGIN_USER_NAME = userName;
                this.Hide();
                return;
            }
            if (result == "FAIL")
            {
                MessageBox.Show("用户不存在或密码不正确");
                return;
            }
            MessageBox.Show(result);
        }

        private void UpdateConfig()
        {
            config = XmlUtil.AppendChild("", "ip", tb_ip.Text.Trim());
            config = XmlUtil.AppendChild(config, "port", tb_port.Text.Trim());
            config = XmlUtil.FormatXml(config);
            File.WriteAllText(configPath,config);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            HideSetting();
            InitSetting();
        }

        private void HideSetting()
        {
            hideSize = this.panel_bottom_bottom.Height;
            this.Height = this.Height - hideSize;
        }

        private void InitSetting()
        {
            config = File.ReadAllText(configPath);
            XmlNode node1 = XmlUtil.SelectFirstNode(config, "/root/ip");
            XmlNode node2 = XmlUtil.SelectFirstNode(config, "/root/port");
            tb_ip.Text = node1.InnerXml.Trim();
            tb_port.Text = node2.InnerXml.Trim();
        }

        private void bt_set_Click(object sender, EventArgs e)
        {
            if (this.bt_set.Text.Trim().Equals("︾"))
            {
                this.bt_set.Text = "︽";
                this.Height = this.Height + hideSize;
                return;
            }
            if (this.bt_set.Text.Trim().Equals("︽"))
            {
                this.bt_set.Text = "︾";
                this.Height = this.Height - hideSize;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(MD5Util.GeneratePassword("a"));
        }
    }
}
