using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using SY.MODEL;

namespace SY.DAL
{
    public class User
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="arUser"></param>
        public void AddUser(ARUser arUser)
        {
            try
            {
                string strSql = "insert into T_User(UserId,UserName,FactName,PWD,Status,RoleName,Remark) " +
                    " values(T_User_SEQ.nextval,:UserName,:FactName,:Password,:Status,:RoleName,:Remark)";

                List<OracleParameter> listParm = new List<OracleParameter>();
                OracleParameter parm = new OracleParameter(":UserName", OracleDbType.Varchar2);
                parm.Value = arUser.UserName;
                listParm.Add(parm); 
                //
                parm = new OracleParameter(":FactName", OracleDbType.Varchar2);
                parm.Value = arUser.FactName;
                listParm.Add(parm);
                 //
                parm = new OracleParameter(":Password", OracleDbType.Varchar2);
                parm.Value= arUser.Password;
                listParm.Add(parm);
                //
                parm = new OracleParameter(":Status", OracleDbType.Int64);
                parm.Value = arUser.Status;
                listParm.Add(parm);
                //
                parm = new OracleParameter(":RoleName", OracleDbType.Varchar2);
                parm.Value = arUser.RoleName;
                listParm.Add(parm);
                //
                parm = new OracleParameter(":Remark", OracleDbType.Varchar2);
                parm.Value = arUser.Remark;
                listParm.Add(parm);
                DBHelper.ExecuteNonQuery(CommandType.Text, strSql, listParm);
            }
            catch (Exception ex)
            {
                //先写错误日志
                throw ex;
            }
        }
    }
}
