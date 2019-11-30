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
    public partial class Import : Form
    {
        public Import()
        {
            InitializeComponent();
        }
        private void Import_Load(object sender, EventArgs e)
        {
            cmbAction.SelectedIndex = 1;
            cmbServer.SelectedIndex = 0;
            cmbUID.SelectedIndex = 0;
            cmbDB.SelectedIndex = 0;
            cmbPass.SelectedIndex = 0;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Engine.cnstring = "data source=" + cmbServer.Text + ";user id=" + cmbUID.Text + ";password=" + cmbPass.Text + ";initial catalog=" + cmbDB.Text;
            if (cmbAction.Text == "Import")
                ImportData();
            if (cmbAction.Text == "Export")
                ExportData();
        }
        private void ImportData()
        {
            MasterRestore();
        }
        private void MasterRestore()
        {
            string cmd = "";
            DataTable masters = Engine.getDataTable("select * from sys.tables where name like '%dim%'", "masters");
            foreach (DataRow row in masters.Rows)
            {
                string file = @"D:\data\" + row["Name"].ToString() + ".txt";
                if (System.IO.File.Exists(file))
                {
                    cmd = "exec('bulk insert " + row["Name"].ToString() + " from ''D:\\data\\" + row["Name"].ToString() + ".txt'' with (fieldterminator = ''|'', rowterminator = ''\n'')')";
                    if (!Engine.ExecuteQry(cmd))
                        Engine.ErrorMsg="";
                        //MessageBox.Show(Engine.ErrorMsg);
                }
            }
        }
        private void ExportData()
        {
            MasterBackup();
        }

        private void MasterBackup()
        {
            string cmd = "";
            DataTable masters = Engine.getDataTable("select * from sys.tables where name like '%dim%'", "masters");
            foreach (DataRow row in masters.Rows)
            {
                cmd = "-U " + cmbUID.Text + " -P " + cmbPass.Text + " -S " + cmbServer.Text + " -d " + cmbDB.Text + " -Q \"set nocount on;select * from " + cmbDB.Text + ".dbo." + row["Name"].ToString() + "\" -o \"D:\\data\\" + row["Name"].ToString() + ".txt\" -s \"|\" -W";
                System.Diagnostics.Process.Start("sqlcmd", cmd);

            }

            foreach (DataRow row in masters.Rows)
            {
                string file = @"D:\data\" + row["Name"].ToString() + ".txt";
                if (System.IO.File.Exists(file))
                {
                    int DeleteTopNRows = 2;
                    string[] lines = System.IO.File.ReadAllLines(file);
                    lines = lines.Skip(DeleteTopNRows).ToArray();
                    System.IO.File.WriteAllLines(file, lines);
                }
            }

            
        }

        private void TestCode()
        {
            //string args="-U dm085 -P 1808 -S DBSERVER2\\DBSERVER2 -d DENAMISDBOCT2017 -Q \"set nocount on;select * from DENAMISDBOCT2017.dbo.DimSplCategory\" -o \"D:\\data\\DimSplCategory.txt\" -s \"|\" -W";
            string args = "-U dm085 -P 1808 -S DBSERVER2\\DBSERVER2 -d UCO_LEGAL_PLUS -Q \"set nocount on;select * from UCO_LEGAL_PLUS.dbo.DimSplCategory\" -o \"D:\\data\\DimSplCategory.txt\" -s \"|\" -W";
            System.Diagnostics.Process.Start("sqlcmd", args);


            int DeleteTopNRows = 2;
            string[] lines = System.IO.File.ReadAllLines(@"D:\data\DimSplCategory.txt");
            lines = lines.Skip(DeleteTopNRows).ToArray();
            System.IO.File.WriteAllLines(@"D:\data\DimSplCategory.txt", lines);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //int DeleteTopNRows = 2;
            //string[] lines = System.IO.File.ReadAllLines(@"D:\data\DimSplCategory.txt");
            //lines = lines.Skip(DeleteTopNRows).ToArray();
            //System.IO.File.WriteAllLines(@"D:\data\DimSplCategory.txt", lines);
            Application.Exit();
        }
    }
}
