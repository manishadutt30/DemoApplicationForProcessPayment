using FirstDotnetApplication_ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotnetApplication_ServiceLayer.Interface
{
    public interface IProcessPayment
    {
        void ProcessAmount(PaymentInformationDto paymentInformationDto);
    }
}
