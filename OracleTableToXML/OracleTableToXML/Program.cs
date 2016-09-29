using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OracleTableToXML
{
    class Program
    {
        static void Main(string[] args)
        {
        OracleConnection conn = new 
        OracleConnection("Data Source=localhost:1521//xe;user id=hr;password=oracle");
        var cmd = conn.CreateCommand();
        cmd.CommandText = "Select * from hr.Employees";
        
        OracleDataAdapter da = new OracleDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ds.DataSetName = "Employee_Data";
        ds.Tables[0].TableName = "Employees";

        ds.WriteXml(@"C:\Lab\employees.xml");
        ds.WriteXmlSchema(@"C:\Lab\employees.xsd");
        XElement element = XElement.Load(@"C:\Lab\employees.xml");
        var employees = element.Elements();
        //foreach (var someOne in employees)
        //{
        //    Console.WriteLine(someOne.Element("FIRST_NAME").Value);
        //    Console.WriteLine(someOne.Element("LAST_NAME").Value);
        //    Console.WriteLine("-----------------------------");
        //}

        var names = from aName in element.Elements("Employees")
                    where aName.Element("FIRST_NAME").Value.StartsWith("B")
                    select new {   FNAME = aName.Element("FIRST_NAME").Value,
                                   LNAME = aName.Element("LAST_NAME").Value };
        foreach (var item in names)
        {
            Console.WriteLine("{0},{1}",item.FNAME,item.LNAME);
        }

        }
    }
}
