﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOracleWriteExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            //step one go nuget odp.net,epplus
            string connstr = 
                "data source=localhost:1521/xe;user id={0};password={1}";
            Console.WriteLine("Oracle Username?");
            string userName = Console.ReadLine();
            Console.WriteLine("Oracle Password?");
            string password = Console.ReadLine();
            connstr=string.Format(connstr, userName, password);
            //Create OracleConnection
            using (OracleConnection conn = new OracleConnection(connstr))
            { 
                StringBuilder sb = new StringBuilder();
           sb.Append("Select /*+ USE_NL (A B) RESULT_CACHE */ A.First_Name,A.Last_Name,B.Department_Name ");
           sb.AppendLine("From Employees A join Departments B ");
           sb.AppendLine("on A.Department_ID =B.Department_ID");

           OracleCommand cmd = new OracleCommand(sb.ToString(), conn);
           conn.Open();
           OracleDataReader dr = cmd.ExecuteReader();
           StreamWriter sw = new StreamWriter(@"C:\Lab\Temp.csv");
           StreamWriter sw2 = new StreamWriter(@"C:\Lab\FixedWidth.csv");
           string header = string.Format("{0,30}{1,30}{2,30}", dr.GetName(0),
              dr.GetName(1),
              dr.GetName(2));
           sw2.WriteLine(header);
           while (dr.Read())
           {
               for (int i = 0; i < dr.VisibleFieldCount; i++)
               {
                   Console.Write(dr.GetName(i) + ":" + dr[i]);
                   Console.Write((i == dr.VisibleFieldCount-1) ? "\n" :",");
                   sw.Write(dr.GetName(i) + ":" + dr[i]);
                   sw.Write((i == dr.VisibleFieldCount - 1) ? "\r\n" : ",");
               }
               sw2.WriteLine(string.Format("{0,30}{1,30}{2,30}", dr[0],
              dr[1],
              dr[2]));
           }
           sw.Close();
           sw2.Close();
           dr = cmd.ExecuteReader();
           DRtoExcel writer = new DRtoExcel(@"C:\Lab\Sample.xlsx");
           string filename = writer.WriteDR(dr);
           Console.WriteLine(filename + " written");
//refactor the following 3 reports into method(s) in DRtoExcel
           //string regionQuery = "Select * from hr.regions";
           //var regionCmd = new OracleCommand(regionQuery, conn);
           //DRtoExcel regionReport = new DRtoExcel(@"C:\Lab\Region.xlsx");
           //regionReport.WriteDR(regionCmd.ExecuteReader());
          
           //string deptQuery = "Select * from hr.departments";
           //var deptCmd = new OracleCommand(deptQuery, conn);
           //DRtoExcel deptReport = new DRtoExcel(@"C:\Lab\Department.xlsx");
           //deptReport.WriteDR(deptCmd.ExecuteReader());

           //string employeeQuery = "Select * from hr.employees";
           //var empCmd = new OracleCommand(employeeQuery, conn);
           //DRtoExcel empReport = new DRtoExcel(@"C:\Lab\emp.xlsx");
           //empReport.WriteDR(empCmd.ExecuteReader());
           DRtoExcel regionWriter = new DRtoExcel(@"C:\Lab\Region.xlsx");
           regionWriter.ReportName = "Emp Region Report";
           regionWriter.WriteDR(conn, "Select * from hr.regions");

           DRtoExcel JobWriter = new DRtoExcel(@"C:\Lab\Jobs.xlsx");
           JobWriter.ReportName = "Jobs Report";
           JobWriter.WriteDR(conn, "Select job_title as \"Title\" from Hr.Jobs");
            
            }
            
        }
    }

}
