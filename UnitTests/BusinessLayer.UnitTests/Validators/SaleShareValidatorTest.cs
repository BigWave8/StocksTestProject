using BusinessLayer.DTOs;
using BusinessLayer.Validators;
using FluentAssertions;
using FluentValidation;

namespace UnitTests.BusinessLayer.UnitTests.Validators
{
    [TestFixture]
    public class SaleShareValidatorTest
    {
        private IValidator<SaleSharesDTO> _validator;
        private const int ValidSharesCount = 100;
        private const decimal ValidPricePerShare = 20;

        [SetUp]
        public void SetUp()
        {
            _validator = new SaleSharesValidator();
        }

        [Test]
        public void SaleSharesValidator_ValidData_IsValidShouldBeTrue()
        {
            SaleSharesDTO saleSharesDTO = CreateValidSaleShares();

            var result = _validator.Validate(saleSharesDTO);

            result.IsValid.Should().BeTrue();
        }

        [Test]
        public void SaleSharesValidator_ZeroShareCount_IsValidShouldBeFalse()
        {
            SaleSharesDTO saleSharesDTO = new () { SharesCount = 0 };

            var result = _validator.Validate(saleSharesDTO);

            result.IsValid.Should().BeFalse();
        }

        [Test]
        public void SaleSharesValidator_ZeroPricePerShare_IsValidShouldBeFalse()
        {
            SaleSharesDTO saleSharesDTO = new() { PricePerShare = decimal.Zero };

            var result = _validator.Validate(saleSharesDTO);

            result.IsValid.Should().BeFalse();
        }

        private static SaleSharesDTO CreateValidSaleShares()
        {
            return new SaleSharesDTO() 
            { 
                SharesCount = ValidSharesCount, 
                PricePerShare = ValidPricePerShare 
            };
        }
    }
}
