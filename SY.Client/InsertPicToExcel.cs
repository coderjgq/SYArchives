using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SY.Client
{
    class InsertPicToExcel
    {
        private Microsoft.Office.Interop.Excel.Application m_objExcel = null;
        private Microsoft.Office.Interop.Excel.Workbooks m_objBooks = null;
        private Microsoft.Office.Interop.Excel._Workbook m_objBook = null;
        private Microsoft.Office.Interop.Excel.Sheets m_objSheets = null;
        private Microsoft.Office.Interop.Excel._Worksheet m_objSheet = null;
        private Microsoft.Office.Interop.Excel.Range m_objRange = null;
        private object m_objOpt = System.Reflection.Missing.Value;

        /// <summary>
        /// 打开没有模板的操作。
        /// </summary>
        public void Open()
        {
            this.Open();
        }

        /// <summary>
        /// 功能：实现Excel应用程序的打开
        /// </summary>
        /// <param name="TemplateFilePath">模板文件物理路径</param>
        public void Open(string TemplateFilePath)
        {
            //打开对象
            m_objExcel = new Microsoft.Office.Interop.Excel.Application();
            m_objExcel.Visible = false;
            m_objExcel.DisplayAlerts = false;

            //if (m_objExcel.Version != "11.0")
            //{
            //    MessageBox.Show("您的 Excel 版本不是 11.0 （Office 2003），操作可能会出现问题。");
            //    m_objExcel.Quit();
            //   return;
            // }

            m_objBooks = (Microsoft.Office.Interop.Excel.Workbooks)m_objExcel.Workbooks;
            if (TemplateFilePath.Equals(String.Empty))
            {
                m_objBook = (Microsoft.Office.Interop.Excel._Workbook)(m_objBooks.Add(m_objOpt));
            }
            else
            {
                m_objBook = m_objBooks.Open(TemplateFilePath, m_objOpt, m_objOpt, m_objOpt, m_objOpt,
                 m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            }
            m_objSheets = (Microsoft.Office.Interop.Excel.Sheets)m_objBook.Worksheets;
            m_objSheet = (Microsoft.Office.Interop.Excel._Worksheet)(m_objSheets.get_Item(1));
            // m_objExcel.WorkbookBeforeClose += new Microsoft.Office.Interop.Excel.AppEvents_WorkbookBeforeCloseEventHandler(m_objExcel_WorkbookBeforeClose);
        }


        /// <summary>
        /// 将图片插入到指定的单元格位置。
        /// 注意：图片必须是绝对物理路径
        /// </summary>
        /// <param name="RangeName">单元格名称，例如：B4</param>
        /// <param name="PicturePath">要插入图片的绝对路径。</param>
        public void InsertPicture(string RangeName, string PicturePath)
        {
            m_objRange = m_objSheet.get_Range(RangeName, m_objOpt);
            m_objRange.Select();
            Microsoft.Office.Interop.Excel.Pictures pics = (Microsoft.Office.Interop.Excel.Pictures)m_objSheet.Pictures(m_objOpt);
            pics.Insert(PicturePath, m_objOpt);
        }

        /// <summary>
        /// 将Excel文件保存到指定的目录，目录必须事先存在，文件名称不一定要存在。
        /// </summary>
        /// <param name="OutputFilePath">要保存成的文件的全路径。</param>
        public void SaveFile(string OutputFilePath)
        {
            m_objBook.SaveAs(OutputFilePath, m_objOpt, m_objOpt,
              m_objOpt, m_objOpt, m_objOpt, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
              m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);

            this.Close();
        }

        /// <summary>
        /// 关闭应用程序
        /// </summary>
        private void Close()
        {
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objExcel.Quit();
        }

        /// <summary>
        /// 释放所引用的COM对象。注意：这个过程一定要执行。
        /// </summary>
        public void Dispose()
        {
            ReleaseObj(m_objSheets);
            ReleaseObj(m_objBook);
            ReleaseObj(m_objBooks);
            ReleaseObj(m_objExcel);
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// 释放对象，内部调用
        /// </summary>
        /// <param name="o"></param>
        private void ReleaseObj(object o)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            }
            catch { }
            finally { o = null; }
        }


    }
}
