using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFun
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringColDemo();

            //NumColDemo();

            //DirDemo();

            List<CoffeeMug> SBuxShelf = new List<CoffeeMug>() { 
            new CoffeeMug("Iain") { Purpose=Purpose.AllPurpose, Content="Water",Volume=32.6f},
            new CoffeeMug("William") {Purpose=Purpose.AllPurpose, Content="Moonshine",Volume=28.4f},
            new CoffeeMug("Jordan") {Purpose=Purpose.ColdBeverage, Content="Water",Volume=42.8f},
            new CoffeeMug("Jason") {Purpose=Purpose.ColdBeverage, Content="VitaminWater",Volume=53.7f}
            };
            foreach (CoffeeMug mug in SBuxShelf.Where(m=> m.Volume>30.0f))
            {
                
                Console.WriteLine(mug.Owner);
                Console.WriteLine(mug);
            }


        }

        private static void DirDemo()
        {
            DirectoryInfo c = new DirectoryInfo(@"C:\Lab\");


            var q2 = from d in c.GetDirectories()
                     where d.GetFiles().Count() > 2
                     select new
                     {
                         Name = d.FullName,
                         LAT = d.LastAccessTime.ToShortDateString(),
                         FileCount = d.GetFiles().Count(),
                         LWT = d.LastWriteTime.ToShortDateString()
                     };

            Console.WriteLine("{0,-45}:{1,-15}:{2,-5}:{3,-10}",
        "Directory Name", "AccessedTime", "File#", "WriteTime");

            foreach (var item in q2)
            {
                Console.WriteLine("{0,-45}:{1,-15}:{2,-5}:{3,-10}",
                    item.Name,
                    item.LAT,
                    item.FileCount,
                    item.LWT
                    );
            }
        }

        private static void NumColDemo()
        {
            int[] randomNumbers = { 16, 98, 23, 54, 23, 66, 90, 12, 13, 57, 48 };
            foreach (var item in randomNumbers.Where(i => (i % 2 == 0)))
            {
                Console.WriteLine(item);
            }

            var q = from i in randomNumbers
                    where i % 2 == 0
                    select i;
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
        }

        private static void StringColDemo()
        {
            string[] names = { "Shannon", "William", "Jason", "Barb", "Iain", "Teresa", "Mary", "Billie Jo", "Jordan", "Michelle" };

            foreach (string result in names.Where(s => s[0] < 'M').OrderBy(s => s.Length).Select(s => s.Substring(0, 2))
                )
            {
                Console.WriteLine(result);
            }
        }
    }
}
