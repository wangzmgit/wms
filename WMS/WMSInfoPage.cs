using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WMS
{
    public partial class WMSInfoPage : Form
    {
        public WMSInfoPage()
        {
            InitializeComponent();
        }

        private void WMSinfoPage_Load(object sender, EventArgs e)
        {
            updataDgvStock();
            updataDgvSales();
            updateQuantiy();
            updateTodayOrder();
            updateAllOrder();
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
        /// <summary>
        /// 销量前5
        /// </summary>
        private void updataDgvSales()
        {
            dgvSales.ForeColor = Color.Black;
            string sql = "select top 5 productID,name,sales from Inventory order by sales desc";
            SqlParameter[] paras = { };
            DataTable dataTable = sqlHelper.GetDataTable(sql, paras);
            dgvSales.DataSource = dataTable;
            dgvSales.AllowUserToAddRows = false;
        }
        
        private void updateQuantiy()
        {
            string sql = "select count(productID) from Inventory where 1=1";
            SqlParameter[] paras ={ };
            string quantity = sqlHelper.insertDate(sql, paras);
            labelQuantity.Text = quantity;
        }

        private void updateTodayOrder()
        {
            string sql = "select count(id) from [order] where Createdate=@date";
            SqlParameter[] paras = 
            {
                new SqlParameter("@date",DateTime.Now.ToString("yyyy-MM-dd"))
            };
            string TDorder = sqlHelper.insertDate(sql, paras);
            labelOrderTD.Text = TDorder;
        }

        private void updateAllOrder()
        {
            string sql = "select count(id) from [order] where 1=1";
            SqlParameter[] paras ={ };
            string order = sqlHelper.insertDate(sql, paras);
            labelOrder.Text = order;
        }
    }
}
