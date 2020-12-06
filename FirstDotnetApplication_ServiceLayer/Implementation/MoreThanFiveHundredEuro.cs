using FirstDotNetApplication_DataLayer;
using FirstDotNetApplication_RepositoryLayer.Interface;
using FirstDotnetApplication_ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotnetApplication_ServiceLayer.Implementation
{
    public class MoreThanFiveHundredEuro : IGetAmount
    {
        private IPremiumPaymentService _premiumPaymentService { get; set; }
        public MoreThanFiveHundredEuro(IPremiumPaymentService premiumPaymentService)
        {
            _premiumPaymentService = premiumPaymentService;
        }

        public void GetAmountAdded(PaymentInformation paymentInformation)
        {
            if(paymentInformation.Amount > 500)
            {
                _premiumPaymentService.ProcessPayment(paymentInformation);
            }
            
        }
    }
}
