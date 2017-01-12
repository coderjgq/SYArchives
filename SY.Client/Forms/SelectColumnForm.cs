using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using HostService.Services;
using System.Collections;

namespace SY.Client.Forms
{
    public partial class SelectColumnForm : Form
    {
        //IArchivesService channelProxy = ServerProxy.GetProxy();
        Label lab;
        List<string> descriptions;//没有显示的字段
        List<string> existDescriptions;//已经显示的字段

        public SelectColumnForm(Label lab, string categoryTableName, List<string> descriptions,List<string> existDescriptions)
        {
            InitializeComponent();
            this.lab = lab;
            this.descriptions = descriptions;
            this.existDescriptions = existDescriptions;

            descriptions.Sort();
            for (int i = 0; i < descriptions.Count; i++)
            {
                cb_columns.Items.Add(descriptions[i].ToString());
            }
            cb_columns.Items.Add(" ");
        }

        private void cb_columns_SelectedIndexChanged(object sender, EventArgs e)
        {
            string after = cb_columns.SelectedItem.ToString();
            string before = lab.Text;
            if (!after.Trim().Equals(""))
            {
                lab.Text = after;
                cb_columns.Items.Remove(cb_columns.SelectedItem);
                existDescriptions.Add(after);
                descriptions.Remove(after);

                if (!before.Trim().Equals(""))
                {
                    descriptions.Add(before);

                    existDescriptions.Remove(before);
                }

            }
            else
            {
                lab.Text = after;
                if (!before.Trim().Equals(""))
                {
                    existDescriptions.Remove(before);
                    descriptions.Add(before);
                }
            }

            cb_columns.Items.Clear();
            descriptions.Sort();
            for (int i = 0; i < descriptions.Count; i++)
            {
                cb_columns.Items.Add(descriptions[i].ToString());
            }
            cb_columns.Items.Add(" ");
            this.Close();
        }

        private void deleteExistDescription()
        {
            for (int i = 0; i < existDescriptions.Count; i++)
            {
                string tmp = existDescriptions[i].ToString().Trim();
                descriptions.Remove(tmp);
            }
        }
    }
}
