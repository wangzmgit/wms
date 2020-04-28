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
    public partial class WMSsell : Form
    {
        public WMSsell()
        {
            InitializeComponent();
        }

        private void displayALL_Click(object sender, EventArgs e)
        {
            //显示全部信息
            string sql = "select productID,name,stock,unit,remarks from Inventory";
            DataTable dtGradeList = sqlHelper.GetDataTable(sql);
            dgvInventory.DataSource = dtGradeList;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            //查找
            string name = textName.Text.Trim();
            textName.Text = "";
            string sql = "select productID,name,stock,unit,remarks from Inventory where name Like @name";
            if (!string.IsNullOrEmpty(name))
            {
                SqlParameter[] paras =
                {
                    new SqlParameter("@name","%"+name+"%")
                };
                DataTable dataTable = sqlHelper.GetDataTable(sql, paras);
                dgvInventory.DataSource = dataTable;
            }
        }


        //添加功能的实现
        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
                DataRow row = (dgvInventory.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                DataGridViewCell cell = dgvInventory.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell is DataGridViewLinkCell && cell.FormattedValue.ToString() == "添加")
                {
                    string quantity = textQuantity.Text.Trim();
                    if (string.IsNullOrEmpty(quantity))
                    {
                        quantity = "1";//默认数量为1
                    }
                    int index = dgvOrder.Rows.Add();
                    dgvOrder.Rows[index].Cells[0].Value = row["productID"].ToString();
                    dgvOrder.Rows[index].Cells[1].Value = row["name"].ToString();
                    dgvOrder.Rows[index].Cells[2].Value = quantity;
                    dgvOrder.Rows[index].Cells[3].Value = row["unit"].ToString();
                    textQuantity.Text = "";
                }
            }
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex!=-1)
            {
                DataGridViewCell cellOrder = dgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cellOrder is DataGridViewLinkCell && cellOrder.FormattedValue.ToString() == "移除")
                {
                    //对选择的进行移除
                    DataGridViewRow rowRemove = dgvOrder.Rows[e.RowIndex];
                    dgvOrder.Rows.Remove(rowRemove);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string orderNum = dataProcessing.GenerateOrderNo();//生成订单号
            int[] IDarr = new int[dgvOrder.RowCount - 1];
            int[] quantityArr = new int[dgvOrder.RowCount - 1];//储存数量
            for (int i = 0; i < dgvOrder.RowCount-1; i++)
            {
                //获取全部ID
                string proID = dgvOrder.Rows[i].Cells[0].Value.ToString();
                int intProID = int.Parse(proID);
                IDarr[i] = intProID;
                //获取全部数量
                string count = dgvOrder.Rows[i].Cells[2].Value.ToString();
                int intCount = int.Parse(count);
                quantityArr[i] = intCount;   
            }
            //写入订单表，获取订单ID
            string sql = "insert into [order](orderNum) values(@orderNum);select @@identity";
            SqlParameter[] paras =
            {
                    new SqlParameter("@orderNum",orderNum),
            };
            string key = sqlHelper.insertDate(sql, paras);
            if (!string.IsNullOrEmpty(key))
            {
                //创建商品表
                string sqlAdd = "insert into order_product (orderID,productID,quantity) values (@orderID,@productID,@quantity)";
                for (int j = 0; j < dgvOrder.RowCount - 1; j++)
                {
                    SqlParameter[] parasOrder =
                    {
                            new SqlParameter("@orderID",key),
                            new SqlParameter("@productID",IDarr[j].ToString()),
                            new SqlParameter("@quantity",quantityArr[j].ToString())
                        };
                    int addProReturn = sqlHelper.ExecuteNonQuery(sqlAdd, parasOrder);
                    if (addProReturn<=0)
                    {
                        MessageBox.Show("订单创建失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                MessageBox.Show("订单创建成功，单号为" + orderNum, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("订单创建失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
