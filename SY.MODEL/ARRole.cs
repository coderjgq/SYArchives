using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SY.MODEL
{
    [DataContract]
    public class ARRole
    {
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public string RoleId { get; set; }
    }
}
