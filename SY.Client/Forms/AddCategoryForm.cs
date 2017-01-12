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

namespace SY.Client.Forms
{
    public partial class AddCategoryForm : Form
    {
        IArchivesService channelProxy = ServerProxy.GetProxy();
        private List<string> categories;
        public AddCategoryForm()
        {
            InitializeComponent();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {

            ARCategory arCategory = new ARCategory();
            ARCategory parentCategory = ServerProxy.GetProxy().GetCategoryByDescription(cb_categoryParentDescription.Text.ToString().Trim());
            arCategory._NAME = tb_categoryName.Text.ToString().Trim();
            //arCategory._AJH_COUNT = tb_AJHCount.Text.ToString().Trim();
            arCategory._PARENT_NO = parentCategory._NAME;
            arCategory._AJ_NO_COMPONENT = tb_AJHComponent.Text.ToString().Trim();
            arCategory._DESCRIPTION = tb_WJJComponent.Text.ToString().Trim();
            if (rb_AJJ.Checked)
            {
                arCategory._TYPE = "AJ";
            }
            else
            {
                arCategory._TYPE = "WJ";
            }

            if (arCategory._NAME == null || arCategory._NAME.Trim().Equals(""))
            {
                MessageBox.Show("请先输入分类名");
                return;
            }

            if (!ServerProxy.GetProxy().CategoryExist(arCategory._NAME, arCategory._DESCRIPTION))
            {
                if (ServerProxy.GetProxy().AddCategory(arCategory))
                {
                    string result = ServerProxy.GetProxy().AddPermission(arCategory._DESCRIPTION);
                    if (result != "SUCCESS")
                    {
                        MessageBox.Show(result);
                    }
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("插入失败");
                }
            }
            else
            {
                MessageBox.Show("分类名：'" + arCategory._NAME + "' 或 " + "分类描述：'" + arCategory._DESCRIPTION + "'已经存在");
            }
        }

        private void initParentComboBox()
        {
            List<ARCategory> categorys = ServerProxy.GetProxy().GetCategorys();
            for (int i = 0; i < categorys.Count; i++)
            {
                cb_categoryParentDescription.Items.Add(categorys[i]._DESCRIPTION);
            }
            cb_categoryParentDescription.Items.Add("");
        }

        private void AddCategoryForm_Load(object sender, EventArgs e)
        {
            initParentComboBox();
        }

    }
}
