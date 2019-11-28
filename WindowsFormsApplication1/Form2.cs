using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Set the processing mode for the ReportViewer to Local  
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer1.LocalReport;

            localReport.ReportPath = "Report1.rdlc";

            // Create a report data source for the sales order data  
            ReportDataSource myReportDS = new ReportDataSource();
            myReportDS.Name = "DataSource1";
            //myReportDS.Value = Engine.getDataTable("SELECT ZoneCode, ZoneName, RegionCode, RegionName, BranchCode, BranchName FROM QRYBRANCH");
            myReportDS.Value = Engine.getDataTable("SELECT * FROM QRYBRANCH");
            localReport.DataSources.Add(myReportDS);
            
            // Refresh the report  
            reportViewer1.RefreshReport();

            int DeleteTopNRows = 1;
            string[] lines = System.IO.File.ReadAllLines("");
            lines = lines.Skip(DeleteTopNRows).ToArray();
        }
    }
}
