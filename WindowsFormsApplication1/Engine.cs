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
        public static bool ExecuteQry(string qry)
        {
            ErrorMsg = "";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand();
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = qry;
            try
            {
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (Exception ex)
            {
                cn.Close();
                ErrorMsg = ex.Message;
                return false;
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
