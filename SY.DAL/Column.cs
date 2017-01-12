using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SY.MODEL;
using Oracle.DataAccess.Client;
using System.Collections;

namespace SY.DAL
{
    public class Column
    {

        public bool AddColumn(ARColumn arColumn)
        {
            string sqlStr = null;
            try
            {
                sqlStr = "insert into T_Field_Medata(FieldId,FieldName,Description,AllowEmpty,FieldType,CategoryName,SystemColum,Bytes) " +
                   " values(T_FIELD_SEQ.nextval,:FieldName,:Description,:AllowEmpty,:FieldType,:CategoryName,:SystemColum,:Bytes)";

                //string strSql = "insert into T_User(UserId,UserName,FactName,PWD,Status,RoleName,Remark) " +
                //    " values(1,:UserName,:FactName,:Password,:Status,:RoleName,:Remark)";

                List<OracleParameter> listParm = new List<OracleParameter>();
                OracleParameter parm = new OracleParameter(":FieldName", OracleDbType.Varchar2);
                parm.Value = arColumn.FieldName;
                listParm.Add(parm);

                parm = new OracleParameter(":Description", OracleDbType.Varchar2);
                parm.Value = arColumn.Description;
                listParm.Add(parm);

                parm = new OracleParameter(":AllowEmpty", OracleDbType.Varchar2);
                parm.Value = arColumn.AllowEmpty;
                listParm.Add(parm);

                parm = new OracleParameter(":FieldType", OracleDbType.Varchar2);
                parm.Value = arColumn.FieldType;
                listParm.Add(parm);

                parm = new OracleParameter(":CategoryName", OracleDbType.Varchar2);
                parm.Value = arColumn.Category;
                listParm.Add(parm);

                parm = new OracleParameter(":SystemColum", OracleDbType.Varchar2);
                parm.Value = arColumn.SystemColum;
                listParm.Add(parm);

                parm = new OracleParameter(":Bytes", OracleDbType.Varchar2);
                parm.Value = arColumn.Bytes;
                listParm.Add(parm);

                Console.WriteLine("sqlStr = " + sqlStr);
                DBHelper.ExecuteNonQuery(System.Data.CommandType.Text, sqlStr, listParm);
            }
            catch (Exception ex)
            {
                //先写错误日志
                Console.WriteLine(ex.Message);
                return false;
                //throw ex;
            }
            return true;
        }
        public bool AddColumnToCategory(ARColumn arColumn)
        {
            //
            //获取分类的类型（文件级、案卷级）
            //

            string categoryType = "";
            if (!arColumn.Category.Equals(""))
            {
                try
                {
                    string sqlStr = "select CATEGORY_TYPE from T_CATEGORY where CATEGORY_NAME = '" + arColumn.Category + "'";
                    List<string> list = DBHelper.GetResultByColumnName(System.Data.CommandType.Text, sqlStr, null, "CATEGORY_TYPE");
                    categoryType = list[0].ToString();
                }
                catch (Exception)
                {
                    return false;
                }

                string table1 = "T_" + categoryType + "_" + arColumn.Category;
                string table2 = "T_" + categoryType + "_" + arColumn.Category + "_Attached";
                try
                {
                    string sqlStr1 = "alter table " + table1 + " add " + arColumn.FieldName + " varchar(" + arColumn.Bytes + ")";
                    string sqlStr2 = "alter table " + table2 + " add " + arColumn.FieldName + " varchar(" + arColumn.Bytes + ")";
                    List<string> sqls = new List<string>();
                    sqls.Add(sqlStr1);
                    sqls.Add(sqlStr2);

                    DBHelper.ExecuteSqlTran(sqls);
                    //DBHelper.ExecuteNonQuery(System.Data.CommandType.Text, sqlStr1, null);
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return true;
        }

        public List<List<string>> GetQueryResult(string[] resultOrder, string sqlstr)
        {
            return DBHelper.GetQueryResult(resultOrder, sqlstr);
        }

        public List<string> QueryArchivesID(string queryStr)
        {
            return DBHelper.QueryArchivesID(queryStr);
        }
        public List<string> GetTableColumns(string tableName)
        {
            return DBHelper.GetTableColumns(System.Data.CommandType.Text, tableName);
        }
        public List<ARColumn> GetColumnTypes(List<string> columnList)
        {
            return DBHelper.GetColumnTypes(columnList);
        }
        public ARColumn GetColumnType(string columnName)
        {
            return DBHelper.GetColumnType(columnName);
        }
        public string GetDescription(string columnName)
        {
            return DBHelper.GetDescription(columnName);
        }
        public List<string> GetTableColumnDescriptions(string tableName)
        {
            return DBHelper.GetTableColumnDescriptions(tableName);
        }

    
        public void SaveConfig(string configKey, string configValue,string userName)
        {
            DBHelper.SaveConfig(configKey, configValue,userName);
        }
        public string GetConfigValue(string configKey,string userName)
        {
            return DBHelper.GetConfigValue(configKey,userName);
        }

        public string GetColumnByDescription(string descrption,string categoryName)
        {
            return DBHelper.GetColumnByDescriptionAndCategory(descrption, categoryName);
        }

        public bool ColumnExist(string fieldName)
        {
            return DBHelper.ColumnExist(fieldName);
        }

        public bool ModifyColumnType(ARColumn oldColumn, ARColumn newColumn)
        {
            return DBHelper.ModifyColumnType(oldColumn, newColumn);
        }

        public Dictionary<string, List<string>> GetColumnReminders()
        {
            return DBHelper.GetColumnReminders();
        }
    }
}
