using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SY.Client
{
    class ConfigType
    {
        public static string AttachedTable = "_Attached";//有些地方还是用的“_Attached”,需要重新设计
        
        public static string InsertCustom = "_InsertCustom";
        public static string QueryCustom = "_QueryCustom";
        public static string ResultOrder = "_ResultOrder";
        public static string AttachResultOrder = "_AttachResultOrder";
        public static string ShowRecordDetail = "_RecordDetail";
        public static string ShowRecordDetail_Attached = "_AttachedDetail";
        

        public static string QueryCustom_Attached = "_AttachedQueryCustom";
    }
}
