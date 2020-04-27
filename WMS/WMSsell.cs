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
                        MessageBox.Show("数量不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {
                        int index = dgvOrder.Rows.Add();
                        dgvOrder.Rows[index].Cells[0].Value = row["productID"].ToString();
                        dgvOrder.Rows[index].Cells[1].Value = row["name"].ToString();
                        dgvOrder.Rows[index].Cells[2].Value = quantity;
                        dgvOrder.Rows[index].Cells[3].Value = row["unit"].ToString();
                        textQuantity.Text = "";
                    }
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
                    DataGridViewRow rowRemove = dgvOrder.Rows[e.RowIndex];
                    dgvOrder.Rows.Remove(rowRemove);
                }
            }
        }
    }
}
