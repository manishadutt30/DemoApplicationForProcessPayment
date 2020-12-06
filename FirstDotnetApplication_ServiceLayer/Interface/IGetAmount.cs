using FirstDotNetApplication_DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotnetApplication_ServiceLayer.Interface
{
    public interface IGetAmount
    {
        void GetAmountAdded(PaymentInformation paymentInformation);
    }
}
