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
    public partial class ModifyCategoryForm : Form
    {
        private string categoryTableName;

        private string categoryName;

        public ModifyCategoryForm(string categoryTableName)
        {
            InitializeComponent();
            this.categoryTableName = categoryTableName;
            this.categoryName = GetCategoryName(categoryTableName);
        }

        private void SelectParent(string parentDescription)
        {
            for (int i = 0; i < cb_categoryParentDescription.Items.Count; i++)
            {
                string selectValue = cb_categoryParentDescription.Items[i].ToString();
                Console.WriteLine(">>>>>> SelectParent::  selectValue = " + selectValue);
                if (selectValue.Equals(parentDescription))
                {
                    cb_categoryParentDescription.SelectedIndex = i;

                    break;
                }
            }
        }

        public void DisplayCategory()
        {
            ARCategory c = ServerProxy.GetProxy().GetCategory(categoryName);
            ARCategory parent = ServerProxy.GetProxy().GetCategory(c._PARENT_NO);

            tb_categoryName.Text = c._NAME;
            //cb_categoryParentDescription.Text = parent._DESCRIPTION;
            SelectParent(parent._DESCRIPTION);

            //tb_AJHCount.Text = c._AJH_COUNT;
            tb_AJHComponent.Text = c._AJ_NO_COMPONENT;
            tb_categoryDescription.Text = c._DESCRIPTION;
            if (c._TYPE.Trim().Equals("AJ"))
            {
                rb_WJJ.Checked = false;
                rb_AJJ.Checked = true;
            }
            else if (c._TYPE.Trim().Equals("WJ"))
            {
                rb_WJJ.Checked = true;
                rb_AJJ.Checked = false;
            }
        }

        private void InitParentComboBox()
        {
            List<ARCategory> categories = ServerProxy.GetProxy().GetCategorys();

            for (int i = 0; i < categories.Count; i++)
            {
                cb_categoryParentDescription.Items.Add(categories[i]._DESCRIPTION);
            }
            cb_categoryParentDescription.Items.Add("");
        }

        private void ModifyCategoryForm_Load(object sender, EventArgs e)
        {
            InitParentComboBox();

            DisplayCategory();

            this.Show();
        }

        private string GetCategoryName(string categoryTableName)
        {
            return categoryName = categoryTableName.Split('_')[2];
        }

        private void bt_modify_Click(object sender, EventArgs e)
        {
            string parentCategoryName = ServerProxy.GetProxy().GetCategoryName(cb_categoryParentDescription.Text);

            ARCategory newCategory = new ARCategory();

            newCategory._NAME = tb_categoryName.Text;
            newCategory._PARENT_NO = parentCategoryName;
            //newCategory._AJH_COUNT = tb_AJHCount.Text;
            newCategory._AJ_NO_COMPONENT = tb_AJHComponent.Text;
            newCategory._DESCRIPTION = tb_categoryDescription.Text;

            if (rb_WJJ.Checked)
            {
                newCategory._TYPE = "WJ";
            }
            else if (rb_AJJ.Checked)
            {
                newCategory._TYPE = "AJ";
            }

            if (ServerProxy.GetProxy().UpdateCategory(newCategory, categoryName))
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void btAJComponent_Click(object sender, EventArgs e)
        {
            new PrimaryKeyForm(this,categoryTableName).Show();
        }
    }
}
