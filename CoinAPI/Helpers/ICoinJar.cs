using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoinData;


namespace CoinAPI.Helpers
{
    public interface ICoinJar
    {
        void AddCoin(ICoin coin);
        decimal GetTotalAmount();
        void Reset();
    }
}