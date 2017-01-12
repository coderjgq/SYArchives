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
    public partial class RoleManagerForm : Form
    {
        private int RowNumber = 0;
        private int RoleName = 1;
        
        private List<ARRole> roles;

        public RoleManagerForm()
        {
            InitializeComponent();
            InitDataGridViewHeader();
            DisplayRoles();
        }

        private void DisplayRoles()
        {
            this.dgv_role.Rows.Clear();
            GetRoles();
            int roleCount = roles.Count;
            if (roleCount == 0)
            {
                return;
            }
            this.dgv_role.RowCount = roleCount;
            int rowNumber = 0;
            foreach (ARRole role in roles)
            {
                DisplayRole(role, rowNumber++);
            }
        }

        public void DisplayRole(ARRole role, int rowNumber)
        {
            this.dgv_role.Rows[rowNumber].Cells[RowNumber].Value = "" + (rowNumber + 1);
            this.dgv_role.Rows[rowNumber].Cells[RoleName].Value = "" + role.RoleName;
        }

        private List<ARRole> GetRoles()
        {
            roles = ServerProxy.GetProxy().GetRoles();
            return roles;
        }

        private void InitDataGridViewHeader()
        {
            this.dgv_role.Columns.Clear();
            this.dgv_role.Rows.Clear();
            this.dgv_role.AllowUserToAddRows = false;

            DataGridViewTextBoxColumn tmpColumn = new DataGridViewTextBoxColumn();
            tmpColumn.HeaderText = "序号";
            tmpColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_role.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmpColumn });

            tmpColumn = new DataGridViewTextBoxColumn();
            tmpColumn.HeaderText = "角色";
            tmpColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_role.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmpColumn });
        }

        private void DeleteRole(string roleName)
        {
            //
            //删除Role之后要删除Role-Permission表中记录
            //
            //string result = ServerProxy.GetProxy().DeleteRole(roleName);
            string result = ServerProxy.GetProxy().Delete_Role_UserRole(roleName);
            if (result == "SUCCESS")
            {
                MessageBox.Show("删除成功");
                DisplayRoles();
            }
            else
            {
                MessageBox.Show("删除失败\n" + result);
            }
        }

        private string getSelectRoleName()
        {
            int rowIndex = this.dgv_role.SelectedCells[0].RowIndex;
            if (rowIndex < 0)
            {
                MessageBox.Show("请先选择");
                return null;
            }
            Object value = this.dgv_role.Rows[rowIndex].Cells[RoleName].Value;
            return value.ToString();
        }
        

        //****************************** 事件 ************************************

        private void bt_add_Click(object sender, EventArgs e)
        {
            new AddRoleForm().ShowDialog();
            DisplayRoles();
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }
            string roleName = getSelectRoleName();
            DeleteRole(roleName);
        }

        private void bt_allocate_Click(object sender, EventArgs e)
        {
            string roleName = getSelectRoleName();
            new SelectPermissionForm(roleName,"Role").Show();
        }
    }
}
