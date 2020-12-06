using FirstDotNetApplication_DataLayer;
using FirstDotNetApplication_RepositoryLayer.Interface;
using FirstDotnetApplication_ServiceLayer.Interface;
using FirstDotnetApplication_ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotnetApplication_ServiceLayer.Implementation
{
    public class ProcessPayment : IProcessPayment
    {
        private List<IGetAmount> _listGetAmounts { get; set; }
        private ICheapPaymentGateway _cheapPaymentGateway { get; set; }
        private IExpensivePaymentGateway _expensivePaymentGateway { get; set; }
        private IConversionModelToEntity _conversionModelToEntity { get; set; }
        private IPremiumPaymentService _premiumPaymentService { get; set; }

        public ProcessPayment(IConversionModelToEntity conversionModelToEntity,
                              ICheapPaymentGateway cheapPaymentGateway,
                              IExpensivePaymentGateway expensivePaymentGateway,
                              IPremiumPaymentService premiumPaymentService)
        {
            _conversionModelToEntity = conversionModelToEntity;
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _premiumPaymentService = premiumPaymentService;
            _listGetAmounts = new List<IGetAmount>
            {
                new LessThanTwentyZero(_cheapPaymentGateway),
                new BetweenTwentAndFiveHundredEuro(_cheapPaymentGateway, _expensivePaymentGateway),
                new MoreThanFiveHundredEuro(_premiumPaymentService)
            };
        }

        public void ProcessAmount(PaymentInformationDto paymentInformationDto)
        {
            PaymentInformation paymentInformation = _conversionModelToEntity.ConvertModelToEntity(paymentInformationDto);
            
            foreach(var item in _listGetAmounts)
            {
                item.GetAmountAdded(paymentInformation);
            }
        }
    }
}
