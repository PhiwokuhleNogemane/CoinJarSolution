using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinData.Coin_Types
{
    public class Nickle :  ICoin
    {
        public decimal Amount { get ; set; }
        public decimal Volume { get ; set; }

        public Nickle()
        {
            Amount = 0.01m;
            Volume = 0.807m;
        }
    }
}
