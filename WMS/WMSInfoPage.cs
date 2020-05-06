using System;
using System.Data;
using System.IO;
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
            //更新产品数量
            string sql = "select count(productID) from Inventory where 1=1";
            SqlParameter[] paras ={ };
            string quantity = sqlHelper.insertDate(sql, paras);
            labelQuantity.Text = quantity;
        }

        private void updateTodayOrder()
        {
            //更新当日订单数量
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
            //更新全部订单数量
            string sql = "select count(id) from [order] where 1=1";
            SqlParameter[] paras ={ };
            string order = sqlHelper.insertDate(sql, paras);
            labelOrder.Text = order;
        }

        private void dbBackUp()
        {
            string dbName = DateTime.Now.ToString("yyyy-MM-dd")+".bak";
            string bkPath = Environment.CurrentDirectory+"\\back-up";
            string bkSql = "backup database WMS to disk='"+bkPath+"\\"+dbName+"'";
            sqlHelper.dbBackUp(bkSql);
        }

        private void buttonBackUp_Click(object sender, EventArgs e)
        {
            string bkPath = Environment.CurrentDirectory + "\\back-up";
            if (!Directory.Exists(bkPath))
            {
                Directory.CreateDirectory(bkPath);
            }
            if(!File.Exists(bkPath+"\\说明文件.txt"))
            {
                FileStream fs1 = new FileStream(bkPath + "\\说明文件.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine("这是数据库备份文件，请勿删除");//开始写入值
                sw.Close();
                fs1.Close();
            }
            dbBackUp();
        }
    }
}
