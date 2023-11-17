using AutoMapper;
using BusinessLayer.DTOs;
using BusinessLayer.Services.Interfaces;
using BusinessLayer.StrategyPattern;
using BusinessLayer.StrategyPattern.Helper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using FluentValidation;
using FluentValidation.Results;

namespace BusinessLayer.Services
{
    public class LotService : ILotService
    {
        private readonly IRepository<Lot> _repository;
        private readonly IValidator<SaleSharesDTO> _validator;
        private ISharesSaleCalculationStrategy _strategy;

        public LotService(IRepository<Lot> repository, IValidator<SaleSharesDTO> validator) 
        {
            _repository = repository;
            _validator = validator;
            DefaultStrategy();
        }

        public SaleSharesCalculationDTO SaleSharesCalculations(SaleSharesDTO saleSharesDTO)
        {
            ValidationResult validationResult = _validator.Validate(saleSharesDTO);
            if (validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            List<LotDTO> lots = GetLots();
            return _strategy.SaleSharesCalculations(lots, saleSharesDTO);
        }

        public List<LotDTO> GetLots()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Lot, LotDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Lot>, List<LotDTO>>(_repository.GetAll());
        }

        public void ChangeCalculationStrategy(Strategies strategy)
        {
            switch (strategy)
            {
                case Strategies.FIFO:
                    SetCalculationStrategy(new FIFOStrategy());
                    break;
                case Strategies.LIFO:
                    break;
                case Strategies.AverageCost:
                    break;
                case Strategies.LowestTaxExposure:
                    break;
                case Strategies.HighestTaxExposure:
                    break;
                case Strategies.LotBased:
                    break;
                default:
                    DefaultStrategy();
                    break;
            }
        }

        private void DefaultStrategy()
        {
            SetCalculationStrategy(new FIFOStrategy());
        }

        private void SetCalculationStrategy(ISharesSaleCalculationStrategy strategy)
        {
            _strategy = strategy;
        }
    }
}
