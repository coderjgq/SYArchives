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


namespace SY.Client.Forms
{
    public partial class ResultOrderForm : Form
    {
        private string categoryTableName;
        private IArchivesService channelProxy = ServerProxy.GetProxy();
        private ArrayList unDisplayDescriptions = new ArrayList();
        private ArrayList displayColumns = new ArrayList();
        private QueryCategoryForm queryCategoryForm;
        private string configType;

        public ResultOrderForm(string categoryTableName, QueryCategoryForm queryCategoryForm,string configType)
        {
            InitializeComponent();
            this.categoryTableName = categoryTableName;
            this.queryCategoryForm = queryCategoryForm;
            this.configType = configType;
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {
                this.Close();
                MessageBox.Show("请先选择分类");
                return;
            }

            //
            //获取所有字段
            //
            List<string> columns = ServerProxy.GetProxy().GetTableColumns(categoryTableName);

            //
            //去掉第一个ARCHIVESID
            //
            for (int i = 1; i < columns.Count; i++)
            {
                string description = ServerProxy.GetProxy().GetDescription(columns[i].ToString());
                unDisplayDescriptions.Add(description);
            }

            //
            //获取显示的配置参数
            //
            string configValue = ServerProxy.GetProxy().GetConfigValue(categoryTableName + configType,LoginForm.LOGIN_USER_NAME);
            //
            //删除已经显示的字段
            //
            if (configValue != null && !configValue.Trim().Equals(""))
            {
                string[] displayColumnsStr = configValue.Split(',');
                for (int i = 0; i < displayColumnsStr.Length; i++)
                {
                    displayColumns.Add(displayColumnsStr[i].ToString());
                    unDisplayDescriptions.Remove(displayColumnsStr[i].ToString());
                    lb_display.Items.Add(displayColumnsStr[i].ToString());
                }
            }

            for (int i = 0; i < unDisplayDescriptions.Count; i++)
            {
                if(unDisplayDescriptions[i] != null)
                    lb_unDisplay.Items.Add(unDisplayDescriptions[i].ToString());
            }

            this.Show();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
        private void bt_add_Click(object sender, EventArgs e)
        {
            if (lb_unDisplay.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择字段");
                return;
            }

            string selected = lb_unDisplay.Items[lb_unDisplay.SelectedIndex].ToString();

            //
            //添加
            //
            displayColumns.Add(selected);
            lb_display.Items.Add(selected);
            //
            //删除
            //
            unDisplayDescriptions.Remove(selected);
            lb_unDisplay.Items.Remove(selected);
           
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (lb_display.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择字段");
                return;
            }

            string selected = lb_display.Items[lb_display.SelectedIndex].ToString();

            //
            //删除
            //
            displayColumns.Remove(selected);
            lb_display.Items.Remove(selected);
            //
            //添加
            //
            unDisplayDescriptions.Add(selected);
            lb_unDisplay.Items.Add(selected);
        }

        private void bt_up_Click(object sender, EventArgs e)
        {
            if (lb_display.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择字段");
                return;
            }
            string selected = lb_display.Items[lb_display.SelectedIndex].ToString();
            if (lb_display.SelectedIndex <= 0)
            {
                return;
            }
            string up =  (string)lb_display.Items[lb_display.SelectedIndex - 1];
            lb_display.Items[lb_display.SelectedIndex] = up;
            lb_display.Items[lb_display.SelectedIndex - 1] = selected;
            lb_display.SelectedIndex--;
        }

        private void bt_down_Click(object sender, EventArgs e)
        {
            if (lb_display.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择字段");
                return;
            }
            string selected = lb_display.Items[lb_display.SelectedIndex].ToString();
            if (lb_display.SelectedIndex >= lb_display.Items.Count - 1)
            {
                return;
            }
            string down = (string)lb_display.Items[lb_display.SelectedIndex + 1];
            lb_display.Items[lb_display.SelectedIndex] = down;
            lb_display.Items[lb_display.SelectedIndex + 1] = selected;
            lb_display.SelectedIndex++;
        }

        private void bt_sure_Click(object sender, EventArgs e)
        {
            string sqlStr = "";
            for (int i = 0; i < lb_display.Items.Count; i++)
            {
                sqlStr += lb_display.Items[i].ToString()+",";
            }
            if (!sqlStr.Trim().Equals(""))
            {
                sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            }

            //
            //保存配置
            //
            Console.WriteLine(sqlStr);
            ServerProxy.GetProxy().SaveConfig(categoryTableName + configType, sqlStr, LoginForm.LOGIN_USER_NAME);

            //
            //Reload 查询
            //
            string[] selectedDescriptions = sqlStr.Split(',');
            string[] selectedColumns = new string[selectedDescriptions.Length];
            //
            //将selectedDecriptions转换成selectedColumns
            //
            for (int i = 0; i < selectedDescriptions.Length; i++)
            {
                string categoryName = categoryTableName.Split('_')[2];
                selectedColumns[i] = ServerProxy.GetProxy().GetColumnByDescriptionAndCategory(selectedDescriptions[i], categoryName);
            }

            if (configType == ConfigType.ResultOrder)
            {
                queryCategoryForm.SetSelectDescriptions(selectedDescriptions);
                queryCategoryForm.SetSelectedColumns(selectedColumns);
                queryCategoryForm.InitDataGridView();
                queryCategoryForm.bt_query_Click(null, null);
            }
            this.Close();
        }
    }
}
