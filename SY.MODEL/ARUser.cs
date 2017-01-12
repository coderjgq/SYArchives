using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SY.MODEL
{
    [DataContract]
    public class ARUser
    {
        [DataMember]        
        public string UserId
        {
            get;
            set;
        }
        
        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string FactName
        {
            get;
            set;
        }

        /// <summary>
        /// 密码
        /// </summary>
        [DataMember]
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// 状态(1:启用，2：停用)
        /// </summary>
        [DataMember]
        public string Status
        {
            get;
            set;
        }

        /// <summary>
        /// 角色名称(1：前处理，2：著入)
        /// </summary>
        [DataMember]
        public string RoleName
        {
            get;
            set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark
        {
            get;
            set;
        }
    }
}
