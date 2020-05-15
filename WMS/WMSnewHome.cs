using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WMS
{
    public partial class WMSnewHome : Form
    {
        private string userName = null;
        public string isAdmin;
        public WMSnewHome(string _userName)
        {
            InitializeComponent();
            cutomizeDesing();
            userName = _userName;
        }

        private void WMSnewHome_Load(object sender, EventArgs e)
        {
            buttonHome_Click(sender, e);
            //notifyIcon1.Visible = false;  //托盘图标可见
            string Identity=dispalyIdentity(userName);
            labelUser.Text = "当前用户: "+userName+"  "+Identity;
            
        }

        private void cutomizeDesing()
        {
            //编辑信息系列按钮
            panel2.Visible = false;
        }

        private void hitOrterButton()
        {
            //点击其他按钮时，关闭编辑菜单
            if (panel2.Visible == true)
                panel2.Visible = false;
        }

        /// <summary>
        /// 编辑信息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if(isAdmin=="1")
            {
                if (panel2.Visible == true)
                    panel2.Visible = false;
                else
                    panel2.Visible = true;
            }
            else
            {
                MessageBox.Show("权限不足", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void WMSnewHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (ConfigurationManager.AppSettings["canTray"].Equals("true"))
                {
                    //隐藏到托盘
                    e.Cancel = true;
                    WindowState = FormWindowState.Minimized;//最小化主窗口
                    ShowInTaskbar = false;
                    notifyIcon1.Visible = true;  //托盘图标可见
                    notifyIcon1.ShowBalloonTip(2000, "最小化到托盘", "程序已经缩小到托盘，单击打开程序。", ToolTipIcon.Info);
                }
                else
                {
                    Application.ExitThread();        
                }
            }
            else
            {
                e.Cancel = true;//取消事件
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hitOrterButton();
            panelWindow.Controls.Clear();//移除所有控件
            WMSInventory inventory = new WMSInventory();
            inventory.TopLevel = false;
            inventory.Dock = System.Windows.Forms.DockStyle.Fill;
            inventory.FormBorderStyle = FormBorderStyle.None;//无边框
            panelWindow.Controls.Add(inventory);
            inventory.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            hitOrterButton();
            panelWindow.Controls.Clear();//移除所有控件
            WMSadd add = new WMSadd();
            add.TopLevel = false;
            add.Dock = System.Windows.Forms.DockStyle.Fill;
            add.FormBorderStyle = FormBorderStyle.None;
            panelWindow.Controls.Add(add);
            add.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            //用户管理
            hitOrterButton();
            panelWindow.Controls.Clear();//移除所有控件
            WMSuser  user= new WMSuser();
            user.TopLevel = false;
            user.Dock = System.Windows.Forms.DockStyle.Fill;
            user.FormBorderStyle = FormBorderStyle.None;
            panelWindow.Controls.Add(user);
            user.Show();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            WMSedit edit = new WMSedit();
            edit.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hitOrterButton();
            panelWindow.Controls.Clear();//移除所有控件
            WMSsell sell = new WMSsell();
            sell.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hitOrterButton();
            panelWindow.Controls.Clear();//移除所有控件
            WMSorder order = new WMSorder();
            order.TopLevel = false;
            order.Dock = System.Windows.Forms.DockStyle.Fill;
            order.FormBorderStyle = FormBorderStyle.None;
            panelWindow.Controls.Add(order);
            order.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hitOrterButton();
            panelWindow.Controls.Clear();//移除所有控件
            WMSsetting setting = new WMSsetting();
            setting.TopLevel = false;
            setting.Dock = System.Windows.Forms.DockStyle.Fill;
            setting.FormBorderStyle = FormBorderStyle.None;
            panelWindow.Controls.Add(setting);
            setting.Show();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            hitOrterButton();
            panelWindow.Controls.Clear();//移除所有控件
            WMSInfoPage infoPage = new WMSInfoPage();
            infoPage.TopLevel = false;
            infoPage.Dock = System.Windows.Forms.DockStyle.Fill;
            infoPage.FormBorderStyle = FormBorderStyle.None;
            panelWindow.Controls.Add(infoPage);
            infoPage.Show();
        }

        /// <summary>
        /// 最小化到托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    //还原窗体
                    WindowState = FormWindowState.Normal;
                    //系统任务栏显示图标
                    ShowInTaskbar = true;
                }
                //激活窗体并获取焦点
                Activate();
            }
        }


        /// <summary>
        /// 托盘菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private string dispalyIdentity(string userName)
        {
            string sql = "select isAdmin from userInfo where UserName=@UserName";
            string Identity = null;
            SqlParameter[] paras =
            {
                new SqlParameter("@UserName",userName)
            };
            isAdmin = sqlHelper.sqlExecuteScalar(sql, paras);
            if(isAdmin=="1")
            {
                Identity = "[管理员]";
            }
            else
            {
                Identity = "[普通用户]";
            }
            return Identity;
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //关闭自动登录
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["autoLogin"].Value = "false";
            cfa.Save();
            //重启
            Application.Restart();
        }
    }
}
