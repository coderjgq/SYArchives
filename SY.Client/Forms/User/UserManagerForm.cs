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
    public partial class UserManagerForm : Form
    {
        public static int RowNumber = 0;
        public static int UserName = 1;
        public static int FactName = 2;
        public static int Password = 3;
        public static int RoleName = 4;
        public static int Status = 5;
        public static int Remark = 6;

        private List<ARUser> userList;

        public UserManagerForm()
        {
            InitializeComponent();
            InitDataGridView();
            DisplayUsers();
        }

        //**************************************** 树相关 ******************************************

        public void InitDataGridView()
        {
            this.dgv_result.Columns.Clear();
            this.dgv_result.Rows.Clear();
            DataGridViewTextBoxColumn tmpColumn = new DataGridViewTextBoxColumn();
            tmpColumn.HeaderText = "序号";
            tmpColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmpColumn });

            tmpColumn = new DataGridViewTextBoxColumn();
            tmpColumn.HeaderText = "用户名";
            tmpColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmpColumn });

            tmpColumn = new DataGridViewTextBoxColumn();
            tmpColumn.HeaderText = "真实姓名";
            tmpColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmpColumn });

            tmpColumn = new DataGridViewTextBoxColumn();
            tmpColumn.HeaderText = "密码";
            tmpColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmpColumn });

            tmpColumn = new DataGridViewTextBoxColumn();
            tmpColumn.HeaderText = "角色";
            tmpColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmpColumn });

            tmpColumn = new DataGridViewTextBoxColumn();
            tmpColumn.HeaderText = "状态";
            tmpColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmpColumn });

            tmpColumn = new DataGridViewTextBoxColumn();
            tmpColumn.HeaderText = "备注";
            tmpColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmpColumn });

        }

        public void DisplayUsers()
        {
            this.dgv_result.Rows.Clear();
            this.userList = ServerProxy.GetProxy().GetUsers();
            this.dgv_result.RowCount = this.userList.Count;
            int rowNumber = 0;
            foreach (ARUser user in userList)
            {
                DisplayUser(user, rowNumber++);
            }
        }
        public void DisplayUser(ARUser user, int rowNumber)
        {
            this.dgv_result.Rows[rowNumber].Cells[RowNumber].Value = "" + (rowNumber + 1);
            this.dgv_result.Rows[rowNumber].Cells[UserName].Value = "" + user.UserName;
            this.dgv_result.Rows[rowNumber].Cells[FactName].Value = "" + user.FactName;
            this.dgv_result.Rows[rowNumber].Cells[Password].Value = "" + user.Password;
            this.dgv_result.Rows[rowNumber].Cells[RoleName].Value = "" + user.RoleName;
            this.dgv_result.Rows[rowNumber].Cells[Status].Value = "" + user.Status;
            this.dgv_result.Rows[rowNumber].Cells[Remark].Value = "" + user.Remark;
        }

        //**************************** 事件 ********************************

        private void 添加用户_Click(object sender, EventArgs e)
        {
            new AddUserForm().ShowDialog();
            DisplayUsers();
        }

        private void 删除用户_Click(object sender, EventArgs e)
        {
            string userName = getSelectUsername();
            if (userName != null)
            {
                //string result = ServerProxy.GetProxy().DeleteUser(userName);
                string result = ServerProxy.GetProxy().Delete_User_Role_ACL_Config(userName);
                if (result == "SUCCESS")
                {
                    MessageBox.Show("删除成功");
                    DisplayUsers();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private string getSelectUsername()
        {
            int rowIndex = this.dgv_result.SelectedCells[0].RowIndex;
            if (rowIndex < 0)
            {
                MessageBox.Show("请先选择");
                return null;
            }
            Object value = this.dgv_result.Rows[rowIndex].Cells[UserName].Value;
            return value.ToString();
        }

        private void 修改_Click(object sender, EventArgs e)
        {
            string userName = getSelectUsername();
            new ModifyUserForm(userName).Show();
        }

        private void bt_allocateRight_Click(object sender, EventArgs e)
        {
            string username = getSelectUsername();
            new SelectPermissionForm(username,"User").Show();
        }

        private void 分配角色_Click(object sender, EventArgs e)
        {
            new SelectRoleForm(getSelectUsername()).Show();
        }

        private void 查看所有权限_Click(object sender, EventArgs e)
        {
            new ViewUserPermissionForm(getSelectUsername(),"All").ShowDialog();
        }
    }
}
