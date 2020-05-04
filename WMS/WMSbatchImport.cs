using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;

namespace WMS
{
    public partial class WMSbatchImport : Form
    {
        public WMSbatchImport()
        {
            InitializeComponent();
        }

        DataTableCollection tableCollection;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[comboBox1.SelectedItem.ToString()];
            dgvImport.DataSource = dt;
            dgvImport.AllowUserToAddRows = false;
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog() { Filter = "Workbook|*.xlsx|Excel 97-2003 Workbook|* .xls" })
            {
                if(openFile.ShowDialog()==DialogResult.OK)
                {
                    textFile.Text = openFile.FileName;
                    using (var stream = File.Open(openFile.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable=(_)=>new ExcelDataTableConfiguration() { UseHeaderRow=true}
                            });
                            tableCollection = result.Tables;
                            comboBox1.Items.Clear();
                            foreach(DataTable table in tableCollection)
                            {
                                comboBox1.Items.Add(table.TableName);
                            }
                        }
                    }
                }
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            int lines = dgvImport.RowCount;
            int temp;//检测数字变量合法性
            float priceF;//检测售价合法性
            string name, stock, unit,price, supplier, reporter, remarks;
            if (lines>0)
            {
                for(int i=0;i<lines;i++)
                {
                    //获取数据
                    name = dgvImport.Rows[i].Cells[0].Value.ToString();
                    stock= dgvImport.Rows[i].Cells[1].Value.ToString();
                    unit= dgvImport.Rows[i].Cells[2].Value.ToString();
                    price= dgvImport.Rows[i].Cells[3].Value.ToString();
                    supplier= dgvImport.Rows[i].Cells[4].Value.ToString();
                    reporter= dgvImport.Rows[i].Cells[5].Value.ToString();
                    remarks= dgvImport.Rows[i].Cells[6].Value.ToString();
                    //检测处理数据
                    while(true)
                    {
                        object oCount= nameExist(name);
                        if (oCount == null || oCount == DBNull.Value || (int)oCount == 0)
                            break;
                        else
                            name = name + "-b";
                    }
                    if (!int.TryParse(stock, out temp))
                        stock = "0";
                    if (!float.TryParse(price, out priceF))
                        price = "0";
                    if (string.IsNullOrEmpty(unit))
                        unit = "个";
                    //进行添加
                    string sqlAdd = "insert into Inventory (name,stock,unit,supplier,entry,remarks,price) values (@name,@stock,@unit,@supplier,@entry,@remarks,@price)";
                    SqlParameter[] paras =
                    {
                    new SqlParameter("@name",name),
                    new SqlParameter("@stock",stock),
                    new SqlParameter("@unit",unit),
                    new SqlParameter("@supplier",supplier),
                    new SqlParameter("@entry",reporter),
                    new SqlParameter("@remarks",remarks),
                    new SqlParameter("@price",price)
                     };
                    sqlHelper.ExecuteNonQuery(sqlAdd, paras);
                }
                MessageBox.Show("导入成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
        }
        
        private object nameExist(string name)
        {
            //检测产品名存在
            string sqlExists = "select count(1) from Inventory where name=@name";
            SqlParameter[] para =
            {
                new SqlParameter("@name",name)
            };
            sqlHelper helper = new sqlHelper();
            object oCount = helper.ExecuteScalar(sqlExists, para);
            return oCount;
        }
    }

}
