using ExcelUtils;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProg
{
    class Program
    {
        static int Main(string[] args)
        {   
            if(args.Length!=3)
            {
                Console.WriteLine("Sample Usage: TestProg.exe \"filename\" \"reportname\" \"query\" ");
                // TestProg.exe "c:\Lab\demo.xlsx" "My Report" "Select * from hr.employees"
                return -1;
            }
            DRtoExcel writer = new DRtoExcel(args[0]);
            using (var conn = new
                OracleConnection("Data Source=xe;user id=hr;password=oracle"))
            {
                writer.ReportName = args[1];
                writer.WriteDR(conn, args[2]);
            }
            return 0;
        }
    }
}
