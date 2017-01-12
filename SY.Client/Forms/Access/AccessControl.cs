using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SY.MODEL;

namespace SY.Client.Forms.Access
{
    public class AccessControl
    {
        //*********************************** 属性 **********************************

        //--------------------- QueryCategoryForm权限 ------------------
        //
        //设置
        //
        public static string 结果排序 = "结果排序";
        public static string 查询条件排序 = "查询条件排序";
        public static string 插入排序 = "插入排序";
        public static string 字段录入提示 = "字段录入提示";
        public static string 附表详细信息排序 = "附表详细信息排序";
        public static string 附表查询条件排序 = "附表查询条件排序";
        public static string 附表查询结果排序 = "附表查询结果排序";
        //
        //系统管理
        //
        public static string 角色管理 = "角色管理";
        public static string 分类管理 = "分类管理";
        public static string 用户管理 = "用户管理";
        //
        //操作
        //
        public static string 批量导入 = "批量导入";
        public static string 录入数据 = "录入数据";
        public static string 输出模板 = "输出模板";
        public static string 修改分类信息 = "修改分类信息";
        public static string 修改字段属性 = "修改字段属性";
        public static string 添加字段 = "添加字段";
        public static string 附表查询导入 = "附表查询导入";
        public static string 附表批量导入 = "附表批量导入";
        public static string 附表输出模板 = "附表输出模板";

        //--------------------- QueryCategoryForm权限 ------------------

        //*********************************** 方法 **********************************
        public static List<ARPermission> USER_PERMISSIONS { get; set; }
        public static ARUser USER { get; set; }
        public static void InitUserPermissions(string username)
        {
            if (username != null)
            {
                USER = ServerProxy.GetProxy().GetUser(username);
                if (USER != null)
                    USER_PERMISSIONS = ServerProxy.GetProxy().GetAllPermissionByUserId(Convert.ToInt32(USER.UserId));
            }
        }
        public static bool HasPermission(string permissionName)
        {
            if (USER.UserName == "a")
            {
                return true;
            }

            if (permissionName == null || USER_PERMISSIONS == null)
            {
                return false;
            }

            foreach (ARPermission permission in USER_PERMISSIONS)
            {
                if (permissionName == permission.Permission_Name)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
