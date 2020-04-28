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
    public partial class WMSdetails : Form
    {
        int orderID = 0;
        string orderNum = null;
        public WMSdetails(int _orderID,string _orderNum)
        {
            InitializeComponent();
            dgvOrder.AllowUserToAddRows = false;
            orderID = _orderID;
            orderNum = _orderNum;
            label2.Text = orderNum;
        }

        private void WMSdetails_Load(object sender, EventArgs e)
        {
            string sql = "select Inventory.name,order_product.quantity,Inventory.unit from order_product,Inventory where order_product.productID = Inventory.productID and order_product.orderID = @orderID";
            SqlParameter[] paras =
            {
                 new SqlParameter("@orderID",orderID)
            };
            DataTable dataTable = sqlHelper.GetDataTable(sql, paras);
            dgvOrder.DataSource = dataTable;
        }
    }
}
