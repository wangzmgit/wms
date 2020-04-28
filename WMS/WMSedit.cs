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
    public partial class WMSedit : Form
    {
        public WMSedit()
        {
            InitializeComponent();
        }

        private void WMSedit_Load(object sender, EventArgs e)
        {
            string sql = "select productID,name,stock,unit,supplier,entry,remarks from Inventory";
            DataTable dtGradeList = sqlHelper.GetDataTable(sql);
            dgvEdit.DataSource = dtGradeList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textName.Text.Trim();
            string sql = "select productID,name,stock,unit,supplier,entry,remarks from Inventory where name Like @name";
            if (!string.IsNullOrEmpty(name))
            {
                SqlParameter[] paras =
                {
                    new SqlParameter("@name","%"+name+"%")
                };
                DataTable dataTable = sqlHelper.GetDataTable(sql, paras);
                dgvEdit.DataSource = dataTable;
            }
        }
        /// <summary>
        /// 修改和删除功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEdit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
                DataRow row = (dgvEdit.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                DataGridViewCell cell = dgvEdit.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell is DataGridViewLinkCell && cell.FormattedValue.ToString() == "修改")
                {
                    //打开修改窗口，传递ID
                    int proID = (int)row["productID"];
                    WMSmodify modify = new WMSmodify(proID);
                    modify.MdiParent = this.MdiParent;
                    modify.Show();
                }
                else if (cell is DataGridViewLinkCell && cell.FormattedValue.ToString() == "删除")
                {
                    if(MessageBox.Show("确定删除该信息吗？","警告",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                    {
                        //获取ID号
                        int productID = int.Parse(row["productID"].ToString());
                        string sql = "delete from Inventory where productID = @productID";
                        SqlParameter paras = new SqlParameter("@productID", productID);
                        int count = sqlHelper.ExecuteNonQuery(sql, paras);
                        if(count>0)
                        {
                            MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            WMSedit_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        
                    }
                }
            }
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            List<int> listID = new List<int>();
            for(int i=0;i<dgvEdit.Rows.Count;i++)
            {
                DataGridViewCheckBoxCell cell = dgvEdit.Rows[i].Cells["check"] as DataGridViewCheckBoxCell;
                bool chk = Convert.ToBoolean(cell.Value);
                if(chk)
                {
                    DataRow row = (dgvEdit.Rows[i].DataBoundItem as DataRowView).Row;
                    int proID = (int)row["productID"];
                    listID.Add(proID);
                }
            }
            if(listID.Count==0)
            {
                MessageBox.Show("没有选择", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("确定删除该信息吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int count = 0;
                    using (SqlConnection conn = new SqlConnection(sqlHelper.connString))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.Transaction = transaction;

                        try
                        {
                            foreach(int id in listID)
                            {
                                cmd.CommandText = "delete from Inventory where productID = @productID";
                                SqlParameter para = new SqlParameter("@productID", id);
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add(para);
                                count += cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch(SqlException ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if(count==listID.Count)
                    {
                        MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        WMSedit_Load(sender, e);
                    }
                }
            }
        }


    }
}
