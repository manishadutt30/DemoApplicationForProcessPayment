using FirstDotNetApplication_DataLayer;
using FirstDotNetApplication_RepositoryLayer.Interface;
using FirstDotnetApplication_ServiceLayer.Implementation;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotnetApplication_UnitTest
{
    public class MoreThanFiveHundredEuroTest
    {
        private MoreThanFiveHundredEuro _moreThanFiveHundredEuro;
        private Mock<IPremiumPaymentService> _premiumPaymentService;

        [SetUp]
        public void Setup()
        {
            _premiumPaymentService = new Mock<IPremiumPaymentService>();
            _moreThanFiveHundredEuro = new MoreThanFiveHundredEuro(_premiumPaymentService.Object);
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

            //When: Call GetAmountAdded from MoreThanFiveHundredEuro class
            _premiumPaymentService.Setup(x => x.ProcessPayment(paymentInformation)).Verifiable();
            _moreThanFiveHundredEuro.GetAmountAdded(paymentInformation);

            //Then: _premiumPaymentService never calls
            _premiumPaymentService.Verify(x => x.ProcessPayment(paymentInformation), Times.Never);
        }

        [Test]
        public void When_Amount_Is_Greater_Than_20_Euro()
        {
            //Given:  Payment Information Model
            PaymentInformation paymentInformation = new PaymentInformation();
            paymentInformation.CreditCardNumber = "76755463723459876";
            paymentInformation.CardHolderName = "ABC";
            paymentInformation.ExpirationDate = DateTime.Now.AddYears(2);
            paymentInformation.SecurityCode = "123";
            paymentInformation.Amount = 545;

            //When: Call GetAmountAdded from MoreThanFiveHundredEuro class
            _premiumPaymentService.Setup(x => x.ProcessPayment(paymentInformation)).Verifiable();
            _moreThanFiveHundredEuro.GetAmountAdded(paymentInformation);

            //Then: _premiumPaymentService calls once
            _premiumPaymentService.Verify(x => x.ProcessPayment(paymentInformation), Times.Once);
        }
    }
}
