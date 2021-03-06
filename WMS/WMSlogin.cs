﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WMS
{
    public partial class WMSlogin : Form
    {
        public string userName;
        string key = "M01z0LTnpbARncm2kdwkFVXAWMBLgmZi";//加密秘钥
        public WMSlogin()
        {
            InitializeComponent();
            //双缓冲
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            //半透明部分
            panel1.BackColor = Color.FromArgb(180, 255, 254, 250);//让panel半透明
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            linkLabel1.BackColor=Color.Transparent;
            checkBox1.BackColor = Color.Transparent;//选择框透明
            checkBox2.BackColor = Color.Transparent;
        }

        private void WMSlogin_Load(object sender, EventArgs e)
        {
            if(ConfigurationManager.AppSettings["rememberPwd"].Equals("true"))
            {
                userNameText.Text = ConfigurationManager.AppSettings["name"];
                string password = ConfigurationManager.AppSettings["pwd"];
                passwordText.Text = dataProcessing.Decrypt(password, key);
                checkBox1.Checked = true;
                checkBox2.Checked = true;
            }
            else if(ConfigurationManager.AppSettings["rememberMe"].Equals("true"))
            {
                userNameText.Text = ConfigurationManager.AppSettings["name"];
                checkBox1.Checked = true;
            }
            if(ConfigurationManager.AppSettings["autoLogin"].Equals("true"))
            {
                login();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //获取用户信息
            string uName = userNameText.Text.Trim();
            string uPwd = passwordText.Text.Trim();
            //判断是否为空
            if (string.IsNullOrEmpty(uName))
            {
                MessageBox.Show("请输入账号");
                userNameText.Focus();
                return;
            }
            if (string.IsNullOrEmpty(uPwd))
            {
                MessageBox.Show("请输入密码");
                passwordText.Focus();
                return;
            }
            //加密密码
            uPwd = dataProcessing.Encrypt(uPwd, key);
            //连接查询数据库
            string sql = "select count(1) from userInfo where UserName=@UserName and UserPwd=@UserPwd";
            SqlParameter[] paras =
            {
                 new SqlParameter("@UserName", uName),
                 new SqlParameter("@UserPwd", uPwd)
             };
            sqlHelper helper = new sqlHelper();
            object o = helper.ExecuteScalar(sql, paras);
            if (o == null || o == DBNull.Value || ((int)o) == 0)
            {
                MessageBox.Show("账户或密码有误");
                return;
            }
            else
            {
                if (checkBox1.Checked && !checkBox2.Checked)
                {
                    cfa.AppSettings.Settings["rememberMe"].Value = "true";
                    cfa.AppSettings.Settings["rememberPwd"].Value = "false";
                    cfa.AppSettings.Settings["name"].Value = userNameText.Text.Trim();
                    cfa.AppSettings.Settings["pwd"].Value = "";
                    cfa.Save();
                }
                else if (checkBox2.Checked)
                {
                    cfa.AppSettings.Settings["rememberMe"].Value = "true";
                    cfa.AppSettings.Settings["rememberPwd"].Value = "true";
                    cfa.AppSettings.Settings["name"].Value = userNameText.Text.Trim();
                    cfa.AppSettings.Settings["pwd"].Value = uPwd;
                    cfa.Save();
                }
                else
                {
                    cfa.AppSettings.Settings["rememberMe"].Value = "false";
                    cfa.AppSettings.Settings["rememberPwd"].Value = "false";
                    cfa.AppSettings.Settings["name"].Value = "";
                    cfa.AppSettings.Settings["pwd"].Value = "";
                    cfa.Save();
                }
                userName = uName;
                //将该窗体的返回值变为OK
                DialogResult = DialogResult.OK;
                //将该窗体关闭
                Close();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //记住密码必须记住用户名
            if(checkBox2.Checked==true)
            {
                checkBox1.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //不记住账号就不能记住密码
            if(checkBox1.Checked==false)
            {
                checkBox2.Checked = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath= Environment.CurrentDirectory+"\\安装说明.txt";
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return;
            }

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = filePath;
            psi.UseShellExecute = true;

            Process.Start(psi);

        }
    }
}
