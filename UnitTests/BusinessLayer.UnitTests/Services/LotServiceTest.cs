using BusinessLayer.DTOs;
using BusinessLayer.Services;
using BusinessLayer.Validators;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace UnitTests.BusinessLayer.UnitTests.Services
{
    [TestFixture]
    internal class LotServiceTest
    {
        private Mock<IRepository<Lot>> _lotRepositoryMock;
        private Mock<IValidator<SaleSharesDTO>> _saleSharesValidatorMock;
        private LotService _lotService;

        [SetUp]
        public void SetUp()
        {
            _lotRepositoryMock = new Mock<IRepository<Lot>>(MockBehavior.Strict);
            _saleSharesValidatorMock = new Mock<IValidator<SaleSharesDTO>>(MockBehavior.Strict);
            _saleSharesValidatorMock.Setup(v => v.Validate(It.IsAny<SaleSharesDTO>())).Returns(new ValidationResult);
            _lotService = new LotService(_lotRepositoryMock.Object, _saleSharesValidatorMock.Object);
        }

        //Tests
    }
}
