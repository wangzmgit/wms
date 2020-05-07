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
            //预警值设置
            int intLess;
            string less = textLessWarning.Text.Trim();
            if(!int.TryParse(less,out intLess))
            {
                MessageBox.Show("预警值输入有误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); 
            {
                cfa.AppSettings.Settings["lessWarning"].Value = less;
            }
            //托盘设置
            if(!checkTray.Checked)
            {
                cfa.AppSettings.Settings["canTray"].Value = "false";
            }
            else
            {
                cfa.AppSettings.Settings["canTray"].Value = "true";
            }
            if(checkStart.Checked)
            {
                MessageBox.Show("此功能正在开发中...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            cfa.Save();
            MessageBox.Show("设置成功，下次启动时生效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WMSsetting_Load(object sender, EventArgs e)
        {
            textLessWarning.Text = ConfigurationManager.AppSettings["lessWarning"];
            if(ConfigurationManager.AppSettings["canTray"].Equals("true"))
            {
                checkTray.Checked = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/wangzmgit/wms");
        }
    }
}
