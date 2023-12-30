using Strategy.Strategy;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class CheckOutWithGoogle : ICheckOut
    {
        public string PayWith(double price)
        {
            return "pay with goole ok";
        }
    }
}
