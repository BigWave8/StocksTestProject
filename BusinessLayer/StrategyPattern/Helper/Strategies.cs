using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.StrategyPattern.Helper
{
    public enum Strategies
    {
        FIFO,
        LIFO,
        AverageCost,
        LowestTaxExposure,
        HighestTaxExposure,
        LotBased
    }
}
