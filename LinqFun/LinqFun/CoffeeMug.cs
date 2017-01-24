using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFun
{
    class CoffeeMug
    {
        public float Volume { get; set; }
        public string Content { get; set; }
        public Purpose Purpose{ get; set; }
        public string Owner { get; private set; }
        public CoffeeMug(string owner)
        {
            this.Owner = owner;
        }
        public override string ToString()
        {
            string purpose;
            switch (this.Purpose)
            {
                case Purpose.HotBeverage:
                    purpose = "hot beverage";
                    break;
                case Purpose.ColdBeverage:
                    purpose = "cold beverage";
                    break;
                case Purpose.AllPurpose:
                    purpose = "any kind of beverage";
                    break;
                default:
                    purpose = "unknown beverage";
                    break;
            }

            return
                string.Format("One is a {0} mug, one serves {1}. one is holding {2} oz of {3}.",
                purpose, Owner, Volume, Content);
                     
        }

    }
    enum Purpose
    {   HotBeverage,
        ColdBeverage,
        AllPurpose
    }

}
