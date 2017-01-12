using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SY.MODEL;
using Oracle.DataAccess.Client;
using System.Collections;

namespace SY.DAL
{
    public class Category
    {
        /// <summary>
        /// 添加分类记录，要附带增加对应分类表、纠错表
        /// </summary>
        /// <param name="arCategory"></param>
        public bool AddCategory(ARCategory arCategory)
        {
            string sqlStr = null;
            try
            {
                //******************************************************************************************
                //                                       在Category表中添加记录
                //******************************************************************************************


                sqlStr = "insert into T_CATEGORY(CATEGORY_NO,CATEGORY_NAME,CATEGORY_PARENT_NO,CATEGORY_AJ_NO_COMPONENT,CATEGORY_DESCRIPTION,CATEGORY_AJH_COUNT,CATEGORY_TYPE) " +
                   " values(T_CATEGORY_SEQ.nextval,:CATEGORY_NAME,:CATEGORY_CHILD_NOS,:CATEGORY_AJ_NO_COMPONENT,:CATEGORY_DESCRIPTION,:CATEGORY_AJH_COUNT,:CATEGORY_TYPE)";

                List<OracleParameter> listParm = new List<OracleParameter>();
                OracleParameter parm = new OracleParameter(":CATEGORY_NAME", OracleDbType.Varchar2);
                parm.Value = arCategory._NAME;
                listParm.Add(parm);

                parm = new OracleParameter(":CATEGORY_CHILD_NOS", OracleDbType.Clob);
                parm.Value = arCategory._PARENT_NO;
                listParm.Add(parm);

                parm = new OracleParameter(":CATEGORY_AJ_NO_COMPONENT", OracleDbType.Varchar2);
                parm.Value = arCategory._AJ_NO_COMPONENT;
                listParm.Add(parm);

                parm = new OracleParameter(":CATEGORY_DESCRIPTION", OracleDbType.Varchar2);
                parm.Value = arCategory._DESCRIPTION;
                listParm.Add(parm);

                parm = new OracleParameter(":CATEGORY_AJH_COUNT", OracleDbType.Varchar2);
                parm.Value = arCategory._AJH_COUNT;
                listParm.Add(parm);

                parm = new OracleParameter(":CATEGORY_TYPE", OracleDbType.Varchar2);
                parm.Value = arCategory._TYPE;
                listParm.Add(parm);

                DBHelper.ExecuteNonQuery(System.Data.CommandType.Text, sqlStr, listParm);


                //*******************************************************************************************
                //                                       新建分类表
                //*******************************************************************************************

                if (arCategory._TYPE.Equals("AJ"))
                {
                    sqlStr = "create table T_AJ_" + arCategory._NAME + " (" +
                         "ArchivesId Number(18), " +
                         "ArchivesNo Varchar2(200), " +
                         "Creator Varchar2(50), " +
                         "CreateTime Varchar2(50), " +
                         "Modifier Varchar2(50), " +
                         "ModifyTime Varchar2(50), " +
                         "Status Varchar2(50), " +
                         "FondsNo Varchar2(50), " +
                         "SonClassNo Varchar2(50), " +
                         "CatalogNo Varchar2(50), " +
                         "RecordNo Varchar2(50), " +
                         "BranchNO Varchar2(50), " +
                         "ArchivesYear Varchar2(50), " +
                         "CustodyPperiod Varchar2(50), " +
                         "SecretsDegree Varchar2(50), " +
                         "BeginDate Varchar2(50), " +
                         "EndDate Varchar2(50), " +
                         "TotalPage Varchar2(50)" +
                        ")";
                }
                else if (arCategory._TYPE.Equals("WJ"))
                {
                    sqlStr = "create table T_WJ_" + arCategory._NAME + " (" +
                         "ArchivesId Number(18), " +
                         "ArchivesNo Varchar2(200), " +
                         "Creator Varchar2(50), " +
                         "CreateTime Varchar2(50), " +
                         "Modifier Varchar2(50), " +
                         "ModifyTime Varchar2(50), " +
                         "Status Varchar2(50), " +
                         "FondsNo Varchar2(50), " +
                         "SonClassNo Varchar2(50), " +
                         "BranchNO Varchar2(50), " +
                         "ArchivesYear Varchar2(50), " +
                         "PartsNo Varchar2(50), " +
                         "CustodyPperiod Varchar2(50), " +
                         "SecretsDegree Varchar2(50), " +
                         "TotalPage Varchar2(50)," +
                         "FormDate Varchar2(50)," +
                         "Subject Varchar2(300)," +
                         "Responsibility Varchar2(150)," +
                         "DocumentNo Varchar2(150)" +

                        ")";
                }

                DBHelper.ExecuteNonQuery(System.Data.CommandType.Text, sqlStr, null);

                //*******************************************************************************************
                //                                       新建分类附表
                //*******************************************************************************************
                if (arCategory._TYPE.Equals("AJ"))
                {
                    sqlStr = "create table T_AJ_" + arCategory._NAME + "_Attached " + " (" +
                         "ArchivesId Number(18), " +
                         "ArchivesNo Varchar2(200), " +
                         "Creator Varchar2(50), " +
                         "CreateTime Varchar2(50), " +
                         "Modifier Varchar2(50), " +
                         "ModifyTime Varchar2(50), " +
                         "Status Varchar2(50), " +
                         "FondsNo Varchar2(50), " +
                         "SonClassNo Varchar2(50), " +
                         "CatalogNo Varchar2(50), " +
                         "RecordNo Varchar2(50), " +
                         "BranchNO Varchar2(50), " +
                         "ArchivesYear Varchar2(50), " +
                         "CustodyPperiod Varchar2(50), " +
                         "SecretsDegree Varchar2(50), " +
                         "BeginDate Varchar2(50), " +
                         "EndDate Varchar2(50), " +
                         "TotalPage Varchar2(50)" +
                        ")";
                }
                else if (arCategory._TYPE.Equals("WJ"))
                {
                    sqlStr = "create table T_WJ_" + arCategory._NAME + "_Attached " + " (" +
                         "ArchivesId Number(18), " +
                         "ArchivesNo Varchar2(200), " +
                         "Creator Varchar2(50), " +
                         "CreateTime Varchar2(50), " +
                         "Modifier Varchar2(50), " +
                         "ModifyTime Varchar2(50), " +
                         "Status Varchar2(50), " +
                         "FondsNo Varchar2(50), " +
                         "SonClassNo Varchar2(50), " +
                         "BranchNO Varchar2(50), " +
                         "ArchivesYear Varchar2(50), " +
                         "PartsNo Varchar2(50), " +
                         "CustodyPperiod Varchar2(50), " +
                         "SecretsDegree Varchar2(50), " +
                         "TotalPage Varchar2(50)," +
                         "FormDate Varchar2(50)," +
                         "Subject Varchar2(300)," +
                         "Responsibility Varchar2(150)," +
                         "DocumentNo Varchar2(150)" +

                        ")";
                }

                DBHelper.ExecuteNonQuery(System.Data.CommandType.Text, sqlStr, null);
            }
            catch (Exception ex)
            {
                //先写错误日志
                Console.WriteLine("插入失败:\n" + sqlStr + "\n" + ex.Message);
                return false;

            }

            return true;
        }
        public bool DeleteCategory(ARCategory arCategory)
        {
            return DBHelper.DeleteCategory(arCategory);
        }

        public List<ARCategory> GetCategorys()
        {
            return DBHelper.GetCategorys();
        }

        public bool UpdateCategory(ARCategory newCategory, string oldCategoryName)
        {
            return DBHelper.UpdateCategory(newCategory,oldCategoryName);
        }

        public bool SaveCategoryPrimaryKey(string categoryName, string primaryKey)
        {
            return DBHelper.SaveCategoryPrimaryKey(categoryName, primaryKey);
        }

        public string GetCategoryPrimaryKey(string categoryName)
        {
            return DBHelper.GetCategoryPrimaryKey(categoryName);
        }

        public List<string> getCategoryNames()
        {
            string sqlStr = "select CATEGORY_NAME from T_CATEGORY";

            List<string> list = DBHelper.GetResultByColumnName(System.Data.CommandType.Text, sqlStr, null, "CATEGORY_NAME");

            return list;
        }

        public bool CategoryExist(string categoryName,string categoryDescription)
        {
            return DBHelper.CategoryExist(categoryName,categoryDescription);
        }

        public int insertCategory(string sqlStr)
        {
            return DBHelper.ExecuteNonQuery(System.Data.CommandType.Text, sqlStr, null);
        }


        public bool ExecuteSqlTran(List<String> SQLStringList)
        {
            return DBHelper.ExecuteSqlTran(SQLStringList);
        }

        public List<string> GetCategoryTableNames()
        {
            return DBHelper.GetCategoryTableNames();
        }

        public ARCategory GetCategory(string categoryName)
        {
            return DBHelper.GetCategory(categoryName);
        }
        public string GetCategoryName(string categoryDescription)
        {
            return DBHelper.GetCategoryName(categoryDescription);
        }
    }
}
