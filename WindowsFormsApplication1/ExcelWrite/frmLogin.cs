using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        DataSet ds;
        DataTable dt;
        private void initDB()
        {
            if(!System.IO.File.Exists("ds.xml"))
            {
                dt = new DataTable();
                dt.Columns.Add("Server", typeof(string));
                dt.Columns.Add("UID", typeof(string));
                dt.Columns.Add("Pass", typeof(string));
                dt.Columns.Add("DB", typeof(string));

                string Priority = DateTime.Now.ToString();
                dt.Rows.Add("Server", "UID", "Pass", "DB");
                ds = new DataSet();
                ds.Tables.Add(dt);
                ds.WriteXml("ds.xml");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            initDB();
            ds = new DataSet();
            ds.ReadXml("ds.xml");
            dt = ds.Tables[0];

            AddItems("Server", cmbServer);
            AddItems("UID", cmbUID);
            AddItems("Pass", cmbPass);
            AddItems("DB", cmbDB);
        }

        private void AddItems(string col, ComboBox cbo)
        {
            cbo.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                cbo.Items.Add(dr[col].ToString());
            }
            cbo.Text = dt.Rows[0][col].ToString();
        }

        public DataTable SelectTopFrom(DataTable dataSource,string[] distinctColumns, int rowCount)
        {
            DataView view=new DataView(dataSource);
            dataSource = view.ToTable("Table1", true, distinctColumns);
            rowCount = dataSource.Rows.Count < rowCount ? dataSource.Rows.Count : rowCount;

            DataTable dtn = dataSource.Clone();
            for (int i = 0; i < rowCount; i++)
            {
                dtn.ImportRow(dataSource.Rows[i]);
            }
            return dtn;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();
            dr["Server"] = cmbServer.Text;
            dr["UID"] = cmbUID.Text;
            dr["Pass"] = cmbPass.Text;
            dr["DB"] = cmbDB.Text;
            dt.Rows.InsertAt(dr, 0);

            string[] columns = { "Server", "UID", "Pass", "DB"};
            dt = SelectTopFrom(dt, columns,5);

            ds.Tables.Clear();
            ds.Tables.Add(dt);

            ds.WriteXml("ds.xml");
            frmExcelWrite xls = new frmExcelWrite();
            xls.ShowDialog();
        }

        private void cmbUID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
