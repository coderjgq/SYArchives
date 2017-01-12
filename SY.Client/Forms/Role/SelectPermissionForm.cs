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
    public partial class SelectPermissionForm : Form
    {
        private string type;
        private string entityName;

        private int RowNumber = 0;
        private int PermissionName = 1;
        private int CheckBox = 2;

        private List<ARPermission> includePermissions;

        public SelectPermissionForm(string entityName,string type)
        {
            InitializeComponent();
            this.entityName = entityName;
            this.type = type;
            InitTitle(type);
            InitDataGridViewHeader();
            GetIncludePermission();
            DisplayPermissions(entityName);
        }

        private void InitTitle(string type)
        {
            if (type == "User")
            {
                this.Text = "用户权限";
            }
            else if (type == "Role")
            {
                this.Text = "角色权限";
            }
        }

        private void InitDataGridViewHeader()
        {
            this.dgv_permission.Columns.Clear();
            this.dgv_permission.Rows.Clear();
            this.dgv_permission.AllowUserToAddRows = false;

            DataGridViewTextBoxColumn tmpColumn = new DataGridViewTextBoxColumn();
            tmpColumn.HeaderText = "序号";
            tmpColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_permission.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmpColumn });

            tmpColumn = new DataGridViewTextBoxColumn();
            tmpColumn.HeaderText = "权限";
            tmpColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_permission.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmpColumn });

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "复选框";
            checkBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_permission.Columns.AddRange(new System.Windows.Forms.DataGridViewCheckBoxColumn[] { checkBoxColumn });
        }

        private void DisplayPermissions(string entityName)
        {
            List<ARPermission> permissions = GetAllPermissions();
            int permissionCount = permissions.Count;
            if (permissionCount == 0)
            {
                return;
            }
            this.dgv_permission.RowCount = permissionCount;
            int rowNumber = 0;
            foreach (ARPermission permission in permissions)
            {
                DisplayPermission(permission, rowNumber++);
            }
        }

        private void GetIncludePermission()
        {
            includePermissions = GetPermissions(entityName,type);
        }

        private void DisplayPermission(ARPermission permission, int rowNumber)
        {
            this.dgv_permission.Rows[rowNumber].Cells[RowNumber].Value = "" + (rowNumber + 1);
            this.dgv_permission.Rows[rowNumber].Cells[PermissionName].Value = "" + permission.Permission_Name;
            if (IsInclude(permission))
            {
                SelectCheckBox(rowNumber);
            }
        }

        private void SelectCheckBox(int rowNumber)
        {
            ((DataGridViewCheckBoxCell)(this.dgv_permission.Rows[rowNumber].Cells[CheckBox])).Value = true;
        }

        private bool IsInclude(ARPermission permission)
        {
            if (includePermissions == null || includePermissions.Count == 0)
            {
                return false;
            }
            foreach (ARPermission p in includePermissions)
            {
                if (p.Permission_Name == permission.Permission_Name)
                {
                    return true;
                }
            }
            return false;
        }

        private List<ARPermission> GetPermissions(string entityName,string type)
        {
            if (type == "Role")
            {
                ARRole role = ServerProxy.GetProxy().GetRole(entityName);
                List<ARPermission> permissions = ServerProxy.GetProxy().GetPermissionsByRoleId(Convert.ToInt32(role.RoleId));
                return permissions;
            }
            else if (type == "User")
            {
                ARUser user = ServerProxy.GetProxy().GetUser(entityName);
                List<ARPermission> permissions = ServerProxy.GetProxy().GetPermissionsByUserId(Convert.ToInt32(user.UserId));
                return permissions;
            }
            return null;
        }

        private List<ARPermission> GetAllPermissions()
        {
            return ServerProxy.GetProxy().GetPermissions();
        }

        private void SelectAll()
        {
            int rowCount = this.dgv_permission.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                ((DataGridViewCheckBoxCell)(this.dgv_permission.Rows[i].Cells[CheckBox])).Value = true;
            }
        }

        private void DeSelectAll()
        {
            int rowCount = this.dgv_permission.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                ((DataGridViewCheckBoxCell)(this.dgv_permission.Rows[i].Cells[CheckBox])).Value = false;
            }
        }

        private void AddACLs(string type)
        {
            List<string> selectPermissionNames = GetSelectPermissionNames();

            if (type == "Role")
            {
                ARRole role = ServerProxy.GetProxy().GetRole(entityName);
                foreach (string name in selectPermissionNames)
                {
                    ARPermission permission = ServerProxy.GetProxy().GetPermission(name);
                    bool existACL = ServerProxy.GetProxy().ExistACL(Convert.ToInt32(role.RoleId), Convert.ToInt32(permission.Permission_Id), type);
                    if (!existACL)
                    {
                        ARACL acl = new ARACL();
                        acl.ACL_Entity_Id = role.RoleId;
                        acl.ACL_Type = type;
                        acl.ACL_Permission_Id = permission.Permission_Id;
                        ServerProxy.GetProxy().AddACL(acl);
                    }
                }
            }
            else if(type == "User")
            {
                ARUser user = ServerProxy.GetProxy().GetUser(entityName);
                foreach (string name in selectPermissionNames)
                {
                    ARPermission permission = ServerProxy.GetProxy().GetPermission(name);
                    bool existACL = ServerProxy.GetProxy().ExistACL(Convert.ToInt32(user.UserId), Convert.ToInt32(permission.Permission_Id), type);
                    if (!existACL)
                    {
                        ARACL acl = new ARACL();
                        acl.ACL_Entity_Id = user.UserId;
                        acl.ACL_Type = type;
                        acl.ACL_Permission_Id = permission.Permission_Id;
                        ServerProxy.GetProxy().AddACL(acl);
                    }
                }
            }
        }

        private void DeleteACLs(string type)
        {
            List<string> unSelectPermissionNames = GetUnSelectPermissionNames();

            if (type == "Role")
            {
                ARRole role = ServerProxy.GetProxy().GetRole(entityName);
                foreach (string name in unSelectPermissionNames)
                {
                    ARPermission permission = ServerProxy.GetProxy().GetPermission(name);
                    ARACL acl = new ARACL();
                    acl.ACL_Entity_Id = role.RoleId;
                    acl.ACL_Type = type;
                    acl.ACL_Permission_Id = permission.Permission_Id;
                    ServerProxy.GetProxy().DeleteACL(acl);
                }
            }
            else if (type == "User")
            {
                ARUser user = ServerProxy.GetProxy().GetUser(entityName);
                foreach (string name in unSelectPermissionNames)
                {
                    ARPermission permission = ServerProxy.GetProxy().GetPermission(name);
                    ARACL acl = new ARACL();
                    acl.ACL_Entity_Id = user.UserId;
                    acl.ACL_Type = type;
                    acl.ACL_Permission_Id = permission.Permission_Id;
                    ServerProxy.GetProxy().DeleteACL(acl);
                }
            }
        }

        private List<string> GetSelectPermissionNames()
        {
            List<string> selectPermissionNames = new List<string>();
            int rowCount = this.dgv_permission.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    bool selected = (bool)((DataGridViewCheckBoxCell)(this.dgv_permission.Rows[i].Cells[CheckBox])).Value;
                    if (selected)
                    {
                        string name = this.dgv_permission.Rows[i].Cells[PermissionName].Value.ToString();
                        selectPermissionNames.Add(name);
                    }
                }
                catch
                {

                }
            }
            return selectPermissionNames;
        }

        private List<string> GetUnSelectPermissionNames()
        {
            List<string> unSelectPermissionNames = new List<string>();
            int rowCount = this.dgv_permission.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    bool selected = (bool)((DataGridViewCheckBoxCell)(this.dgv_permission.Rows[i].Cells[CheckBox])).Value;
                    if (!selected)
                    {
                        string name = this.dgv_permission.Rows[i].Cells[PermissionName].Value.ToString();
                        unSelectPermissionNames.Add(name);
                    }
                }
                catch
                {

                }
            }
            return unSelectPermissionNames;
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
            AddACLs(type);
            DeleteACLs(type);
            MessageBox.Show("保存成功");
        }
    }
}
