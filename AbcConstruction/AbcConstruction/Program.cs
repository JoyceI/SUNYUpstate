using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcConstruction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Window front = new Window(70, 25);
            //Window back = new Window(90, 25);
            //Window side = new Window(50, 25);
            //Window[] houseWindows = { front, back, side };
            Window[] houseWindows = {   new Window(70, 25), 
                                        new Window(90, 25), 
                                        new Window(50, 25) };
            foreach (var item in houseWindows)
            {
                item.OnBroken += (x, y) => 
                    Console.WriteLine("Are you kidding for parts:{0} {1:c}??!!",x,y);
              
            }

            for (int i = 0; i < 200; i++)
            {
                foreach (var item in houseWindows)
                {
                    item.Open();
                    item.Close();
                }
            }
            


        }

      
    }
}
