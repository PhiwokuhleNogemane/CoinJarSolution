using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinData.Coin_Types
{
    public class Penny: ICoin
    {
        public decimal Amount { get ; set; }
        public decimal Volume { get ; set; }

        public Penny()
        {
            Amount = 0.5m;
            Volume = 0.75m;

        }
    }
}
