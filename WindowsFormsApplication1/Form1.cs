using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (xPictureBox1.DataSource != null)
            {
                string sql = "insert imageControl(Photo) values(@img)";
                SqlConnection cn = new SqlConnection(Engine.cnstring);
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@img", xPictureBox1.DataSource);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.ExecuteQuery("if object_id('imageControl')is null "
    + " create table imageControl(id int IDENTITY(1,1),Photo image)");
        }
    }
}
