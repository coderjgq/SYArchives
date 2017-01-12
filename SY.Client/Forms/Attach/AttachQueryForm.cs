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

namespace SY.Client.Forms.Attach
{
    public partial class AttachQueryForm : Form
    {
        private string[] selectedDescriptions;
        private string[] selectedColumns;
        private string queryStr;
        private string categoryTableName;
        private string attachedCategoryTableName;
        private string categoryName;
        private string queryConfigValue;
        private int rowHeight = 30;
        private int columnWidth = 100;
        private int columnCount = 0;
        private int rowCount = 0;
        private ArrayList typeList = new ArrayList();
        private List<string> columnList = new List<string>();
        private int pageSize = 100;
        private int page = 0;
        private int totalPage = 0;
        private int total = 0;
        private List<List<string>> results = null;

        //
        //详细信息
        //
        private string categoryComponent;
        private string insertColumnMsgs;
        private List<Control> componentControls = new List<Control>();
        private int detailRowHeight = 30;
        private int detailColumnWidth = 200;
        private Dictionary<string, List<string>> reminders;

        public AttachQueryForm()
        {
            InitializeComponent();
            this.categoryName = categoryTableName.Split('_')[2];
            InitAttachedQueryConditions();
            InitResultOrder();
            InitDataGridView();
            InitAttachedDetailColumns();
            ShowStatus();
        }

        public AttachQueryForm(string categoryTableName)
        {
            InitializeComponent();
            this.categoryTableName = categoryTableName;
            this.categoryName = categoryTableName.Split('_')[2];
            this.attachedCategoryTableName = categoryTableName + ConfigType.AttachedTable;
            InitAttachedQueryConditions();
            InitResultOrder();
            InitDataGridView();
            InitAttachedDetailColumns();
            ShowStatus();
        }

        //************************************* 初始化查询界面 ******************************************

        public void InitAttachedQueryConditions()
        {
            SetFormTitle();
            this.tlp_query.Controls.Clear();
            this.tlp_query.RowCount = 0;
            this.tlp_query.ColumnCount = 0;
            this.queryConfigValue = ServerProxy.GetProxy().GetConfigValue(this.categoryTableName + ConfigType.QueryCustom_Attached, LoginForm.LOGIN_USER_NAME);
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

        private void SetFormTitle()
        {
            if (this.categoryTableName != null && !this.categoryTableName.Equals(""))
            {
                string categoryName = this.categoryTableName.Split('_')[2];
                ARCategory ar = ServerProxy.GetProxy().GetCategory(categoryName);
                this.Text = "查询导入 - " + ar._DESCRIPTION;
            }
        }

        private void InitTableLayout()
        {
            this.tlp_query.ColumnStyles.Clear();
            this.tlp_query.RowStyles.Clear();
            this.tlp_query.Height = 0;
            this.tlp_query.Width = 0;
            this.queryConfigValue = ServerProxy.GetProxy().GetConfigValue(this.categoryTableName + ConfigType.QueryCustom, LoginForm.LOGIN_USER_NAME);
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
                this.tlp_query.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, columnWidth));
            }
            this.tlp_query.Width = columnCount * columnWidth;
            for (int i = 0; i < rowCount; i++)
            {
                this.tlp_query.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
            }
            this.tlp_query.Height = rowCount * rowHeight;
        }

        private TextBox CreateTextBox()
        {
            TextBox tb = new TextBox();
            tb.Margin = new System.Windows.Forms.Padding(1);
            tb.AutoSize = false;
            tb.Dock = DockStyle.Fill;
            tb.Multiline = true;
            return tb;
        }

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
            tb.Margin = new System.Windows.Forms.Padding(1);
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

        //****************************************** 查询结果 ******************************************

        private void bt_query_Click(object sender, EventArgs e)
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
            QueryTable();
            ShowStatus();
        }

        public void InitResultOrder()
        {
            //
            //获取显示字段信息
            //
            string configValue = ServerProxy.GetProxy().GetConfigValue(categoryTableName + ConfigType.AttachResultOrder, LoginForm.LOGIN_USER_NAME);

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
            string sqlstr = "select rownum r, t.* from " + attachedCategoryTableName + " t where ";

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

        private int CountWidth(List<DataGridViewTextBoxColumn> tmpList)
        {
            int ret = 0;
            foreach (DataGridViewTextBoxColumn tmp in tmpList)
            {
                ret += tmp.Width;
            }
            return ret;
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

        private void ClearAutoSizeMode(List<DataGridViewTextBoxColumn> tmpList)
        {
            foreach (DataGridViewTextBoxColumn tmp in tmpList)
            {
                tmp.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
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
    
        //****************************************** 详细信息显示 ******************************************
        
        public void InitAttachedDetailColumns()
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
            if (categoryComponent != null && !categoryComponent.Trim().Equals(""))
            {
                categoryComponent = categoryComponent.Replace(",", "-");
                //l_dah.Text = categoryComponent;
            }
            componentControls.Clear();

            insertColumnMsgs = ServerProxy.GetProxy().GetConfigValue(categoryTableName + ConfigType.ShowRecordDetail_Attached, LoginForm.LOGIN_USER_NAME);
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
                this.tablePannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, detailColumnWidth));
            }
            this.tablePannel.Width = columnCount * detailColumnWidth;
            for (int i = 0; i < rowCount; i++)
            {
                this.tablePannel.RowStyles.Add(new RowStyle(SizeType.Percent, detailRowHeight));
            }
            this.tablePannel.Height = rowCount * detailRowHeight;

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
                    DateTimePicker tb = CreateDateTimePicker(columnDesciption);

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
                    if (categoryComponent != null && categoryComponent.Contains(tb.Name.Trim()))
                    {
                        componentControls.Add(tb);
                    }
                }
                else
                {
                    TextBox tb = CreateDetailTextBox();
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
                    if (categoryComponent != null && !categoryComponent.Trim().Equals(""))
                    {
                        if (categoryComponent.Contains(tb.Name.Trim()))
                        {
                            componentControls.Add(tb);
                        }
                    }
                }

                if (categoryComponent != null && categoryComponent.Contains(ar.Description.Trim()))
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

        private DateTimePicker CreateDateTimePicker(string columnDesciption)
        {
            DateTimePicker tb = new DateTimePicker();
            tb.Name = columnDesciption;
            tb.Margin = new System.Windows.Forms.Padding(1);
            tb.AutoSize = false;
            tb.Dock = DockStyle.Fill;
            return tb;
        }

        private void FillColumn(NameContentPair ncp)
        {
            string description = ServerProxy.GetProxy().GetDescription(ncp.name);
            for (int i = 0; i < this.tablePannel.Controls.Count; i++)
            {
                Control c = this.tablePannel.Controls[i];
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;

                    if (tb.Name.Trim().Equals(description))
                    {
                        tb.Text = ncp.content;
                    }
                }
                else if (c is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)c;
                    try
                    {
                        dtp.Text = ncp.content;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public void InitRecord(int archivesId)
        {
            ClearRecord();
            
            List<NameContentPair> record = ServerProxy.GetProxy().GetRecord(attachedCategoryTableName, archivesId);

            for (int i = 0; i < record.Count; i++)
            {
                NameContentPair ncp = record[i];
            }

            if (record.Count != 0)
            {
                for (int i = 0; i < record.Count; i++)
                {
                    NameContentPair ncp = record[i];
                    FillColumn(ncp);
                }
            }
        }

        private void ClearRecord()
        {
            for (int i = 0; i < this.tablePannel.Controls.Count; i++)
            {
                Control c = this.tablePannel.Controls[i];
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    tb.Clear();
                    
                }
                else if (c is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)c;
                    try
                    {
                        dtp.Text = "";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private TextBox CreateDetailTextBox()
        {
            TextBox tb = new TextBox();
            tb.Margin = new System.Windows.Forms.Padding(1);
            tb.AutoSize = false;
            tb.Dock = DockStyle.Fill;
            tb.Multiline = true;
            tb.KeyDown += new System.Windows.Forms.KeyEventHandler(KeyDown);
            return tb;
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
                string columnName = ServerProxy.GetProxy().GetColumnByDescriptionAndCategory(tb.Name, categoryName);
                new SelectReminderForm(columnName, tb).ShowDialog();
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
                InitRecord(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取ID有误," + row[row.Count - 1]);
                return;
            }
        }

        //****************************************** 分页 ******************************************

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

        private void btLastPage_Click(object sender, EventArgs e)
        {
            if (page > 0)
            {
                page--;
                bt_query_Click(null, null);
                ShowStatus();
            }
        }

        private void ShowStatus()
        {
            this.statusStrip.Items[0].Text = "总共 " + (totalPage + 1) + " 页  当前第 " + (page + 1) + " 页";
        }

        private void btNextPage_Click(object sender, EventArgs e)
        {
            if (page < totalPage)
            {
                page++;
                bt_query_Click(null, null);
                //ShowStatus();
            }
        }

        //****************************************** 插入主表 ******************************************

        public string CheckType(string content, ARColumn column)
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
                            errorStr += CheckType(tb.Text, ar);
                        }
                    }
                }
            }
            return errorStr;
        }

        private void Insert()
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
                        valuePart += ConvertToDateFormat(tb.Text) + "','";
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
                Insert();
            }
            else
            {
                MessageBox.Show(errorStr);
            }
        }
        
    }
}
