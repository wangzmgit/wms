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
            beautify.SetGridViewType(dgvInventory);
            dgvInventory.RowHeadersVisible = false;//除去第一列
        }

        private void WMSInventory_Load(object sender, EventArgs e)
        {
            dispalyAll();
        }

        /// <summary>
        /// 查找按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textName.Text.Trim();
            string sql = "select productID,name,stock,unit,price,supplier,entry,remarks from Inventory where name Like @name and isDelete=0";
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
        //显示全部按钮 
        private void button2_Click(object sender, EventArgs e)
        {
            dispalyAll();
        }

        /// <summary>
        /// 查找按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFind_Click(object sender, EventArgs e)
        {
            //上面的查找按钮，单击打开查找的groupBox
            groupBox1.Visible = true;
            buttonFind.Visible = false;
        }

        /// <summary>
        /// 收起按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCollapse_Click(object sender, EventArgs e)
        {
            buttonFind.Visible = true;
            groupBox1.Visible = false;
        }

        //显示全部
        private void dispalyAll()
        {

            dgvInventory.ForeColor = Color.Black;
            string sql = "select productID,name,stock,unit,price,supplier,entry,remarks from Inventory where isDelete=0";
            DataTable dtGradeList = sqlHelper.GetDataTable(sql);
            dgvInventory.DataSource = dtGradeList;
        }
    }
}
