using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace SY.MODEL
{
    [DataContract]
    public class ARColumn
    {
        [DataMember]
        public string FieldId
        {
            get;
            set;
        }
        [DataMember]       
        public string FieldName
        {
            get;
            set;
        }

        [DataMember]
        public string Description
        {
            get;
            set;
        }

        [DataMember]
        public string AllowEmpty
        {
            get;
            set;
        }

        [DataMember]
        public string FieldType
        {
            get;
            set;
        }

        [DataMember]
        public string Category
        {
            get;
            set;
        }

        [DataMember]
        public string SystemColum
        {
            get;
            set;
        }

        [DataMember]
        public string Bytes
        {
            get;
            set;
        }
    }
}
