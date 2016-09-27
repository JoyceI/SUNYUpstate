using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            OracleConnection conn =
                new OracleConnection("Data Source=XE;User Id=hr;Password=oracle;");
            conn.Open();
            OracleCommand cmd =
                new OracleCommand("Select * from Employees", conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("{0} {1} : {2} ",
                    dr["First_Name"],
                    dr["Last_Name"],
                    dr["Email"]
                    );
            }
            conn.Close();

        }
    }
}
