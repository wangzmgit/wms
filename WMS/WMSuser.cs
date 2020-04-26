using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS
{
    public partial class WMSuser : Form
    {
        public WMSuser()
        {
            InitializeComponent();
            label5.Visible = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textUserName.Text.Trim();
            string oldPwd = textOldPwd.Text.Trim();
            string newPwd = textNewPwd.Text.Trim();
            string newPwd2 = textNewPwd2.Text.Trim();
            if(string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("用户名不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (string.IsNullOrEmpty(oldPwd))
            {
                MessageBox.Show("旧密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (string.IsNullOrEmpty(newPwd)&&!label5.Visible)
            {
                MessageBox.Show("新密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //比对数据
            string sql = "select count(1) from userInfo where UserName=@UserName and UserPwd=@UserPwd";
            SqlParameter[] paras =
{
                 new SqlParameter("@UserName", userName),
                 new SqlParameter("@UserPwd", oldPwd)
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
                string sqlUpdate = "update userInfo set UserPwd=@newPwd where UserName=@userName";
                SqlParameter[] parasUpdate =
                {
                    new SqlParameter("@newPwd",newPwd),
                    new SqlParameter("userName",userName)
                };
                int count = sqlHelper.ExecuteNonQuery(sqlUpdate, parasUpdate);
                if (count > 0)
                {
                    MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textNewPwd2_TextChanged(object sender, EventArgs e)
        {
            //确认密码不一致提示
            string str = textNewPwd.Text.Trim();
            string str2 = textNewPwd2.Text.Trim();
            if(str!=str2)
            {
                label5.Visible = true;
            }
            else
            {
                label5.Visible = false;
            }
        }

        private void textNewPwd_TextChanged(object sender, EventArgs e)
        {
            //确认密码不一致提示
            string str = textNewPwd.Text.Trim();
            string str2 = textNewPwd2.Text.Trim();
            if (str != str2)
            {
                label5.Visible = true;
            }
            else
            {
                label5.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string addUserName = textaddName.Text.Trim();
            string adminPwd = textAdminPwd.Text.Trim();
            string addPwd = textAddPwd.Text.Trim();
            string addpwd2 = textAddPwd2.Text.Trim();
            if (string.IsNullOrEmpty(addUserName))
            {
                MessageBox.Show("用户名不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (string.IsNullOrEmpty(adminPwd))
            {
                MessageBox.Show("管理员密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (addPwd!=addpwd2)
            {
                MessageBox.Show("两次密码不一致", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (string.IsNullOrEmpty(addPwd))
            {
                MessageBox.Show("密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //验证管理员密码
            string sql = "select count(1) from userInfo where UserName='admin' and UserPwd=@adminPwd";
            SqlParameter[] paras =
            {
                 new SqlParameter("@adminPwd", adminPwd),
             };
            sqlHelper helper = new sqlHelper();
            object o = helper.ExecuteScalar(sql, paras);
            if (o == null || o == DBNull.Value || ((int)o) == 0)
            {
                MessageBox.Show("管理员密码有误","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                //检测用户是否存在
                string sqlExists = "select count(1) from userInfo where UserName=@userName";
                SqlParameter[] paraExist =
                {
                    new SqlParameter("@userName", addUserName)
                };
                object oCount = helper.ExecuteScalar(sqlExists, paraExist);
                if (oCount == null || oCount == DBNull.Value || (int)oCount == 0)
                {
                    //用户名不存在，进行添加
                    string sqlAdd = "insert into userInfo (UserName,UserPwd) values (@userName,@userPwd)";
                    SqlParameter[] paraAdd =
                    {
                    new SqlParameter("@userName",addUserName),
                    new SqlParameter("@userPwd",addPwd)
                     };
                    int count = sqlHelper.ExecuteNonQuery(sqlAdd, paraAdd);
                    if (count > 0)
                    {
                        MessageBox.Show("成功添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("该用户已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }
    }
}
