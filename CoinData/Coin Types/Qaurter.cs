using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinData.Coin_Types
{
    public class Qaurter : ICoin
    {
        public decimal Amount { get ; set; }
        public decimal Volume { get ; set; }

        public Qaurter()
        {
            Amount = 0.10m;
            Volume = 0.955m;
        }
    }
}
