using FirstDotNetApplication_DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotNetApplication_RepositoryLayer.Interface
{
    public interface ICheapPaymentGateway
    {
        bool IsAvailable();
        void ProcessPayment(PaymentInformation paymentInformation);
        void CheckStatus(PaymentInformation paymentInformation);
    }
}
