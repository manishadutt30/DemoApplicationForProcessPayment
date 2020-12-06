using FirstDotNetApplication_DataLayer;
using FirstDotNetApplication_RepositoryLayer.Interface;
using FirstDotnetApplication_ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotnetApplication_ServiceLayer.Implementation
{
    public class BetweenTwentAndFiveHundredEuro : IGetAmount
    {
        private ICheapPaymentGateway _cheapPaymentGateway { get; set; }

        private IExpensivePaymentGateway _expensivePaymentGateway { get; set; }

        public BetweenTwentAndFiveHundredEuro(ICheapPaymentGateway cheapPaymentGateway,
                                        IExpensivePaymentGateway expensivePaymentGateway)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
        }

        public void GetAmountAdded(PaymentInformation paymentInformation)
        {
            if(paymentInformation.Amount > 20 && paymentInformation.Amount <= 500)
            {
                if (_expensivePaymentGateway.IsAvailable())
                {
                    _expensivePaymentGateway.ProcessPayment(paymentInformation);
                }
                else
                {
                    _cheapPaymentGateway.ProcessPayment(paymentInformation);
                }
            }
        }
    }
}
