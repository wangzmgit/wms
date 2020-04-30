using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    public partial class WMSsetting : Form
    {
        public WMSsetting()
        {
            InitializeComponent();
        }
        Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (autoLogin.Checked)
            {
                //自动登录
                MessageBox.Show("此功能还在开发中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void WMSsetting_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["autoLogin"].Equals("true"))
            {
                autoLogin.Checked = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.cn");
        }
    }
}
