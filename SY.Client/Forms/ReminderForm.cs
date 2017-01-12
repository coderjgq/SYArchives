using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SY.MODEL;

namespace SY.Client.Forms
{
    public partial class ReminderForm : Form
    {
        private List<string> reminderColumnNames;

        private List<string> reminderColumnDescriptions;

        private List<string> allColumnDescriptions;
        
        public ReminderForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            initColumns();
            countColumns();
            initListBox();
        }

        private void initListBox()
        {
            initReminderListBox();
            initAllColumnListBox();
        }

        private void countColumns()
        {
            for (int i = 0; i < reminderColumnDescriptions.Count; i++)
            {
                string column = reminderColumnDescriptions[i];
                allColumnDescriptions.Remove(column);
            }
        }

        private void countAddColumn(string columnName)
        {
            reminderColumnNames.Add(columnName);
            allColumnDescriptions.Remove(columnName);
        }

        private void countDeleteColumn(string columnName)
        {
            allColumnDescriptions.Add(columnName);
            reminderColumnNames.Remove(columnName);
        }

        public void initColumns()
        {
            //allColumnNames = ServerProxy.GetProxy().GetAllColummnNames();
            //columnNames = ServerProxy.GetProxy().GetReminderColumnNames();

            allColumnDescriptions = ServerProxy.GetProxy().GetAllColumnDescriptions();
            reminderColumnNames = ServerProxy.GetProxy().GetReminderColumnNames();
            reminderColumnDescriptions = new List<string>();
            foreach (string columnName in reminderColumnNames)
            {
                string description = ServerProxy.GetProxy().GetDescription(columnName);
                if (description != null)
                    reminderColumnDescriptions.Add(description);
            }

        }

        private void initAllColumnListBox()
        {
            lb_allColumnDescriptions.Items.Clear();

            for (int i = 0; i < allColumnDescriptions.Count; i++)
            {
                lb_allColumnDescriptions.Items.Add(allColumnDescriptions[i]);
            }
        }

        private void initReminderListBox()
        {
            lb_reminderColumnDescriptions.Items.Clear();

            for (int i = 0; i < reminderColumnDescriptions.Count; i++)
            {
                lb_reminderColumnDescriptions.Items.Add(reminderColumnDescriptions[i]);
            }
        }

        private void clearDisplayColumn()
        {
            tb_description.Text = "";
            tb_category.Text = "";
            tb_default.Text = "";
            lb_reminders.Items.Clear();
        }

        private void displayColumn(string columnName)
        {
            clearDisplayColumn();
            try
            {
                ARReminder ar = ServerProxy.GetProxy().GetReminder(columnName);
                if (ar == null)
                {
                    return;
                }

                if (ar.Description != null)
                {
                    tb_description.Text = ar.Description;
                }

                if (ar.CategoryName != null)
                {
                    tb_category.Text = ar.CategoryName;
                }

                if (ar.DefaultContent != null)
                {
                    tb_default.Text = ar.DefaultContent;
                }

                if (ar.Reminders != null && !ar.Reminders.Trim().Equals(""))
                {
                    lb_reminders.Items.Clear();
                    List<string> reminders = XmlUtil.GetReminders(ar.Reminders);
                    //string[] reminders = ar.Reminders.Split(',');
                    for (int i = 0; i < reminders.Count; i++)
                    {
                        string head = Get4ByteHeader(i + 1);
                        lb_reminders.Items.Add(head + "." + reminders[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string Get4ByteHeader(int i)
        {
            if (i < 10)
            {
                return "00" + i;
            }
            else if (i >= 10 && i < 100)
            {
                return "0" + i;
            }
            else if (i >= 100 && i < 1000)
            {
                return "" + i;
            }
            return "";
        }

        private void lb_columnNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_reminderColumnDescriptions.SelectedIndex >= 0)
            {
                string columnDescription = lb_reminderColumnDescriptions.SelectedItem.ToString();
                string columnName = ServerProxy.GetProxy().GetColumnByDescription(columnDescription);
                displayColumn(columnName);
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (tb_reminder.Text.Trim().Equals(""))
            {
                MessageBox.Show("提示不能为空！");
                return;
            }
            string head = Get4ByteHeader(lb_reminders.Items.Count + 1);
            lb_reminders.Items.Add(head + "." + tb_reminder.Text);
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (lb_reminders.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择提示！");
                return;
            }
            lb_reminders.Items.Remove(lb_reminders.Items[lb_reminders.SelectedIndex].ToString());
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            ARReminder reminder = new ARReminder();
            string columnDescription = lb_reminderColumnDescriptions.Items[lb_reminderColumnDescriptions.SelectedIndex].ToString();
            string columnName = ServerProxy.GetProxy().GetColumnByDescription(columnDescription);
            reminder.FieldName = columnName;
            reminder.Reminders = GetReminderFromListBox();
            reminder.DefaultContent = tb_default.Text;
            reminder.Description = tb_description.Text;
            reminder.CategoryName = tb_category.Text;

            string result = ServerProxy.GetProxy().SaveReminder(reminder);

            if (result.Equals("SUCCESS"))
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }

        private string GetReminderFromListBox()
        {
            string xml = "";

            for (int i = 0; i < lb_reminders.Items.Count; i++)
            {
                string reminder = RemoveHeader(lb_reminders.Items[i].ToString());
                xml = XmlUtil.AddReminderToXml(xml, reminder);
            }
            return xml;
            //string content = "";
            //string xml = "";
            //for (int i = 0; i < lb_reminders.Items.Count; i++)
            //{
            //    content += RemoveHeader(lb_reminders.Items[i].ToString()) + ",";
            //}
            //return content.Substring(0, content.Length - 1);
        }

        private string RemoveHeader(string content)
        {
            return content.Substring(4, content.Length - 4);
        }

        private void bt_addColumn_Click(object sender, EventArgs e)
        {
            if (lb_allColumnDescriptions.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择");
                return;
            }
            string columnDescription = lb_allColumnDescriptions.Items[lb_allColumnDescriptions.SelectedIndex].ToString();
            string columnName = ServerProxy.GetProxy().GetColumnByDescription(columnDescription);

            ARColumn ar = ServerProxy.GetProxy().GetColumnType(columnName);
            ARReminder reminder = new ARReminder();
            reminder.FieldName = ar.FieldName;
            reminder.Description = ar.Description;
            reminder.CategoryName = ar.Category;
            string result = ServerProxy.GetProxy().SaveReminder(reminder);
            if (result.Equals("SUCCESS"))
            {
                countAddColumn(columnDescription);
                Init();
                //initListBox();
                //MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void bt_deleteColumn_Click(object sender, EventArgs e)
        {
            if (lb_reminderColumnDescriptions.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择");
                return;
            }
            string columnDescription = lb_reminderColumnDescriptions.Items[lb_reminderColumnDescriptions.SelectedIndex].ToString();
            string columnName = ServerProxy.GetProxy().GetColumnByDescription(columnDescription);
            string result = ServerProxy.GetProxy().DeleteReminder(columnName);
            if (result.Equals("SUCCESS"))
            {
                //MessageBox.Show("操作成功");
                countDeleteColumn(columnDescription);
                //initListBox();
                Init();
                displayColumn("");
            }
            else
            {
                MessageBox.Show("操作失败");
            }

        }

    }
}
