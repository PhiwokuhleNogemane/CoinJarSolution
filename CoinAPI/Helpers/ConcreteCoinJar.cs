using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoinAPI.Database;
using CoinData;


namespace CoinAPI.Helpers
{
    public class ConcreteCoinJar : ICoinJar
    {
        DatabaseContext databaseContext;

        public ConcreteCoinJar()
        {
            databaseContext = new DatabaseContext();
        }
        public void  AddCoin(ICoin coin)
        {
            databaseContext.AddCoin(coin);
        }
        public  decimal GetTotalAmount()
        {
            return databaseContext.GetTotalAmount();
        }
        public  void  Reset()
        {
            databaseContext.Reset();
        }
    }
}