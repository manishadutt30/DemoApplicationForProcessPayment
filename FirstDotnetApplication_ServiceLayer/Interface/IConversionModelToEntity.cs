using FirstDotNetApplication_DataLayer;
using FirstDotnetApplication_ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotnetApplication_ServiceLayer.Interface
{
    public interface IConversionModelToEntity
    {
        PaymentInformation ConvertModelToEntity(PaymentInformationDto paymentInformationDto );
    }
}
