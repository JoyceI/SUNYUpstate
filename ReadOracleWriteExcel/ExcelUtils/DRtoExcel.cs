using OfficeOpenXml;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelUtils
{
    public class DRtoExcel
    {
        public string ReportName { get; set; }
        private FileInfo newFile;
        public DRtoExcel(string fileName)
        {
            if (File.Exists(fileName)) File.Delete(fileName);
            newFile = new FileInfo(fileName);
            
        }
        /// <summary>
        /// returns the fully qualified file name to the excel file.
        /// </summary>
        /// <param name="dr">please pass in a data reader object</param>
        /// <returns></returns>
        public string WriteDR(DbDataReader dr)
        {
            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("Employee");
                if (worksheet != null)
                {
                    const int startRow = 5;
                    int row = startRow;
                    worksheet.Cells["A1"].Value = ReportName;
                    for (int i = 0; i < dr.VisibleFieldCount; i++)
                    {
                        string cell = ((char)(65+i)).ToString()+"4";
                        worksheet.Cells[cell].Value = dr.GetName(i);
                    }

                    while (dr.Read())
                    {
                        int col = 1;
                        for (int i = 0; i < dr.VisibleFieldCount; i++)
                        {
                            if (dr.GetValue(i) != null)
                                worksheet.Cells[row, col].Value = dr.GetValue(i);
                            col++;
                        }
                        row++;
                    }
                    dr.Close();
                }
                xlPackage.Workbook.Properties.Title = "Title";
                xlPackage.Workbook.Properties.Author = "AuthorName";
                xlPackage.Workbook.Properties.Subject = "Some Subjects";
                xlPackage.Workbook.Properties.Keywords = "Keyword for search";
                xlPackage.Workbook.Properties.Category = "SUNY Samples";
                xlPackage.Workbook.Properties.Comments = "This sample demonstrates how to create an Excel 2007 file from data reader";

                xlPackage.Save();

            }
            return newFile.FullName;
        }

        public string WriteDR(DbConnection conn, string query)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = query;
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return WriteDR(cmd.ExecuteReader());
        }
    }
}
