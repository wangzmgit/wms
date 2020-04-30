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
    public partial class WMSnewHome : Form
    {
        public WMSnewHome()
        {
            InitializeComponent();
            cutomizeDesing();
        }
        
        private void cutomizeDesing()
        {
            panel2.Visible = false;
        }

        private void hitOrterButton()
        {
            //点击其他按钮时，关闭编辑菜单
            if (panel2.Visible == true)
                panel2.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
                panel2.Visible = false;
            else
                panel2.Visible = true;
        }

        private void WMSnewHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;//取消事件
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hitOrterButton();
            panelWindow.Controls.Clear();//移除所有控件
            WMSInventory inventory = new WMSInventory();
            inventory.TopLevel = false;
            inventory.Dock = System.Windows.Forms.DockStyle.Fill;
            inventory.FormBorderStyle = FormBorderStyle.None;//无边框
            panelWindow.Controls.Add(inventory);
            inventory.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            hitOrterButton();
            panelWindow.Controls.Clear();//移除所有控件
            WMSadd add = new WMSadd();
            add.TopLevel = false;
            add.Dock = System.Windows.Forms.DockStyle.Fill;
            add.FormBorderStyle = FormBorderStyle.None;
            panelWindow.Controls.Add(add);
            add.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            //用户管理
            hitOrterButton();
            panelWindow.Controls.Clear();//移除所有控件
            WMSuser  user= new WMSuser();
            user.TopLevel = false;
            user.Dock = System.Windows.Forms.DockStyle.Fill;
            user.FormBorderStyle = FormBorderStyle.None;
            panelWindow.Controls.Add(user);
            user.Show();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            WMSedit edit = new WMSedit();
            edit.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hitOrterButton();
            panelWindow.Controls.Clear();//移除所有控件
            WMSsell sell = new WMSsell();
            sell.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hitOrterButton();
            panelWindow.Controls.Clear();//移除所有控件
            WMSorder order = new WMSorder();
            order.TopLevel = false;
            order.Dock = System.Windows.Forms.DockStyle.Fill;
            order.FormBorderStyle = FormBorderStyle.None;
            panelWindow.Controls.Add(order);
            order.Show();
        }

    }
}
