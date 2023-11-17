using BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.StrategyPattern
{
    public interface ISharesSaleCalculationStrategy
    {
        SaleSharesCalculationDTO SaleSharesCalculations(List<LotDTO> lots, SaleSharesDTO saleSharesDTO);
    }
}
