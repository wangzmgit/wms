﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WMS
{
    public partial class WMSsell : Form
    {
        float amount = 0;//总金额
        FormWindowState tempWindowState;//最大化状态
        public WMSsell()
        {
            InitializeComponent();
            initHeight();
        }

        private void WMSsell_Load(object sender, EventArgs e)
        {
            dgvInventory.RowHeadersVisible = false;//除去第一列
            dgvOrder.RowHeadersVisible = false;
            displayAll();
        }

        private void displayALL_Click(object sender, EventArgs e)
        {
            displayAll();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            //查找
            string name = textName.Text.Trim();
            textName.Text = "";
            string sql = "select productID,name,stock,unit,price,remarks from Inventory where name Like @name";
            if (!string.IsNullOrEmpty(name))
            {
                SqlParameter[] paras =
                {
                    new SqlParameter("@name","%"+name+"%")
                };
                DataTable dataTable = sqlHelper.GetDataTable(sql, paras);
                dgvInventory.DataSource = dataTable;
            }
        }


        //添加功能的实现
        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
                DataRow row = (dgvInventory.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                DataGridViewCell cell = dgvInventory.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell is DataGridViewLinkCell && cell.FormattedValue.ToString() == "添加")
                {
                    string quantity = textQuantity.Text.Trim();
                    if (string.IsNullOrEmpty(quantity))
                    {
                        quantity = "1";//默认数量为1
                    }
                    int temp;//临时变量，检测数量正确性
                    if (!int.TryParse(quantity, out temp))
                    {
                        MessageBox.Show("数量输入有误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int margin =int.Parse(row["stock"].ToString())-int.Parse(quantity);//用存量减去数量
                    if(margin<0)
                    {
                        MessageBox.Show("库存不足", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int index = dgvOrder.Rows.Add();
                    dgvOrder.Rows[index].Cells[0].Value = row["productID"].ToString();
                    dgvOrder.Rows[index].Cells[1].Value = row["name"].ToString();
                    dgvOrder.Rows[index].Cells[2].Value = quantity;
                    dgvOrder.Rows[index].Cells[3].Value = row["unit"].ToString();
                    dgvOrder.Rows[index].Cells[4].Value = row["price"].ToString();
                    //更新金额
                    amount += float.Parse(row["price"].ToString())*int.Parse(quantity);//单价乘数量
                    label4.Text = amount.ToString();
                    textQuantity.Text = "";
                    
                }
            }
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex!=-1)
            {
                DataGridViewCell cellOrder = dgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cellOrder is DataGridViewLinkCell && cellOrder.FormattedValue.ToString() == "移除")
                {
                    //对选择的进行移除
                    DataGridViewRow rowRemove = dgvOrder.Rows[e.RowIndex];
                    amount -= float.Parse(rowRemove.Cells[4].Value.ToString()) * int.Parse(rowRemove.Cells[2].Value.ToString());
                    label4.Text = amount.ToString();
                    dgvOrder.Rows.Remove(rowRemove);
                }
            }
        }

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSell_Click(object sender, EventArgs e)
        {
            if(dgvOrder.RowCount==0)
            {
                MessageBox.Show("订单内容不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string orderNum = dataProcessing.GenerateOrderNo();//生成订单号
            int[] IDarr = new int[dgvOrder.RowCount];
            int[] quantityArr = new int[dgvOrder.RowCount];//储存数量
            for (int i = 0; i < dgvOrder.RowCount; i++)
            {
                //获取全部ID
                IDarr[i] = int.Parse(dgvOrder.Rows[i].Cells[0].Value.ToString());
                //获取全部数量
                quantityArr[i] = int.Parse(dgvOrder.Rows[i].Cells[2].Value.ToString());
            }
            //写入订单表，获取订单ID
            string sql = "insert into [order](orderNum,amount) values(@orderNum,@amount);select @@identity";
            SqlParameter[] paras =
            {
                    new SqlParameter("@orderNum",orderNum),
                    new SqlParameter("@amount",amount)
            };
            string key = sqlHelper.sqlExecuteScalar(sql, paras);//订单的ID
            if (!string.IsNullOrEmpty(key))
            {
                //创建商品表
                string sqlAdd = "insert into order_product (orderID,productID,quantity) values (@orderID,@productID,@quantity)";
                for (int j = 0; j < dgvOrder.RowCount; j++)
                {
                    SqlParameter[] parasOrder =
                    {
                            new SqlParameter("@orderID",key),
                            new SqlParameter("@productID",IDarr[j].ToString()),
                            new SqlParameter("@quantity",quantityArr[j].ToString())
                    };
                    int addProReturn = sqlHelper.ExecuteNonQuery(sqlAdd, parasOrder);
                    if (addProReturn <= 0)
                    {
                        MessageBox.Show("订单创建失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    //修改库存
                    string sqlFind = "select stock from Inventory where productID = @productID";
                    SqlParameter paraID = new SqlParameter("@productID", IDarr[j]);
                    SqlDataReader reader = sqlHelper.ExecutReader(sqlFind, paraID);
                    if (reader.Read())
                    {
                        //获取旧库存
                        int oldStock = int.Parse(reader["stock"].ToString());
                        //获取旧的销量
                        int oldSales = 0;//销量
                        string sqlSales = "select sales from Inventory where productID = @productID";
                        SqlParameter paraSales = new SqlParameter("@productID", IDarr[j]);
                        oldSales = int.Parse(sqlHelper.sqlExecuteScalar(sqlSales, paraSales));
                        //旧库存减去数量
                        oldStock -= int.Parse(quantityArr[j].ToString());
                        //增加销量
                        oldSales += int.Parse(quantityArr[j].ToString());
                        //重新写入
                        string sqlUpdate = "update Inventory set stock = @stock,sales=@sales where productID = @productID";
                        SqlParameter[] parasUpdate =
                        {
                             new SqlParameter("@stock",oldStock),
                             new SqlParameter("@sales",oldSales),
                             new SqlParameter("@productID",IDarr[j])
                        };
                        int updataReturn = sqlHelper.ExecuteNonQuery(sqlUpdate, parasUpdate);
                        if (updataReturn <= 0)
                        {
                            MessageBox.Show("库存更新时发生错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                MessageBox.Show("订单创建成功，单号为" + orderNum, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("订单创建失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 最大化与还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WMSsell_Resize(object sender, EventArgs e)
        {
            int height = Height;//获取窗口高度
            if (tempWindowState != FormWindowState.Maximized && WindowState == FormWindowState.Maximized)//点击最大化
            {
                tempWindowState = FormWindowState.Maximized;
                //最大化时高度为窗口大小的35%，下同
                dgvInventory.Height = Convert.ToInt32(height * 0.35);
                groupBox2.Height= Convert.ToInt32(height * 0.4);
                dgvOrder.Height= Convert.ToInt32(height * 0.4);
            }
            else if (tempWindowState == FormWindowState.Maximized && WindowState == FormWindowState.Normal)//窗口由最大化还原为普通
            {
                tempWindowState = FormWindowState.Normal;
                initHeight();
            }
        }

        /// <summary>
        /// 初始高度
        /// </summary>
        private void initHeight()
        {
            int height = Height;//获取窗口高度
            dgvInventory.Height = Convert.ToInt32(height * 0.3);
            groupBox2.Height = Convert.ToInt32(height * 0.35);
            dgvOrder.Height = Convert.ToInt32(height * 0.35);
        }

        /// <summary>
        /// 显示全部信息
        /// </summary>
        private void displayAll()
        {
            string sql = "select productID,name,stock,unit,price,remarks from Inventory";
            DataTable dtGradeList = sqlHelper.GetDataTable(sql);
            dgvInventory.DataSource = dtGradeList;
        }
    }
}
