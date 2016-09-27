using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcConstruction
{
    class Window
    {
        public decimal Width { get { return _width; } }
        private decimal _width;
        public decimal Height { get { return _height; } }
        private decimal _height;
        private DateTime _dateMade;
        public Window()
        {
        }
        public Window(decimal height, decimal width)
        {
            this._height = height;
            this._width = width;
        }

    }
}
