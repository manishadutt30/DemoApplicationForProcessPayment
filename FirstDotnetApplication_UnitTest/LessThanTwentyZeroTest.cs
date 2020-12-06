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
    public class LessThanTwentyZeroTest
    {
        private LessThanTwentyZero _lessThanTwentyZero;

        private Mock<ICheapPaymentGateway> _cheapPaymentGateway;

        [SetUp]
        public void Setup()
        {
            _cheapPaymentGateway = new Mock<ICheapPaymentGateway>();
            _lessThanTwentyZero = new LessThanTwentyZero(_cheapPaymentGateway.Object);
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

            //When: Call GetAmountAdded from LessThanTwentyZero class
            _cheapPaymentGateway.Setup(x => x.CheckStatus(paymentInformation)).Verifiable();
            _lessThanTwentyZero.GetAmountAdded(paymentInformation);

            //Then: _cheapPaymentGateway calls once
            _cheapPaymentGateway.Verify(x => x.CheckStatus(paymentInformation), Times.Once);
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
            paymentInformation.Amount = 34;

            //When: Call GetAmountAdded from LessThanTwentyZero class
            _cheapPaymentGateway.Setup(x => x.CheckStatus(paymentInformation)).Verifiable();
            _lessThanTwentyZero.GetAmountAdded(paymentInformation);

            //Then: _cheapPaymentGateway never calls
            _cheapPaymentGateway.Verify(x => x.CheckStatus(paymentInformation), Times.Never);
        }
    }
}
