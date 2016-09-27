using HRLib.HRTableAdapters;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HRLib
{
    public class HRDataAccess
    {
        private string _connStr;
        public HRDataAccess(string connStr)
        {
            this._connStr = connStr;
        }
        public HR GetFullHRDataSet()
        {
            HR ds = new HR();
          
            OracleConnection conn = new OracleConnection(_connStr);
            EMPLOYEESTableAdapter eta = new EMPLOYEESTableAdapter() 
            { Connection = conn };
            eta.Fill(ds.EMPLOYEES);
            DEPARTMENTSTableAdapter dta = new DEPARTMENTSTableAdapter() 
            { Connection = conn };
            dta.Fill(ds.DEPARTMENTS);

            LOCATIONSTableAdapter lta = new LOCATIONSTableAdapter() 
            { Connection = conn };
            lta.Fill(ds.LOCATIONS);
           
            eta.Dispose();
            dta.Dispose();
            lta.Dispose();
            return ds;

        }
    }
}
