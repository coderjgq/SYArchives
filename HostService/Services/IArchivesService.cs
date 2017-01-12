using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using SY.MODEL;
using System.Collections;

namespace HostService.Services
{
    [ServiceContract]
    public interface IArchivesService
    {
        #region ACL
        [OperationContract]
        bool ExistACL(int entityId, int permissionId, string type);
        [OperationContract]
        string AddACL(ARACL acl);
        [OperationContract]
        string UpdateACL(ARACL acl);
        [OperationContract]
        string DeleteACLById(int aclId);
        [OperationContract]
        string DeleteACLByUserId(int userId);
        [OperationContract]
        string DeleteACLByRoleId(int roleId);
        [OperationContract]
        string DeleteACL(ARACL acl);
        #endregion

        #region permission
        [OperationContract]
        ARPermission GetPermission(string permissionName);
        [OperationContract]
        List<ARPermission> GetPermissionsByRoleId(int roleId);
        [OperationContract]
        List<ARPermission> GetPermissionsByUserId(int userId);
        [OperationContract]
        List<ARPermission> GetPermissions();
        [OperationContract]
        List<ARPermission> GetRolePermissionsByUserId(int userid);
        [OperationContract]
        List<ARPermission> GetAllPermissionByUserId(int userid);
        [OperationContract]
        string AddPermission(string permissionName);
        [OperationContract]
        string DeletePermission(string permissionName);
        #endregion

        #region user-role
        [OperationContract]
        string AddUserRole(int userId, int roleId);
        [OperationContract]
        string DeleteUserRole(int userId, int roleId);
        [OperationContract]
        string DeleteUserRoleByUserId(int userId);
        [OperationContract]
        string DeleteUserRoleByRoleId(int roleId);
        [OperationContract]
        List<ARRole> GetRolesByUserId(int userid);
        #endregion

        #region role
        [OperationContract]
        List<ARRole> GetRoles();
        [OperationContract]
        ARRole GetRole(string roleName);
        [OperationContract]
        string DeleteRole(string roleName);
        [OperationContract]
        string UpdateRole(ARRole role);
        [OperationContract]
        string AddRole(ARRole role);
        [OperationContract]
        bool ExistRole(string roleName);
        [OperationContract]
        string Delete_Role_UserRole(string roleName);
        #endregion

        #region user
        [OperationContract]
        string AddUser(ARUser arUser);
        [OperationContract]
        List<ARUser> GetUsers();
        [OperationContract]
        ARUser GetUser(string userName);
        [OperationContract]
        bool ExistUser(string userName);
        [OperationContract]
        string DeleteUser(string userName);
        [OperationContract]
        string ModifyUser(ARUser user);
        [OperationContract]
        string Delete_User_Role_ACL_Config(string userName);
        #endregion

        #region 增加新字段
        [OperationContract]
        bool AddColumn(ARColumn arColumn);
        [OperationContract]
        bool AddColumnToCategory(ARColumn arColumn);
        #endregion

        #region 增加分类
        [OperationContract]
        bool AddCategory(ARCategory arCategory);
        [OperationContract]
        bool DeleteCategory(ARCategory arCategory);
        [OperationContract]
        List<string> getCategoryNames();
        [OperationContract]
        List<ARCategory> GetCategorys();
        [OperationContract]
        bool UpdateCategory(ARCategory newCategory, string oldCategoryName);
        [OperationContract]
        string GetCategoryName(string categoryDescription);
        #endregion

        #region 其它
        [OperationContract]
        List<string> GetTableColumns(string tableName);
        [OperationContract]
        List<ARColumn> GetColumnTypes(List<string> columnList);

        [OperationContract]
        ARColumn GetColumnType(string columnName);

        [OperationContract]
        int insertCategory(string sqlStr);

        [OperationContract]
        string GetDescription(string columnName);
        [OperationContract]
        List<string> GetTableColumnDescriptions(string tableName);


        [OperationContract]
        void SaveConfig(string configKey, string configValue,string userName);
        [OperationContract]
        string GetConfigValue(string configKey, string userName);

        [OperationContract]
        string GetColumnByDescriptionAndCategory(string description, string categoryName);
        [OperationContract]
        string GetColumnByDescription(string description);

        [OperationContract]
        List<string> QueryArchivesID(string queryStr);

        [OperationContract]
        List<List<string>> GetQueryResult(string[] resultOrder, string sqlstr);
        [OperationContract]
        bool ColumnExist(string columnName);
        [OperationContract]
        bool CategoryExist(string categoryName, string categoryDescription);

        [OperationContract]
        bool SaveCategoryPrimaryKey(string categoryName, string primaryKey);
        [OperationContract]
        string GetCategoryPrimaryKey(string categoryName);
        [OperationContract]
        bool ExecuteSqlTran(List<String> SQLStringList);
        [OperationContract]
        bool ModifyColumnType(ARColumn oldColumn, ARColumn newColumn);

        [OperationContract]
        List<string> GetCategoryTableNames();
        [OperationContract]
        ARCategory GetCategory(string categoryName);
        [OperationContract]
        Dictionary<string, List<string>> GetColumnReminders();
        [OperationContract]
        List<string> GetReminderColumnNames();
        [OperationContract]
        List<ARReminder> GetReminders();
        [OperationContract]
        ARReminder GetReminder(string columnName);
        [OperationContract]
        string SaveReminder(ARReminder reminder);
        [OperationContract]
        List<string> GetAllColummnNames();
        [OperationContract]
        string DeleteReminder(string columnName);

        [OperationContract]
        string ExcuteNonQuery(string sqlStr);

        [OperationContract]
        int GetTotal(string queryStr);
        [OperationContract]
        ARCategory GetCategoryByDescription(string categoryDescription);
        [OperationContract]
        List<NameContentPair> GetRecord(string categoryTableName, int archivesId);
        [OperationContract]
        string UserLogin(string userName, string pwd);
        [OperationContract]
        List<string> GetAllColumnDescriptions();
        #endregion








        
    }
}
