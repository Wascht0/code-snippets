using Strategy.Strategy;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Shop
    {
        private ICheckOut _checkOut;

        public Shop(ICheckOut checkOut)
        {
            this._checkOut = checkOut;
        }

        public void ChangeCheckOut(ICheckOut check)
        {
            _checkOut = check;
        }

        public string Pay(double price)
        {
            return _checkOut.PayWith(price);
        }
    }
}
