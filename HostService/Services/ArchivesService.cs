using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using SY.DAL;
using SY.MODEL;
using System.Data;
using System.Collections;

namespace HostService.Services
{
    [ServiceBehavior]
    public class ArchivesService : IArchivesService
    {
        #region ACL
        [OperationBehavior]
        public bool ExistACL(int entityId, int permissionId, string type)
        {
            return DBHelper.ExistACL(entityId, permissionId, type);
        }
        [OperationBehavior]
        public string AddACL(ARACL acl)
        {
            return DBHelper.AddACL(acl);
        }
        [OperationBehavior]
        public string UpdateACL(ARACL acl)
        {
            return DBHelper.UpdateACL(acl);
        }
        [OperationBehavior]
        public string DeleteACLById(int aclId)
        {
            return DBHelper.DeleteACLById(aclId);
        }
        [OperationBehavior]
        public string DeleteACLByUserId(int userId)
        {
            return DBHelper.DeleteACLByUserId(userId);
        }
        [OperationBehavior]
        public string DeleteACLByRoleId(int roleId)
        {
            return DBHelper.DeleteACLByRoleId(roleId);
        }
        [OperationBehavior]
        public string DeleteACL(ARACL acl)
        {
            return DBHelper.DeleteACL(acl);
        }
        #endregion
        #region permission
        [OperationBehavior]
        public ARPermission GetPermission(string permissionName)
        {
            return DBHelper.GetPermission(permissionName);
        }
        [OperationBehavior]
        public List<ARPermission> GetPermissionsByRoleId(int roleId)
        {
            return DBHelper.GetPermissionsByRoleId(roleId);
        }
        [OperationBehavior]
        public List<ARPermission> GetPermissionsByUserId(int userId)
        {
            return DBHelper.GetPermissionsByUserId(userId);
        }
        [OperationBehavior]
        public List<ARPermission> GetPermissions()
        {
            return DBHelper.GetPermissions();
        }
        [OperationBehavior]
        public List<ARPermission> GetRolePermissionsByUserId(int userid)
        {
            return DBHelper.GetRolePermissionsByUserId(userid);
        }
        [OperationBehavior]
        public List<ARPermission> GetAllPermissionByUserId(int userid)
        {
            return DBHelper.GetAllPermissionByUserId(userid);
        }
        [OperationBehavior]
        public string AddPermission(string permissionName)
        {
            return DBHelper.AddPermission(permissionName);
        }
        [OperationBehavior]
        public string DeletePermission(string permissionName)
        {
            return DBHelper.DeletePermission(permissionName);
        }
        #endregion

        #region user-role

        [OperationBehavior]
        public string AddUserRole(int userId, int roleId)
        {
            return DBHelper.AddUserRole(userId, roleId);
        }

        [OperationBehavior]
        public string DeleteUserRole(int userId, int roleId)
        {
            return DBHelper.DeleteUserRole(userId, roleId);
        }
        [OperationBehavior]
        public string DeleteUserRoleByUserId(int userId)
        {
            return DBHelper.DeleteUserRoleByUserId(userId);
        }
        [OperationBehavior]
        public string DeleteUserRoleByRoleId(int roleId)
        {
            return DBHelper.DeleteUserRoleByRoleId(roleId);
        }
        [OperationBehavior]
        public List<ARRole> GetRolesByUserId(int userid)
        {
            return DBHelper.GetRolesByUserId(userid);
        }
        #endregion

        #region role
        [OperationBehavior]
        public bool ExistRole(string roleName)
        {
            return DBHelper.ExistRole(roleName);
        }
        [OperationBehavior]
        public string AddRole(ARRole role)
        {
            return DBHelper.AddRole(role);
        }
        [OperationBehavior]
        public List<ARRole> GetRoles()
        {
            return DBHelper.GetRoles();
        }

        [OperationBehavior]
        public ARRole GetRole(string roleName)
        {
            return DBHelper.GetRole(roleName);
        }
        [OperationBehavior]
        public string DeleteRole(string roleName)
        {
            return DBHelper.DeleteRole(roleName);
        }
        [OperationBehavior]
        public string UpdateRole(ARRole role)
        {
            return DBHelper.UpdateRole(role);
        }
        [OperationBehavior]
        public string Delete_Role_UserRole(string roleName)
        {
            return DBHelper.Delete_Role_UserRole(roleName);
        }
        #endregion

        #region 用户
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="arUser"></param>
        [OperationBehavior]
        public string AddUser(ARUser arUser)
        {
            return DBHelper.AddUser(arUser);
        }
        [OperationBehavior]
        public List<ARUser> GetUsers()
        {
            return DBHelper.GetUsers();
        }
        [OperationBehavior]
        public ARUser GetUser(string userName)
        {
            return DBHelper.GetUser(userName);
        }
        [OperationBehavior]
        public string ModifyUser(ARUser user)
        {
            return DBHelper.ModifyUser(user);
        }
        [OperationBehavior]
        public string UserLogin(string userName, string pwd)
        {
            return DBHelper.UserLogin(userName, pwd);
        }
        [OperationBehavior]
        public bool ExistUser(string userName)
        {
            return DBHelper.ExistUser(userName);
        }
        [OperationBehavior]
        public string DeleteUser(string userName)
        {
            return DBHelper.DeleteUser(userName);
        }
        [OperationBehavior]
        public string Delete_User_Role_ACL_Config(string userName)
        {
            return DBHelper.Delete_User_Role_ACL_Config(userName);
        }
        #endregion

        #region 增加新字段
        [OperationBehavior]
        public bool AddColumn(ARColumn arColumn)
        {
            Column column = new Column();
            return column.AddColumn(arColumn);
        }
        [OperationBehavior]
        public bool AddColumnToCategory(ARColumn arColumn)
        {
            Column column = new Column();
            return column.AddColumnToCategory(arColumn);
        }
        #endregion

        #region 增加分类
        [OperationBehavior]
        public bool AddCategory(ARCategory arCategory)
        {
            Category category = new Category();
            return category.AddCategory(arCategory);
        }
        [OperationBehavior]
        public bool DeleteCategory(ARCategory arCategory)
        {
            return new Category().DeleteCategory(arCategory);
        }
        [OperationBehavior]
        public List<string> getCategoryNames()
        {
            return new Category().getCategoryNames();
        }

        [OperationBehavior]
        public int insertCategory(string sqlStr)
        {
            return new Category().insertCategory(sqlStr);
        }
        [OperationBehavior]
        public bool CategoryExist(string categoryName, string categoryDescription)
        {
            return new Category().CategoryExist(categoryName, categoryDescription);
        }

        [OperationBehavior]
        public List<ARCategory> GetCategorys()
        {
            return new Category().GetCategorys();
        }
        [OperationBehavior]
        public bool UpdateCategory(ARCategory newCategory, string oldCategoryName)
        {
            return new Category().UpdateCategory(newCategory, oldCategoryName);
        }

        [OperationBehavior]
        public string GetCategoryName(string categoryDescription)
        {
            return new Category().GetCategoryName(categoryDescription);
        }

        #endregion

        #region 其他
        [OperationBehavior]
        public List<string> GetTableColumns(string tableName)
        {
            return new Column().GetTableColumns(tableName);
        }

        [OperationBehavior]
        public List<ARColumn> GetColumnTypes(List<string> columnList)
        {
            return new Column().GetColumnTypes(columnList);
        }

        [OperationBehavior]
        public ARColumn GetColumnType(string columnName)
        {
            return new Column().GetColumnType(columnName);
        }

        [OperationBehavior]
        public String GetDescription(string columnName)
        {
            return new Column().GetDescription(columnName);
        }

        [OperationBehavior]
        public List<string> GetTableColumnDescriptions(string tableName)
        {
            return new Column().GetTableColumnDescriptions(tableName);
        }

        [OperationBehavior]
        public void SaveConfig(string configKey, string configValue,string userName)
        {
            new Column().SaveConfig(configKey, configValue,userName);
        }
        [OperationBehavior]
        public string GetConfigValue(string configKey,string userName)
        {
            return new Column().GetConfigValue(configKey,userName);
        }
        [OperationBehavior]
        public string GetColumnByDescriptionAndCategory(string description, string categoryName)
        {
            return DBHelper.GetColumnByDescriptionAndCategory(description, categoryName);
        }
        [OperationBehavior]
        public string GetColumnByDescription(string description)
        {
            return DBHelper.GetColumnByDescription(description);
        }
        [OperationBehavior]
        public List<string> QueryArchivesID(string queryStr)
        {
            return new Column().QueryArchivesID(queryStr);
        }
        [OperationBehavior]
        public List<List<string>> GetQueryResult(string[] resultOrder, string sqlstr)
        {
            return new Column().GetQueryResult(resultOrder, sqlstr);
        }
        [OperationBehavior]
        public bool ColumnExist(string fieldName)
        {
            return new Column().ColumnExist(fieldName);
        }
        [OperationBehavior]
        public bool SaveCategoryPrimaryKey(string categoryName, string primaryKey)
        {
            return new Category().SaveCategoryPrimaryKey(categoryName, primaryKey);
        }
        [OperationBehavior]
        public string GetCategoryPrimaryKey(string categoryName)
        {
            return new Category().GetCategoryPrimaryKey(categoryName);
        }

        [OperationBehavior]
        public bool ExecuteSqlTran(List<String> SQLStringList)
        {
            return new Category().ExecuteSqlTran(SQLStringList);
        }
        [OperationBehavior]
        public bool ModifyColumnType(ARColumn oldColumn, ARColumn newColumn)
        {
            return new Column().ModifyColumnType(oldColumn, newColumn);
        }
        [OperationBehavior]
        public List<string> GetCategoryTableNames()
        {
            return new Category().GetCategoryTableNames();
        }

        [OperationBehavior]
        public ARCategory GetCategory(string categoryName)
        {
            return new Category().GetCategory(categoryName);
        }
        [OperationBehavior]
        public Dictionary<string, List<string>> GetColumnReminders()
        {
            return new Column().GetColumnReminders();
        }
        [OperationBehavior]
        public List<ARReminder> GetReminders()
        {
            return DBHelper.GetReminders();
        }
        [OperationBehavior]
        public string SaveReminder(ARReminder reminder)
        {
            return DBHelper.SaveReminder(reminder);
        }
        [OperationBehavior]
        public List<string> GetReminderColumnNames()
        {
            return DBHelper.GetReminderColumnNames();
        }
        [OperationBehavior]
        public ARReminder GetReminder(string columnName)
        {
            return DBHelper.GetReminder(columnName);
        }
        [OperationBehavior]
        public List<string> GetAllColummnNames()
        {
            return DBHelper.GetAllColummnNames();
        }
        [OperationBehavior]
        public string DeleteReminder(string columnName)
        {
            return DBHelper.DeleteReminder(columnName);
        }
        [OperationBehavior]
        public string ExcuteNonQuery(string sqlStr)
        {
            return DBHelper.ExcuteNonQuery(sqlStr);
        }
        [OperationBehavior]
        public int GetTotal(string queryStr)
        {
            return DBHelper.GetTotal(queryStr);
        }
        [OperationBehavior]
        public ARCategory GetCategoryByDescription(string categoryDescription)
        {
            return DBHelper.GetCategoryByDescription(categoryDescription);
        }
        [OperationBehavior]
        public List<NameContentPair> GetRecord(string categoryTableName, int archivesId)
        {
            return DBHelper.GetRecord(categoryTableName, archivesId);
        }
        [OperationBehavior]
        public List<string> GetAllColumnDescriptions()
        {
            return DBHelper.GetAllColumnDescriptions();
        }
        #endregion
    }
}
