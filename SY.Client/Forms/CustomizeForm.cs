using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using HostService.Services;
using System.Collections.Generic;

namespace SY.Client.Forms
{
    public partial class CustomizeForm : Form
    {
        private IArchivesService channelProxy = ServerProxy.GetProxy();
        private List<string> descriptions;//没有显示的字段
        private List<string> existDescriptions = new List<string>();//已经显示的字段
        private string categoryTableName;
        private string customType = "";//可以是：InsertCustom(插入时字段排序)，QueryCustom(查询时字段排序),ShowCategoryRecord

        private int rowHeight = 30;
        private int columnWidth = 200;
        private bool mergeState = false;// true 合并单元格操作， false 选择字段操作

        private Color mergeSelectedColor = Color.Green;
        private Color mergeUnSelectedColor = Color.LightBlue;

        private QueryCategoryForm queryCategoryForm = null;
        private InsertCategoryForm insertCategoryForm = null;
        private ShowRecordDetailForm showRecordDetailForm = null;
        private AttachedInsertForm attachedInsertForm = null;

        public CustomizeForm(string categoryTableName, string customType,
                                QueryCategoryForm queryCategoryForm,
                                InsertCategoryForm insertCategoryForm,
                                ShowRecordDetailForm showCategoryRecordForm,
                                AttachedInsertForm attachedInsertForm)
        {
            InitializeComponent();
            this.queryCategoryForm = queryCategoryForm;
            this.insertCategoryForm = insertCategoryForm;
            this.showRecordDetailForm = showCategoryRecordForm;
            this.attachedInsertForm = attachedInsertForm;

            this.categoryTableName = categoryTableName;
            this.customType = customType;
            this.tableLayOut.ColumnStyles.Clear();
            this.tableLayOut.RowStyles.Clear();
            this.tableLayOut.Height = 0;
            this.tableLayOut.Width = 0;

            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {
                this.Close();
                MessageBox.Show("请先选择分类");
                return;
            }
            this.Show();
            //
            //查询条件布局没有合并、打散的概念
            //
            if (queryCategoryForm != null)
            {
                bt_merge.Hide();
                bt_break.Hide();
                bt_mergeState.Hide();
            }

            string format = ServerProxy.GetProxy().GetConfigValue(categoryTableName + customType, LoginForm.LOGIN_USER_NAME);

            //
            //如果数据库里没有查到配置文件
            //
            if (format == null || format.Equals(""))
            {
                format = "{2:2},{ :1:1:0:0},{ :1:1:0:1},{ :1:1:1:0},{ :1:1:1:1}";
            }

            string[] columnMsgs = format.Split(',');//[0]是行列信息，后面是字段信息

            string tmp = columnMsgs[0].Substring(1, columnMsgs[0].Length - 1 - 1);
            string[] row_column = tmp.Split(':');
            string columnCountStr = row_column[1];
            string rowCountStr = row_column[0];

            int columnCount = Convert.ToInt32(columnCountStr);
            int rowCount = Convert.ToInt32(rowCountStr);

            this.tableLayOut.ColumnCount = columnCount;
            this.tableLayOut.RowCount = rowCount;

            //
            //初始化行列
            //
            for (int i = 0; i < columnCount; i++)
            {
                this.tableLayOut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, columnWidth));
            }
            this.tableLayOut.Width = columnCount * columnWidth;
            for (int i = 0; i < rowCount; i++)
            {
                this.tableLayOut.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
                this.tableLayOut.Height += rowHeight;
            }

            //
            //根据columnMsgs
            //
            existDescriptions.Clear();
            for (int i = 1; i < columnMsgs.Length; i++)
            {
                string msg = columnMsgs[i];
                string[] column_span = msg.Substring(1, msg.Length - 1 - 1).Split(':');

                string columnDescription = column_span[0];
                int rowSpan = Convert.ToInt32(column_span[1]);
                int columnSpan = Convert.ToInt32(column_span[2]);
                int rowPosition = Convert.ToInt32(column_span[3]);
                int columnPosition = Convert.ToInt32(column_span[4]);
                Label l = CreateLabel();
                l.Text = columnDescription;
                //l.Name = 
                this.tableLayOut.Controls.Add(l, columnPosition, rowPosition);
                this.tableLayOut.SetColumnSpan(l, columnSpan);
                this.tableLayOut.SetRowSpan(l, rowSpan);

                existDescriptions.Add(columnDescription);
            }

            descriptions = ServerProxy.GetProxy().GetTableColumnDescriptions(categoryTableName);

            deleteExistDescription();
        }

        //
        //删除已经存在的description
        //
        private void deleteExistDescription()
        {
            for (int i = 0; i < existDescriptions.Count; i++)
            {
                string tmp1 = existDescriptions[i].ToString().Trim();
                for (int j = 0; j < descriptions.Count; j++)
                {
                    string tmp2 = (string)descriptions[j];
                    if (tmp2.ToString().Trim().Equals(tmp1))
                    {
                        descriptions.Remove(tmp2);
                    }
                }
            }
        }

        private void bt_addColumn_Click(object sender, EventArgs e)
        {

        }

        private Label CreateLabel()
        {
            Label lab = new Label();
            lab.BackColor = mergeUnSelectedColor;
            lab.Margin = new System.Windows.Forms.Padding(1);
            lab.Dock = DockStyle.Fill;
            lab.AutoSize = false;
            lab.TextAlign = ContentAlignment.MiddleCenter;
            lab.DoubleClick += new EventHandler(selectColumn);
            //lab.Text = (label_index++) + "";
            return lab;
        }

        private void selectColumn(object sender, EventArgs e)
        {
            Label l = ((Label)sender);
            if (mergeState)//如果是合并单元格操作
            {
                //MessageBox.Show("合并单元格操作");
                if (l.BackColor == Color.Green)
                {
                    l.BackColor = Color.LightBlue;
                }
                else
                {
                    l.BackColor = Color.Green;
                }
            }
            else //选择字段操作
            {
                new SelectColumnForm((Label)sender, categoryTableName, descriptions, existDescriptions).ShowDialog();
            }
        }

        private void bt_addRow_Click(object sender, EventArgs e)
        {
            this.tableLayOut.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
            this.tableLayOut.RowCount++;
            int rowCount = this.tableLayOut.RowCount;

            this.tableLayOut.Height = rowCount * rowHeight;

            Label l = CreateLabel();
            this.tableLayOut.Controls.Add(l, 0, rowCount - 1);
            l = CreateLabel();
            this.tableLayOut.Controls.Add(l, 1, rowCount - 1);
        }

        private void bt_deleteRow_Click(object sender, EventArgs e)
        {
            if (this.tableLayOut.RowCount <= 1)
            {
                return;
            }
            //
            //根据位置删除
            //
            int rowCount = this.tableLayOut.RowCount;
            int columnCount = this.tableLayOut.ColumnCount;
            int deleteRowSpan = 0;

            for (int j = 0; j < columnCount; j++)
            {
                Control c = this.tableLayOut.GetControlFromPosition(j, rowCount - 1);
                if (c != null)
                {
                    int rowSpan = this.tableLayOut.GetRowSpan(c);
                    deleteRowSpan = deleteRowSpan > rowSpan ? deleteRowSpan : rowSpan;
                    this.tableLayOut.Controls.Remove(c);

                    if (!c.Text.Trim().Equals(""))
                    {
                        existDescriptions.Remove(((Label)c).Text);
                        descriptions.Add(((Label)c).Text);
                    }

                }
            }

            this.tableLayOut.RowCount -= deleteRowSpan;

            rowCount = this.tableLayOut.RowCount;

            this.tableLayOut.Height = (rowCount) * rowHeight;
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            ArrayList labels = new ArrayList();

            string configValue = "";

            configValue += "{" + tableLayOut.RowCount + ":" + tableLayOut.ColumnCount + "}";

            //
            //根据位置取控件
            //
            int row = this.tableLayOut.RowCount;
            int column = this.tableLayOut.ColumnCount;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Label l = (Label)this.tableLayOut.GetControlFromPosition(j, i);
                    if (l == null)// || l.Text == "")
                    {
                        //configValue += "," + "{" + "" + ":" + 0 + ":" + 0 + "}";
                    }
                    else if (!labels.Contains(l))
                    {
                        labels.Add(l);
                        string tmp = "{" + l.Text + ":" + tableLayOut.GetRowSpan(l) + ":" + tableLayOut.GetColumnSpan(l) + "";
                        string item = "{" + l.Text + ":" + tableLayOut.GetRowSpan(l) + ":" + tableLayOut.GetColumnSpan(l) + ":" + i + ":" + j + "}";
                        configValue += "," + item;
                    }
                }
            }


            ServerProxy.GetProxy().SaveConfig(categoryTableName + customType, configValue, LoginForm.LOGIN_USER_NAME);
            
            if (this.queryCategoryForm != null)
            {
                //
                //Reload queryCategoryForm查询条件
                //
                this.queryCategoryForm.SetQueryConfigValue(configValue);
                this.queryCategoryForm.InitQueryConditions();
            }

            if (this.insertCategoryForm != null)
            {
                //
                //Reload insertCategoryForm 插入条件
                //
                this.insertCategoryForm.setInsertColumnMsgs(configValue);
                this.insertCategoryForm.initInsertConditions();

            }

            if (this.showRecordDetailForm != null)
            {
                this.showRecordDetailForm.setInsertColumnMsgs(configValue);
                this.showRecordDetailForm.initDisplayConditions();
                this.showRecordDetailForm.initRecord();
            }

            if (this.attachedInsertForm != null)
            {
                this.attachedInsertForm.setInsertColumnMsgs(configValue);
                this.attachedInsertForm.initDisplayConditions();
                this.attachedInsertForm.initRecord();
            }

        }

        private void bt_mergeState_Click(object sender, EventArgs e)
        {
            if (mergeState)
            {
                mergeState = false;
                bt_mergeState.BackColor = mergeUnSelectedColor;
                bt_mergeState.Text = "选择字段状态";
            }
            else
            {
                mergeState = true;
                bt_mergeState.BackColor = mergeSelectedColor;
                bt_mergeState.Text = "选择合并状态";
            }
        }

        private void bt_merge_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("------------------merge----------------");

            if (mergeState)
            {
                int firstColumnIndex = 0, firstRowIndex = 0, firstRowSpan = 0, firstColumnSpan = 0;
                int lastColumnIndex = 0, lastRowIndex = 0, lastRowSpan = 0, lastColumnSpan = 0;
                Label lastLabel = null;//解决一个区域内选择出的控件是同一个的问题
                Label firstLabel = null;

                bool isFirst = true;
                int column = tableLayOut.ColumnCount;
                int row = tableLayOut.RowCount;

                //选择第一个和最后一个label
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        Label l = (Label)tableLayOut.GetControlFromPosition(j, i);
                        if (l == null)
                        {
                            continue;
                        }
                        if (l.BackColor == mergeSelectedColor)
                        {
                            if (isFirst)
                            {
                                isFirst = false;
                                firstColumnIndex = j;
                                firstRowIndex = i;
                                firstRowSpan = this.tableLayOut.GetRowSpan(l);
                                firstColumnSpan = this.tableLayOut.GetColumnSpan(l);
                                firstLabel = l;

                                lastColumnIndex = j;
                                lastRowIndex = i;
                                lastRowSpan = this.tableLayOut.GetRowSpan(l);
                                lastColumnSpan = this.tableLayOut.GetColumnSpan(l);
                                lastLabel = l;
                            }
                            else
                            {
                                if (l != lastLabel && l != firstLabel)
                                {
                                    lastColumnIndex = j;
                                    lastRowIndex = i;
                                    lastRowSpan = this.tableLayOut.GetRowSpan(l);
                                    lastColumnSpan = this.tableLayOut.GetColumnSpan(l);
                                    lastLabel = l;
                                    Console.WriteLine("lastLabel.Text = " + lastLabel.Text);
                                }
                            }
                        }
                    }
                }

                if (!isFirst)
                {
                    if (lastColumnIndex < firstColumnIndex || lastColumnIndex < firstColumnIndex)
                    {
                        MessageBox.Show("选择合并单元格有误");
                        return;
                    }

                    //
                    //删除多余的label
                    //
                    isFirst = true;
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < column; j++)
                        {
                            Label l = (Label)tableLayOut.GetControlFromPosition(j, i);
                            if (l == null)
                            {
                                continue;
                            }
                            if (l.BackColor == mergeSelectedColor)
                            {
                                if (isFirst)
                                {
                                    isFirst = false;
                                    this.tableLayOut.Controls.Remove(l);

                                }
                                else
                                {
                                    this.tableLayOut.Controls.Remove(l);
                                }
                            }
                        }
                    }

                    firstLabel = CreateLabel();
                    this.tableLayOut.Controls.Add(firstLabel, firstColumnIndex, firstRowIndex);

                    int setColumnSpan = lastColumnIndex + lastColumnSpan - firstColumnIndex;
                    int setRowSpan = lastRowIndex + lastRowSpan - firstRowIndex;

                    tableLayOut.SetColumnSpan(firstLabel, setColumnSpan);
                    tableLayOut.SetRowSpan(firstLabel, setRowSpan);

                    firstLabel.BackColor = mergeUnSelectedColor;

                    Console.WriteLine("firstLabel = " + firstLabel.Text);
                    Console.WriteLine("firstRowIndex = " + firstRowIndex + ", firstColumnIndex = " + firstColumnIndex);
                    Console.WriteLine("firstRowSpan = " + firstRowSpan + ", firstColumnSpan = " + firstColumnSpan);
                    Console.WriteLine("---");
                    Console.WriteLine("lastRowIndex = " + lastRowIndex + ", lastColumnIndex = " + lastColumnIndex);
                    Console.WriteLine("lastRowSpan = " + lastRowSpan + ", lastColumnSpan = " + lastColumnSpan);
                    Console.WriteLine("---");
                    Console.WriteLine("setColumnSpan = " + (setColumnSpan));
                    Console.WriteLine("setRowSpan = " + (setRowSpan));
                }

                Console.WriteLine("tableLayOut.Controls.Count = " + tableLayOut.Controls.Count);
            }
            else
            {
                MessageBox.Show("请选择到合并状态再合并");
            }
        }

        private void bt_break_Click(object sender, EventArgs e)
        {
            Console.WriteLine("------------------break--------------------");

            if (mergeState)
            {
                int column = tableLayOut.ColumnCount;
                int row = tableLayOut.RowCount;
                int columnIndex = 0;
                int rowIndex = 0;
                Label l = null;

                bool isFind = false;

                for (int i = 0; i < row && !isFind; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        l = (Label)tableLayOut.GetControlFromPosition(j, i);

                        if (l == null)
                        {
                            continue;
                        }
                        if (l.BackColor == mergeSelectedColor)
                        {
                            columnIndex = j;
                            rowIndex = i;
                            Console.WriteLine("break label = " + l.Text);
                            isFind = true;
                            break;
                        }
                    }
                }

                if (l == null || !isFind)
                {
                    MessageBox.Show("请选择要拆分的单元格");
                    return;
                }

                int rowSpan = tableLayOut.GetRowSpan(tableLayOut.GetControlFromPosition(columnIndex, rowIndex));
                int columnSpan = tableLayOut.GetColumnSpan(tableLayOut.GetControlFromPosition(columnIndex, rowIndex));

                Console.WriteLine("rowIndex = " + rowIndex + ", columnIndex = " + columnIndex);
                Console.WriteLine("rowSpan = " + rowSpan + ", columnSpan = " + columnSpan);

                Label c = (Label)tableLayOut.GetControlFromPosition(columnIndex, rowIndex);
                tableLayOut.Controls.Remove(c);

                for (int i = rowIndex; i < rowIndex + rowSpan; i++)
                {
                    for (int j = columnIndex; j < columnIndex + columnSpan; j++)
                    {
                        c = CreateLabel();
                        tableLayOut.Controls.Add(c, j, i);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择到合并状态再拆分");
            }
        }
    }
}
