using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WMS
{
    public class sqlHelper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

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

        public static DataTable GetDataTable(string sql,params SqlParameter[] paras)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //创建Command对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                if(paras!=null)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(paras);
                }
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dataTable);
            }
            return dataTable;
        }

        public static int ExecuteNonQuery (string sql,params SqlParameter[] paras)
        {
            int count=0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(paras);
                conn.Open();
                count = cmd.ExecuteNonQuery();//执行T-SQL语句，返回受影响的行数
            }
            return count;
        }
        /// <summary>
        /// 执行查询，返回SqlDataReader
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static SqlDataReader ExecutReader (string sql,params SqlParameter[] paras)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Clear();        
                cmd.Parameters.AddRange(paras);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch(SqlException ex)
            {
                conn.Close();
                throw new Exception("执行查询出现异常",ex);
            }
        }
        /// <summary>
        /// 操作数据库，返回一个值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static string sqlExecuteScalar(string sql,params SqlParameter[] paras)
        {
            string key = null;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(paras);
                conn.Open();
                key = cmd.ExecuteScalar().ToString();
            }
            return key;
        }

        public static void dbBackUp(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql,conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
