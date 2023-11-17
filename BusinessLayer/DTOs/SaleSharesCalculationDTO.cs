using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class SaleSharesCalculationDTO
    {
        public int RemainingSharesCount { get; set; }
        public decimal CostBasisPerShareSold { get; set; }
        public decimal CostBasisPerShareRemaining { get; set; }
        public decimal TotalProfitOrLoss { get; set; }

        public SaleSharesCalculationDTO(
            int remainingSharesCount,
            decimal costBasisPerShareSold,
            decimal costBasisPerShareRemaining,
            decimal totalProfitOrLoss)
        {
            RemainingSharesCount = remainingSharesCount;
            CostBasisPerShareSold = costBasisPerShareSold;
            CostBasisPerShareRemaining = costBasisPerShareRemaining;
            TotalProfitOrLoss = totalProfitOrLoss;
        }
    }
}
