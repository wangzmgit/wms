using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace WMS
{
    public partial class WMSInfoPage : Form
    {
        public WMSInfoPage()
        {
            InitializeComponent();
            beautify.SetGridViewType(dgvSales);
            beautify.SetGridViewType(dgvStock);
        }

        private void WMSinfoPage_Load(object sender, EventArgs e)
        {
            updataDgvStock();
            updataDgvSales();
            updateQuantiy();
            updateTodayOrder();
            updateAllOrder();
            backUpDB();
        }
        /// <summary>
        /// 更新低库存数据
        /// </summary>
       private void updataDgvStock()
       {
            dgvStock.ForeColor = Color.Red;
            //获取低库存预警值
            string lessWaring = ConfigurationManager.AppSettings["lessWarning"];
            string sql = "select productID,name,stock from Inventory where stock < @stock";
            SqlParameter[] paras =
            {
                new SqlParameter("@stock",lessWaring)
            };
            DataTable dataTable = sqlHelper.GetDataTable(sql, paras);
            dgvStock.DataSource = dataTable;
            dgvStock.RowHeadersVisible = false;
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
            dgvSales.RowHeadersVisible = false;
        }
        
        private void updateQuantiy()
        {
            //更新产品数量
            string sql = "select count(productID) from Inventory where 1=1";
            SqlParameter[] paras ={ };
            string quantity = sqlHelper.sqlExecuteScalar(sql, paras);
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
            string TDorder = sqlHelper.sqlExecuteScalar(sql, paras);
            labelOrderTD.Text = TDorder;
        }

        private void updateAllOrder()
        {
            //更新全部订单数量
            string sql = "select count(id) from [order] where 1=1";
            SqlParameter[] paras ={ };
            string order = sqlHelper.sqlExecuteScalar(sql, paras);
            labelOrder.Text = order;
        }

        private void backUpDB()
        {
            //数据库备份信息
            string bkDate = ConfigurationManager.AppSettings["LastBackup"];
            if(string.IsNullOrEmpty(bkDate))
            {

                labelBackUpDate.Text = "暂无备份记录";
                linkLabelGoSetting.Visible = true;
            }
            else
            {
                labelBackUpDate.Text = bkDate;
            }
            //计算间隔时间
            DateTime dateTime = DateTime.Parse(bkDate);
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan timeSpan = dateTime.Subtract(dateTimeNow);
            int day = timeSpan.Days;
            if(day>=15)
            {
                labelInterval.Text = "您已" + day + "天没有备份数据";
                labelInterval.Visible = true;
                linkLabelGoSetting.Visible = true;
            }

        }

        private void linkLabelGoSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //在当前panel里加载设置页
            panel1.Controls.Clear();//移除所有控件
            WMSsetting setting = new WMSsetting();
            setting.TopLevel = false;
            setting.Dock = DockStyle.Fill;
            setting.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(setting);
            setting.Show();
        }
    }
}
