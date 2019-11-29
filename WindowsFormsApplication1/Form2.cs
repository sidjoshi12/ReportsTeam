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

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer1.LocalReport;
            localReport.ReportPath = "Report1.rdlc";
            ReportDataSource myReportDS = new ReportDataSource();
            myReportDS.Name = "DataSet1";
            myReportDS.Value = Engine.getDataTable("SELECT BranchCode,BranchName,RegionCode,RegionName FROM QRYBRANCH");
            localReport.DataSources.Add(myReportDS);
            reportViewer1.RefreshReport();
        }
    }
}
