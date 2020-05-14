using System;
using System.IO;
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

        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBackUp_Click(object sender, EventArgs e)
        {
            string bkPath = Environment.CurrentDirectory + "\\back-up";
            if (!Directory.Exists(bkPath))
            {
                Directory.CreateDirectory(bkPath);
            }
            if (!File.Exists(bkPath + "\\说明文件.txt"))
            {
                FileStream fs1 = new FileStream(bkPath + "\\说明文件.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine("这是数据库备份文件，请勿删除");//开始写入值
                sw.Close();
                fs1.Close();
            }
            dbBackUp();
        }

        private void dbBackUp()
        {
            //数据库备份
            string dbName = DateTime.Now.ToString("yyyy-MM-dd") + ".bak";
            string bkPath = Environment.CurrentDirectory + "\\back-up";
            string bkSql = "backup database WMS to disk='" + bkPath + "\\" + dbName + "'";
            sqlHelper.dbBackUp(bkSql);
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["LastBackup"].Value = DateTime.Now.ToString("yyyy-MM-dd");
            cfa.Save();
            MessageBox.Show("完成", "提示", MessageBoxButtons.OK);
        }
    }
}
