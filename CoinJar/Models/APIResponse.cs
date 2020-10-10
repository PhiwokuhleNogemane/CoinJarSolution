using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoinJar.Models
{
    public class APIResponse
    {
        public bool IsSuccess { get; set; }
        public decimal Amount { get; set; }
        public string ResponseMesage { get; set; }
    }
}