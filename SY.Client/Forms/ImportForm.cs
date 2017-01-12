using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using SY.MODEL;
namespace SY.Client.Forms
{
    public partial class ImportForm : Form
    {

        ExcelUtil excel = new ExcelUtil();
        List<ARColumn> columns;
        List<string> excelShortNames;//存放excel字段名称
        List<string> dbShortName;//存放数据库字段名称
        List<ComboBox> dbCombobox = new List<ComboBox>();//存放显示数据库的Combobox
        List<ComboBox> excelCombobox = new List<ComboBox>();//存放显示excel的Combobox

        public StringBuilder error = new StringBuilder();//记录错误信息
        public string state = "";//当前执行状态

        private bool isStop = false;

        private string excelPath;
        //public int total = 0;
        public string headStr = "";
        int[] indexs;
        private String categoryTableName = "";
        private List<string> columnNames;

        public ImportForm(string categoryTableName, string excelPath)
        {
            InitializeComponent();
            this.lb_state.Text = "";
            this.categoryTableName = categoryTableName;
            this.excelPath = excelPath;
            init();
        }

        public void init()
        {
            try
            {
                initDBColumns();

                excel.load(excelPath);

                lb_total.Text = getTotal(excel.table) + " 条";

                initExcelColumns();
            }
            catch (Exception ex)
            {
                throw new Exception("初始化出错\n" + ex.Message);
            }
        }

        public int getTotal(DataTable table)
        {
            int total = 0;
            for (int i = 2; i < table.Rows.Count; i++)
            {

                DataRow row = table.Rows[i];
                bool isEmpty = true;
                for (int j = 0; j < row.ItemArray.Length; j++)
                {
                    string tmp = row[j].ToString().Trim();
                    if (!tmp.Trim().Equals(""))
                    {
                        isEmpty = false;
                        break;
                    }
                }
                if (isEmpty)
                {
                    break;
                }
                total = i - 1;
            }
            return total;
        }

        public void initDBColumns()
        {
            //数据库字段
            columnNames = ServerProxy.GetProxy().GetTableColumns(categoryTableName);

            dbShortName = ServerProxy.GetProxy().GetTableColumnDescriptions(categoryTableName);

            for (int i = 0; i < dbShortName.Count; i++)
            {
                ComboBox cb = new ComboBox();
                panel_left.Controls.Add(cb);
                cb.FormattingEnabled = true;
                cb.Location = new System.Drawing.Point(41, 8 + 30 * i);
                cb.Name = "cbDbShortName" + i;
                cb.Size = new System.Drawing.Size(121, 20);
                cb.TabIndex = 0;
                cb.Text = dbShortName[i] + "";
                dbCombobox.Add(cb);
            }
        }

        public void initExcelColumns()
        {
            excelShortNames = excel.getShortNameFromExcel();
            for (int i = 0; i < excelShortNames.Count; i++)
            {
                ComboBox cb = new ComboBox();
                panel_left.Controls.Add(cb);
                cb.FormattingEnabled = true;
                cb.Location = new System.Drawing.Point(180, 8 + 30 * i);
                cb.Name = "cbExcelShortName" + i;
                cb.Size = new System.Drawing.Size(121, 20);
                cb.TabIndex = 0;

                for (int j = 0; j < excelShortNames.Count; j++)
                {
                    cb.Items.Add(excelShortNames[j]);
                }

                if (i < dbShortName.Count)
                {
                    if (excelShortNames.Contains(dbShortName[i]))
                    {
                        cb.Text = dbShortName[i] + "";
                    }
                }
                excelCombobox.Add(cb);
            }
        }

        public void insert()
        {
            Console.WriteLine("start time = " + DateTime.Now.ToString());
            error.Clear();
            DataTable table = excel.table;
            Console.WriteLine("table.Rows.Count = " + table.Rows.Count);
            for (int i = 2; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                state = "正在插入第" + (i - 1) + "条记录";

                //判断该行是否为空
                bool isEmpty = true;
                if (row.ItemArray.Length <= 0)
                {
                    isEmpty = false;
                }
                Console.WriteLine("row.ItemArray.Length = " + row.ItemArray.Length);
                for (int j = 0; j < row.ItemArray.Length; j++)
                {
                    string tmp = row[j].ToString().Trim();
                    Console.WriteLine("tmp = " + tmp);
                    if (!tmp.Trim().Equals(""))
                    {
                        isEmpty = false;
                        break;
                    }
                }
                //本行为空的话退出
                if (isEmpty)
                {
                    Console.WriteLine("stop time = " + DateTime.Now.ToString());
                    state = "导入完成";
                    break;
                }

                string sqlStr = headStr;

                //给每个字段赋值
                for (int j = 0; j < excelCombobox.Count; j++)
                {
                    int index = indexs[j];
                    string content = row[index].ToString().Trim();
                    sqlStr = sqlStr + "'" + content + "',";
                }
                sqlStr = sqlStr.Substring(0, sqlStr.LastIndexOf(","));
                sqlStr = sqlStr + ")";
                //Console.WriteLine("正在插入第" + i + "条记录");
                //db.excuteNonQuery(sqlStr);
                List<string> sqls = new List<string>();
                sqls.Add(sqlStr);
                Console.WriteLine("sqlStr = " + sqlStr);
                string msg = ServerProxy.GetProxy().ExcuteNonQuery(sqlStr);
                if (!msg.Equals("SUCCESS"))
                {
                    error.Append("\n" + msg + "\n" + sqlStr + "\n");
                }
            }

            Console.WriteLine("stop time = " + DateTime.Now.ToString());
            state = "导入完成";
            isStop = true;
        }

        private void StartTimer()
        {
            flesh.Enabled = true;
            isStop = false;
        }

        private void StopTimer()
        {
            flesh.Enabled = false;
            isStop = true;
        }

        private void bt_insert_Click(object sender, EventArgs e)
        {
            StartTimer();

            DataTable table = excel.table;

            //获取insert头
            headStr = "insert into " + categoryTableName + "(ARCHIVESID,";
            for (int j = 0; j < dbShortName.Count; j++)
            {
                string categoryName = categoryTableName.Split('_')[2];
                string column = ServerProxy.GetProxy().GetColumnByDescriptionAndCategory(dbShortName[j].ToString(), categoryName);
                headStr = headStr + column + ",";
            }
            headStr = headStr.Substring(0, headStr.LastIndexOf(","));
            headStr = headStr + ") values(T_ARCHIVESID_SEQ.nextval,";

            indexs = new int[excelCombobox.Count];
            for (int j = 0; j < excelCombobox.Count; j++)
            {
                ComboBox cb = (ComboBox)excelCombobox[j];
                string column = cb.Text.Trim();

                //获取索引号
                for (int k = 0; k < excelShortNames.Count; k++)
                {
                    string tmpColumn = excelShortNames[k].ToString().Trim();
                    if (tmpColumn.Equals(column))
                    {
                        indexs[j] = k;
                    }
                }
            }

            Thread t = new Thread(this.insert);
            t.Start();
        }

        private void flesh_Tick(object sender, EventArgs e)
        {
            rtb_error.Text = error.ToString();
            lb_state.Text = state;
            if (isStop == true)
            {
                StopTimer();
            }
        }

    }
}
