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
    public partial class SelectReminderForm : Form
    {
        public static int NUMBER = 0;
        public static int REMINDER = 1;
        public static int CODE = 2;

        private string columnName { set; get; }
        private TextBox tb { get; set; }
        public List<string> reminders;

        public SelectReminderForm(string columnName, TextBox tb)
        {
            InitializeComponent();
            this.columnName = columnName;
            this.tb = tb;
            string description = ServerProxy.GetProxy().GetDescription(columnName);
            this.Text = "提示 - " + description;
            InitReminder();
        }

        private void InitReminder()
        {
            reminders = ReminderUtil.GetReminders(columnName);
            this.dgv_reminder.Rows.Clear();
            for (int i = 0; i < reminders.Count; i++)
            {
                string reminder = reminders[i];
                this.dgv_reminder.Rows.Add();
                this.dgv_reminder.Rows[i].Cells[0].Value = "" + (i + 1);
                this.dgv_reminder.Rows[i].Cells[1].Value = reminder;
            }
        }

        private List<string> GetReminderList()
        {
            List<string> reminders = new List<string>();
            for (int i = 0; i < this.dgv_reminder.Rows.Count; i++)
            {
                string reminder = this.dgv_reminder.Rows[i].Cells[REMINDER].Value + "";
                if (!reminder.Trim().Equals(""))
                {
                    reminders.Add(reminder);
                }
            }
            return reminders;
        }

        private void SaveReminder()
        {

            reminders = GetReminderList();
            string xml = XmlUtil.GetReminderXml(reminders);
            Console.WriteLine("xml = " + xml);

            ARReminder ar = ServerProxy.GetProxy().GetReminder(columnName);
            if (ar == null)
            {
                ar = new ARReminder();
                ar.FieldName = columnName;
                ar.Description = ServerProxy.GetProxy().GetDescription(columnName);
            }
            ar.Reminders = xml;
            string result = ServerProxy.GetProxy().SaveReminder(ar);

            if (result.Trim().Equals("SUCCESS"))
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败\n" + result);
            }

        }

        //************************************ 事件 *****************************************

        private void dgv_reminder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string content = this.dgv_reminder.Rows[e.RowIndex].Cells[REMINDER].Value + "";
            if (!content.Trim().Equals(""))
            {
                CountNumber(e.RowIndex);
            }
            else
            {
                ClearNumber(e.RowIndex);
            }
        }

        private void ClearNumber(int rowIndex)
        {
            this.dgv_reminder.Rows[rowIndex].Cells[NUMBER].Value = "";
        }

        private void CountNumber(int rowIndex)
        {
            this.dgv_reminder.Rows[rowIndex].Cells[NUMBER].Value = "" + (rowIndex + 1);
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            SaveReminder();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            //this.dgv_reminder.Rows.Add();
            //this.dgv_reminder.Rows[this.dgv_reminder.RowCount - 1].Cells[0].Value = "" + this.dgv_reminder.RowCount;
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dgv_reminder.SelectedCells[0].RowIndex;
            deleteRow(rowIndex);
        }

        private void deleteRow(int rowIndex)
        {
            this.dgv_reminder.Rows.RemoveAt(rowIndex);
        }

        private void bt_select_Click(object sender, EventArgs e)
        {
            string reminder = GetSelectReminder();
            if (tb != null && reminder != null)
            {
                tb.Text = reminder;
            }
        }

        private string GetSelectReminder()
        {
            int rowIndex = this.dgv_reminder.SelectedCells[0].RowIndex;
            Object value = this.dgv_reminder.Rows[rowIndex].Cells[REMINDER].Value;
            if(value == null)
            {
                return null;
            }
            string reminder = value.ToString().Trim();
            return reminder;
        }

        private void bt_up_Click(object sender, EventArgs e)
        {
            if (!CheckSelected())
            {
                return;
            }
            
            int selectRowIndex = this.dgv_reminder.SelectedCells[0].RowIndex;
            int rowCount = this.dgv_reminder.RowCount;
            if (selectRowIndex < 0 + 1)
            {
                return;
            }
            string selectReminder = this.dgv_reminder.Rows[selectRowIndex].Cells[REMINDER].Value.ToString().Trim();
            string upReminder = this.dgv_reminder.Rows[selectRowIndex - 1].Cells[REMINDER].Value.ToString().Trim();
            this.dgv_reminder.Rows[selectRowIndex].Cells[REMINDER].Value = "" + upReminder;
            this.dgv_reminder.Rows[selectRowIndex - 1].Cells[REMINDER].Value = "" + selectReminder;
            this.dgv_reminder.CurrentCell = this.dgv_reminder.Rows[selectRowIndex - 1].Cells[REMINDER];
        }

        private void bt_down_Click(object sender, EventArgs e)
        {
            if (!CheckSelected())
            {
                return;
            }
            int selectRowIndex = this.dgv_reminder.SelectedCells[0].RowIndex;
            int rowCount = this.dgv_reminder.RowCount;
            if (selectRowIndex >= rowCount - 1 - 1)
            {
                return;
            }
            string selectReminder = this.dgv_reminder.Rows[selectRowIndex].Cells[REMINDER].Value.ToString().Trim();
            string upReminder = this.dgv_reminder.Rows[selectRowIndex+1].Cells[REMINDER].Value.ToString().Trim();
            this.dgv_reminder.Rows[selectRowIndex].Cells[REMINDER].Value = "" + upReminder;
            this.dgv_reminder.Rows[selectRowIndex+1].Cells[REMINDER].Value = "" + selectReminder;
            this.dgv_reminder.CurrentCell = this.dgv_reminder.Rows[selectRowIndex + 1].Cells[REMINDER];
        }

        private bool CheckSelected()
        {
            int count = this.dgv_reminder.SelectedCells.Count;
            if (count > 0)
            {
                return true;
            }
            MessageBox.Show("请先选中");
            return false;
        }


    }
}