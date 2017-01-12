using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SY.MODEL;

namespace SY.Client.Forms
{
    public partial class CategoryManagerForm : Form
    {
        private string categoryTableName = "";

        private QueryCategoryForm queryCategoryForm;

        public CategoryManagerForm(QueryCategoryForm queryCategoryForm)
        {
            InitializeComponent();
            this.queryCategoryForm = queryCategoryForm;
            DisplayTree();
        }

        //*************************************   树相关  *******************************************************

        private void DisplayTree()
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

        private void btAddCategory_Click(object sender, EventArgs e)
        {
            new AddCategoryForm().ShowDialog();
            DisplayTree();
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
            if (ServerProxy.GetProxy().DeleteCategory(ar))
            {
                ServerProxy.GetProxy().DeletePermission(ar._DESCRIPTION);
                DisplayTree();
            }
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = tv.SelectedNode;
            this.categoryTableName = node.Tag + "";
        }

        private void CategoryManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            queryCategoryForm.DisplayTree();
        }

        private void bt_modify_Click(object sender, EventArgs e)
        {
            if (categoryTableName == null || categoryTableName.Trim().Equals(""))
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            new ModifyCategoryForm(categoryTableName).ShowDialog();
        }

        private void bt_flesh_Click(object sender, EventArgs e)
        {
            DisplayTree();
        }

        
    }
}
