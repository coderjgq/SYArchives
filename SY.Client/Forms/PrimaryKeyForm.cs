using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HostService.Services;

namespace SY.Client.Forms
{
    public partial class PrimaryKeyForm : Form
    {
        private string categoryTableName = null;
        private IArchivesService channelProxy = ServerProxy.GetProxy();
        private List<string> unDisplayDescriptions = new List<string>();
        private List<string> displayColumns = new List<string>();
        private ModifyCategoryForm modifyCategoryForm = null;

        public PrimaryKeyForm(ModifyCategoryForm modifyCategoryForm, string categoryTableName)
        {
            InitializeComponent();
            this.categoryTableName = categoryTableName;
            this.modifyCategoryForm = modifyCategoryForm;
        }

        private void PrimaryKeyForm_Load(object sender, EventArgs e)
        {
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
            string categoryName = (categoryTableName.Split('_'))[2];
            string configValue = ServerProxy.GetProxy().GetCategoryPrimaryKey(categoryName);
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
                if (unDisplayDescriptions[i] != null)
                    lb_unDisplay.Items.Add(unDisplayDescriptions[i].ToString());
            }

           
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
            string up = (string)lb_display.Items[lb_display.SelectedIndex - 1];
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
            string configValue = "";
            for (int i = 0; i < lb_display.Items.Count; i++)
            {
                configValue += lb_display.Items[i].ToString() + ",";
            }

            if (configValue.Equals(""))
            {
                MessageBox.Show("请先选择字段");
                return;
            }

            configValue = configValue.Substring(0, configValue.Length - 1);

            //
            //保存配置
            //
            string[] descriptions = configValue.Split(',');
            string columns = "";
            for (int i = 0; i < descriptions.Length; i++)
            {
                string categoryName = categoryTableName.Split('_')[2];
                string column = ServerProxy.GetProxy().GetColumnByDescriptionAndCategory(descriptions[i], categoryName);
                columns += column + ",";
            }
            columns = columns.Substring(0,columns.Length - 1);
        
            //
            //测试
            //
            string sql1 = "alter table " + categoryTableName + " drop constraint " + categoryTableName + "_PK";
            string sql2 = "alter table " + categoryTableName + " add constraint " + categoryTableName + "_PK primary key (" + columns + ")";
            Console.WriteLine(sql1);
            Console.WriteLine(sql2);
            List<string> sqls = new List<string>();
            sqls.Add(sql1);
            ServerProxy.GetProxy().ExecuteSqlTran(sqls);//删除主键
            sqls.Clear();
            sqls.Add(sql2);
            if (ServerProxy.GetProxy().ExecuteSqlTran(sqls))
            {
                //
                //将主键字段修改为不能为null
                //
                MessageBox.Show("修改成功");
                string categoryName = (categoryTableName.Split('_'))[2];
                if (ServerProxy.GetProxy().SaveCategoryPrimaryKey(categoryName, configValue))
                {
                    MessageBox.Show("保存失败");
                }
                else
                {
                    MessageBox.Show("保存成功");
                }
            }
            else
            {
                MessageBox.Show("修改失败");
            }

            if (modifyCategoryForm != null)
            {
                modifyCategoryForm.DisplayCategory();
            }
        }

    }
}
