using BusinessLayer.DTOs;

namespace BusinessLayer.StrategyPattern
{
    public class FIFOStrategy : ISharesSaleCalculationStrategy
    {
        public SaleSharesCalculationDTO SaleSharesCalculations(List<LotDTO> lots, SaleSharesDTO saleSharesCalculationDTO)
        {
            //It can be in another place, for example in the repository;
            //The data is already hard-coded sorted, but sorting and filtering are necessary to calculate by FIFO strategy
            FilterAndSortLots(lots, saleSharesCalculationDTO);
            int remainingSharesCount = CalculateCountOfRemainingShares(lots, saleSharesCalculationDTO.SharesCount);
            decimal costBasisPerShareSold = CalculateCostBasisPerShareSold(lots, saleSharesCalculationDTO.SharesCount);
            decimal costBasisPerShareRemaining = CalculateCostBasisPerShareRemaining(lots, remainingSharesCount);
            decimal totalProfitOrLoss = CalculateProfitOrLoss(costBasisPerShareSold, saleSharesCalculationDTO);

            return new SaleSharesCalculationDTO(
                remainingSharesCount, 
                costBasisPerShareSold, 
                costBasisPerShareRemaining, 
                totalProfitOrLoss);
        }

        private static List<LotDTO> FilterAndSortLots(List<LotDTO> lots, SaleSharesDTO saleSharesCalculationDTO) 
            => lots
                .Where(l => l.PurchaseDate < saleSharesCalculationDTO.PurchaseDate)
                .OrderBy(l => l.PurchaseDate)
                .ToList();

        private static int CalculateCountOfRemainingShares(List<LotDTO> lots, int soldSharesCount)
        {
            int remainingSharesCount = lots.Sum(l => l.SharesCount) - soldSharesCount;
            if (remainingSharesCount < 0)
            {
                throw new Exception("You can't sell more shares than you own");
            }

            return remainingSharesCount;
        }

        private static decimal CalculateCostBasisPerShareSold(List<LotDTO> lots, int soldSharesCount)
        {
            return CalculateCostPerShare(lots, soldSharesCount);
        }

        private static decimal CalculateCostBasisPerShareRemaining(List<LotDTO> lots, int remainingSharesCount)
        {
            return CalculateCostPerShare(Enumerable.Reverse(lots), remainingSharesCount);
        }

        private static decimal CalculateCostPerShare(IEnumerable<LotDTO> lots, int sharesCount)
        {
            int numberOfShares = sharesCount;
            decimal totalSharesValue = 0;
            foreach (var lot in lots)
            {
                int sharesFromLot = Math.Min(lot.SharesCount, numberOfShares);
                totalSharesValue += sharesFromLot * lot.PricePerShare;
                numberOfShares -= sharesFromLot;

                if (numberOfShares <= 0)
                {
                    break;
                }
            }
            if (sharesCount == 0)
            {
                return 0;
            }
            return totalSharesValue / sharesCount;
        }

        private static decimal CalculateProfitOrLoss(decimal costBasisPerShareSold, SaleSharesDTO saleSharesCalculationDTO)
        {
            return (saleSharesCalculationDTO.PricePerShare - costBasisPerShareSold) * saleSharesCalculationDTO.SharesCount;
        }
    }
}
