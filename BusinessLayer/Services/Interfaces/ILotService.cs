using BusinessLayer.DTOs;
using BusinessLayer.StrategyPattern;
using BusinessLayer.StrategyPattern.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface ILotService
    {
        SaleSharesCalculationDTO SaleSharesCalculations(SaleSharesDTO saleSharesDTO);

        List<LotDTO> GetLots();

        void ChangeCalculationStrategy(Strategies strategy);
    }
}
