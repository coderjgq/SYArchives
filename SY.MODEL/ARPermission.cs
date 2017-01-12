using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SY.MODEL
{
    [DataContract]
    public class ARPermission
    {
        [DataMember]
        public string Permission_Id { set; get; }
        [DataMember]
        public string Permission_Name { set; get; }
    }
}
