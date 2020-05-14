using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WMS
{
    public partial class WMSorder : Form
    {
        public WMSorder()
        {
            InitializeComponent();
            beautify.SetGridViewType(dgvOrder);
        }

        private void WMSorder_Load(object sender, EventArgs e)
        {
            dispalyAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string orderNum = textOrderNum.Text.Trim();
            string sql = "select id,orderNum,amount,Createdate from [order] where orderNum Like @orderNum";
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
            dispalyAll();
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataRow row = (dgvOrder.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                DataGridViewCell cell = dgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell is DataGridViewLinkCell && cell.FormattedValue.ToString() == "详情")
                {
                    //打开订单详情窗口，传递ID
                    int orderID = (int)row["id"];
                    string orderNum = row["orderNum"].ToString();
                    WMSorderDetails details = new WMSorderDetails(orderID,orderNum);
                    details.Show();
                }
            }
        }
        private void dispalyAll()
        {
            dgvOrder.ForeColor = Color.Black;
            string sql = "select id,orderNum,amount,Createdate from [order]";
            DataTable dtGradeList = sqlHelper.GetDataTable(sql);
            dgvOrder.DataSource = dtGradeList;
            dgvOrder.RowHeadersVisible = false;
        }
    }
}
