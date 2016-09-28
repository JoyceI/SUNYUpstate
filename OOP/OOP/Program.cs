using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> y = Console.WriteLine;
            y("ABCDEFG");
           A o = new C();
           B p = o as B;
           C q = p as C;
           
           //B p = new B();
           o.Jump();
           o.Sit();
           List<C> bunchOfC = new List<C> {
                   new C { X = 10 },
                   new C { X = 5},
                   new C { X = 15 },
                   new C { X = 9 },
           };
           bunchOfC.Sort();
           foreach (var item in bunchOfC)
           {
               Console.WriteLine(item.X);
           }

           var result =bunchOfC.Where((input) => input.X > 10);
           foreach (var item in result)
           {
               item.DoSomething(Math.BigMul);
               item.DoSomething((a, b) => a + b);
               item.DoSomething((a, b) => a - b);
               item.DoSomething((a, b) => a / b);

               Console.WriteLine(item.X);
           }
        }
    }

    class A
    {
        private int _x;
        static internal int _y;
        internal int X
        {
        get { return _x;}
        set {
            if ((value > 100) || (value < 1))
            { throw new ArgumentOutOfRangeException(); }
            _x = value;
            }
        }
        internal virtual void Jump() { Console.WriteLine("How High"); }
        internal void Sit() { Console.WriteLine("Sitting Down");
        }
    }
    class B : A {
        internal override void Jump()
        {
            //base.Jump();
            Console.WriteLine("How Far");
        }
        internal void SomethingNewInB() { }
    }
    class C : B ,IComparable<C>
    {

        public int CompareTo(C other)
        {
            return this.X - other.X;
        }
        public void DoSomething(Func<int, int, long> operation)
        {
            int result = operation(10, 5);
            Console.WriteLine(result);
        }
    }
}
