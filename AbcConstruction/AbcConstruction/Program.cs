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

            var q = from w in houseWindows.AsQueryable<Window>()
                    where w.Width >= 70
                    orderby w
                    select w;
            foreach (var item in q.Take(1))
            {
                Console.WriteLine(item.Height);
            }


            
            foreach (var item in houseWindows)
            {
                int z = 100;
                item.OnBroken += (x, y) => 
                    Console.WriteLine("Are you kidding for parts:{0} {1:c}??!! {2}",x,y,z);

                item.OnBroken += (x, y) =>
                 Console.WriteLine("Thats cheap parts:{0} {1:c}??!! {2}", x, y, z);
            
                // here is some changes
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
