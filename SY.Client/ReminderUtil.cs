using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SY.MODEL;

namespace SY.Client
{
    class ReminderUtil
    {
        public static List<string> GetReminders(string columnName)
        {
            List<string> reminders = new List<string>();
            try
            {
                ARReminder reminder = ServerProxy.GetProxy().GetReminder(columnName);
                reminders = XmlUtil.GetReminders(reminder.Reminders);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return reminders;
        }

        public static string SaveReminder(ARReminder reminder)
        {
            return ServerProxy.GetProxy().SaveReminder(reminder);
        }

    }
}
