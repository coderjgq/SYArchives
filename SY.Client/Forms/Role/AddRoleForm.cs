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
    public partial class AddRoleForm : Form
    {
        private int RowNumber = 0;
        private int RoleName = 1;
        
        
        private List<ARRole> roles;

        public AddRoleForm()
        {
            InitializeComponent();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                ARRole role = InitRole();
                if (!ServerProxy.GetProxy().ExistRole(role.RoleName))
                {
                    string result = ServerProxy.GetProxy().AddRole(role);
                    if (result == "SUCCESS")
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
                }
                else
                {
                    MessageBox.Show("角色 '"+role.RoleName+"' 已经存在");
                }
            }
        }

        private bool Check()
        {
            if (tb_roleName.Text.Trim() == "")
            {
                MessageBox.Show("请输入角色名");
                return false;
            }
            else
            {
                return true;
            }
        }

        private ARRole InitRole()
        {
            ARRole role = new ARRole();
            role.RoleName = tb_roleName.Text.Trim();
            return role;
        }
    }
}
