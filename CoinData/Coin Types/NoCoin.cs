﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinData
{
    public class NoCoin : ICoin
    {
        public decimal Amount { get ; set ; }
        public decimal Volume { get ; set ; }
    }
}
