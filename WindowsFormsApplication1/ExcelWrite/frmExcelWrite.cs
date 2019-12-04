using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmExcelWrite : Form
    {
        public frmExcelWrite()
        {
            InitializeComponent();
        }
        private static Microsoft.Office.Interop.Excel.Workbook mWorkBook;
        private static Microsoft.Office.Interop.Excel.Sheets mWorkSheets;
        private static Microsoft.Office.Interop.Excel.Worksheet mWSheet1;
        private static Microsoft.Office.Interop.Excel.Application oXL;
        //private void button1_Click(object sender, EventArgs e)
        //{
        //   string path = "File1.xls";
        //   oXL = new Microsoft.Office.Interop.Excel.Application();
        //   oXL.Visible = true;
        //   oXL.DisplayAlerts = false;
        //   mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
        //   //Get all the sheets in the workbook
        //  mWorkSheets = mWorkBook.Worksheets;
        //   //Get the allready exists sheet
        //   mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("Sheet1");
        //   Microsoft.Office.Interop.Excel.Range range= mWSheet1.UsedRange;
        //   int colCount = range.Columns.Count;
        //   int rowCount= range.Rows.Count;
        //   for (int index = 1; index < 15; index++)
        //   {
        //      mWSheet1.Cells[rowCount + index, 1] = rowCount +index;
        //      mWSheet1.Cells[rowCount + index, 2] = "New Item"+index;
        //   }
        //   mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
        //   Missing.Value, Missing.Value, Missing.Value, Missing.Value,Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
        //   Missing.Value, Missing.Value, Missing.Value,
        //   Missing.Value, Missing.Value);
        //   //mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
        //   //mWSheet1 = null;
        //   //mWorkBook = null;
        //   //oXL.Quit();
        //   //GC.WaitForPendingFinalizers();
        //   //GC.Collect();
        //   //GC.WaitForPendingFinalizers();
        //   //GC.Collect();

        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    string sql = "select 1 as RowNo,'STD' as D,sum(Balance) as E from repRWMS where Mark=0"
        //                +" union select 2 as RowNo,'NPA' as D,sum(Balance) as E from repRWMS where Mark=1"
        //                +" union select 3 as RowNo,'NF' as D,sum(Balance) as E from repRWMS where Mark=2"
        //                +" union select 4 as RowNo,'UND' as D,sum(Balance) as E from repRWMS where Mark=3";
        //    DataTable dt = Engine.getDataTable(sql);
        //    string path = @"D:\siddharth\Reports\ReportsTeam\WindowsFormsApplication1\bin\Debug\File1.xls";
        //    oXL = new Microsoft.Office.Interop.Excel.Application();
        //    oXL.Visible = true;
        //    oXL.DisplayAlerts = false;
        //    mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
        //    //Get all the sheets in the workbook
        //    mWorkSheets = mWorkBook.Worksheets;
        //    //Get the allready exists sheet
        //    mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("Sheet1");
        //    Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;
        //    int colCount = range.Columns.Count;
        //    int rowCount = range.Rows.Count;
        //    //for (int index = 1; index < 15; index++)
        //    //{
        //    //    mWSheet1.Cells[rowCount + index, 1] = rowCount + index;
        //    //    mWSheet1.Cells[rowCount + index, 2] = "New Item" + index;
        //    //}


        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        foreach (DataColumn col in dt.Columns)
        //        {
        //            int colIndex = ((int)col.ColumnName.ToUpper().ToCharArray()[0])-64;
        //            mWSheet1.Cells[dr["RowNo"], colIndex] = dr[col.ColumnName].ToString();
        //        }
        //    }
            

        //    mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
        //    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
        //    Missing.Value, Missing.Value, Missing.Value,
        //    Missing.Value, Missing.Value);
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            //string path = @"D:\siddharth\Reports\ReportsTeam\WindowsFormsApplication1\bin\Debug\File1.xls";
            //string sql = "select 1 as RowNo,'STD' as D,sum(Balance) as E from repRWMS where Mark=0"
            //            + " union select 2 as RowNo,'NPA' as D,sum(Balance) as E from repRWMS where Mark=1"
            //            + " union select 3 as RowNo,'NF' as D,sum(Balance) as E from repRWMS where Mark=2"
            //            + " union select 4 as RowNo,'UND' as D,sum(Balance) as E from repRWMS where Mark=3";

            string path = textBox1.Text;
            string sql = xCodeEditor1.Text;
            DataTable dt = Engine.getDataTable(sql);
            if (Engine.ErrorMsg != "")            
                MessageBox.Show(Engine.ErrorMsg);            
            else
            {
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = true;
                oXL.DisplayAlerts = false;
                mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                //Get all the sheets in the workbook
                mWorkSheets = mWorkBook.Worksheets;
                //Get the allready exists sheet
                mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("Sheet1");
                //Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;
                //int colCount = range.Columns.Count;
                //int rowCount = range.Rows.Count;
                //for (int index = 1; index < 15; index++)
                //{
                //    mWSheet1.Cells[rowCount + index, 1] = rowCount + index;
                //    mWSheet1.Cells[rowCount + index, 2] = "New Item" + index;
                //}


                //foreach (DataRow dr in dt.Rows)
                //{
                //    foreach (DataColumn col in dt.Columns)
                //    {
                //        if (col.ColumnName != "RowNo")
                //        {
                //            int colIndex = ((int)col.ColumnName.ToUpper().ToCharArray()[0]) - 64;
                //            mWSheet1.Cells[dr["RowNo"], colIndex] = dr[col.ColumnName].ToString();
                //        }
                //    }
                //}


                foreach (DataRow drow in dt.Rows)
                {
                    foreach (DataColumn dCol in dt.Columns)
                    {
                        if (dCol.ColumnName != "RowNo")
                        {
                            mWSheet1.Range[dCol.ColumnName + drow["RowNo"]].Value = drow[dCol.ColumnName].ToString();                            
                        }
                    }
                }


                mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.FileName;
            }
        }
    }
}
