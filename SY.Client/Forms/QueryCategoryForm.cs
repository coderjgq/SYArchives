using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SY.MODEL;
using HostService.Services;
using System.IO;
using SY.Client.Forms.Attach;
using SY.Client.Forms.User;
using SY.Client.Forms.Access;

namespace SY.Client.Forms
{
    public partial class QueryCategoryForm : Form
    {
        private LoginForm loginForm;
        private string[] selectedDescriptions;
        private string[] selectedColumns;
        private string queryStr;
        private string categoryTableName;
        private string categoryName;
        private string queryConfigValue;
        
        private int rowHeight = 30;
        private int columnWidth = 150;
        private int additionalWidth = 0;
        
        private int columnCount = 0;
        private int rowCount = 0;
        private ArrayList typeList = new ArrayList();
        private List<string> columnList = new List<string>();
        private int pageSize = 100;
        private int page = 0;
        private int totalPage = 0;
        private int total = 0;
        private List<List<string>> results = null;

        public QueryCategoryForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            CheckAccess();
        }

        //**************************************   其他  **********************************************************

        private void InitStatus()
        {
            l_status.Text = "总共 " + (0 + 1) + " 页  当前第 " + (0 + 1) + " 页";
        }

        private void ShowStatus()
        {
            l_status.Text = "总共 " + (totalPage + 1) + " 页  当前第 " + (page + 1) + " 页";
        }

        private void SetFormTitle()
        {
            if (this.categoryTableName != null && !this.categoryTableName.Equals(""))
            {
                string categoryName = this.categoryTableName.Split('_')[2];
                ARCategory ar = ServerProxy.GetProxy().GetCategory(categoryName);
                this.Text = "查询 - " + ar._DESCRIPTION;
            }
        }

        private void InitTableLayout()
        {
            this.tlp_query.ColumnStyles.Clear();
            this.tlp_query.RowStyles.Clear();
            this.tlp_query.Height = 0;
            this.tlp_query.Width = 0;

            string[] columnMsgs = queryConfigValue.Split(',');//[0]是行列信息，后面是字段信息
            string tmp = columnMsgs[0].Substring(1, columnMsgs[0].Length - 1 - 1);
            string[] row_column = tmp.Split(':');
            string rowCountStr = row_column[0];
            string columnCountStr = row_column[1];

            rowCount = Convert.ToInt32(rowCountStr);
            columnCount = Convert.ToInt32(columnCountStr) + 4 + 4 + 1;
            this.tlp_query.ColumnCount = columnCount;
            this.tlp_query.RowCount = rowCount;
            for (int i = 0; i < columnCount; i++)
            {
                if (i == 2 || i == 8)
                {
                    //最后一列 + additionalWidth
                    this.tlp_query.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, columnWidth + additionalWidth));
                }
                else
                {
                    this.tlp_query.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, columnWidth));
                }
            }
            this.tlp_query.Width = columnCount * columnWidth + 2*additionalWidth;
            for (int i = 0; i < rowCount; i++)
            {
                this.tlp_query.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
            }
            this.tlp_query.Height = rowCount * rowHeight;
            Console.WriteLine("tlp_query.Width = " + tlp_query.Width + ", tlp_query.Height = " + tlp_query.Height);
        }

        private void InitColumnType()
        {
            string[] columnMsgs = queryConfigValue.Split(',');//[0]是行列信息，后面是字段信息
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
        }

        public void InitResultOrder()
        {
            //
            //获取显示字段信息
            //
            string configValue = ServerProxy.GetProxy().GetConfigValue(categoryTableName + ConfigType.ResultOrder, LoginForm.LOGIN_USER_NAME);

            if (configValue == null || configValue.Trim().Equals(""))
            {
                selectedDescriptions = null;
                selectedColumns = null;
                return;
            }

            selectedDescriptions = configValue.Split(',');
            selectedColumns = new string[selectedDescriptions.Length + 1];
            //
            //将selectedDecriptions转换成selectedColumns
            //
            for (int i = 0; i < selectedDescriptions.Length; i++)
            {
                selectedColumns[i] = ServerProxy.GetProxy().GetColumnByDescriptionAndCategory(selectedDescriptions[i], categoryName);
            }
            selectedColumns[selectedDescriptions.Length] = "ARCHIVESID";

            for (int i = 0; i < selectedColumns.Length; i++)
            {
                Console.WriteLine(">>>>>:: " + selectedColumns[i]);
            }
        }

        public void InitDataGridView()
        {
            //
            //初始化DataGridView
            //
            this.dgv_result.Columns.Clear();
            this.dgv_result.Rows.Clear();
            DataGridViewTextBoxColumn tmpColumn = new DataGridViewTextBoxColumn();
            tmpColumn.HeaderText = "序号";

            this.dgv_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmpColumn });

            if (selectedDescriptions != null)
            {
                List<DataGridViewTextBoxColumn> tmpList = new List<DataGridViewTextBoxColumn>();

                for (int i = 0; i < selectedDescriptions.Length; i++)
                {
                    string description = selectedDescriptions[i];
                    if (description == null || description.Trim().Equals(""))
                    {
                        break;
                    }
                    tmpColumn = new DataGridViewTextBoxColumn();
                    tmpColumn.HeaderText = description;
                    tmpColumn.Name = selectedColumns[i];
                    tmpList.Add(tmpColumn);
                }
                HandleColumn(tmpList);
            }
        }

        private void HandleColumn(List<DataGridViewTextBoxColumn> tmpList)
        {
            int width = CountWidth(tmpList);
            if (width > dgv_result.Width)
            {
                AddNoSetColumn(tmpList);
            }
            else
            {
                AddFillModeColumn(tmpList);
            }
            ClearAutoSizeMode(tmpList);
        }

        private void AddNoSetColumn(List<DataGridViewTextBoxColumn> tmpList)
        {
            foreach (DataGridViewTextBoxColumn tmp in tmpList)
            {
                tmp.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                this.dgv_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmp });
            }
        }

        private void AddFillModeColumn(List<DataGridViewTextBoxColumn> tmpList)
        {
            foreach (DataGridViewTextBoxColumn tmp in tmpList)
            {
                tmp.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgv_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tmp });
            }
        }

        private int CountWidth(List<DataGridViewTextBoxColumn> tmpList)
        {
            int ret = 0;
            foreach (DataGridViewTextBoxColumn tmp in tmpList)
            {
                ret += tmp.Width;
            }
            return ret;
        }

        private void ClearAutoSizeMode(List<DataGridViewTextBoxColumn> tmpList)
        {
            foreach (DataGridViewTextBoxColumn tmp in tmpList)
            {
                tmp.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            }
        }

        public void SetQueryConfigValue(string queryConfigValue)
        {
            this.queryConfigValue = queryConfigValue;
        }

        public void SetSelectDescriptions(string[] selectedDescriptions)
        {
            this.selectedDescriptions = selectedDescriptions;
        }

        public void SetSelectedColumns(string[] selectedColumns)
        {
            this.selectedColumns = selectedColumns;
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


        //***********************************   初始化查询条件界面   ****************************************

        private void InitQueryControls()
        {
            string[] columnMsgs = queryConfigValue.Split(',');//[0]是行列信息，后面是字段信息
            for (int i = 1; i < columnMsgs.Length; i++)
            {
                string msg = columnMsgs[i];
                string[] column_span = msg.Substring(1, msg.Length - 1 - 1).Split(':');

                ColumnMessage.ColumnDesciption = column_span[0];
                ColumnMessage.RowSpan = Convert.ToInt32(column_span[1]);
                ColumnMessage.ColumnSpan = Convert.ToInt32(column_span[2]);
                ColumnMessage.RowPosition = Convert.ToInt32(column_span[3]);
                ColumnMessage.ColumnPosition = Convert.ToInt32(column_span[4]);

                ARColumn ar = GetType(ColumnMessage.ColumnDesciption);

                if (ar == null)
                {
                    continue;
                }

                string columnName = ar.FieldName;

                ColumnMessage.ColumnPosition = ColumnMessage.ColumnPosition == 0 ? 0 : 6;
                //
                //description
                //
                AddRowDescription(columnName);

                if (ar.FieldType.Equals("Int") || ar.FieldType.Equals("Double"))
                {
                    AddIntColumn(columnName);
                }
                else if (ar.FieldType.Equals("String"))
                {
                    AddStringColumn(columnName);
                }
                else if (ar.FieldType.Equals("Bool"))
                {
                    AddBoolColumn(columnName);
                }
                else if (ar.FieldType.Equals("Time"))
                {
                    AddTimeColumn(columnName);
                }
            }
        }

        public void InitQueryConditions()
        {
            SetFormTitle();
            this.tlp_query.Controls.Clear();
            this.tlp_query.RowCount = 0;
            this.tlp_query.ColumnCount = 0;
            this.queryConfigValue = ServerProxy.GetProxy().GetConfigValue(this.categoryTableName + ConfigType.QueryCustom, LoginForm.LOGIN_USER_NAME);
            if (queryConfigValue == null || queryConfigValue.Trim().Equals(""))
            {
                return;
            }
            //
            //初始化TableLayout
            //
            InitTableLayout();
            //
            //获取字段类型
            //
            InitColumnType();
            //
            //初始化查询界面
            //
            InitQueryControls();
        }

        private TextBox CreateTextBox()
        {
            TextBox tb = new TextBox();
            tb.Margin = new System.Windows.Forms.Padding(2);
            tb.AutoSize = false;
            tb.Dock = DockStyle.Fill;
            tb.Width = columnWidth + additionalWidth;
            tb.Multiline = true;
            return tb;
        }

        private Label CreateLabel()
        {
            Label lab = new Label();
            lab.BackColor = Color.LightBlue;
            lab.Margin = new System.Windows.Forms.Padding(2);
            lab.Dock = DockStyle.Fill;
            lab.AutoSize = false;
            lab.TextAlign = ContentAlignment.MiddleCenter;
            return lab;
        }

        private ComboBox CreateComboBox()
        {
            ComboBox lab = new ComboBox();
            lab.Dock = DockStyle.Fill;
            lab.DropDownStyle = ComboBoxStyle.DropDownList;

            lab.Items.Add(" = ");
            lab.Items.Add(" > ");
            lab.Items.Add(" < ");
            lab.Items.Add(" >= ");
            lab.Items.Add(" <= ");
            lab.Items.Add(" 介于 ");
            lab.Items.Add(" ");

            return lab;
        }

        private ComboBox CreateHidenComboBox()
        {
            ComboBox lab = new ComboBox();
            lab.Dock = DockStyle.Fill;
            lab.DropDownStyle = ComboBoxStyle.DropDownList;

            lab.Items.Add(" = ");
            lab.Items.Add(" > ");
            lab.Items.Add(" < ");
            lab.Items.Add(" >= ");
            lab.Items.Add(" <= ");
            lab.Items.Add(" 介于 ");
            lab.Items.Add(" ");
            lab.Hide();
            lab.Tag = "InControl";
            return lab;
        }

        private TextBox CreateHidenTextBox()
        {
            TextBox tb = new TextBox();
            tb.Width = columnWidth;
            tb.Margin = new System.Windows.Forms.Padding(2);
            tb.AutoSize = false;
            tb.Dock = DockStyle.Fill;
            tb.Multiline = true;
            tb.Hide();
            tb.Tag = "InControl";
            return tb;
        }

        private ComboBox CreateIntControlComboBox()
        {
            ComboBox lab = new ComboBox();
            lab.Dock = DockStyle.Fill;
            lab.DropDownStyle = ComboBoxStyle.DropDownList;

            lab.Items.Add(" = ");
            lab.Items.Add(" > ");
            lab.Items.Add(" < ");
            lab.Items.Add(" >= ");
            lab.Items.Add(" <= ");
            lab.Items.Add(" 介于 ");
            lab.Items.Add(" ");

            lab.SelectedIndexChanged += new System.EventHandler(IntControl_SelectedIndexChanged);

            return lab;
        }

        private ComboBox CreateTimeControlComboBox()
        {
            ComboBox lab = new ComboBox();
            lab.Dock = DockStyle.Fill;
            lab.DropDownStyle = ComboBoxStyle.DropDownList;

            lab.Items.Add(" = ");
            lab.Items.Add(" > ");
            lab.Items.Add(" < ");
            lab.Items.Add(" >= ");
            lab.Items.Add(" <= ");
            lab.Items.Add(" 介于 ");
            lab.Items.Add(" ");

            lab.SelectedIndexChanged += new System.EventHandler(TimeControl_SelectedIndexChanged);

            return lab;
        }

        private DateTimePicker CreateHidenDateTimePicker()
        {
            DateTimePicker dtp = new DateTimePicker();
            dtp.Hide();
            dtp.Tag = "InControl";
            return dtp;
        }

        private void AddRowDescription(string columnName)
        {
            Label l = CreateLabel();
            l.Text = ColumnMessage.ColumnDesciption;
            l.Name = columnName;
            this.tlp_query.Controls.Add(l, ColumnMessage.ColumnPosition, ColumnMessage.RowPosition);
        }

        private void AddIntColumn(string columnName)
        {
            //
            //=,>,<,>=,<=
            //
            ComboBox cb = CreateIntControlComboBox();
            cb.Name = columnName;
            this.tlp_query.Controls.Add(cb, ColumnMessage.ColumnPosition + 1, ColumnMessage.RowPosition);
            //
            //内容1
            //
            TextBox t = CreateTextBox();
            t.Name = columnName;
            t.Dock = DockStyle.Left;
            this.tlp_query.Controls.Add(t, ColumnMessage.ColumnPosition + 2, ColumnMessage.RowPosition);
            //
            //内容2
            //
            t = CreateHidenTextBox();
            t.Name = columnName;
            t.Dock = DockStyle.Left;
            this.tlp_query.Controls.Add(t, ColumnMessage.ColumnPosition + 3, ColumnMessage.RowPosition);
        }

        private void AddStringColumn(string columnName)
        {
            //
            //=,>,<,>=,<=
            //
            ComboBox cb = CreateComboBox();
            cb.Items.Clear();
            cb.Items.Add("等于");
            cb.Items.Add("不等于");
            cb.Items.Add("包含");
            cb.Items.Add("不包含");
            cb.Items.Add(" ");
            cb.Name = columnName;
            //cb.Text = "等于";
            this.tlp_query.Controls.Add(cb, ColumnMessage.ColumnPosition + 1, ColumnMessage.RowPosition);
            //
            //内容1
            //
            TextBox t = CreateTextBox();
            t.Name = columnName;
            t.Dock = DockStyle.Left;
            this.tlp_query.Controls.Add(t, ColumnMessage.ColumnPosition + 2, ColumnMessage.RowPosition);
        }

        private void AddBoolColumn(string columnName)
        {
            //
            //=,>,<,>=,<=
            //
            ComboBox cb = CreateComboBox();
            cb.Items.Clear();
            cb.Items.Add("是");
            cb.Items.Add("否");
            cb.Items.Add(" ");
            cb.Name = columnName;

            this.tlp_query.Controls.Add(cb, ColumnMessage.ColumnPosition + 1, ColumnMessage.RowPosition);
        }

        private void AddTimeColumn(string columnName)
        {
            //
            //=,>,<,>=,<=
            //
            ComboBox cb = CreateTimeControlComboBox();
            cb.Name = columnName;
            this.tlp_query.Controls.Add(cb, ColumnMessage.ColumnPosition + 1, ColumnMessage.RowPosition);
            //
            //内容1
            //
            DateTimePicker t = new DateTimePicker();
            t.Name = columnName;
            t.Dock = DockStyle.Left;
            this.tlp_query.Controls.Add(t, ColumnMessage.ColumnPosition + 2, ColumnMessage.RowPosition);
            //
            //内容2
            //
            t = CreateHidenDateTimePicker();
            t.Name = columnName;
            t.Dock = DockStyle.Left;
            this.tlp_query.Controls.Add(t, ColumnMessage.ColumnPosition + 3, ColumnMessage.RowPosition);
        }

        private void ShowTextBox(string columnName)
        {
            foreach (Control c in this.tlp_query.Controls)
            {
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    if (tb.Name.Trim().Equals(columnName))
                    {
                        if (tb.Tag != null && tb.Tag.Equals("InControl"))
                        {
                            tb.Show();
                        }
                    }
                }
            }
        }

        private void ShowComboBox(string columnName)
        {
            foreach (Control c in this.tlp_query.Controls)
            {
                if (c is ComboBox)
                {
                    ComboBox tb = (ComboBox)c;
                    if (tb.Name.Trim().Equals(columnName))
                    {
                        if (tb.Tag != null && tb.Tag.Equals("InControl"))
                        {
                            tb.Show();
                        }
                    }
                }
            }
        }

        private void ShowDateTimePicker(string columnName)
        {
            foreach (Control c in this.tlp_query.Controls)
            {
                if (c is DateTimePicker)
                {
                    DateTimePicker tb = (DateTimePicker)c;
                    if (tb.Name.Trim().Equals(columnName))
                    {
                        if (tb.Tag != null && tb.Tag.Equals("InControl"))
                        {
                            Console.WriteLine("ShowDateTimePicker = " + columnName);
                            tb.Show();
                        }
                    }
                }
            }
        }

        private void HideTextBox(string columnName)
        {
            foreach (Control c in this.tlp_query.Controls)
            {
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    if (tb.Name.Trim().Equals(columnName))
                    {
                        if (tb.Tag != null && tb.Tag.Equals("InControl"))
                        {
                            tb.Hide();
                        }
                    }
                }
            }
        }

        private void HideComboBox(string columnName)
        {
            foreach (Control c in this.tlp_query.Controls)
            {
                if (c is ComboBox)
                {
                    ComboBox tb = (ComboBox)c;
                    if (tb.Name.Trim().Equals(columnName))
                    {
                        if (tb.Tag != null && tb.Tag.Equals("InControl"))
                        {
                            tb.Hide();
                        }
                    }
                }
            }
        }

        private void HideDateTimePicker(string columnName)
        {
            foreach (Control c in this.tlp_query.Controls)
            {
                if (c is DateTimePicker)
                {
                    DateTimePicker tb = (DateTimePicker)c;
                    if (tb.Name.Trim().Equals(columnName))
                    {
                        if (tb.Tag != null && tb.Tag.Equals("InControl"))
                        {
                            tb.Hide();
                        }
                    }
                }
            }
        }

        private void IntControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            string columnName = cb.Name;
            string select = cb.Items[cb.SelectedIndex].ToString();
            Console.WriteLine("select = " + select);
            if (!select.Equals(" 介于 "))
            {
                HideTextBox(columnName);
            }
            else
            {
                ShowTextBox(columnName);
            }
        }

        private void TimeControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            string columnName = cb.Name;
            string select = cb.Items[cb.SelectedIndex].ToString();
            Console.WriteLine("select = " + select);
            if (!select.Equals(" 介于 "))
            {
                HideDateTimePicker(columnName);
            }
            else
            {
                ShowDateTimePicker(columnName);
            }
        }

        //******************************************  查询语句  *****************************************************

        private string GetQueryHead()
        {
            string sqlHead = "select ";
            for (int i = 0; i < selectedColumns.Length; i++)
            {
                sqlHead += selectedColumns[i] + ",";
            }

            sqlHead = sqlHead.Substring(0, sqlHead.Length - 1);

            sqlHead = sqlHead + " from ";

            return sqlHead;
        }

        private string GetQuerySelectStr()
        {
            string sqlstr = "select rownum r, t.* from " + categoryTableName + " t where ";

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (j == 0 || j == 6)
                    {
                        Label l = (Label)this.tlp_query.GetControlFromPosition(j, i);
                        if (l == null)
                        {
                            continue;
                        }
                        string columnName = l.Name;
                        string columnDescription = l.Text;

                        ARColumn ar = GetType(columnDescription);

                        if (ar.FieldType.Equals("Int") || ar.FieldType.Equals("Double"))
                        {
                            sqlstr += GetIntSqlStr(i, j, columnName);
                        }
                        else if (ar.FieldType.Equals("String") || ar.FieldType.Equals("Bool"))
                        {
                            sqlstr += GetStringSqlStr(i, j, columnName);
                        }
                        else if (ar.FieldType.Equals("Time"))
                        {
                            sqlstr += GetDateTimeSqlStr(i, j, columnName);
                        }
                    }
                }
            }
            return sqlstr;
        }

        private string GetIntSqlStr(int row, int column, string columnName)
        {
            string sqlstr = "";
            ComboBox cb1 = (ComboBox)this.tlp_query.GetControlFromPosition(column + 1, row);
            TextBox tb1 = (TextBox)this.tlp_query.GetControlFromPosition(column + 2, row);
            TextBox tb2 = (TextBox)this.tlp_query.GetControlFromPosition(column + 3, row);

            if (cb1.Text.Equals(" 介于 "))
            {
                if (!tb1.Text.Trim().Equals(""))
                {
                    sqlstr += "to_number(" + columnName + ")" + " >= " + tb1.Text + " and ";
                }
                if (!tb2.Text.Trim().Equals(""))
                {
                    sqlstr += "to_number(" + columnName + ")" + " <= " + tb2.Text + " and ";
                }
                return sqlstr;
            }

            if (!tb1.Text.Trim().Equals(""))
            {
                sqlstr += "to_number(" + columnName + ")" + cb1.Text + tb1.Text + " and ";
            }

            return sqlstr;
        }

        private string GetStringSqlStr(int row, int column, string columnName)
        {
            string sqlstr = "";
            ComboBox cb1 = (ComboBox)this.tlp_query.GetControlFromPosition(column + 1, row);
            TextBox tb1 = (TextBox)this.tlp_query.GetControlFromPosition(column + 2, row);
            string option = cb1.Text.Trim();
            if (!option.Equals(""))
            {
                if (option.Equals("不等于"))
                {
                    option = " != ";
                    sqlstr += columnName + option + "\'" + tb1.Text.Trim() + "\' and ";
                }
                else if (option.Equals("等于"))
                {
                    option = " = ";
                    sqlstr += columnName + option + "\'" + tb1.Text.Trim() + "\' and ";
                }
                else if (option.Equals("包含"))
                {
                    option = " like ";
                    sqlstr += columnName + option + "\'%" + tb1.Text.Trim() + "%\' and ";
                }
                else if (option.Equals("不包含"))
                {
                    option = " not like ";
                    sqlstr += columnName + option + "\'%" + tb1.Text.Trim() + "%\' and ";
                }
            }
            return sqlstr;
        }

        private string GetDateTimeSqlStr(int row, int column, string columnName)
        {
            string sqlstr = "";
            ComboBox cb1 = (ComboBox)this.tlp_query.GetControlFromPosition(column + 1, row);
            DateTimePicker tb1 = (DateTimePicker)this.tlp_query.GetControlFromPosition(column + 2, row);
            DateTimePicker tb2 = (DateTimePicker)this.tlp_query.GetControlFromPosition(column + 3, row);

            if (cb1.Text.Equals(" 介于 "))
            {
                if (!tb1.Text.Trim().Equals(""))
                {
                    sqlstr += "to_date(" + columnName + ",\'yy-mm-dd\' )" + " >= " + "to_date('" + ConvertToDateFormat(tb1.Text) + "\', \'yy-mm-dd\') and ";
                }
                if (!tb2.Text.Trim().Equals(""))
                {
                    sqlstr += "to_date(" + columnName + ",\'yy-mm-dd\' )" + " <= " + "to_date(\'" + ConvertToDateFormat(tb2.Text) + "\', \'yy-mm-dd\') and ";
                }
                return sqlstr;
            }

            if (!cb1.Text.Trim().Equals(""))
            {
                sqlstr += "to_date(" + columnName + ",\'yy-mm-dd\' )" + cb1.Text.Trim() + "to_date('" + ConvertToDateFormat(tb1.Text) + "\', \'yy-mm-dd\') and ";
            }

            return sqlstr;
        }

        private int GetTotal()
        {
            string sqlHead = "select count(*) from ";
            string sqlstr = GetQuerySelectStr();
            string endStr = sqlstr.Substring(sqlstr.Length - 1 - 5, 5);
            if (endStr.Equals("where"))
            {
                return 0;
            }
            sqlstr = sqlstr.Substring(0, sqlstr.Length - 5);//去末尾的and
            queryStr = sqlHead + "(" + sqlstr + ")";// where " + " r between " + (page * pageSize + 1) + " and " + (page * pageSize + pageSize);
            int total = ServerProxy.GetProxy().GetTotal(queryStr);
            Console.WriteLine("total sqlstr = " + queryStr);
            return total;
        }

        private List<List<string>> QueryResult()
        {
            results = null;

            string sqlHead = GetQueryHead();

            string sqlstr = GetQuerySelectStr();

            string endStr = sqlstr.Substring(sqlstr.Length - 1 - 5, 5);

            if (endStr.Equals("where"))
            {
                MessageBox.Show("请选择查询条件");
                return null;
            }
            sqlstr = sqlstr.Substring(0, sqlstr.Length - 5);//去末尾的and
            queryStr = sqlHead + "(" + sqlstr + ") where " + " r between " + (page * pageSize + 1) + " and " + (page * pageSize + pageSize);

            Console.WriteLine(queryStr);
            try
            {
                //
                //获取查询结果
                //
                results = ServerProxy.GetProxy().GetQueryResult(selectedColumns, queryStr);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return results;
        }

        private void QueryAttachedTable()
        {
            string oldTableName = this.categoryTableName;

            this.categoryTableName = this.categoryTableName + ConfigType.AttachedTable;

            List<List<string>> results = QueryResult();
            if (results != null)
            {
                DisplayResults(selectedDescriptions, results);
            }
            this.categoryTableName = oldTableName;
        }

        private void QueryTable()
        {
            List<List<string>> results = QueryResult();
            if (results != null)
            {
                DisplayResults(selectedDescriptions, results);
            }
        }

        private void DisplayResults(string[] resultOrder, List<List<string>> results)
        {
            InitDataGridView();
            for (int i = 0; i < results.Count; i++)
            {
                List<string> row = results[i];
                string tmp = "";
                dgv_result.Rows.Add();
                dgv_result.Rows[i].Cells[0].Value = "" + (i + 1);
                for (int j = 0; j < row.Count - 1; j++)
                {
                    tmp += row[j].ToString() + ",";

                    dgv_result.Rows[i].Cells[j + 1].Value = row[j].ToString();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src">年月日格式</param>
        /// <returns></returns>
        private string ConvertToDateFormat(string src)
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

        //*************************************   树相关  *******************************************************

        public void DisplayTree()
        {
            this.tv.Nodes.Clear();
            List<ARCategory> list = ServerProxy.GetProxy().GetCategorys();
            List<ARCategory> roots = GetRoots(list);
            for (int i = 0; i < roots.Count; i++)
            {
                ARCategory r = roots[i];
                TreeNode rootNode = new TreeNode();
                rootNode.Text = r._DESCRIPTION;
                rootNode.Tag = "T_" + r._TYPE + "_" + r._NAME;
                this.tv.Nodes.Add(rootNode);
                GetChildren(r, list, rootNode);
            }
        }

        private void GetChildren(ARCategory root, List<ARCategory> list, TreeNode rootNode)
        {
            if (root == null)
            {
                return;
            }
            for (int i = 0; i < list.Count; i++)
            {
                ARCategory c = list[i];
                if (c._PARENT_NO != null && c._PARENT_NO.Trim().Equals(root._NAME.Trim()))
                {
                    TreeNode child = new TreeNode();
                    child.Text = c._DESCRIPTION;
                    child.Tag = "T_" + c._TYPE + "_" + c._NAME;
                    rootNode.Nodes.Add(child);
                    GetChildren(c, list, child);
                }
            }
        }

        private List<ARCategory> GetRoots(List<ARCategory> list)
        {
            List<ARCategory> roots = new List<ARCategory>();
            for (int i = 0; i < list.Count; i++)
            {
                ARCategory c = list[i];
                if (c._PARENT_NO == null || c._PARENT_NO.Trim().Equals(""))
                {
                    roots.Add(c);
                }
            }
            return roots;
        }

        //*********************************  事件  *****************************************************

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = tv.SelectedNode;
            this.categoryTableName = node.Tag + "";
            this.queryConfigValue = ServerProxy.GetProxy().GetConfigValue(this.categoryTableName + ConfigType.QueryCustom, LoginForm.LOGIN_USER_NAME);
            InitQueryConditions();
            InitResultOrder();
            InitDataGridView();
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {

                MessageBox.Show("请先选择分类");
                return;
            }
            new InsertCategoryForm(this.categoryTableName).Show();
        }

        private void btNextPage_Click(object sender, EventArgs e)
        {
            if (page < totalPage)
            {
                page++;
                bt_query_Click(null, null);
                ShowStatus();
            }
        }

        private void btLastPage_Click(object sender, EventArgs e)
        {
            if (page > 0)
            {
                page--;
                bt_query_Click(null, null);
                ShowStatus();
            }
        }

        private void tbPageSize_TextChanged(object sender, EventArgs e)
        {
            if (!tbPageSize.Text.Trim().Equals(""))
            {
                try
                {
                    pageSize = Convert.ToInt32(tbPageSize.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    tbPageSize.Text = "";
                }
            }
        }

        private void btSetKey_Click(object sender, EventArgs e)
        {
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            new PrimaryKeyForm(null, categoryTableName).Show();
        }

        private void btColumnModify_Click(object sender, EventArgs e)
        {
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            new ModifyColumnForm(categoryTableName).Show();
        }
        
        private void btLeftHiden_Click(object sender, EventArgs e)
        {
            if (btLeftHiden.Text.Equals(">"))
            {
                btLeftHiden.Text = "<";
                this.panel_left.Width = this.btLeftHiden.Width + this.panel_left_left.Width;
                this.panel_left_left.Show();
                this.DisplayTree();
            }
            else
            {
                btLeftHiden.Text = ">";
                this.panel_left_left.Hide();
                this.panel_left.Width = this.btLeftHiden.Width;
            }
        }

        private void btModifyCategory_Click(object sender, EventArgs e)
        {
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            new ModifyCategoryForm(this.categoryTableName).Show();
        }

        private void btAddCategory_Click(object sender, EventArgs e)
        {
            new AddCategoryForm().ShowDialog();
        }

        private void btDeleteCategory_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }
            string categoryName = categoryTableName.Split('_')[2];
            ARCategory ar = ServerProxy.GetProxy().GetCategory(categoryName);
            ServerProxy.GetProxy().DeleteCategory(ar);
        }

        private string GetExportTemplatePath()
        {
            string path = "";
            DialogResult dr = exportTemplatePath.ShowDialog();
            if (dr == DialogResult.OK)
            {
                path = exportTemplatePath.SelectedPath;
                return path;
            }
            else
            {
                return null;
            }
        }

        private void exportExcel(string tableName, string path)
        {
            List<string> descriptions = ServerProxy.GetProxy().GetTableColumnDescriptions(tableName);
            List<string> columnNames = ServerProxy.GetProxy().GetTableColumns(tableName);

            columnNames.Remove("ARCHIVESID");
            ExcelUtil excel = new ExcelUtil();
            try
            {
                excel.init();
                //
                //------------------输出模板内容-----------------------------
                //
                for (int i = 0; i < descriptions.Count; i++)
                {
                    excel.write(1, 1 + i, descriptions[i]);
                }

                for (int i = 0; i < columnNames.Count; i++)
                {
                    excel.write(2, 1 + i, columnNames[i]);
                }

                path = path + tableName + ".xlsx";

                Console.WriteLine("path = " + path);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                excel.save(path);
                excel.close();
                MessageBox.Show("导出成功!");

            }
            catch (Exception ex)
            {
                excel.close();
                Console.WriteLine("失败！");
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private void bt_export_Click(object sender, EventArgs e)
        {
            string path = GetExportTemplatePath();
            if (path == null)
            {
                return;
            }
            exportExcel(this.categoryTableName, path);
        }

        private void bt_import_Click(object sender, EventArgs e)
        {
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            DialogResult dr = importPath.ShowDialog();
            string excelPath = "";
            if (dr == DialogResult.OK)
            {
                Console.WriteLine(importPath.FileName);
                excelPath = importPath.FileName;
            }

            try
            {
                new ImportForm(categoryTableName, excelPath).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgv_result_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            List<string> row = results[rowIndex];
            int id = 0;
            try
            {
                id = Convert.ToInt32(row[row.Count - 1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取ID有误," + row[row.Count - 1]);
                return;
            }

            {
                new ShowRecordDetailForm(categoryTableName, id).Show();
            }
        }

        private void bt_showRecord_Click(object sender, EventArgs e)
        {

        }

        private void QueryCategoryForm_Load(object sender, EventArgs e)
        {
            DisplayTree();
            InitStatus();
        }

        private void bt_queryCustom_Click(object sender, EventArgs e)
        {
            new CustomizeForm(categoryTableName, ConfigType.QueryCustom, this, null, null, null);
        }

        public void bt_query_Click(object sender, EventArgs e)
        {
            if (selectedColumns == null)
            {
                MessageBox.Show("请先设置结果排序");
                return;
            }
            if (sender != null && e != null)
            {
                total = GetTotal();
                pageSize = Convert.ToInt32(tbPageSize.Text);
                totalPage = total / pageSize;
                page = 0;
            }

            {
                QueryTable();
            }

            ShowStatus();
        }

        private void 角色管理_Click(object sender, EventArgs e)
        {
            new RoleManagerForm().Show();
        }

        private void 修改分类信息_Click(object sender, EventArgs e)
        {
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            new ModifyCategoryForm(this.categoryTableName).ShowDialog();
        }

        private void 结果排序_Click(object sender, EventArgs e)
        {
            new ResultOrderForm(categoryTableName, this, ConfigType.ResultOrder);
        }

        private void 查询条件排序_Click(object sender, EventArgs e)
        {
            new CustomizeForm(categoryTableName, ConfigType.QueryCustom, this, null, null, null);
        }

        private void 修改字段属性_Click(object sender, EventArgs e)
        {
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            new ModifyColumnForm(categoryTableName).ShowDialog();
        }

        private void 导入数据_Click(object sender, EventArgs e)
        {
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            DialogResult dr = importPath.ShowDialog();
            string excelPath = "";
            if (dr == DialogResult.OK)
            {
                Console.WriteLine(importPath.FileName);
                excelPath = importPath.FileName;
            }

            try
            {
                new ImportForm(categoryTableName, excelPath).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void 插入数据_Click(object sender, EventArgs e)
        {
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {

                MessageBox.Show("请先选择分类");
                return;
            }
            new InsertCategoryForm(this.categoryTableName).Show();
        }

        private void 输出模板_Click(object sender, EventArgs e)
        {
            string path = "";
            DialogResult dr = exportTemplatePath.ShowDialog();
            if (dr == DialogResult.OK)
            {
                path = exportTemplatePath.SelectedPath;
            }
            else
            {
                return;
            }
            exportExcel(this.categoryTableName, path);
        }

        private void 插入排序_Click(object sender, EventArgs e)
        {
            new CustomizeForm(categoryTableName, ConfigType.InsertCustom, null, null, null, null);
        }

        private void 修改分类信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            new ModifyCategoryForm(this.categoryTableName).ShowDialog();
        }

        private void 修改字段属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            new ModifyColumnForm(categoryTableName).ShowDialog();
        }

        private void 添加字段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddColumnForm().ShowDialog();
        }

        private void 字段录入提示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReminderForm().ShowDialog();
        }

        private void 分类管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CategoryManagerForm(this).ShowDialog();
        }

        private void 详细信息显示排序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CustomizeForm(categoryTableName, ConfigType.ShowRecordDetail_Attached, null, null, null, null);
        }

        private void 附表查询条件排序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CustomizeForm(categoryTableName, ConfigType.QueryCustom_Attached, null, null, null, null);
        }

        private void 附表导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AttachQueryForm(categoryTableName).Show();
        }

        private void 附表查询结果排序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ResultOrderForm(categoryTableName, this, ConfigType.AttachResultOrder).Show();
        }

        private void 附表批量导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            DialogResult dr = importPath.ShowDialog();
            string excelPath = "";
            if (dr == DialogResult.OK)
            {
                Console.WriteLine(importPath.FileName);
                excelPath = importPath.FileName;
            }
            else
            {
                return;
            }

            try
            {
                new ImportForm(this.categoryTableName + ConfigType.AttachedTable, excelPath).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 附表输出模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = GetExportTemplatePath();
            if (path == null)
            {
                return;
            }
            exportExcel(this.categoryTableName + ConfigType.AttachedTable, path);
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UserManagerForm().Show();
        }

        private void QueryCategoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                loginForm.Close();
            }
            catch
            {
            }
        }
        
        //*********************************  权限  *****************************************************

        private void CheckAccess()
        {
            if (!AccessControl.HasPermission(AccessControl.插入排序))
            {
                this.插入排序.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.查询条件排序))
            {
                this.查询条件排序.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.分类管理))
            {
                this.分类管理.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.附表查询导入))
            {
                this.附表查询导入.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.附表查询结果排序))
            {
                this.附表查询结果排序.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.附表查询条件排序))
            {
                this.附表查询条件排序.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.附表批量导入))
            {
                this.附表批量导入.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.附表输出模板))
            {
                this.附表输出模板.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.附表详细信息排序))
            {
                this.附表详细信息排序.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.角色管理))
            {
                this.角色管理.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.结果排序))
            {
                this.结果排序.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.录入数据))
            {
                this.录入数据.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.批量导入))
            {
                this.批量导入.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.输出模板))
            {
                this.输出模板.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.添加字段))
            {
                this.添加字段.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.修改分类信息))
            {
                this.修改分类信息.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.修改字段属性))
            {
                this.修改字段属性.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.用户管理))
            {
                this.用户管理.Enabled = false;
            }

            if (!AccessControl.HasPermission(AccessControl.字段录入提示))
            {
                this.字段录入提示.Enabled = false;
            }
        }
    }
}
