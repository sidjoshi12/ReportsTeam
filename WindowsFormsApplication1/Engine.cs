using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    class Engine
    {
        public static string ErrorMsg = "";
        public static string cnstring="data source=d2k62\\sqlexpress;user id=sa;password=sa123;initial catalog=OVSepPOST";
        public static void ExecuteQuery(string sql)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cnstring);
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                cn.Close();
            }
            catch (Exception ex)
            {
                ErrorMsg = "";
                ErrorMsg = ex.Message;
            }
        }
        public static DataTable getDataTable(string sql,string tableName="Table1")
        {
            SqlConnection cn = new SqlConnection(cnstring);
            cn.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable(tableName);
            ad.Fill(dt);
            cn.Close();
            if (dt.Rows.Count > 0)
                return dt;
            else
                return null;
        }
    }
}
