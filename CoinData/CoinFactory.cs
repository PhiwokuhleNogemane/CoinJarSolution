using CoinData.Coin_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinData
{
    public class CoinFactory
    {
        public ICoin GetCoin(int coinTypeId)
        {
            ICoin coin;

            switch (coinTypeId)
            {
                case 1:
                    coin = new Nickle();
                    break;
                case 5:
                    coin = new Penny();
                    break;
                case 10:
                    coin = new Qaurter();
                    break;
                case 25:
                    coin = new Dime();
                    break;
                default:
                    coin =  new NoCoin();
                    break;
            }
            return coin;
        }
    }
}