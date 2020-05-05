using System;
using System.Configuration;
using System.Windows.Forms;

namespace WMS
{
    public partial class WMSsetting : Form
    {
        public WMSsetting()
        {
            InitializeComponent();
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (autoLogin.Checked)
            {
                //自动登录
                MessageBox.Show("此功能还在开发中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                if(ConfigurationManager.AppSettings["rememberPwd"].Equals("true"))
                {
                    cfa.AppSettings.Settings["autoLogin"].Value = "true";
                    cfa.Save();  
                }
            }
            else
            {
                cfa.AppSettings.Settings["autoLogin"].Value = "false";
                cfa.Save();
            }
           // MessageBox.Show("设置成功，下次启动时生效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            System.Diagnostics.Process.Start("https://github.com/wangzmgit/wms");
        }
    }
}
