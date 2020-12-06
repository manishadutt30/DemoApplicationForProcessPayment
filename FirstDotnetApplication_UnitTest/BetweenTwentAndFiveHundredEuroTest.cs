using FirstDotNetApplication_DataLayer;
using FirstDotNetApplication_RepositoryLayer.Interface;
using FirstDotnetApplication_ServiceLayer.Implementation;
using Moq;
using NUnit.Framework;
using System;

namespace FirstDotnetApplication_UnitTest
{
    public class BetweenTwentAndFiveHundredEuroTest
    {
        private BetweenTwentAndFiveHundredEuro _betweenTwentAndFiveHundredEuro;
        private Mock<ICheapPaymentGateway> _cheapPaymentGateway;
        private Mock<IExpensivePaymentGateway> _expensivePaymentGateway;

        [SetUp]
        public void Setup()
        {
            _cheapPaymentGateway = new Mock<ICheapPaymentGateway>();
            _expensivePaymentGateway = new Mock<IExpensivePaymentGateway>();
            _betweenTwentAndFiveHundredEuro = new BetweenTwentAndFiveHundredEuro(_cheapPaymentGateway.Object, _expensivePaymentGateway.Object);
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

            //When: Call GetAmountAdded from BetweenTwentAndFiveHundredEuro class
            _cheapPaymentGateway.Setup(x => x.ProcessPayment(paymentInformation)).Verifiable();
            _betweenTwentAndFiveHundredEuro.GetAmountAdded(paymentInformation);

            //Then: _cheapPaymentGateway never calls
            _cheapPaymentGateway.Verify(x => x.ProcessPayment(paymentInformation), Times.Never);
        }

        [Test]
        public void When_Amount_Is_Between_21_And_500_Euro()
        {
            //Given:  Payment Information Model
            PaymentInformation paymentInformation = new PaymentInformation();
            paymentInformation.CreditCardNumber = "76755463723459876";
            paymentInformation.CardHolderName = "ABC";
            paymentInformation.ExpirationDate = DateTime.Now.AddYears(2);
            paymentInformation.SecurityCode = "123";
            paymentInformation.Amount = 34;

            //When: Call GetAmountAdded from BetweenTwentAndFiveHundredEuro class
            _cheapPaymentGateway.Setup(x => x.ProcessPayment(paymentInformation)).Verifiable();
            _betweenTwentAndFiveHundredEuro.GetAmountAdded(paymentInformation);

            //Then: _cheapPaymentGateway calls once 
            _cheapPaymentGateway.Verify(x => x.ProcessPayment(paymentInformation), Times.Once);
        }

        [Test]
        public void When_Amount_Is_Greater_Than_500_Euro()
        {
            //Given:  Payment Information Model
            PaymentInformation paymentInformation = new PaymentInformation();
            paymentInformation.CreditCardNumber = "76755463723459876";
            paymentInformation.CardHolderName = "ABC";
            paymentInformation.ExpirationDate = DateTime.Now.AddYears(2);
            paymentInformation.SecurityCode = "123";
            paymentInformation.Amount = 555;

            //When: Call GetAmountAdded from BetweenTwentAndFiveHundredEuro class
            _cheapPaymentGateway.Setup(x => x.ProcessPayment(paymentInformation)).Verifiable();
            _betweenTwentAndFiveHundredEuro.GetAmountAdded(paymentInformation);

            //Then: _cheapPaymentGateway never calls
            _cheapPaymentGateway.Verify(x => x.ProcessPayment(paymentInformation), Times.Never);
        }
    }
}