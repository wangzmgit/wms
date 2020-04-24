﻿using System;
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
    public partial class WMSHome : Form
    {
        public WMSHome()
        {
            InitializeComponent();
        }

        private void WMSHome_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 关闭应用程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WMSHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result= MessageBox.Show("确认退出吗", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;//取消事件
            }

        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMSInventory inventory = new WMSInventory();
            inventory.MdiParent = this;
            inventory.Show();
        }
    }
}
