using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HostService.Services;
using SY.MODEL;

namespace SY.Client.Forms
{
    public partial class ModifyColumnForm : Form
    {
        private string categoryTableName;
        private IArchivesService channelProxy = ServerProxy.GetProxy();
        private List<string> columnNames;
        private List<ARColumn> types;
        private List<string> columnDescriptions;
        private List<string> categorys;

        public ModifyColumnForm(string categoryTableName)
        {
            InitializeComponent();
            this.categoryTableName = categoryTableName;
        }

        private void ModifyColumnForm_Load(object sender, EventArgs e)
        {
            //
            //获得字段
            //
            columnDescriptions = channelProxy.GetTableColumnDescriptions(categoryTableName);
            for (int i = 0; i < columnDescriptions.Count; i++)
            {
                lbColumns.Items.Add(columnDescriptions[i]);
            }
            //
            //获得类型
            //
            columnNames = ServerProxy.GetProxy().GetTableColumns(categoryTableName);
            types = ServerProxy.GetProxy().GetColumnTypes(columnNames);
            //
            //获取所有Category
            //
            categorys = ServerProxy.GetProxy().getCategoryNames();
            for (int i = 0; i < categorys.Count; i++)
            {
                cb_category.Items.Add(categorys[i]);
            }
        }

        private void lbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectDescription = lbColumns.SelectedItem.ToString();
            ARColumn ar = GetType(selectDescription);
            if (ar != null)
            {
                DisplayARColumn(ar);
            }
        }

        private void DisplayARColumn(ARColumn ar)
        {
            tb_columnName.Text = ar.FieldName;
            tb_bytes.Text = ar.Bytes;
            tb_description.Text = ar.Description;
            cb_category.Text = ar.Category;

            if(ar.SystemColum.Equals("Y"))
            {
                rb_systemYes.Checked = true;
            }
            else
            {
                rb_systemNo.Checked = true;
            }

            if (ar.FieldType.Equals("Int"))
            {
                rb_typeInt.Checked = true;
            }
            else if(ar.FieldType.Equals("Double"))
            {
                rb_typeDouble.Checked = true;
            }
            else if (ar.FieldType.Equals("Time"))
            {
                rb_typeTime.Checked = true;
            }
            else if (ar.FieldType.Equals("Bool"))
            {
                rb_typeBool.Checked = true;
            }
            else if (ar.FieldType.Equals("String"))
            {
                rb_typeString.Checked = true;
            }

            
        }

        private ARColumn GetType(string description)
        {
            for (int i = 0; i < types.Count; i++)
            {
                ARColumn c = types[i];
                if (c.Description.Equals(description))
                {
                    return c;
                }
            }
            return null;
        }

        private void bt_modify_Click(object sender, EventArgs e)
        {
            string selectDescription = lbColumns.SelectedItem.ToString();
            //int index = lbColumns.SelectedIndex;
            ARColumn oldColumn = GetType(selectDescription);
            if (oldColumn == null)
            {
                return;
            }

            ARColumn newColumn = new ARColumn();
            newColumn.FieldName = tb_columnName.Text.ToString().ToUpper();
            newColumn.Description = tb_description.Text.ToString();
            newColumn.Category = cb_category.Text.ToString() + "";
            newColumn.Bytes = tb_bytes.Text.ToString();

            if (rb_emptyYes.Checked)
            {
                newColumn.AllowEmpty = "Y";
            }
            else
            {
                newColumn.AllowEmpty = "N";
            }

            if (rb_systemYes.Checked)
            {
                newColumn.SystemColum = "Y";
            }
            else
            {
                newColumn.SystemColum = "N";
            }

            if (rb_typeInt.Checked)
            {
                newColumn.FieldType = "Int";
            }
            else if (rb_typeString.Checked)
            {
                newColumn.FieldType = "String";
            }
            else if (rb_typeBool.Checked)
            {
                newColumn.FieldType = "Bool";
            }
            else if (rb_typeTime.Checked)
            {
                newColumn.FieldType = "Time";
            }
            else if (rb_typeDouble.Checked)
            {
                newColumn.FieldType = "Double";
            }

            //
            //非系统字段，修改一张表
            //
            ServerProxy.GetProxy().ModifyColumnType(oldColumn, newColumn);
            //
            //系统字段，需要修改多张表
            //

           
        }

    }
}
