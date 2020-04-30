using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WMS
{
    public partial class WMSinfoPage : Form
    {
        public WMSinfoPage()
        {
            InitializeComponent();
        }

        private void WMSinfoPage_Load(object sender, EventArgs e)
        {
            updataDgvStock();
        }

       private void updataDgvStock()
        {
            dgvStock.ForeColor = Color.Red;
            string sql = "select productID,name,stock from Inventory where stock < @stock";
            SqlParameter[] paras =
            {
                    new SqlParameter("@stock",20)
            };
            DataTable dataTable = sqlHelper.GetDataTable(sql, paras);
            dgvStock.DataSource = dataTable;
            dgvStock.AllowUserToAddRows = false;
        }
    }
}
