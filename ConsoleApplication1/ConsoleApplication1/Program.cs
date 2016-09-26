using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator myCalculator;
            Calculator yourCalculator;
            myCalculator = new Calculator();
            decimal result = myCalculator.Add(15, 20);

            yourCalculator = myCalculator;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(result);
            Console.ReadLine();



        }
    }
}
