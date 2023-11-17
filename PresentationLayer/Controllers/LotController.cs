using BusinessLayer.DTOs;
using BusinessLayer.Services.Interfaces;
using BusinessLayer.StrategyPattern.Helper;

namespace PresentationLayer.Controllers
{
    public class LotController
    {
        private readonly ILotService _service;

        public LotController(ILotService service)
        {
            _service = service;
        }

        public List<LotDTO> GetAll()
        {
            var lots = _service.GetLots();
            return lots;
        }

        public int ChangeCalculationStrategy(Strategies strategy)
        {
            _service.ChangeCalculationStrategy(strategy);

            return StatusCodes.Status200OK;
        }

        public SaleSharesCalculationDTO SaleSharesCalculations(SaleSharesDTO saleSharesDTO)
        {
            SaleSharesCalculationDTO calculation = _service.SaleSharesCalculations(saleSharesDTO);
            return calculation;
        }
    }
}
