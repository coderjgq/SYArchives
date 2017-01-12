using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SY.MODEL;

namespace SY.Client.Forms.User
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (!CheckFormat())
            {
                return;
            }
            if (!CheckNull())
            {
                return;
            }
            if (!CheckPwd())
            {
                return;
            }
            ARUser user = InitUser();
            SaveUser(user);
        }

        private void SaveUser(ARUser user)
        {

            if (ServerProxy.GetProxy().ExistUser(user.UserName))
            {
                MessageBox.Show("用户名" + user.UserName + "已经存在");
                return;
            }
            user.Password = MD5Util.GeneratePassword(user.Password);
            string result = ServerProxy.GetProxy().AddUser(user);
            if (result == "SUCCESS")
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败\n"+result);
            }
        }

        private bool CheckFormat()
        {
            try
            {
                Convert.ToInt16(this.tb_status.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        private bool CheckNull()
        {
            if (this.tb_userName.Text.Trim() == "")
            {
                MessageBox.Show("用户名不能为空");
                return false;
            }
            if (this.tb_factName.Text.Trim() == "")
            {
                MessageBox.Show("真实姓名不能为空");
                return false;
            }
            if (this.tb_pwd1.Text.Trim() == "")
            {
                MessageBox.Show("密码不能为空");
                return false;
            }
            if (this.tb_pwd2.Text.Trim() == "")
            {
                MessageBox.Show("密码不能为空");
                return false;
            }
            return true;
        }

        private bool CheckPwd()
        {
            string pwd1 = this.tb_pwd1.Text.Trim();
            string pwd2 = this.tb_pwd2.Text.Trim();
            if (pwd1 == pwd2)
            {
                return true;
            }
            MessageBox.Show("密码输入不一致");
            return false;
        }

        private ARUser InitUser()
        {
            ARUser user = new ARUser();
            user.UserName = this.tb_userName.Text.Trim();
            user.FactName = this.tb_factName.Text.Trim();
            user.Status = Convert.ToInt16(this.tb_status.Text.Trim()) + "";
            user.Remark = this.tb_remark.Text.Trim();
            user.RoleName = this.tb_role.Text.Trim();
            user.Password = this.tb_pwd1.Text.Trim();
            return user;
        }

    }
}
