using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HostService.Services;
using System.Collections;
using System.ServiceModel;
using System.Threading;
using SY.MODEL;

namespace SY.Client.Forms
{
    public partial class InsertCategoryForm : Form
    {
        private string categoryTableName = "";
        private string categoryName = "";
        private string insertColumnMsgs;

        private int rowHeight = 30;
        private int columnWidth = 200;
        private int additionalWidth = 100;

        private string categoryComponent;
        private List<Control> componentControls = new List<Control>();
        private List<ARColumn> typeList = new List<ARColumn>();
        private List<string> columnList = new List<string>();
        private Dictionary<string, List<string>> reminders;

        public InsertCategoryForm(string categoryTableName)
        {
            InitializeComponent();
            this.categoryTableName = categoryTableName;
            initColumnReminders();
            initInsertConditions();
        }

        public void initColumnReminders()
        {
            reminders = ServerProxy.GetProxy().GetColumnReminders();

            foreach (string key in reminders.Keys)
            {
                Console.WriteLine("key = " + key + ", value = " + reminders[key][0]);
            }
        }

        public void setInsertColumnMsgs(string insertColumnMsgs)
        {
            this.insertColumnMsgs = insertColumnMsgs;
        }

        public void initInsertConditions()
        {
            //
            //**************************初始化字段**************************
            //
            this.tablePannel.Controls.Clear();
            this.tablePannel.RowCount = 0;
            this.tablePannel.ColumnCount = 0;
            //
            //获取档案号组成
            //
            categoryName = categoryTableName.Split('_')[2];
            ARCategory tmpCategory = ServerProxy.GetProxy().GetCategory(categoryName);
            categoryComponent = tmpCategory._AJ_NO_COMPONENT;
            categoryComponent = categoryComponent.Replace(",", "-");
            l_dah.Text = categoryComponent;
            componentControls.Clear();

            insertColumnMsgs = ServerProxy.GetProxy().GetConfigValue(categoryTableName + ConfigType.InsertCustom, LoginForm.LOGIN_USER_NAME);
            if (insertColumnMsgs == null || insertColumnMsgs.Trim().Equals(""))
            {
                MessageBox.Show("请先设置字段排序");
                return;
            }
            timer_dah.Enabled = true;

            //
            //获取字段类型
            //
            columnList = ServerProxy.GetProxy().GetTableColumns(categoryTableName);
            typeList.Clear();

            for (int i = 0; i < columnList.Count; i++)
            {
                ARColumn ar = ServerProxy.GetProxy().GetColumnType(columnList[i].ToString());
                if (ar != null)
                {
                    typeList.Add(ar);
                }
                else
                {
                    Console.WriteLine("=> ar = null, columnName = " + columnList[i].ToString());
                }
            }
            //
            //根据配置文件排序
            //
            this.tablePannel.ColumnStyles.Clear();
            this.tablePannel.RowStyles.Clear();
            this.tablePannel.Height = 0;
            this.tablePannel.Width = 0;

            string[] columnMsgs = insertColumnMsgs.Split(',');//[0]是行列信息，后面是字段信息

            string tmp = columnMsgs[0].Substring(1, columnMsgs[0].Length - 1 - 1);
            string[] row_column = tmp.Split(':');
            string rowCountStr = row_column[0];
            string columnCountStr = row_column[1];

            int rowCount = Convert.ToInt32(rowCountStr);
            int columnCount = Convert.ToInt32(columnCountStr) + 2 + 2;//两列是用来显示名字的，两列用来显示标注  |描述|内容|标注|描述|内容|标注
            this.tablePannel.ColumnCount = columnCount;
            this.tablePannel.RowCount = rowCount;
            //
            //初始化行列
            //
            for (int i = 0; i < columnCount; i++)
            {
                if (i == 1 || i == 4)
                {
                    this.tablePannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, columnWidth + additionalWidth));
                }
                else
                {
                    this.tablePannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, columnWidth));
                }
            }
            this.tablePannel.Width = columnCount * columnWidth + 2 * additionalWidth;
            for (int i = 0; i < rowCount; i++)
            {
                this.tablePannel.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
            }
            this.tablePannel.Height = rowCount * rowHeight;

            for (int i = 1; i < columnMsgs.Length; i++)
            {
                string msg = columnMsgs[i];
                string[] column_span = msg.Substring(1, msg.Length - 1 - 1).Split(':');

                string columnDesciption = column_span[0];
                int rowSpan = Convert.ToInt32(column_span[1]);
                int columnSpan = Convert.ToInt32(column_span[2]);
                int rowPosition = Convert.ToInt32(column_span[3]);//转换成6列模式的时候不变
                int columnPosition = Convert.ToInt32(column_span[4]);//

                if (columnDesciption == null || columnDesciption.Trim().Equals(""))
                {
                    continue;
                }
                //
                //获取字段类型
                //
                ARColumn ar = GetType(columnDesciption);
                columnPosition = (columnPosition == 0 ? 1 : 4);//转换成6列模式的时候 columnPosition = 0 为 1， columnPosition = 1 为 4
                //
                //Label description
                //
                Label l = CreateLabel();
                l.Text = columnDesciption;
                this.tablePannel.Controls.Add(l, columnPosition - 1, rowPosition);
                this.tablePannel.SetRowSpan(l, rowSpan);
                //
                //TextBox
                //
                if (ar != null && ar.FieldType.Equals("Time"))
                {
                    DateTimePicker tb = new DateTimePicker();
                    tb.Name = columnDesciption;
                    tb.Margin = new System.Windows.Forms.Padding(1);
                    tb.AutoSize = false;
                    tb.Dock = DockStyle.Fill;
                    this.tablePannel.Controls.Add(tb, columnPosition, rowPosition);

                    if (columnSpan == 2) //columnSpan不是1就是2
                    {
                        columnSpan = 4;
                    }

                    this.tablePannel.SetRowSpan(tb, rowSpan);
                    this.tablePannel.SetColumnSpan(tb, columnSpan);
                    //
                    //如果是档案号组成项，保存
                    //
                    if (categoryComponent.Contains(tb.Name.Trim()))
                    {
                        componentControls.Add(tb);
                    }
                }
                else
                {
                    TextBox tb = CreateTextBox();
                    //ComboBox tb = CreateComboBox(ar.FieldName);
                    tb.Name = columnDesciption;
                    this.tablePannel.Controls.Add(tb, columnPosition, rowPosition);

                    if (columnSpan == 2) //columnSpan不是1就是2
                    {
                        columnSpan = 4;
                    }

                    this.tablePannel.SetRowSpan(tb, rowSpan);
                    this.tablePannel.SetColumnSpan(tb, columnSpan);

                    //
                    //如果是档案号组成项，保存
                    //
                    if (categoryComponent.Contains(tb.Name.Trim()))
                    {
                        componentControls.Add(tb);
                    }
                }
                if (categoryComponent.Contains(ar.Description.Trim()))
                {
                    l = CreateLabel();
                    l.Text = "PK";
                    l.ForeColor = Color.Red;
                    l.Dock = DockStyle.None;
                    this.tablePannel.Controls.Add(l, columnPosition + 1, rowPosition);
                }
                //
                //Label 是否能为空
                //
                else if (ar != null && ar.AllowEmpty.Equals("N"))
                {
                    l = CreateLabel();
                    l.Text = "*";
                    l.ForeColor = Color.Red;
                    l.Dock = DockStyle.None;
                    this.tablePannel.Controls.Add(l, columnPosition + 1, rowPosition);
                }

            }
        }

        private ARColumn GetType(String columnDescription)
        {
            for (int i = 0; i < typeList.Count; i++)
            {
                ARColumn ar = (ARColumn)typeList[i];
                if (ar.Description.Equals(columnDescription))
                {
                    return ar;
                }
            }
            return null;
        }

        private ComboBox CreateComboBox(string columnName)
        {
            ComboBox tb = new ComboBox();
            tb.Margin = new System.Windows.Forms.Padding(1);
            tb.AutoSize = false;
            tb.Dock = DockStyle.Fill;
            //
            //获取提示信息
            //
            try
            {
                List<string> reminder = reminders[columnName];
                for (int i = 0; i < reminder.Count; i++)
                {
                    tb.Items.Add(reminder[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tb;
        }

        //创建文本框
        private TextBox CreateTextBox()//string name)
        {
            TextBox tb = new TextBox();
            tb.Margin = new System.Windows.Forms.Padding(1);
            tb.AutoSize = false;
            tb.Dock = DockStyle.Fill;
            tb.Multiline = true;
            tb.KeyDown += new System.Windows.Forms.KeyEventHandler(KeyDown);
            return tb;
        }

        //创建文本框label
        private Label CreateLabel()
        {
            Label lab = new Label();
            lab.BackColor = Color.LightBlue;
            lab.Margin = new System.Windows.Forms.Padding(1);
            lab.Dock = DockStyle.Fill;
            lab.AutoSize = false;
            lab.TextAlign = ContentAlignment.MiddleCenter;
            return lab;
        }

        private string CheckError()
        {
            string errorStr = "";
            for (int i = 0; i < this.tablePannel.Controls.Count; i++)
            {
                Control c = this.tablePannel.Controls[i];
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)(c);
                    //
                    //找到与tb.name名字相同的type
                    //
                    for (int j = 0; j < typeList.Count; j++)
                    {
                        ARColumn ar = (ARColumn)typeList[j];
                        if (tb.Name.Equals(ar.Description))
                        {
                            errorStr += checkType(tb.Text, ar);
                        }
                    }
                }
            }
            return errorStr;
        }

        private void insert()
        {
            string insertPart = "insert into " + categoryTableName + "(ARCHIVESID,";
            string valuePart = "values(T_ARCHIVESID_SEQ.nextval,'";
            for (int i = 0; i < this.tablePannel.Controls.Count; i++)
            {
                Control c = this.tablePannel.Controls[i];
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    string description = tb.Name;
                    string columnName = ServerProxy.GetProxy().GetColumnByDescriptionAndCategory(description, categoryName);
                    insertPart += columnName + ",";
                    if (tb.Text.Trim().Equals(""))
                    {
                        valuePart += "','";
                    }
                    else
                    {
                        valuePart += tb.Text + "','";
                    }
                }
                else if (c is DateTimePicker)
                {
                    DateTimePicker tb = (DateTimePicker)c;
                    string description = tb.Name;
                    string columnName = ServerProxy.GetProxy().GetColumnByDescriptionAndCategory(description, categoryName);
                    insertPart += columnName + ",";
                    if (tb.Text.Trim().Equals(""))
                    {
                        valuePart += "','";
                    }
                    else
                    {
                        valuePart += convertToDateFormat(tb.Text) + "','";
                    }

                }
            }
            insertPart = insertPart.Substring(0, insertPart.Length - 1) + ")";
            valuePart = valuePart.Substring(0, valuePart.Length - 1 - 1) + ")";
            string sqlStr = insertPart + valuePart;
            Console.WriteLine(sqlStr);
            if (ServerProxy.GetProxy().insertCategory(sqlStr) == 1)
            {
                MessageBox.Show("插入成功");
            }
            else
            {
                MessageBox.Show("插入失败");
            }
        }

        private void bt_insert_Click(object sender, EventArgs e)
        {
            string errorStr = CheckError();
            if (errorStr.Equals(""))  //没有错误
            {
                insert();
            }
            else
            {
                MessageBox.Show(errorStr);
            }
        }

        //
        //检查字段内容是否符合字段类型
        //
        public string checkType(string content, ARColumn column)
        {
            string ret = "";
            //
            //检查是否为档案号组成
            //
            if (categoryComponent.Contains(column.Description) && content.Trim().Equals(""))
            {
                ret += column.Description + ":是档案号组成项，不能为空\n";
            }

            //
            //检查字节数
            //
            int bytes = Convert.ToInt32(column.Bytes);
            int len = content.Length;
            if (len > bytes)
            {
                ret += column.Description + ":字段内容超过" + column.Bytes + "字节\n";
            }

            //
            //检查是否为空
            //
            if (column.AllowEmpty.Trim().Equals("N") && content.Trim().Equals(""))
            {
                ret += column.Description + ":字段内容不允许为空\n";
                return ret;
            }

            //
            //检查类型
            //
            if (!content.Equals(""))
            {
                try
                {
                    if (column.FieldType.Equals("String"))
                    {

                    }
                    else if (column.FieldType.Equals("Int"))
                    {
                        Convert.ToInt32(content);
                    }
                    else if (column.FieldType.Equals("Time"))
                    {
                        Convert.ToDateTime(content);
                    }
                    else if (column.FieldType.Equals("Bool"))
                    {

                    }
                    else if (column.FieldType.Equals("Double"))
                    {
                        Convert.ToDouble(content);
                    }
                }
                catch (Exception ex)
                {
                    ret += column.Description + ":" + ex.Message + "\n";
                }
            }

            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src">年月日格式</param>
        /// <returns></returns>
        private string convertToDateFormat(string src)
        {
            string dest = "";
            int yearIndex = src.IndexOf("年");
            int monthIndex = src.IndexOf("月");
            int dateIndex = src.IndexOf("日");


            dest += src.Substring(0, yearIndex);
            dest += "-";
            dest += src.Substring(yearIndex + 1, monthIndex - yearIndex - 1);
            dest += "-";
            dest += src.Substring(monthIndex + 1, dateIndex - monthIndex - 1);
            return dest;
        }

        private void btinsertCustom_Click(object sender, EventArgs e)
        {
            new CustomizeForm(categoryTableName, ConfigType.InsertCustom, null, this, null, null).Show();
        }

        private void timer_dah_Tick(object sender, EventArgs e)
        {
            string[] components = categoryComponent.Split('-');
            GenerateDAH(components);
        }

        private void GenerateDAH(string[] components)
        {
            string dah = categoryComponent + " : ";
            for (int i = 0; i < components.Length; i++)
            {
                foreach (Control c in componentControls)
                {
                    try
                    {
                        TextBox tb = (TextBox)c;
                        if (tb.Name.Equals(components[i]))
                        {
                            dah += tb.Text + "-";
                        }
                    }
                    catch
                    {

                    }
                }
            }
            l_dah.Text = dah.Substring(0, dah.Length - 1);
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            StringBuilder keyValue = new StringBuilder();
            keyValue.Length = 0;
            keyValue.Append("");
            if (e.Modifiers != 0)
            {
                if (e.Control)
                    keyValue.Append("Ctrl + ");
                if (e.Alt)
                    keyValue.Append("Alt + ");
                if (e.Shift)
                    keyValue.Append("Shift + ");
            }
            if ((e.KeyValue >= 33 && e.KeyValue <= 40) ||
                (e.KeyValue >= 65 && e.KeyValue <= 90) ||   //a-z/A-Z
                (e.KeyValue >= 112 && e.KeyValue <= 123))   //F1-F12
            {
                keyValue.Append(e.KeyCode);
            }
            else if ((e.KeyValue >= 48 && e.KeyValue <= 57))    //0-9
            {
                keyValue.Append(e.KeyCode.ToString().Substring(1));
            }

            if (keyValue.ToString().Trim().Equals("Ctrl + H"))
            {
                TextBox tb = (TextBox)sender;
                Console.WriteLine(tb.Name + ":" + categoryName);
                string columnName = ServerProxy.GetProxy().GetColumnByDescriptionAndCategory(tb.Name, categoryName);
                new SelectReminderForm(columnName, tb).Show();
            }
        }
    }
}
