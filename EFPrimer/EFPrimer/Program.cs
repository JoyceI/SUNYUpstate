using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPrimer
{

    class Rec
    {
        public string A { get; set; }
        public string B { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HR db = new HR();
            db.Database.Log = s => {
                Console.WriteLine(s);
                //File.AppendText("log.txt").WriteLine(s);
            };
            //
            //
            //Sales
            //    bob,tom,John
            //Admin
            //    David, Jay, ....
            var result = db.Database.SqlQuery<Rec>(
                "select d.department_name as A, listagg(e.first_name,',') WITHIN GROUP (ORDER BY first_name) as B from departments d join employees e using (department_ID) Group by Department_Name"
                );
            foreach (var item in result.ToList())
            {
                Console.WriteLine(item.A);
                Console.WriteLine(item.B);
                Console.WriteLine("---------------");
            }
            Console.WriteLine("==========EOF 1=Press Enter =========");
            Console.ReadLine();

            var q = from d in db.DEPARTMENTS.Include("EMPLOYEES")
                    where (d.EMPLOYEES.Count>0)
                    select d;
                    
            foreach (var item in q.ToList())
            {

                Console.WriteLine(item.DEPARTMENT_NAME);
                Console.WriteLine(string.Join(",",item.EMPLOYEES.Select(e=>e.FIRST_NAME)));
                Console.WriteLine("---------------");
            }
            
            Console.WriteLine("==== EOF 2====Press Enter==================");
            
            
            Console.ReadLine();
            var q3 = from d in db.DEPARTMENTS.Include("EMPLOYEES")
                     where (d.EMPLOYEES.Count > 0)
                     group d by d.DEPARTMENT_NAME into g
                     select new { A = g.Key, B= g.Select(d=>d.EMPLOYEES.Select(e=>e.FIRST_NAME))};
            foreach (var item in q3.ToList())
            {
                Console.WriteLine(item.A);
                Console.WriteLine(string.Join(",",item.B.ElementAt(0)));
                Console.WriteLine("---------------");
            }
            Console.WriteLine("==========EOF 3=Press Enter =========");
            Console.ReadLine();

                     


            //foreach (var emp in db.EMPLOYEES.Include("DEPARTMENT").Where(e=>e.FIRST_NAME.StartsWith("A")).ToList().Take(3))
            //{   Console.WriteLine(emp.FIRST_NAME);
            //    Console.WriteLine(emp.DEPARTMENT.DEPARTMENT_NAME);
            //    //emp.FIRST_NAME = emp.FIRST_NAME+ "-Lah";
            //}

            //db.SaveChanges();
        }
    }
}
