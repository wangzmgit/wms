﻿using System;
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

        /// <summary>
        /// 查找按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textName.Text.Trim();
            string sql = "select productID,name,stock,unit,supplier,entry,remarks from Inventory where name Like @name";
            if(!string.IsNullOrEmpty(name))
            {
                SqlParameter[] paras =
                {
                    new SqlParameter("@name","%"+name+"%")
                };
                DataTable dataTable = sqlHelper.GetDataTable(sql, paras);
                dgvInventory.DataSource = dataTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select productID,name,stock,unit,supplier,entry,remarks from Inventory";
            DataTable dtGradeList = sqlHelper.GetDataTable(sql);
            dgvInventory.DataSource = dtGradeList;
        }
    }
}
