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
    public partial class SelectRoleForm : Form
    {
        private string username;

        private int RowNumber = 0;
        private int PermissionName = 1;
        private int CheckBox = 2;

        private List<ARRole> includeRoles;

        public SelectRoleForm(string username)
        {
            InitializeComponent();
            this.username = username;
            InitDataGridViewHeader();
            DisplayRoles();
        }

        private void InitUserRoles()
        {
            int userid = Convert.ToInt32(ServerProxy.GetProxy().GetUser(username).UserId);
            includeRoles = ServerProxy.GetProxy().GetRolesByUserId(userid);
        }

        private void DisplayRoles()
        {
            InitUserRoles();
            List<ARRole> roles = ServerProxy.GetProxy().GetRoles();
            this.dgv_role.RowCount = roles.Count;
            int rowNumber = 0;
            foreach (ARRole role in roles)
            {
                DisplayRole(role, rowNumber++);
            }
        }

        private void DisplayRole(ARRole role, int rowNumber)
        {
            this.dgv_role.Rows[rowNumber].Cells[RowNumber].Value = "" + (rowNumber + 1);
            this.dgv_role.Rows[rowNumber].Cells[PermissionName].Value = "" + role.RoleName;
            if (IsInclude(role))
            {
                SelectCheckBox(rowNumber);
            }
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

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_role.Columns.AddRange(new System.Windows.Forms.DataGridViewCheckBoxColumn[] { checkBoxColumn });
        }

        private void GetIncludeRoles()
        {
            //includeRoles = ServerProxy.GetProxy().GetRolesByUserId();
        }

        private void SelectCheckBox(int rowNumber)
        {
            ((DataGridViewCheckBoxCell)(this.dgv_role.Rows[rowNumber].Cells[CheckBox])).Value = true;
        }

        private bool IsInclude(ARRole role)
        {
            if (includeRoles == null || includeRoles.Count == 0)
            {
                return false;
            }
            foreach (ARRole p in includeRoles)
            {
                if (p.RoleName == role.RoleName)
                {
                    return true;
                }
            }
            return false;
        }

        private void SelectAll()
        {
            int rowCount = this.dgv_role.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                ((DataGridViewCheckBoxCell)(this.dgv_role.Rows[i].Cells[CheckBox])).Value = true;
            }
        }

        private void DeSelectAll()
        {
            int rowCount = this.dgv_role.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                ((DataGridViewCheckBoxCell)(this.dgv_role.Rows[i].Cells[CheckBox])).Value = false;
            }
        }

        private List<string> GetSelectRoleNames()
        {
            List<string> selectPermissionNames = new List<string>();
            int rowCount = this.dgv_role.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    bool selected = (bool)((DataGridViewCheckBoxCell)(this.dgv_role.Rows[i].Cells[CheckBox])).Value;
                    if (selected)
                    {
                        string name = this.dgv_role.Rows[i].Cells[PermissionName].Value.ToString();
                        selectPermissionNames.Add(name);
                    }
                }
                catch
                {

                }
            }
            return selectPermissionNames;
        }

        private List<string> GetUnSelectRoleNames()
        {
            List<string> unSelectPermissionNames = new List<string>();
            int rowCount = this.dgv_role.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    bool selected = (bool)((DataGridViewCheckBoxCell)(this.dgv_role.Rows[i].Cells[CheckBox])).Value;
                    if (!selected)
                    {
                        string name = this.dgv_role.Rows[i].Cells[PermissionName].Value.ToString();
                        unSelectPermissionNames.Add(name);
                    }
                }
                catch
                {

                }
            }
            return unSelectPermissionNames;
        }

        private void AddUserRole(string username,string rolename)
        {
            int roleid = Convert.ToInt32(ServerProxy.GetProxy().GetRole(rolename).RoleId);
            int userid = Convert.ToInt32(ServerProxy.GetProxy().GetUser(username).UserId);
            ServerProxy.GetProxy().AddUserRole(userid,roleid);
        }

        private void DeleteUserRole(string username, string rolename)
        {
            int roleid = Convert.ToInt32(ServerProxy.GetProxy().GetRole(rolename).RoleId);
            int userid = Convert.ToInt32(ServerProxy.GetProxy().GetUser(username).UserId);
            ServerProxy.GetProxy().DeleteUserRole(userid, roleid);
        }

        private void AddUserRoles()
        {
            List<string> selects = GetSelectRoleNames();
            foreach (string rolename in selects)
            {
                AddUserRole(username,rolename);
            }
        }

        private void DeleteUserRoles()
        {
            List<string> selects = GetUnSelectRoleNames();
            foreach (string rolename in selects)
            {
                DeleteUserRole(username, rolename);
            }
        }

        private void UpdateUserRoleTable()
        {
            List<string> selectRoleNames = GetSelectRoleNames();

        }
        
        //******************************* 事件 ***************************************

        private void cb_selectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_selectAll.Checked)
            {
                SelectAll();
            }
            else
            {
                DeSelectAll();
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_sure_Click(object sender, EventArgs e)
        {
            AddUserRoles();
            DeleteUserRoles();
            MessageBox.Show("保存成功!");
        }
    }
}
