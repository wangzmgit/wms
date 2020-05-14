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
    public partial class WMSedit : Form
    {
        public WMSedit()
        {
            InitializeComponent();
        }

        private void WMSedit_Load(object sender, EventArgs e)
        {
            dispalyAll();
        }
        /// <summary>
        /// 查找功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textName.Text.Trim();
            string sql = "select productID,name,stock,unit,supplier,entry,remarks from Inventory where name Like @name";
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

        private void dispalyAll()
        {
            string sql = "select productID,name,stock,unit,supplier,entry,remarks from Inventory";
            DataTable dtGradeList = sqlHelper.GetDataTable(sql);
            dgvInventory.DataSource = dtGradeList;
            dgvInventory.AllowUserToAddRows = false;//去除空行
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dispalyAll();
        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataRow row = (dgvInventory.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                DataGridViewCell cell = dgvInventory.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell is DataGridViewLinkCell && cell.FormattedValue.ToString() == "修改")
                {
                    //打开修改窗口，传递ID
                    //打开修改窗口，传递ID
                    int proID = (int)row["productID"];
                    WMSmodify modify = new WMSmodify(proID);
                    modify.Show();
                }
                else if (cell is DataGridViewLinkCell && cell.FormattedValue.ToString() == "删除")
                {
                    DialogResult dr = MessageBox.Show("是否确认删除?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if(dr==DialogResult.OK)
                    {
                        //获取ID号
                        int productID = int.Parse(row["productID"].ToString());
                        string sql = "delete from Inventory where productID = @productID";
                        SqlParameter paras = new SqlParameter("@productID", productID);
                        int count = sqlHelper.ExecuteNonQuery(sql, paras);
                        if (count > 0)
                        {
                            MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            WMSedit_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                    
                }
            }
        }
    }
}
