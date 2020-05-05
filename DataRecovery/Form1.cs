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

namespace DataRecovery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog() { Filter = "DB|*.bak" })
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    textFile.Text = openFile.FileName;
                }
            }
        }

        private void buttonIrecovery_Click(object sender, EventArgs e)
        {
            string path = textFile.Text.Trim();
            if(!string.IsNullOrEmpty(path))
            {
                bool restore= RestoreDataBase("WMS", path);
                if (restore)
                    MessageBox.Show("恢复成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("恢复失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 还原数据库
        /// </summary>
        /// <param name="databasename">需要还原数据库的名称</param>
        /// <param name="databasefile">文件路径</param>
        /// <returns></returns>
        public bool RestoreDataBase(string databasename, string databasefile)
        {
            SqlConnection constring = new SqlConnection("server=.;database=WMS;integrated security=true");
            string sql = " RESTORE DATABASE " + databasename + " from DISK ='" + databasefile + "'" + " WITH REPLACE";//数据库名称和路径 WITH REPLACE是去除日志文件
            SqlCommand sqlcmd = new SqlCommand(sql, constring);
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                //开始
                constring.Open();
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                constring.Close();
                return false;
            }
            constring.Close();//结束
            return true;
        }
    }
}
