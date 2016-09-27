using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcConstruction
{   delegate void delBrokenWindow(string partsBroken, decimal costForReplacement);
    class Window
    {
        public event delBrokenWindow OnBroken;
        public bool Refundable
        {
            get { return (this._dateMade.AddDays(30) < DateTime.Now); }
        }
        public bool InWarranty
        {
            get { return (this._dateMade.AddYears(10) < DateTime.Now); }
        }

        public decimal Width { get { return _width; } }
      
        public decimal Height { get { return _height; } }
        public Window()
        {
        }
        public Window(decimal height, decimal width)
        {
            this._height = height;
            this._width = width;
            this._dateMade = DateTime.Now;
        }

        public void Open()
        {
            Random r = new Random();
            if (r.Next(100) < 50)
            {
                Console.WriteLine("Window Broken");
                //if (OnBroken != null) { OnBroken("hinge", 50); }
                try
                {
                    OnBroken("hinge", 50);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("so sad, I'm broke inside");
                }
                
            }
            else
            { Console.WriteLine("Window Open"); }
        }
        public void Close() { }


        #region private fields
        private decimal _width;
        private decimal _height;
        private DateTime _dateMade; 
        #endregion
          
    }
}
