using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SY.MODEL
{
    [DataContract]
    public class ARReminder
    {
        [DataMember]
        public string FieldName { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string Reminders { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string DefaultContent { get; set; }
    }
}
