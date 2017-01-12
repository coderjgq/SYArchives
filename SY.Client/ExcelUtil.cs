using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.OleDb;
using System.Reflection;
using System.Windows.Forms;

namespace SY.Client
{
    /// <summary>
    /// 有两个文件合成，读取EXCEL、输出EXCEL模块
    /// </summary>
    class ExcelUtil
    {
        //**************************************读取EXCEL模块****************************************

        public DataTable table;

        public void load(string path)
        {
            DataSet ds = ExcelToDS(path);
            table = ds.Tables[0];
        }

        public List<string> getShortNameFromExcel()
        {
            DataRow first = table.Rows[0];
            List<string> ret = new List<string>();
            
            for (int j = 0; j < first.ItemArray.Length; j++)
            {
                Console.WriteLine("excel shortName = " + first[j]);
                ret.Add(first[j].ToString());
            }
           
            return ret;
        }

        public DataSet ExcelToDS(string Path)
        {
            //HDR=YES表示把第一行作为字段，不会读取出来
            String strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Path + ";" + ";Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1\"";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            if (myCommand != null)
                myCommand.Dispose();
            return ds;
        }

        //**************************************输出EXCEL模块****************************************
        Microsoft.Office.Interop.Excel.Application app;
        Microsoft.Office.Interop.Excel.Workbooks workbooks;
        Microsoft.Office.Interop.Excel._Workbook workbook;
        Microsoft.Office.Interop.Excel.Sheets sheets;
        Microsoft.Office.Interop.Excel._Worksheet worksheet;
        String modelPath = System.Environment.CurrentDirectory + "\\报表模板.xlsx";

        public ExcelUtil()
        {
            //init(modelPath);            
        }

        public void write(int row, int column, String message)
        {
            if (worksheet != null)
            {
                worksheet.Cells[row, column] = message;
            }
            else
            {
                Console.WriteLine("worksheet没有初始化");
            }
        }

        public void save(String savePath)
        {
            worksheet.Columns.AutoFit(); //自动调整列宽。
            workbook.SaveAs(savePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
        }

        public void close()
        {
            NAR(worksheet);
            NAR(sheets);
            NAR(workbook);
            NAR(workbooks);
            app.Quit();
            NAR(app);
        }

        private void NAR(object o)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            }
            catch
            { }
            finally
            {
                o = null;
            }
        }

        public void init(String path)
        {
            app = new Microsoft.Office.Interop.Excel.Application();
            if (app == null)
            {
                MessageBox.Show("服务器上缺少Excel组件，需要安装Office软件。");
                return;
            }
            app.Visible = false;
            app.UserControl = true;
            workbooks = app.Workbooks;
            workbook = workbooks.Add(path); //加载模板
            sheets = workbook.Sheets;
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)sheets.get_Item(1); //第一个工作薄。

            if (worksheet == null)
            {
                MessageBox.Show("工作薄中没有工作表!");
                return;  //工作薄中没有工作表.
            }
        }

        public void init()
        {
            init(modelPath);
        }
    }
}
