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
    public partial class ViewUserPermissionForm : Form
    {
        private string type;
        private string entityName;

        private int RowNumber = 0;
        private int PermissionName = 1;

        private List<ARPermission> includePermissions;

        public ViewUserPermissionForm(string entityName, string type)
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

        }

        private void DisplayPermissions(string entityName)
        {
            //List<ARPermission> permissions = GetAllPermissions();
            int permissionCount = includePermissions.Count;
            if (permissionCount == 0)
            {
                return;
            }
            this.dgv_permission.RowCount = permissionCount;
            int rowNumber = 0;
            foreach (ARPermission permission in includePermissions)
            {
                DisplayPermission(permission, rowNumber++);
            }
        }

        private void GetIncludePermission()
        {
            includePermissions = GetPermissions(entityName, type);
        }

        private void DisplayPermission(ARPermission permission, int rowNumber)
        {
            this.dgv_permission.Rows[rowNumber].Cells[RowNumber].Value = "" + (rowNumber + 1);
            this.dgv_permission.Rows[rowNumber].Cells[PermissionName].Value = "" + permission.Permission_Name;
        }

        private List<ARPermission> GetPermissions(string entityName, string type)
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
            }else if(type == "All")
            {
                ARUser user = ServerProxy.GetProxy().GetUser(entityName);
                List<ARPermission> permissions = ServerProxy.GetProxy().GetAllPermissionByUserId(Convert.ToInt32(user.UserId));
                return permissions;
            }

            return null;
        }

        private List<ARPermission> GetAllPermissions()
        {
            return ServerProxy.GetProxy().GetPermissions();
        }

        //******************************* 事件 ***************************************

        private void 用户权限_Click(object sender, EventArgs e)
        {

        }

        private void 角色权限_Click(object sender, EventArgs e)
        {

        }
    }
}
