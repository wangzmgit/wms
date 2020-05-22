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
        
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //预警值设置
            string less = numericUpDown.Value.ToString();
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
            //自动登录
            if(!checkBoxAutoLogin.Checked)
            {
                cfa.AppSettings.Settings["autoLogin"].Value = "false";
            }
            else
            {
                cfa.AppSettings.Settings["autoLogin"].Value = "true";
            }
            cfa.Save();
            DialogResult dr = MessageBox.Show("重启后生效，是否立即重启", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(dr==DialogResult.OK)
            {
                Application.Restart();
            }
            else
            {
                return;
            }           
        }

        private void WMSsetting_Load(object sender, EventArgs e)
        {
            numericUpDown.Value =int.Parse( ConfigurationManager.AppSettings["lessWarning"]);
            //托盘是否选中
            if(ConfigurationManager.AppSettings["canTray"].Equals("true"))
            {
                checkTray.Checked = true;
            }
            //是否自动登录
            if (ConfigurationManager.AppSettings["autoLogin"].Equals("true"))
            {
                checkBoxAutoLogin.Checked = true;
            }
            label3.Text = "批量导入示例位置：" + Environment.CurrentDirectory;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/wangzmgit/wms");
        }

        /// <summary>
        /// 备份数据库按钮
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

        /// <summary>
        /// 备份数据库
        /// </summary>
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
