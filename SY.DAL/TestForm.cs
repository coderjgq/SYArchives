using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SY.DAL
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void bt_test_Click(object sender, EventArgs e)
        {
            List<MODEL.ARPermission> permissions = DBHelper.GetPermissionsByUserId(1);
            foreach (MODEL.ARPermission permission in permissions)
            {
                Console.WriteLine("permission = " + permission.Permission_Name);
            }
        }
    }
}
