using BusinessLayer.DTOs;
using BusinessLayer.StrategyPattern;
using BusinessLayer.Validators;
using DataAccessLayer.Models;
using FluentAssertions;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.BusinessLayer.UnitTests.Strategy
{
    [TestFixture]
    internal class FIFOStrategyTest
    {
        private const int ValidSharesCount = 100;
        private const decimal ValidPricePerShare = 20;
        private ISharesSaleCalculationStrategy _strategy;

        [SetUp]
        public void SetUp()
        {
            _strategy = new FIFOStrategy();
        }

        [TestCase(150, 150)]
        [TestCase(150, 150)]
        [TestCase(100, 200)]
        [TestCase(200, 100)]
        [TestCase(300, 0)]
        public void CalculateCountOfRemainingShares_SeedData1AndValidInput_ExpectedResult(
            int sharesCount,
            int countOfRemainingShares)
        {
            SaleSharesDTO saleSharesDTO = new()
            {
                SharesCount = sharesCount,
                PricePerShare = ValidPricePerShare
            };

            var result = _strategy.SaleSharesCalculations(SeedData1(), saleSharesDTO);

            result.RemainingSharesCount.Should().Be(countOfRemainingShares);
        }

        [TestCase(1, 369)]
        [TestCase(100, 270)]
        [TestCase(250, 120)]
        [TestCase(370, 0)]
        [TestCase(150, 220)]
        public void CalculateCountOfRemainingShares_SeedData2AndValidInput_ExpectedResult(
            int sharesCount,
            int countOfRemainingShares)
        {
            SaleSharesDTO saleSharesDTO = new()
            {
                SharesCount = sharesCount,
                PricePerShare = ValidPricePerShare
            };

            var result = _strategy.SaleSharesCalculations(SeedData2(), saleSharesDTO);

            result.RemainingSharesCount.Should().Be(countOfRemainingShares);
        }

        [TestCase(0, 0)]
        [TestCase(10, 20)]
        [TestCase(100, 20)]
        [TestCase(150, 23.33)]
        [TestCase(200, 25)]
        [TestCase(300, 26.66)]
        public void CalculateCostBasisPerShareSold_SeedData1AndValidInput_ExpectedResult(
            int sharesCount,
            decimal costBasisPerShareSold)
        {
            SaleSharesDTO saleSharesDTO = new()
            {
                SharesCount = sharesCount,
                PricePerShare = ValidPricePerShare
            };

            var result = _strategy.SaleSharesCalculations(SeedData1(), saleSharesDTO);

            result.CostBasisPerShareSold.Should().BeApproximately(costBasisPerShareSold, 0.01m);
        }

        [TestCase(300, 0)]
        [TestCase(100, 30)]
        [TestCase(200, 30)]
        [TestCase(50, 28)]
        [TestCase(10, 26.89)]
        [TestCase(150, 30)]
        public void CalculateCostBasisPerShareRemaining_SeedData1AndValidInput_ExpectedResult(
            int sharesCount,
            decimal costBasisPerShareRemaining)
        {
            SaleSharesDTO saleSharesDTO = new()
            {
                SharesCount = sharesCount,
                PricePerShare = ValidPricePerShare
            };

            var result = _strategy.SaleSharesCalculations(SeedData1(), saleSharesDTO);

            result.CostBasisPerShareRemaining.Should().BeApproximately(costBasisPerShareRemaining, 0.01m);
        }

        [TestCase(1, 120, 100)]
        [TestCase(300, 10, -5000)]
        [TestCase(100, 20, 0)]
        [TestCase(200, 25, 0)]
        [TestCase(100, 30, 1000)]
        [TestCase(200, 30, 1000)]
        [TestCase(150, 40, 2500)]
        [TestCase(200, 40, 3000)]
        public void CalculateProfitOrLoss_SeedData1AndValidInput_ExpectedResult(
            int sharesCount,
            decimal pricePerShare,
            decimal totalProfitOrLoss)
        {
            SaleSharesDTO saleSharesDTO = new()
            {
                SharesCount = sharesCount,
                PricePerShare = pricePerShare
            };

            var result = _strategy.SaleSharesCalculations(SeedData1(), saleSharesDTO);

            result.TotalProfitOrLoss.Should().BeApproximately(totalProfitOrLoss, 0.01m);
        }



        private static List<LotDTO> SeedData1()
        {
            return new List<LotDTO>()
            {
                new LotDTO { Id = 1, SharesCount = 100, PricePerShare = 20, PurchaseDate = new DateTime(2023, 1, 1) },
                new LotDTO { Id = 2, SharesCount = 200, PricePerShare = 30, PurchaseDate = new DateTime(2023, 2, 1) }
            };
        }

        private static List<LotDTO> SeedData2() //For example only used in one test
        {
            return new List<LotDTO>()
            {
                new LotDTO { Id = 1, SharesCount = 100, PricePerShare = 20, PurchaseDate = new DateTime(2023, 1, 1) },
                new LotDTO { Id = 2, SharesCount = 150, PricePerShare = 30, PurchaseDate = new DateTime(2023, 2, 1) },
                new LotDTO { Id = 3, SharesCount = 120, PricePerShare = 10, PurchaseDate = new DateTime(2023, 3, 1) }
            };
        }
    }
}
