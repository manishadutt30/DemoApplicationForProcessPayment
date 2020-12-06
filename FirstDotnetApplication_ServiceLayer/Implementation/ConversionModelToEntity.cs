using FirstDotNetApplication_DataLayer;
using FirstDotnetApplication_ServiceLayer.Interface;
using FirstDotnetApplication_ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotnetApplication_ServiceLayer.Implementation
{
    public class ConversionModelToEntity : IConversionModelToEntity
    {
        public PaymentInformation ConvertModelToEntity(PaymentInformationDto paymentInformationDto)
        {
            PaymentInformation paymentInformation = null ;
            if (paymentInformationDto != null)
            {
                paymentInformation = new PaymentInformation();

                paymentInformation.CreditCardNumber = paymentInformationDto.CreditCardNumber;
                paymentInformation.CardHolderName = paymentInformationDto.CardHolderName;
                paymentInformation.ExpirationDate = paymentInformationDto.ExpirationDate;
                paymentInformation.SecurityCode = paymentInformationDto.SecurityCode;
                paymentInformation.Amount = paymentInformationDto.Amount;
            }

            return paymentInformation;
        }
    }
}
