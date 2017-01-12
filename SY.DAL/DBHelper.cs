using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Data;
using Oracle.DataAccess.Client;
using SY.MODEL;
using System.Data.SqlClient;

namespace SY.DAL
{
    /// <summary>
    /// SqlHelper SQL数据库访问组件
    /// </summary>
    public abstract class DBHelper
    {
        /// <summary>
        /// 数据库连接字串
        /// </summary>
        public static readonly string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        //缓存参数Hashtable
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        public static List<NameContentPair> GetRecord(string categoryTableName, int archivesId)
        {
            string sqlStr = "select * from " + categoryTableName + " where ARCHIVESID = " + archivesId;
            List<NameContentPair> ret = new List<NameContentPair>();
            NameContentPair tmp = null;
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    OracleDataReader data = cmd.ExecuteReader();
                    if (data.Read())
                    {
                        int count = data.FieldCount;
                        for (int i = 0; i < count; i++)
                        {
                            try
                            {
                                string name = data.GetName(i);
                                string content = data.GetString(i);
                                tmp = new NameContentPair();
                                tmp.name = name;
                                tmp.content = content;
                                ret.Add(tmp);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(">>>>>GetRecord::" + ex.Message);
                            }
                        }
                    }
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ret;
                }
            }
            return ret;
        }

        public static ARCategory GetCategoryByDescription(string categoryDescription)
        {
            OracleCommand cmd = new OracleCommand();
            ARCategory c = new ARCategory();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_CATEGORY where CATEGORY_DESCRIPTION = '" + categoryDescription + "'";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {

                    try
                    {
                        c._NAME = data.GetString(data.GetOrdinal("CATEGORY_NAME"));
                    }
                    catch
                    {
                        //c._NAME = "";
                    }

                    try
                    {
                        c._TYPE = data.GetString(data.GetOrdinal("CATEGORY_TYPE"));
                    }
                    catch
                    {
                        // c._TYPE = "";
                    }

                    try
                    {
                        c._DESCRIPTION = data.GetString(data.GetOrdinal("CATEGORY_DESCRIPTION"));
                    }
                    catch
                    { //c._WJ_NO_COMPONENT = ""; 
                    }

                    try
                    {
                        c._PARENT_NO = data.GetString(data.GetOrdinal("CATEGORY_PARENT_NO"));
                    }

                    catch
                    { //c._CHILD_NOS = ""; 
                    }

                    try
                    {
                        c._AJ_NO_COMPONENT = data.GetString(data.GetOrdinal("CATEGORY_AJ_NO_COMPONENT"));
                    }
                    catch
                    { //c._AJ_NO_COMPONENT = ""; 
                    }

                    try
                    {
                        c._AJH_COUNT = data.GetString(data.GetOrdinal("CATEGORY_AJH_COUNT"));
                    }
                    catch
                    { //c._AJH_COUNT = ""; 
                    }


                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return c;
        }

        public static int GetTotal(string queryStr)
        {
            int total = 0;
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                OracleDataReader data = null;
                try
                {
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, queryStr, null);
                    data = cmd.ExecuteReader();
                    if (data.Read())
                    {
                        total = Convert.ToInt32(data[0]);
                    }
                    cmd.Parameters.Clear();
                    data.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (data != null)
                    {
                        data.Close();
                    }
                    return -1;
                }
            }
            return total;
        }

        public static List<string> GetAllColummnNames()
        {
            List<string> columnNames = new List<string>();
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select FIELDNAME from T_FIELD_MEDATA";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    string columnName;
                    try
                    {
                        columnName = data.GetString(data.GetOrdinal("FIELDNAME"));
                        columnNames.Add(columnName.Trim());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return columnNames;
        }

        public static bool DeleteCategory(ARCategory arCategory)
        {
            List<string> sqls = new List<string>();
            DeleteCategoryTree(arCategory, sqls);
            for (int i = 0; i < sqls.Count; i++)
            {
                Console.WriteLine(sqls[i]);
            }
            return ExecuteSqlTran(sqls);
        }

        public static void DeleteCategoryTree(ARCategory arCategory, List<string> sqls)
        {
            if (sqls == null)
            {
                sqls = new List<string>();
            }
            string sql1 = "delete from T_CATEGORY where CATEGORY_NAME = '" + arCategory._NAME + "'";
            string sql2 = "drop table T_" + arCategory._TYPE + "_" + arCategory._NAME;
            string sql3 = "drop table T_" + arCategory._TYPE + "_" + arCategory._NAME + "_Attached";
            string sql4 = "delete from T_CONFIG where CONFIGKEY like 'T_" + arCategory._TYPE + "_" + arCategory._NAME + "%'";
            sqls.Add(sql1);
            sqls.Add(sql2);
            sqls.Add(sql3);
            sqls.Add(sql4);
            List<ARCategory> ars = GetChildren(arCategory._NAME);
            for (int i = 0; i < ars.Count; i++)
            {
                DeleteCategoryTree(ars[i], sqls);
            }
        }

        public static List<ARCategory> GetChildren(string categoryName)
        {

            OracleCommand cmd = new OracleCommand();
            List<ARCategory> ret = new List<ARCategory>();

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_CATEGORY where CATEGORY_PARENT_NO = \'" + categoryName + "\'";
                Console.WriteLine(sqlStr);
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    ARCategory c = new ARCategory();
                    try
                    {
                        c._NAME = data.GetString(data.GetOrdinal("CATEGORY_NAME"));
                    }
                    catch
                    {
                        //c._NAME = "";
                    }

                    try
                    {
                        c._TYPE = data.GetString(data.GetOrdinal("CATEGORY_TYPE"));
                    }
                    catch
                    {
                        // c._TYPE = "";
                    }

                    try
                    {
                        c._DESCRIPTION = data.GetString(data.GetOrdinal("CATEGORY_DESCRIPTION"));
                    }
                    catch
                    { //c._WJ_NO_COMPONENT = ""; 
                    }

                    try
                    {
                        c._PARENT_NO = data.GetString(data.GetOrdinal("CATEGORY_PARENT_NO"));
                    }

                    catch
                    { //c._CHILD_NOS = ""; 
                    }

                    try
                    {
                        c._AJ_NO_COMPONENT = data.GetString(data.GetOrdinal("CATEGORY_AJ_NO_COMPONENT"));
                    }
                    catch
                    { //c._AJ_NO_COMPONENT = ""; 
                    }

                    try
                    {
                        c._AJH_COUNT = data.GetString(data.GetOrdinal("CATEGORY_AJH_COUNT"));
                    }
                    catch
                    { //c._AJH_COUNT = ""; 
                    }

                    ret.Add(c);
                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static string GetCategoryName(string categoryDescription)
        {
            OracleCommand cmd = new OracleCommand();
            string ret = "";
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select CATEGORY_NAME from T_CATEGORY where CATEGORY_DESCRIPTION = '" + categoryDescription + "'";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();

                if (data.Read())
                {
                    try
                    {
                        ret = data.GetString(data.GetOrdinal("CATEGORY_NAME"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static bool UpdateCategory(ARCategory newCategory, string oldCategoryName)
        {
            OracleCommand cmd = new OracleCommand();
            bool ret = false;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    string sqlStr = "update T_CATEGORY set " +
                        "CATEGORY_AJ_NO_COMPONENT = '" + newCategory._AJ_NO_COMPONENT + "'," +
                        "CATEGORY_NAME = '" + newCategory._NAME + "'," +
                        "CATEGORY_DESCRIPTION = '" + newCategory._DESCRIPTION + "'," +
                        "CATEGORY_AJH_COUNT = '" + newCategory._AJH_COUNT + "'," +
                        "CATEGORY_TYPE = '" + newCategory._TYPE + "'," +
                        "CATEGORY_PARENT_NO = '" + newCategory._PARENT_NO + "'" +
                        " where CATEGORY_NAME = '" + oldCategoryName + "'";
                    //Console.WriteLine(sqlStr);
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    //cmd.Parameters.Clear();
                    ret = true;
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    ret = false;
                }
            }
            return ret;
        }

        public static List<string> GetCategoryTableNames()
        {
            OracleCommand cmd = new OracleCommand();
            List<string> ret = new List<string>();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from tab";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    string tableName = data.GetString(data.GetOrdinal("TNAME"));
                    if (!tableName.Equals("T_CATEGORY") &&
                        !tableName.Equals("T_CONFIG") &&
                        !tableName.Equals("T_FIELD_MEDATA") &&
                        !tableName.Equals("T_USER") &&
                        !tableName.Equals("T_USER_ROLE") &&
                        !tableName.Equals("T_ROLE") &&
                        !tableName.Equals("T_REMINDER") &&
                        !tableName.Equals("T_PERMISSION") &&
                        !tableName.Equals("T_ACL")
                        )
                        ret.Add(tableName);
                }
                data.Close();
                cmd.Parameters.Clear();
            }

            return ret;
        }

        public static bool ModifyColumnType(ARColumn oldColumn, ARColumn newColumn)
        {
            List<string> sqls = new List<string>();
            string sqlstr1 = "update T_FIELD_MEDATA set FIELDNAME = \'" + newColumn.FieldName + "\'" +
                                                       " , DESCRIPTION = \'" + newColumn.Description + "\'" +
                                                       " , ALLOWEMPTY = \'" + newColumn.AllowEmpty + "\'" +
                                                       " , FIELDTYPE = \'" + newColumn.FieldType + "\'" +
                                                       " , CATEGORYNAME = \'" + newColumn.Category + "\'" +
                                                       " , SYSTEMCOLUM = \'" + newColumn.SystemColum + "\'" +
                                                       " , BYTES = \'" + newColumn.Bytes + "\'" +
                                                       " where FIELDID = " + oldColumn.FieldId + "";
            sqls.Add(sqlstr1);
            //
            //根据是否是系统字段，系统字段所有表的字段都要修改，非系统字段只要修改一张表
            //
            if (oldColumn.Category.Trim().Equals(""))
            {
                List<string> tableNames = GetCategoryTableNames();
                for (int i = 0; i < tableNames.Count; i++)
                {
                    List<string> columns = GetTableColumns(CommandType.Text, tableNames[i]);
                    if (columns.Contains(oldColumn.FieldName))
                    {
                        //
                        //位数有变化
                        //
                        if (!oldColumn.Bytes.Equals(newColumn.Bytes))
                        {
                            string sql2 = "alter table " + tableNames[i] + " modify " + oldColumn.FieldName + " varchar(" + newColumn.Bytes + ")";
                            sqls.Add(sql2);
                        }

                        //
                        //名字有变化
                        //
                        if (!oldColumn.FieldName.Equals(newColumn.FieldName))
                        {
                            string sql2 = "alter table " + tableNames[i] + " rename column " + oldColumn.FieldName + " to " + newColumn.FieldName;
                            sqls.Add(sql2);
                        }
                    }
                }
            }
            else
            {
                //
                //位数有变化
                //
                if (!oldColumn.Bytes.Equals(newColumn.Bytes))
                {
                    ARCategory c = GetCategory(oldColumn.Category);
                    string categoryTableName = "T_" + c._TYPE + "_" + c._NAME;
                    string sql2 = "alter table " + categoryTableName + " modify " + oldColumn.FieldName + " varchar(" + newColumn.Bytes + ")";
                    sqls.Add(sql2);
                }

                //
                //名字有变化
                //
                if (!oldColumn.FieldName.Equals(newColumn.FieldName))
                {
                    ARCategory c = GetCategory(oldColumn.Category);
                    string categoryTableName = "T_" + c._TYPE + "_" + c._NAME;
                    string sql2 = "alter table " + categoryTableName + " rename column " + oldColumn.FieldName + " to " + newColumn.FieldName;
                    sqls.Add(sql2);
                }
            }

            for (int i = 0; i < sqls.Count; i++)
            {
                Console.WriteLine(i + " " + sqls[i]);
            }

            return ExecuteSqlTran(sqls);
            //return false;
        }

        public static bool ExecuteSqlTran(List<String> SQLStringList)
        {
            //Console.WriteLine(">>>>> ExecuteSqlTran");
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                OracleTransaction tx = conn.BeginTransaction();

                try
                {
                    foreach (string sql in SQLStringList)
                    {
                        if (!String.IsNullOrEmpty(sql))
                        {
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (OracleException E)
                {
                    Console.WriteLine(E.Message);
                    tx.Rollback();
                    return false;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
            return true;
        }

        public static List<ARCategory> GetCategorys()
        {
            OracleCommand cmd = new OracleCommand();
            List<ARCategory> ret = new List<ARCategory>();

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_CATEGORY order by CATEGORY_NO";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    ARCategory c = new ARCategory();
                    try
                    {
                        c._NAME = data.GetString(data.GetOrdinal("CATEGORY_NAME"));
                    }
                    catch
                    {
                        //c._NAME = "";
                    }

                    try
                    {
                        c._TYPE = data.GetString(data.GetOrdinal("CATEGORY_TYPE"));
                    }
                    catch
                    {
                        // c._TYPE = "";
                    }

                    try
                    {
                        c._DESCRIPTION = data.GetString(data.GetOrdinal("CATEGORY_DESCRIPTION"));
                    }
                    catch
                    { //c._WJ_NO_COMPONENT = ""; 
                    }

                    try
                    {
                        c._PARENT_NO = data.GetString(data.GetOrdinal("CATEGORY_PARENT_NO"));
                    }

                    catch
                    { //c._CHILD_NOS = ""; 
                    }

                    try
                    {
                        c._AJ_NO_COMPONENT = data.GetString(data.GetOrdinal("CATEGORY_AJ_NO_COMPONENT"));
                    }
                    catch
                    { //c._AJ_NO_COMPONENT = ""; 
                    }

                    try
                    {
                        c._AJH_COUNT = data.GetString(data.GetOrdinal("CATEGORY_AJH_COUNT"));
                    }
                    catch
                    { //c._AJH_COUNT = ""; 
                    }

                    ret.Add(c);
                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static ARCategory GetCategory(string categoryName)
        {
            OracleCommand cmd = new OracleCommand();
            ARCategory c = new ARCategory();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_CATEGORY where CATEGORY_NAME = '" + categoryName + "'";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {

                    try
                    {
                        c._NAME = data.GetString(data.GetOrdinal("CATEGORY_NAME"));
                    }
                    catch
                    {
                        //c._NAME = "";
                    }

                    try
                    {
                        c._TYPE = data.GetString(data.GetOrdinal("CATEGORY_TYPE"));
                    }
                    catch
                    {
                        // c._TYPE = "";
                    }

                    try
                    {
                        c._DESCRIPTION = data.GetString(data.GetOrdinal("CATEGORY_DESCRIPTION"));
                    }
                    catch
                    { //c._WJ_NO_COMPONENT = ""; 
                    }

                    try
                    {
                        c._PARENT_NO = data.GetString(data.GetOrdinal("CATEGORY_PARENT_NO"));
                    }

                    catch
                    { //c._CHILD_NOS = ""; 
                    }

                    try
                    {
                        c._AJ_NO_COMPONENT = data.GetString(data.GetOrdinal("CATEGORY_AJ_NO_COMPONENT"));
                    }
                    catch
                    { //c._AJ_NO_COMPONENT = ""; 
                    }

                    try
                    {
                        c._AJH_COUNT = data.GetString(data.GetOrdinal("CATEGORY_AJH_COUNT"));
                    }
                    catch
                    { //c._AJH_COUNT = ""; 
                    }


                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return c;
        }

        public static string GetCategoryPrimaryKey(string categoryName)
        {
            OracleCommand cmd = new OracleCommand();
            string ret = null;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select CATEGORY_AJ_NO_COMPONENT from T_CATEGORY where CATEGORY_NAME = '" + categoryName + "'";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();

                if (data.Read())
                {
                    try
                    {
                        ret = data.GetString(data.GetOrdinal("CATEGORY_AJ_NO_COMPONENT"));
                    }
                    catch
                    {

                    }
                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static bool SaveCategoryPrimaryKey(string categoryName, string primaryKey)
        {
            OracleCommand cmd = new OracleCommand();
            bool ret = false;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    string sqlStr = "update T_CATEGORY set CATEGORY_AJ_NO_COMPONENT = '" + primaryKey + "' where CATEGORY_NAME = '" + categoryName + "'";
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    //cmd.Parameters.Clear();
                }
                catch
                {
                    cmd.Parameters.Clear();
                    ret = false;
                }
            }
            return ret;
        }

        /// <summary>
        /// 根据指定字段和查询sql返回结果
        /// </summary>
        /// <param name="resultOrder">选择的字段</param>
        /// <param name="sqltr"></param>
        /// <returns></returns>
        public static List<List<string>> GetQueryResult(string[] selectedColumns, string sqltr)
        {
            OracleCommand cmd = new OracleCommand();
            List<List<string>> ret = new List<List<string>>();
            try
            {
                using (OracleConnection conn = new OracleConnection(ConnectionString))
                {
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqltr, null);
                    OracleDataReader data = cmd.ExecuteReader();

                    while (data.Read())
                    {
                        List<string> row = new List<string>();
                        for (int i = 0; i < selectedColumns.Length; i++)
                        {
                            int index = data.GetOrdinal(selectedColumns[i]);
                            string tmp = "";
                            try
                            {
                                if (selectedColumns[i].Trim().Equals("ARCHIVESID"))
                                {
                                    tmp = data.GetInt64(index) + "";
                                }
                                else
                                {
                                    tmp = data.GetString(index);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                tmp = "null";
                            }
                            row.Add(tmp);
                        }
                        ret.Add(row);
                    }
                    data.Close();
                    cmd.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
        }

        public static List<string> QueryArchivesID(string queryStr)
        {
            OracleCommand cmd = new OracleCommand();
            List<string> ret = new List<string>();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, queryStr, null);
                OracleDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    long tmp = data.GetInt64(data.GetOrdinal("ARCHIVESID"));
                    ret.Add(tmp + "");
                }
                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        /// <summary>
        /// 根据描述获取字段名称,先根据description和categoryName获取，若没有根据description获取
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string GetColumnByDescriptionAndCategory(string description, string categoryName)
        {
            OracleCommand cmd = new OracleCommand();
            string ret = null;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select FIELDNAME from T_FIELD_MEDATA where DESCRIPTION = '" + description + "' and CATEGORYNAME = '" + categoryName + "'";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();

                if (data.Read())
                {
                    ret = data.GetString(data.GetOrdinal("FIELDNAME"));
                }
                else
                {
                    sqlStr = "select FIELDNAME from T_FIELD_MEDATA where DESCRIPTION = '" + description + "'";
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    data = cmd.ExecuteReader();
                    if (data.Read())
                    {
                        ret = data.GetString(data.GetOrdinal("FIELDNAME"));
                    }
                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static string GetColumnByDescription(string description)
        {
            OracleCommand cmd = new OracleCommand();
            string ret = null;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select FIELDNAME from T_FIELD_MEDATA where DESCRIPTION = '" + description + "'";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();

                if (data.Read())
                {
                    ret = data.GetString(data.GetOrdinal("FIELDNAME"));
                }
                else
                {
                    sqlStr = "select FIELDNAME from T_FIELD_MEDATA where DESCRIPTION = '" + description + "'";
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    data = cmd.ExecuteReader();
                    if (data.Read())
                    {
                        ret = data.GetString(data.GetOrdinal("FIELDNAME"));
                    }
                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static List<string> GetTableColumnDescriptions(string tableName)
        {
            OracleCommand cmd = new OracleCommand();
            List<string> ret = new List<string>();

            //
            //首先获取ColumnNames
            //
            List<string> columnames = GetTableColumns(System.Data.CommandType.Text, tableName);
            //
            //获取每个Column的description
            //
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                for (int i = 0; i < columnames.Count; i++)
                {
                    string sqlStr = "select DESCRIPTION from T_FIELD_MEDATA where FIELDNAME = '" + columnames[i] + "'";
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    OracleDataReader data = cmd.ExecuteReader();
                    if (data.Read())
                    {
                        ret.Add((string)data.GetString(data.GetOrdinal("DESCRIPTION")));
                    }
                    else
                    {
                        data.Close();
                        cmd.Parameters.Clear();
                    }
                    data.Close();
                    cmd.Parameters.Clear();
                }
            }

            return ret;
        }

        public static bool CategoryExist(string categoryName, string categoryDescription)
        {
            OracleCommand cmd = new OracleCommand();
            bool ret = false;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_CATEGORY where CATEGORY_NAME = '" + categoryName + "' or CATEGORY_DESCRIPTION = '" + categoryDescription + "'";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    ret = true;
                }
                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static bool ColumnExist(string columnName)
        {
            OracleCommand cmd = new OracleCommand();
            bool ret = false;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_FIELD_MEDATA where FIELDNAME = '" + columnName + "'";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    ret = true;
                }
                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static string GetDescription(string columnName)
        {
            OracleCommand cmd = new OracleCommand();
            string ret = null;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select DESCRIPTION from T_FIELD_MEDATA where FIELDNAME = '" + columnName + "'";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    ret = data.GetString(data.GetOrdinal("DESCRIPTION"));
                }
                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        /// <summary>
        /// 根据字段名字获取字段的属性,没有则返回null
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static ARColumn GetColumnType(string columnName)
        {
            OracleCommand cmd = new OracleCommand();
            ARColumn c = new ARColumn();
            bool isFind = false;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_FIELD_MEDATA where FIELDNAME = '" + columnName + "'";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    isFind = true;
                    c.FieldId = data.GetInt64(data.GetOrdinal("FIELDID")) + "";
                    c.FieldName = data.GetString(data.GetOrdinal("FIELDNAME"));
                    c.FieldType = data.GetString(data.GetOrdinal("FIELDTYPE"));
                    c.Description = data.GetString(data.GetOrdinal("DESCRIPTION"));
                    c.Category = data.GetString(data.GetOrdinal("CATEGORYNAME"));
                    c.AllowEmpty = data.GetString(data.GetOrdinal("ALLOWEMPTY"));
                    c.SystemColum = data.GetString(data.GetOrdinal("SYSTEMCOLUM"));
                    c.Bytes = data.GetString(data.GetOrdinal("BYTES"));
                }
                data.Close();
                cmd.Parameters.Clear();
            }
            if (isFind)
                return c;
            return null;
        }

        /// <summary>
        /// 根据字段名字list获取字段的属性list
        /// </summary>
        /// <param name="columnList"></param>
        /// <returns></returns>
        public static List<ARColumn> GetColumnTypes(List<string> columnList)
        {
            List<ARColumn> list = new List<ARColumn>();
            for (int i = 0; i < columnList.Count; i++)
            {
                string columnName = columnList[i].ToString();
                ARColumn c = GetColumnType(columnName);
                if (c != null)
                    list.Add(c);
            }
            return list;
        }

        /// <summary>
        /// 根据字段名获取数据
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static List<string> GetResultByColumnName(CommandType cmdType, string cmdText, List<OracleParameter> commandParameters, string columnName)
        {
            OracleCommand cmd = new OracleCommand();
            List<string> list = new List<string>();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, commandParameters);
                OracleDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    string name = data.GetString(data.GetOrdinal(columnName));
                    list.Add(name);
                }
                data.Close();
                cmd.Parameters.Clear();
                return list;
            }
        }
        /// <summary>
        /// 获取表字段
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<string> GetTableColumns(CommandType cmdType, string tableName)
        {
            string sqlStr = "select tt.column_name from user_col_comments tt where tt.table_name=upper('" + tableName + "')";
            OracleCommand cmd = new OracleCommand();
            List<string> list = new List<string>();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                PrepareCommand(cmd, conn, cmdType, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    string column = data.GetString(0);
                    list.Add(column);
                }
                data.Close();
                cmd.Parameters.Clear();
            }

            return list;
        }

        public static string ExcuteNonQuery(string sqlStr)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Parameters.Clear();
                    }
                }

            }
            return "SUCCESS";
        }

        public static List<string> GetAllColumnDescriptions()
        {
            OracleCommand cmd = new OracleCommand();
            List<string> ret = new List<string>();

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select DESCRIPTION from T_FIELD_MEDATA";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    ret.Add((string)data.GetString(data.GetOrdinal("DESCRIPTION")));
                }

                data.Close();
                cmd.Parameters.Clear();
            }

            return ret;
        }

        //******************************************* Reminder ***********************************************
        public static string DeleteReminder(string columnName)
        {
            string sqlStr = "delete from T_FIELD_REMINDER where FIELD_NAME = '" + columnName + "'";
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
            return "SUCCESS";
        }

        public static List<string> GetReminderColumnNames()
        {
            List<string> columnNames = new List<string>();
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select FIELD_NAME from T_FIELD_REMINDER";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    string columnName;
                    try
                    {
                        columnName = data.GetString(data.GetOrdinal("FIELD_NAME"));
                        columnNames.Add(columnName.Trim());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return columnNames;
        }

        public static ARReminder GetReminder(string columnName)
        {
            ARReminder ar = null;
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_FIELD_REMINDER where FIELD_NAME = '" + columnName + "'";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();

                if (data.Read())
                {
                    ar = new ARReminder();
                    try
                    {
                        ar.FieldName = data.GetString(data.GetOrdinal("FIELD_NAME"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ar.Reminders = data.GetString(data.GetOrdinal("REMINDER"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    try
                    {
                        ar.Description = data.GetString(data.GetOrdinal("DESCRIPTION"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    try
                    {
                        ar.DefaultContent = data.GetString(data.GetOrdinal("DEFAULT_CONTENT"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ar.CategoryName = data.GetString(data.GetOrdinal("CATEGORY_NAME"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return ar;
        }

        public static string SaveReminder(ARReminder reminder)
        {
            //
            //判断是否存在
            //
            string isExistStr = "select * from T_FIELD_REMINDER where FIELD_NAME = '" + reminder.FieldName + "'";
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, isExistStr, null);
                    OracleDataReader data = cmd.ExecuteReader();
                    if (data.Read())
                    {
                        Console.WriteLine("update---");
                        string updateStr = " update T_FIELD_REMINDER set FIELD_NAME = '" + reminder.FieldName + "'," +
                               " CATEGORY_NAME = '" + reminder.CategoryName + "'," +
                               " REMINDER = '" + reminder.Reminders + "'," +
                               " DESCRIPTION = '" + reminder.Description + "'," +
                               " DEFAULT_CONTENT = '" + reminder.DefaultContent + "' where FIELD_NAME = '" + reminder.FieldName + "'";
                        PrepareCommand(cmd, conn, System.Data.CommandType.Text, updateStr, null);
                        Console.WriteLine(updateStr);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        Console.WriteLine("insert---");
                        string insertStr = "insert into T_FIELD_REMINDER values(T_REMINDER_SEQ.nextval,'" +
                                 reminder.FieldName + "','" +
                                 reminder.CategoryName + "','" +
                                 reminder.Reminders + "','" +
                                 reminder.Description + "','" +
                                 reminder.DefaultContent + "')";
                        PrepareCommand(cmd, conn, System.Data.CommandType.Text, insertStr, null);
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Parameters.Clear();
                    data.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
            return "SUCCESS";
        }

        public static Dictionary<string, List<string>> GetColumnReminders()
        {
            Dictionary<string, List<string>> ret = new Dictionary<string, List<string>>();
            OracleCommand cmd = new OracleCommand();

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_FIELD_REMINDER";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                string fieldname;
                string reminders;
                while (data.Read())
                {
                    try
                    {
                        fieldname = data.GetString(data.GetOrdinal("FIELD_NAME"));
                        reminders = data.GetString(data.GetOrdinal("REMINDER"));
                        if (fieldname != null && !fieldname.Trim().Equals(""))
                        {
                            string[] reminderArr = reminders.Split(',');
                            List<string> list = new List<string>();
                            for (int i = 0; i < reminderArr.Length; i++)
                            {
                                list.Add(reminderArr[i]);
                            }
                            ret.Add(fieldname, list);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static List<ARReminder> GetReminders()
        {
            List<ARReminder> reminders = new List<ARReminder>();
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_FIELD_REMINDER";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    ARReminder ar = new ARReminder();

                    try
                    {
                        ar.FieldName = data.GetString(data.GetOrdinal("FIELD_NAME"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ar.Reminders = data.GetString(data.GetOrdinal("REMINDER"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    try
                    {
                        ar.Description = data.GetString(data.GetOrdinal("DESCRIPTION"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    try
                    {
                        ar.DefaultContent = data.GetString(data.GetOrdinal("DEFAULT_CONTENT"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ar.CategoryName = data.GetString(data.GetOrdinal("CATEGORY_NAME"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    reminders.Add(ar);
                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return reminders;
        }

        //******************************************* CONFIG ***********************************************

        public static string GetConfigValue(string configKey,string userName)
        {
            OracleCommand cmd = new OracleCommand();
            string ret = null;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select CONFIGVALUE from T_CONFIG where ");
                sb.Append("CONFIGKEY = '" + configKey + "'");
                sb.Append(" and ");
                sb.Append("USERNAME = '" + userName+"'");
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sb.ToString(), null);
                OracleDataReader data = cmd.ExecuteReader();

                if (data.Read())
                {
                    try
                    {
                        ret = data.GetString(data.GetOrdinal("CONFIGVALUE"));
                    }
                    catch (Exception ex)
                    {
                        ret = "";
                        Console.WriteLine(ex.Message);
                    }
                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static void SaveConfig(string configKey, string configValue,string userName)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_CONFIG where CONFIGKEY = '" + configKey + "'";

                StringBuilder sb = new StringBuilder("select * from T_CONFIG where ");
                sb.Append("CONFIGKEY = '" + configKey + "'");
                sb.Append(" and ");
                sb.Append("USERNAME = '" + userName + "'");

                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sb.ToString(), null);
                OracleDataReader data = cmd.ExecuteReader();
                if (data.Read())  //存在Update
                {
                    data.Close();
                    cmd.Parameters.Clear();

                    //sqlStr = "update T_CONFIG where CONFIGKEY = '" + configKey + "'" + "set CONFIGVALUE = " + configValue;
                    sqlStr = "update T_CONFIG set CONFIGVALUE = '" + configValue + "' where CONFIGKEY = '" + configKey + "'";

                    sb = new StringBuilder();
                    sb.Append("update T_CONFIG set ");
                    sb.Append("CONFIGVALUE = '" + configValue+"'");
                    sb.Append(" where CONFIGKEY = '" + configKey + "'");
                    sb.Append(" and ");
                    sb.Append(" USERNAME = '" + userName + "'");

                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sb.ToString(), null);
                    data = cmd.ExecuteReader();

                    data.Close();
                    cmd.Parameters.Clear();
                }
                else //不存在Insert
                {
                    data.Close();
                    cmd.Parameters.Clear();

                    sqlStr = "insert into T_CONFIG values('" + configKey + "','" + configValue + "')";
                    sb = new StringBuilder();
                    sb.Append("insert into T_CONFIG values(");
                    sb.Append("'" + configKey+"'");
                    sb.Append(",");
                    sb.Append("'" + configValue + "'");
                    sb.Append(",");
                    sb.Append("'" + userName + "'");
                    sb.Append(")");
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sb.ToString(), null);
                    data = cmd.ExecuteReader();

                    data.Close();
                    cmd.Parameters.Clear();
                }

            }
        }

        public static string GetConfigValueBackup(string configKey)
        {
            OracleCommand cmd = new OracleCommand();
            string ret = null;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select CONFIGVALUE from T_CONFIG where CONFIGKEY = '" + configKey + "'";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();

                if (data.Read())
                {
                    try
                    {
                        ret = data.GetString(data.GetOrdinal("CONFIGVALUE"));
                    }
                    catch (Exception ex)
                    {
                        ret = "";
                        Console.WriteLine(ex.Message);
                    }
                }

                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static string GetConfigByNameBackup(string configKey)
        {
            OracleCommand cmd = new OracleCommand();
            string ret = null;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_CONFIG where CONFIGKEY = '" + configKey + "'";
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    ret = data.GetString(data.GetOrdinal("CONFIGVALUE"));
                }
                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        //
        //如果有Update，没有Insert
        //
        public static void SaveConfigBackup(string configKey, string configValue)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_CONFIG where CONFIGKEY = '" + configKey + "'";


                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                if (data.Read())  //存在Update
                {
                    data.Close();
                    cmd.Parameters.Clear();

                    //sqlStr = "update T_CONFIG where CONFIGKEY = '" + configKey + "'" + "set CONFIGVALUE = " + configValue;
                    sqlStr = "update T_CONFIG set CONFIGVALUE = '" + configValue + "' where CONFIGKEY = '" + configKey + "'";
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    data = cmd.ExecuteReader();

                    data.Close();
                    cmd.Parameters.Clear();
                }
                else //不存在Insert
                {
                    data.Close();
                    cmd.Parameters.Clear();

                    sqlStr = "insert into T_CONFIG values('" + configKey + "','" + configValue + "')";
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    data = cmd.ExecuteReader();

                    data.Close();
                    cmd.Parameters.Clear();
                }

            }
        }
        //******************************************* USER ***********************************************
        public static string UserLogin(string userName, string pwd)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    string sqlStr = "select * from T_USER where USERNAME = '" + userName + "' and PWD = '" + pwd + "'";
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    OracleDataReader data = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    if (data.Read())
                    {
                        return "SUCCESS";
                    }
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
            return "FAIL";
        }
        public static ARUser GetUser(string userName)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    string sqlStr = "select * from T_USER where USERNAME = '" + userName + "'";
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    OracleDataReader data = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    if (data.Read())
                    {
                        ARUser user = new ARUser();
                        try
                        {
                            user.UserId = data.GetInt64(data.GetOrdinal("USERID")) + "";
                        }
                        catch
                        {
                        }
                        try
                        {
                            user.UserName = data.GetString(data.GetOrdinal("USERNAME"));
                        }
                        catch
                        {
                        }
                        try
                        {
                            user.Password = data.GetString(data.GetOrdinal("PWD"));
                        }
                        catch
                        {
                        }

                        try
                        {
                            user.FactName = data.GetString(data.GetOrdinal("FACTNAME"));
                        }
                        catch
                        {
                        }

                        try
                        {
                            user.Remark = data.GetString(data.GetOrdinal("REMARK"));
                        }
                        catch
                        {
                        }

                        try
                        {
                            user.Status = data.GetString(data.GetOrdinal("PWD"));
                        }
                        catch
                        {
                        }

                        try
                        {
                            user.RoleName = data.GetString(data.GetOrdinal("ROLENAME"));
                        }
                        catch
                        {
                        }
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }
        public static List<ARUser> GetUsers()
        {
            List<ARUser> list = new List<ARUser>();
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    string sqlStr = "select * from T_USER order by USERID";
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    OracleDataReader data = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    while (data.Read())
                    {
                        ARUser user = new ARUser();
                        try
                        {
                            user.UserId = data.GetInt64(data.GetOrdinal("USERID")) + "";
                        }
                        catch
                        {
                        }
                        try
                        {
                            user.UserName = data.GetString(data.GetOrdinal("USERNAME"));
                        }
                        catch
                        {
                        }
                        try
                        {
                            user.Password = data.GetString(data.GetOrdinal("PWD"));
                        }
                        catch
                        {
                        }

                        try
                        {
                            user.FactName = data.GetString(data.GetOrdinal("FACTNAME"));
                        }
                        catch
                        {
                        }

                        try
                        {
                            user.Remark = data.GetString(data.GetOrdinal("REMARK"));
                        }
                        catch
                        {
                        }

                        try
                        {
                            user.Status = data.GetString(data.GetOrdinal("STATUS"));
                        }
                        catch
                        {
                        }

                        try
                        {
                            user.RoleName = data.GetString(data.GetOrdinal("ROLENAME"));
                        }
                        catch
                        {
                        }

                        list.Add(user);
                    }

                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }

            return list;
        }
        public static string AddUser(ARUser user)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("insert into T_USER values(T_USER_SEQ.nextval,");
                sql.Append("'" + user.UserName + "'");
                sql.Append(",");
                sql.Append("'" + user.FactName + "'");
                sql.Append(",");
                sql.Append("'" + user.Password + "'");
                sql.Append(",");
                sql.Append("'" + user.Status + "'");
                sql.Append(",");
                sql.Append("'" + user.RoleName + "'");
                sql.Append(",");
                sql.Append("'" + user.Remark + "'");
                sql.Append(")");
                Console.WriteLine("sql = " + sql.ToString());
                try
                {
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sql.ToString(), null);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
            return "SUCCESS";
        }
        public static bool ExistUser(string userName)
        {
            OracleCommand cmd = new OracleCommand();
            bool ret = false;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_USER where USERNAME = '" + userName + "'";
                Console.WriteLine("sqlStr");
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    ret = true;
                }
                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static string Delete_User_Role_ACL_Config(string userName)
        {
            ARUser user = GetUser(userName);
            string result1 = DeleteUser(userName);
            string result2 = DeleteUserRoleByUserId(Convert.ToInt32(user.UserId));
            string result3 = DeleteACLByUserId(Convert.ToInt32(user.UserId));
            string result4 = DeleteConfigByUsename(user.UserName);
            if (result1 == "SUCCESS" && result2 == "SUCCESS" && result3 == "SUCCESS" && result4 == "SUCCESS")
            {
                return "SUCCESS";
            }
            else
            {
                return "DeleteUser: " + result1 + "\n" + "DeleteRole:" + result2 + "\n" + "DeleteUserAccess:" + result3 + "\n" + "DeleteConfigByUsename:" + result4;
            }
        }

        private static string DeleteConfigByUsename(string userName)
        {
            string sqlStr = "delete from T_CONFIG where USERNAME = '" + userName + "'";
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
            return "SUCCESS";
        }

        public static string DeleteUser(string userName)
        {
            string sqlStr = "delete from T_USER where USERNAME = '" + userName + "'";
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
            return "SUCCESS";
        }
        public static string ModifyUser(ARUser user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update T_USER set ");
            sb.Append("USERNAME = '" + user.UserName + "'");
            sb.Append(",");
            sb.Append("FACTNAME = '" + user.FactName + "'");
            sb.Append(",");
            sb.Append("PWD = '" + user.Password + "'");
            sb.Append(",");
            sb.Append("STATUS = '" + user.Status + "'");
            sb.Append(",");
            sb.Append("ROLENAME = '" + user.Status + "'");
            sb.Append(",");
            sb.Append("REMARK = '" + user.Remark + "'");
            sb.Append(" where USERID = " + user.UserId);
            string sqlStr = sb.ToString();
            Console.WriteLine(sqlStr);
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
            return "SUCCESS";
        }

        //******************************************* Role ***********************************************
        public static List<ARRole> GetRoles()
        {
            List<ARRole> list = new List<ARRole>();
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    string sqlStr = "select * from T_ROLE order by ROLE_ID";
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    OracleDataReader data = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    while (data.Read())
                    {
                        ARRole role = new ARRole();
                        try
                        {
                            role.RoleId = data.GetInt64(data.GetOrdinal("ROLE_ID")) + "";
                        }
                        catch
                        {
                        }

                        try
                        {
                            role.RoleName = data.GetString(data.GetOrdinal("ROLE_NAME")) + "";
                        }
                        catch
                        {
                        }

                        list.Add(role);
                    }

                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }

            return list;
        }

        public static bool ExistRole(string roleName)
        {
            OracleCommand cmd = new OracleCommand();
            bool ret = false;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select * from T_ROLE where ROLE_NAME = '" + roleName + "'";
                Console.WriteLine("sqlStr");
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    ret = true;
                }
                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static ARRole GetRole(string roleName)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    string sqlStr = "select * from T_ROLE where ROLE_NAME = '" + roleName + "'";
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    OracleDataReader data = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    while (data.Read())
                    {
                        ARRole role = new ARRole();
                        try
                        {
                            role.RoleId = data.GetInt64(data.GetOrdinal("ROLE_ID")) + "";
                        }
                        catch
                        {
                        }

                        try
                        {
                            role.RoleName = data.GetString(data.GetOrdinal("ROLE_NAME")) + "";
                        }
                        catch
                        {
                        }
                        return role;
                    }

                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }

            return null;
        }

        public static ARRole GetRole(long roleid)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    string sqlStr = "select * from T_ROLE where ROLE_ID = " + roleid + "";
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    OracleDataReader data = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    while (data.Read())
                    {
                        ARRole role = new ARRole();
                        try
                        {
                            role.RoleId = data.GetInt64(data.GetOrdinal("ROLE_ID")) + "";
                        }
                        catch
                        {
                        }

                        try
                        {
                            role.RoleName = data.GetString(data.GetOrdinal("ROLE_NAME")) + "";
                        }
                        catch
                        {
                        }
                        return role;
                    }

                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }

            return null;
        }

        public static string DeleteRole(string roleName)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    string sqlStr = "delete from T_ROLE where ROLE_NAME = '" + roleName + "'";
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }

        public static string UpdateRole(ARRole role)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("update T_ROLE set ");
                    sb.Append("ROLE_NAME = '" + role.RoleName + "'");
                    sb.Append(" where ROLE_ID = " + role.RoleId);
                    string sqlStr = sb.ToString();
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }

        public static string AddRole(ARRole role)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("insert into T_ROLE values(T_ROLE_SEQ.nextval,");
                    sb.Append("'" + role.RoleName + "'");
                    sb.Append(")");
                    string sqlStr = sb.ToString();
                    Console.WriteLine(sqlStr);
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }

        public static string Delete_Role_UserRole(string roleName)
        {
            ARRole role = GetRole(roleName);
            string result1 = DeleteRole(roleName);
            string result2 = DeleteUserRoleByRoleId(Convert.ToInt32(role.RoleId));
            string result3 = DeleteACLByRoleId(Convert.ToInt32(role.RoleId));
            if (result1 == "SUCCESS" && result2 == "SUCCESS" && result3 == "SUCCESS")
            {
                return "SUCCESS";
            }
            else
            {
                return "DeleteRole: " + result1 + "\n" + "DeleteUserRole:" + result2 + "\n" + "DeleteACL:" + result3;
            }
        }
        //******************************************* User-Role ***********************************************

        public static string AddUserRole(int userId, int roleId)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("insert into T_USER_ROLE values(T_USER_ROLE_SEQ.nextval,");
                    sb.Append(userId);
                    sb.Append(",");
                    sb.Append(roleId);
                    sb.Append(")");
                    string sqlStr = sb.ToString();
                    Console.WriteLine(sqlStr);
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }

        public static string DeleteUserRole(int userId, int roleId)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("delete from T_USER_ROLE where ");
                    sb.Append("USER_ID = " + userId);
                    sb.Append(" and ");
                    sb.Append("ROLE_ID = " + roleId);
                    string sqlStr = sb.ToString();
                    Console.WriteLine(sqlStr);
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }

        public static string DeleteUserRoleByUserId(int userId)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("delete from T_USER_ROLE where ");
                    sb.Append("USER_ID = " + userId);
                    string sqlStr = sb.ToString();
                    Console.WriteLine(sqlStr);
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }

        public static string DeleteUserRoleByRoleId(int roleId)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("delete from T_USER_ROLE where ");
                    sb.Append("ROLE_ID = " + roleId);
                    string sqlStr = sb.ToString();
                    Console.WriteLine(sqlStr);
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }

        private static List<long> GetRoleIdsByUserId(int userid)
        {
            OracleCommand cmd = new OracleCommand();
            List<long> ids = new List<long>();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                string sqlStr = "select ROLE_ID from T_USER_ROLE where user_id = " + userid;
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    long roleid = data.GetInt64(data.GetOrdinal("ROLE_ID"));
                    ids.Add(roleid);
                }
                data.Close();
                cmd.Parameters.Clear();
            }

            return ids;
        }

        public static List<ARRole> GetRolesByUserId(int userid)
        {
            List<ARRole> roles = new List<ARRole>();
            List<long> roleids = GetRoleIdsByUserId(userid);
            if (roleids == null)
            {
                return roles;
            }
            foreach (long roleid in roleids)
            {
                ARRole role = GetRole(roleid);
                if (role != null)
                    roles.Add(role);
            }
            return roles;
        }

        //******************************************* Permission ***********************************************

        public static List<ARPermission> GetPermissions()
        {
            List<ARPermission> list = new List<ARPermission>();
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select * from T_PERMISSION");
                    string sqlStr = sb.ToString();
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    OracleDataReader data = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    while (data.Read())
                    {
                        ARPermission permission = new ARPermission();
                        try
                        {
                            permission.Permission_Name = data.GetString(data.GetOrdinal("PERMISSION_NAME"));
                        }
                        catch
                        {

                        }
                        try
                        {
                            permission.Permission_Id = data.GetInt64(data.GetOrdinal("PERMISSION_ID")) + "";
                        }
                        catch
                        {

                        }
                        list.Add(permission);
                    }
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            return list;
        }

        public static List<ARPermission> GetPermissionsByRoleId(int roleId)
        {
            List<ARPermission> list = new List<ARPermission>();
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select * from T_PERMISSION ");
                    sb.Append("where PERMISSION_ID in ( select ACL_PERMISSION_ID from T_ACL where ACL_ENTITY_ID = ");
                    sb.Append(roleId + " and ACL_TYPE = 'Role'");
                    sb.Append(")");
                    string sqlStr = sb.ToString();
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    OracleDataReader data = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    while (data.Read())
                    {
                        ARPermission permission = new ARPermission();
                        try
                        {
                            permission.Permission_Name = data.GetString(data.GetOrdinal("PERMISSION_NAME"));
                        }
                        catch
                        {

                        }
                        try
                        {
                            permission.Permission_Id = data.GetInt64(data.GetOrdinal("PERMISSION_ID")) + "";
                        }
                        catch
                        {

                        }
                        list.Add(permission);
                    }
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            return list;
        }

        public static List<ARPermission> GetPermissionsByUserId(int userId)
        {
            List<ARPermission> list = new List<ARPermission>();
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select * from T_PERMISSION ");
                    sb.Append("where PERMISSION_ID in ( select ACL_PERMISSION_ID from T_ACL where ACL_ENTITY_ID = ");
                    sb.Append(userId + " and ACL_TYPE = 'User'");
                    sb.Append(")");
                    string sqlStr = sb.ToString();
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    OracleDataReader data = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    while (data.Read())
                    {
                        ARPermission permission = new ARPermission();
                        try
                        {
                            permission.Permission_Name = data.GetString(data.GetOrdinal("PERMISSION_NAME"));
                        }
                        catch
                        {

                        }
                        try
                        {
                            permission.Permission_Id = data.GetInt64(data.GetOrdinal("PERMISSION_ID")) + "";
                        }
                        catch
                        {

                        }
                        list.Add(permission);
                    }
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            return list;
        }

        public static ARPermission GetPermission(string permissionName)
        {
            ARPermission permission = null;
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select * from T_PERMISSION where PERMISSION_NAME = '" + permissionName + "'");
                    string sqlStr = sb.ToString();
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    OracleDataReader data = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    if (data.Read())
                    {
                        permission = new ARPermission();
                        try
                        {
                            permission.Permission_Name = data.GetString(data.GetOrdinal("PERMISSION_NAME"));
                        }
                        catch
                        {

                        }
                        try
                        {
                            permission.Permission_Id = data.GetInt64(data.GetOrdinal("PERMISSION_ID")) + "";
                        }
                        catch
                        {

                        }
                    }
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            return permission;
        }

        public static List<ARPermission> GetRolePermissionsByUserId(int userid)
        {
            List<ARPermission> rolePermissions = new List<ARPermission>();
            List<ARRole> roles = GetRolesByUserId(userid);
            foreach (ARRole role in roles)
            {
                List<ARPermission> permissions = GetPermissionsByRoleId(Convert.ToInt32(role.RoleId));
                if (permissions != null && permissions.Count != 0)
                    rolePermissions.AddRange(permissions);
            }
            return rolePermissions;
        }

        private static bool ContainPermission(List<ARPermission> list, ARPermission permission)
        {
            foreach (ARPermission p in list)
            {
                if (p.Permission_Name == permission.Permission_Name)
                {
                    return true;
                }
            }
            return false;
        }

        private static List<ARPermission> MergeList(List<ARPermission> list1, List<ARPermission> list2)
        {
            List<ARPermission> all = new List<ARPermission>();
            if (list1 != null && list1.Count != 0)
            {
                all.AddRange(list1);
            }
            if (list2 != null && list2.Count != 0)
            {
                foreach (ARPermission permission in list2)
                {
                    if (!ContainPermission(all, permission))
                    {
                        all.Add(permission);
                    }
                }
            }
            return all;
        }

        public static List<ARPermission> GetAllPermissionByUserId(int userid)
        {
            List<ARPermission> userPermissions = GetPermissionsByUserId(userid);
            List<ARPermission> rolePermissions = GetRolePermissionsByUserId(userid);

            return MergeList(userPermissions, rolePermissions);
        }

        public static string AddPermission(string permissionName)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into T_PERMISSION values(T_PERMISSION_SEQ.NEXTVAL,");
                sb.Append("'"+permissionName+"'");
                sb.Append(")");
                string sqlStr = sb.ToString();
                Console.WriteLine("sqlstr="+sqlStr);
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                try
                {
                    cmd.ExecuteNonQuery();
                        return "SUCCESS";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public static string DeletePermission(string permissionName)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("delete from T_PERMISSION where ");
                sb.Append("PERMISSION_NAME = '" + permissionName + "'");
                string sqlStr = sb.ToString();
                Console.WriteLine("sqlstr=" + sqlStr);
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                try
                {
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        //********************************* ACL *********************************************************
        public static bool ExistACL(int entityId, int permissionId, string type)
        {
            OracleCommand cmd = new OracleCommand();
            bool ret = false;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from T_ACL where ");
                sb.Append(" ACL_TYPE = '" + type + "'");
                sb.Append(" and ACL_ENTITY_ID = " + entityId);
                sb.Append(" and ACL_PERMISSION_ID = " + permissionId);
                string sqlStr = sb.ToString();
                PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                OracleDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    ret = true;
                }
                data.Close();
                cmd.Parameters.Clear();
            }
            return ret;
        }

        public static string AddACL(ARACL acl)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("insert into T_ACL values(T_ACL_SEQ.nextval,");
                    sb.Append("'" + acl.ACL_Type + "'");
                    sb.Append(",");
                    sb.Append(acl.ACL_Entity_Id);
                    sb.Append(",");
                    sb.Append(acl.ACL_Permission_Id);
                    sb.Append(")");
                    string sqlStr = sb.ToString();
                    Console.WriteLine(sqlStr);
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }

        public static string UpdateACL(ARACL acl)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("update T_ROLE set ");
                    sb.Append("ACL_TYPE = '" + acl.ACL_Type + "'");
                    sb.Append("ACL_ENTITY_ID = '" + acl.ACL_Entity_Id + "'");
                    sb.Append("ACL_PERMISSION_ID = '" + acl.ACL_Permission_Id + "'");
                    sb.Append(" where ACL_ID = " + acl.ACL_Id);
                    string sqlStr = sb.ToString();
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }

        public static string DeleteACLById(int aclId)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("delete from T_ACL where ");
                    sb.Append("ACL_ID = " + aclId);
                    sb.Append(")");
                    string sqlStr = sb.ToString();
                    Console.WriteLine(sqlStr);
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }

        public static string DeleteACLByUserId(int userId)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("delete from T_ACL where ");
                    sb.Append("ACL_ENTITY_ID = " + userId);
                    sb.Append(" and ");
                    sb.Append("ACL_TYPE = 'User'");
                    string sqlStr = sb.ToString();
                    Console.WriteLine(sqlStr);
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }

        public static string DeleteACLByRoleId(int roleId)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("delete from T_ACL where ");
                    sb.Append("ACL_ENTITY_ID = " + roleId);
                    sb.Append(" and ");
                    sb.Append("ACL_TYPE = 'Role'");
                    string sqlStr = sb.ToString();
                    Console.WriteLine(sqlStr);
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }

        public static string DeleteACL(ARACL acl)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("delete from T_ACL where ");
                    sb.Append(" ACL_TYPE = '" + acl.ACL_Type + "'");
                    sb.Append(" and ACL_ENTITY_ID = " + acl.ACL_Entity_Id);
                    sb.Append(" and ACL_PERMISSION_ID = " + acl.ACL_Permission_Id);
                    string sqlStr = sb.ToString();
                    Console.WriteLine(sqlStr);
                    PrepareCommand(cmd, conn, System.Data.CommandType.Text, sqlStr, null);
                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch (Exception ex)
                {
                    cmd.Parameters.Clear();
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }

        //*****************************************************************************************************************/
        /// <summary>
        /// 执行一条SqlCommand（无返回结果集）
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">SQL语句</param>
        /// <param name="commandParameters">SQL参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, List<OracleParameter> commandParameters)
        {
            OracleCommand cmd = new OracleCommand();

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, commandParameters);

                try
                {
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }
        }

        /// <summary>
        /// 执行一条SqlCommand（无返回结果集）
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="conn">一个有效的SQL数据库连接</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">SQL语句</param>
        /// <param name="commandParameters">SQL参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(OracleConnection connection, CommandType cmdType, string cmdText, List<OracleParameter> commandParameters)
        {
            OracleCommand cmd = new OracleCommand();
            PrepareCommand(cmd, connection, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 执行一条SqlCommand返回第一行第一列
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">SQL语句</param>
        /// <param name="commandParameters">SQL参数</param>
        /// <returns>返回第一行第一列</returns>
        /// <summary>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, List<OracleParameter> commandParameters)
        {
            OracleCommand cmd = new OracleCommand();

            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                PrepareCommand(cmd, connection, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                connection.Close();
                return val;
            }
        }
        /// <summary>
        /// 执行一条SqlCommand返回第一行第一列
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="connectionString">一个有效的连接</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">SQL语句</param>
        /// <param name="commandParameters">SQL参数</param>
        /// <returns>返回第一行第一列</returns>
        public static object ExecuteScalar(OracleConnection connection, CommandType cmdType, string cmdText, List<OracleParameter> commandParameters)
        {

            OracleCommand cmd = new OracleCommand();

            PrepareCommand(cmd, connection, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 添加一个参数到参数缓存中
        /// </summary>
        /// <param name="cacheKey">参数缓存的关键字</param>
        /// <param name="cmdParms">参数数组</param>
        public static void CacheParameters(string cacheKey, params object[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// 得到缓存的参数
        /// </summary>
        /// <param name="cacheKey">缓存参数关键字</param>
        /// <returns>返回参数值数组</returns>
        public static OracleParameter[] GetCachedParameters(string cacheKey)
        {
            OracleParameter[] cachedParms = (OracleParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            OracleParameter[] clonedParms = new OracleParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (OracleParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        /// <summary>
        /// 向命令集中添加参数
        /// </summary>
        /// <param name="cmd">oarcleCommand对象</param>
        /// <param name="conn">OracleConnection对象</param>
        /// <param name="trans">SqlTransaction对象</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">SQL命令</param>
        /// <param name="cmdParms">命令参数</param>
        private static void PrepareCommand(OracleCommand cmd, OracleConnection conn, CommandType cmdType, string cmdText, List<OracleParameter> cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                {
                    if (parm.Value == null)
                        parm.Value = DBNull.Value;
                    cmd.Parameters.Add(parm);
                }
            }
        }
    }
}