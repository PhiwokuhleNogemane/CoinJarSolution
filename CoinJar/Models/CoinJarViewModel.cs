using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoinJar.Models
{
    public class CoinJarViewModel
    {
        public int Coin { get; set; }
        public decimal TotalAmount { get; set; }
        public  decimal TotalVolume { get; set; }

        public string OutputMessage { get; set; }

      
    }
}