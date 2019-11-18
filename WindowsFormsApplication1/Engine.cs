using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

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
    }
}
