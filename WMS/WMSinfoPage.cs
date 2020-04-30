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
            updataDgvSales();
        }
        /// <summary>
        /// 更新低库存数据
        /// </summary>
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

        private void updataDgvSales()
        {
            dgvSales.ForeColor = Color.Black;
            string sql = "select top 5 productID,name,sales from Inventory order by sales desc";
            SqlParameter[] paras =
            {
                    
            };
            DataTable dataTable = sqlHelper.GetDataTable(sql, paras);
            dgvSales.DataSource = dataTable;
            dgvSales.AllowUserToAddRows = false;
        }
    }
}
