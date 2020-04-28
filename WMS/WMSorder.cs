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
    public partial class WMSorder : Form
    {
        public WMSorder()
        {
            InitializeComponent();
        }

        private void WMSorder_Load(object sender, EventArgs e)
        {
            string sql = "select id,orderNum,Createdate from [order]";
            DataTable dtGradeList = sqlHelper.GetDataTable(sql);
            dgvOrder.DataSource = dtGradeList;
            dgvOrder.AllowUserToAddRows = false;//去除空行
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string orderNum = textOrderNum.Text.Trim();
            string sql = "select id,orderNum,Createdate from [order] where orderNum Like @orderNum";
            if (!string.IsNullOrEmpty(orderNum))
            {
                SqlParameter[] paras =
                {
                    new SqlParameter("@orderNum","%"+orderNum+"%")
                };
                DataTable dataTable = sqlHelper.GetDataTable(sql, paras);
                dgvOrder.DataSource = dataTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WMSorder_Load(sender, e);
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataRow row = (dgvOrder.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                DataGridViewCell cell = dgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell is DataGridViewLinkCell && cell.FormattedValue.ToString() == "详情")
                {
                    //打开修改窗口，传递ID
                    int orderID = (int)row["id"];
                    string orderNum = row["orderNum"].ToString();
                    WMSdetails details = new WMSdetails(orderID,orderNum);
                    details.MdiParent = this.ParentForm;
                    details.Show();
                }
            }
        }
    }
}
