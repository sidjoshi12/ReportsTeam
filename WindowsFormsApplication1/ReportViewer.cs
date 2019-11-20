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
    public partial class ReportViewer : Form
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {

            // Set the processing mode for the ReportViewer to Local  
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            LocalReport localReport = reportViewer1.LocalReport;

            localReport.ReportPath = "TableReport.rdlc";

            // Create a report data source for the sales order data  
            ReportDataSource myReportDS = new ReportDataSource();
            myReportDS.Name = "DataSource1";
            myReportDS.Value = "Data Source=D2K62\\SQLEXPRESS;Initial Catalog=OVSepPOST";

            //myReportDS.Value = Engine.getDataTable("SELECT ZoneCode, ZoneName, RegionCode, RegionName, BranchCode, BranchName FROM QRYBRANCH");

            localReport.DataSources.Add(myReportDS);

            // Create a report parameter for the sales order number   
            //ReportParameter rpSalesOrderNumber = new ReportParameter();
            //rpSalesOrderNumber.Name = "SalesOrderNumber";
            //rpSalesOrderNumber.Values.Add("SO43661");

            // Set the report parameters for the report  
            //localReport.SetParameters(
            //    new ReportParameter[] { rpSalesOrderNumber });

            // Refresh the report  
            reportViewer1.RefreshReport();  
        }
    }
}
