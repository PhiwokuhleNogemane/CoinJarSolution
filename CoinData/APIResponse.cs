using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoinData
{
    public class APIResponse
    {
        public bool IsSuccess { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalVolume { get; set; }

        public string ResponseMesage { get; set; }

    }
}