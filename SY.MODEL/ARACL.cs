using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SY.MODEL
{
    [DataContract]
    public class ARACL
    {
        [DataMember]
        public string ACL_Id { set; get; }
        [DataMember]
        public string ACL_Type { set; get; }
        [DataMember]
        public string ACL_Entity_Id { set; get; }
        [DataMember]
        public string ACL_Permission_Id { set; get; }
    }
}
