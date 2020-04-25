using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    public partial class WMSInventory : Form
    {
        public WMSInventory()
        {
            InitializeComponent();
        }

        private void WMSInventory_Load(object sender, EventArgs e)
        {
            string sql = "select productID,name,stock,unit,supplier,entry,remarks from Inventory";
            DataTable dtGradeList = sqlHelper.GetDataTable(sql);
            dgvInventory.DataSource = dtGradeList;
        }

       
    }
}
