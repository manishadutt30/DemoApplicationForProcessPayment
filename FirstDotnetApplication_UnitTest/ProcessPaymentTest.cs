using FirstDotNetApplication_DataLayer;
using FirstDotNetApplication_RepositoryLayer.Interface;
using FirstDotnetApplication_ServiceLayer.Implementation;
using FirstDotnetApplication_ServiceLayer.Interface;
using FirstDotnetApplication_ServiceLayer.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotnetApplication_UnitTest
{
    public class ProcessPaymentTest
    {
        private ProcessPayment _processPayment;
        private Mock<ICheapPaymentGateway> _cheapPaymentGateway;
        private Mock<IExpensivePaymentGateway> _expensivePaymentGateway;
        private Mock<IConversionModelToEntity> _conversionModelToEntity { get; set; }
        private Mock<IPremiumPaymentService> _premiumPaymentService { get; set; }

        [SetUp]
        public void Setup()
        {
            _conversionModelToEntity = new Mock<IConversionModelToEntity>();
            _cheapPaymentGateway = new Mock<ICheapPaymentGateway>();
            _expensivePaymentGateway = new Mock<IExpensivePaymentGateway>();
            _premiumPaymentService = new Mock<IPremiumPaymentService>();
            _processPayment = new ProcessPayment(_conversionModelToEntity.Object, _cheapPaymentGateway.Object,
                                                _expensivePaymentGateway.Object, _premiumPaymentService.Object);
        }

        [Test]
        public void When_Amount_Is_Less_Than_20_Euro()
        {
            //Given:  Payment Information Model
            PaymentInformation paymentInformation = new PaymentInformation();
            paymentInformation.CreditCardNumber = "76755463723459876";
            paymentInformation.CardHolderName = "ABC";
            paymentInformation.ExpirationDate = DateTime.Now.AddYears(2);
            paymentInformation.SecurityCode = "123";
            paymentInformation.Amount = 19;

            PaymentInformationDto paymentInformationDto = new PaymentInformationDto();
            paymentInformationDto.CreditCardNumber = "76755463723459876";
            paymentInformationDto.CardHolderName = "ABC";
            paymentInformationDto.ExpirationDate = DateTime.Now.AddYears(2);
            paymentInformationDto.SecurityCode = "123";
            paymentInformationDto.Amount = 19;

            //When: Call GetAmountAdded from BetweenTwentAndFiveHundredEuro class
            _conversionModelToEntity.Setup(x => x.ConvertModelToEntity(paymentInformationDto)).Returns(paymentInformation);
            _cheapPaymentGateway.Setup(x => x.ProcessPayment(paymentInformation)).Verifiable();
            _processPayment.ProcessAmount(paymentInformationDto);

            //Then: _cheapPaymentGateway never calls
            _cheapPaymentGateway.Verify(x => x.ProcessPayment(paymentInformation), Times.Never);
        }
    }
}
