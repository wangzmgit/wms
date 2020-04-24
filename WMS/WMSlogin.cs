using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    public partial class WMSlogin : Form
    {
        public WMSlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取用户信息
            string uName = userNameText.Text.Trim();
            string uPwd = passwordText.Text.Trim();
            //判断是否为空
            if(string.IsNullOrEmpty(uName))
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
            //连接查询数据库
            string sql = "select count(1) from userInfo where UserName=@UserName and UserPwd=@UserPwd";
            SqlParameter[] paras =
            {
                 new SqlParameter("@UserName", uName),
                 new SqlParameter("@UserPwd", uPwd)
             };
            sqlHelper helper = new sqlHelper();
            object o = helper.ExecuteScalar(sql, paras);
            if (o==null||o==DBNull.Value||((int)o)==0)
            {
                MessageBox.Show("账户或密码有误");
                return;
            }
            else
            {
                MessageBox.Show("111");

            }
        }
    }
}
