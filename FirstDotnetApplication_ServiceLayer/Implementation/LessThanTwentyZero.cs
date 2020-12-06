using FirstDotNetApplication_DataLayer;
using FirstDotNetApplication_RepositoryLayer.Interface;
using FirstDotnetApplication_ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotnetApplication_ServiceLayer.Implementation
{
    public class LessThanTwentyZero : IGetAmount
    {
        private ICheapPaymentGateway _cheapPaymentGateway { get; set; }
        public LessThanTwentyZero(ICheapPaymentGateway cheapPaymentGateway)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
        }

        public void GetAmountAdded(PaymentInformation paymentInformation)
        {
            if(paymentInformation.Amount <= 20)
            {
                _cheapPaymentGateway.CheckStatus(paymentInformation);
            }
        }
    }
}
