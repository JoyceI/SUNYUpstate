using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory("Oracle.ManagedDataAccess.Client");

            using (DbConnection conn = factory.CreateConnection())
            {
                conn.ConnectionString = "user id=hr;password=oracle;Data Source=xe";
                OracleCommand cmd =(OracleCommand) factory.CreateCommand();
                cmd.Connection = (OracleConnection) conn;
                cmd.CommandText = "Select * from HR.VW_EMPSAL";
                conn.Open();
               // cmd.ExecuteToStream(File.OpenWrite(@"C:\Lab\Emp.txt"))
                OracleDataReader dr = cmd.ExecuteReader();
                StreamWriter sw = new StreamWriter(@"C:\Lab\Emp.txt");
                while (dr.Read())
                {
                    sw.WriteLine("{0},{1},{2},{3},{4},{5}",
                        dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]
                        );
                }
                sw.Flush();
            }


        }
    }
}
