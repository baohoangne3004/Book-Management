using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BookManagement
{
    class DAO
    {
        public static SqlConnection GetConnection()
        {
            string strConn = ConfigurationManager.ConnectionStrings["DBString"].ToString();
            return new SqlConnection(strConn);
        }

        private static DataSet GetDataSet(string sqlScript, SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand(sqlScript, GetConnection());
            if (paras != null)
            {
                cmd.Parameters.AddRange(paras);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public static int AddBook(Book book)
        {
            int count = 0;
            string sql = "INSERT INTO[dbo].[Books]\n"
                   + "([Id]\n"
                   + ",[Title]\n"
                   + ",[UnitPrice]\n"
                   + ",[Quantity])\n"
             + "VALUES\n"
                   + "(@id\n"
                   + ",@title\n"
                   + ",@unitprice\n"
                   + ",@quantity)\n";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.NVarChar),
                new SqlParameter("@title", SqlDbType.NVarChar),
                new SqlParameter("@unitprice", SqlDbType.Float),
                new SqlParameter("@quantity", SqlDbType.Int)
            };

            paras[0].Value = book.Id;
            paras[1].Value = book.Title;
            paras[2].Value = book.UnitPrice;
            paras[3].Value = book.Quantity;
            cmd.Parameters.AddRange(paras);
            cmd.Connection.Open();
            count = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return count;
        }

        public static DataTable GetBookOrderByTitle()
        {
            string sqlScript = "SELECT [Id]\n" 
                   + ",[Title]\n"
                   + ",[UnitPrice]\n"
                   + ",[Quantity]\n"
                + "FROM[dbo].[Books]\n" 
                + "ORDER BY [Title]";               
            return GetDataSet(sqlScript, null).Tables[0];
        }

        public static DataTable GetBookMaxPrice()
        {
            string sqlScript = "SELECT TOP 1 [Id]\n"
                   + ",[Title]\n"
                   + ",[UnitPrice]\n"
                   + ",[Quantity]\n"
                + "FROM [dbo].[Books]\n"
                + "ORDER BY [UnitPrice]";
            return GetDataSet(sqlScript, null).Tables[0];
        }
        public static DataTable GetBook3MinPrice()
        {
            string sqlScript = "SELECT TOP 3 [Id]\n"
                   + ",[Title]\n"
                   + ",[UnitPrice]\n"
                   + ",[Quantity]\n"
                + "FROM [dbo].[Books]\n"
                + "ORDER BY [UnitPrice] DESC";
            return GetDataSet(sqlScript, null).Tables[0];
        }
    }
}
