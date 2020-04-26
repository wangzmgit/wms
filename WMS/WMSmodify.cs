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
    public partial class WMSmodify : Form
    {
        private int proID = 0;
        public WMSmodify(int _proID)
        {
            InitializeComponent();
            proID = _proID;
        }

        private void WMSmodify_Load(object sender, EventArgs e)
        {
            this.comboBoxUnit.SelectedIndex = 0;
            if (proID != 0)
            {
                //对ID查询
                string sql = "select name,stock,unit,supplier,entry,remarks from Inventory where productID = @productID";
                SqlParameter para = new SqlParameter("@productID", proID);
                SqlDataReader reader = sqlHelper.ExecutReader(sql, para);
                //读取数据
                if(reader.Read())
                {
                    textName.Text = reader["name"].ToString();
                    textStock.Text = reader["stock"].ToString();
                    textSupplier.Text = reader["supplier"].ToString();
                    textReporter.Text = reader["entry"].ToString();
                    textRemarks.Text = reader["remarks"].ToString();
                }
                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //信息获取
            string name = textName.Text.Trim();
            string stock = textStock.Text.Trim();
            string unit = comboBoxUnit.Text.Trim();
            string supplier = textSupplier.Text.Trim();
            string reporter = textReporter.Text.Trim();
            string remarks = textRemarks.Text.Trim();
            //判断是否为空
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("产品名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(stock))
            {
                MessageBox.Show("数量不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(unit))
            {
                MessageBox.Show("单位不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //不存在数据，进行添加
            int intStock;
            if (!int.TryParse(stock, out intStock))
            {
                MessageBox.Show("数量输入有误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sqlUpdate = "update Inventory set name = @name,stock = @stock,unit = @unit,supplier = @supplier,entry = @entry,remarks = @remarks where productID = @productID";
            SqlParameter[] parasUpdate =
            {
                    new SqlParameter("@name",name),
                    new SqlParameter("@stock",intStock),
                    new SqlParameter("@unit",unit),
                    new SqlParameter("@supplier",supplier),
                    new SqlParameter("@entry",reporter),
                    new SqlParameter("@remarks",remarks),
                    new SqlParameter("@productID",proID)
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
}
