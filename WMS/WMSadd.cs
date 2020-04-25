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
    public partial class WMSadd : Form
    {
        public WMSadd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if(string.IsNullOrEmpty(name))
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
            //判断已经存在
            string sqlExists = "select count(1) from Inventory where name=@name";
            SqlParameter[] para =
            {
                new SqlParameter("@name",name)
            };
            sqlHelper helper = new sqlHelper();
            object oCount = helper.ExecuteScalar(sqlExists, para);
            if(oCount==null||oCount==DBNull.Value||(int)oCount==0)
            {
                //不存在数据，进行添加
                int intStock = int.Parse(stock);
                string sqlAdd = "insert into Inventory (name,stock,unit,supplier,entry,remarks) values (@name,@stock,@unit,@supplier,@entry,@remarks)";
                SqlParameter[] paras =
                {
                    new SqlParameter("@name",name),
                    new SqlParameter("@stock",intStock),
                    new SqlParameter("@unit",unit),
                    new SqlParameter("@supplier",supplier),
                    new SqlParameter("@entry",reporter),
                    new SqlParameter("@remarks",remarks)
                };
                int count = sqlHelper.ExecuteNonQuery(sqlAdd,paras);
                if(count>0)
                {
                    MessageBox.Show("插入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("插入失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            else
            {
                MessageBox.Show("该产品已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

    }
}
