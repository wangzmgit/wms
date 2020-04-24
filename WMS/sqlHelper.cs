using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace WMS
{
    public class sqlHelper
    {
        private string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public object ExecuteScalar(string sql,SqlParameter[] paras)
        {
            object o = null;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //创建Command对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(paras);
                conn.Open();
                 o = cmd.ExecuteScalar();//执行查询，返回结果第一行第一列的值
            }
            return o;
        }
    }
}
