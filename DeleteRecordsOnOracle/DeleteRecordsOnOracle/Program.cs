using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteRecordsOnOracle
{
    class Program
    {
        static void Main(string[] args)
        {
            OracleConnection conn = new OracleConnection("Data Source=xe;user id=hr;password=oracle");
            
            var cmd = conn.CreateCommand();
            cmd.CommandText="Delete from Job_History";
            conn.Open();
            int numOfRowsDeleted = cmd.ExecuteNonQuery();
            conn.Close();
            

        }
    }
}
