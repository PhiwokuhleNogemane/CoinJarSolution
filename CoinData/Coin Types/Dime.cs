using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinData.Coin_Types
{
    public class Dime : ICoin
    {
        public decimal Amount { get ; set ; }
        public decimal Volume { get ; set ; }

        public Dime()
        {
            Amount = 0.25m;
            Volume = 0.705m;

        }
    }
}
