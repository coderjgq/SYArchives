using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SY.MODEL;
using System.ServiceModel;
using HostService.Services;
using System.Collections;


namespace SY.Client.Forms
{
    public partial class AddColumnForm : Form
    {
        public AddColumnForm()
        {
            InitializeComponent();
            List<string> list = getCategoryNames();
            for (int i = 0; i < list.Count; i++)
            {
                cb_category.Items.Add(list[i].ToString());
            }
        }

        private List<string> getCategoryNames()
        {
            List<string> list = new List<string>();
            list = ServerProxy.GetProxy().getCategoryNames();
            return list;
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (tb_columnName.Text.Trim().Equals(""))
            {
                MessageBox.Show("字段名不能为空");
                return;
            }
            if (tb_bytes.Text.Trim().Equals(""))
            {
                MessageBox.Show("字段位数不能为空");
                return;
            }
            if (tb_description.Text.Trim().Equals(""))
            {
                MessageBox.Show("字段描述不能为空");
                return;
            }
            if (cb_category.Text.Trim().Equals(""))
            {
                MessageBox.Show("分类号不能为空");
                return;
            }
            ARColumn arColumn = new ARColumn();
            arColumn.FieldName = tb_columnName.Text.ToString().ToUpper();
            arColumn.Description = tb_description.Text.ToString();
            arColumn.Category = cb_category.Text.ToString() + "";
            arColumn.Bytes = tb_bytes.Text.ToString();

            if (rb_emptyYes.Checked)
            {
                arColumn.AllowEmpty = "Y";
            }
            else
            {
                arColumn.AllowEmpty = "N";
            }

            if (rb_systemYes.Checked)
            {
                arColumn.SystemColum = "Y";
            }
            else
            {
                arColumn.SystemColum = "N";
            }

            if (rb_typeInt.Checked)
            {
                arColumn.FieldType = "Int";
            }
            else if (rb_typeString.Checked)
            {
                arColumn.FieldType = "String";
            }
            else if (rb_typeBool.Checked)
            {
                arColumn.FieldType = "Bool";
            }
            else if (rb_typeTime.Checked)
            {
                arColumn.FieldType = "Time";
            }
            else if (rb_typeDouble.Checked)
            {
                arColumn.FieldType = "Double";
            }

            if (arColumn.FieldName == null || arColumn.FieldName.Trim().Equals(""))
            {
                MessageBox.Show("请先输入字段名");
                return;
            }

            if (ServerProxy.GetProxy().ColumnExist(arColumn.FieldName))
            {
                MessageBox.Show("字段：" + arColumn.FieldName + "已经存在");
                return;
            }

            bool result1 = ServerProxy.GetProxy().AddColumn(arColumn);
            bool result2 = ServerProxy.GetProxy().AddColumnToCategory(arColumn);
            if (result1 && result2)
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
    }
}
