using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SY.MODEL
{
    [DataContract]
    public class ARCategory
    {
        [DataMember]
        public string _NAME
        {
            get;
            set;
        }
        [DataMember]
        public string _PARENT_NO
        {
            get;
            set;
        }
        [DataMember]
        public string _AJ_NO_COMPONENT
        {
            get;
            set;
        }
        [DataMember]
        public string _DESCRIPTION
        {
            get;
            set;
        }
        [DataMember]
        public string _AJH_COUNT
        {
            get;
            set;
        }
        [DataMember]
        public string _TYPE
        {
            get;
            set;
        }
    }
}
