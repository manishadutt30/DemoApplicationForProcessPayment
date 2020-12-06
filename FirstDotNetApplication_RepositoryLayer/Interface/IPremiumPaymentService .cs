using FirstDotNetApplication_DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotNetApplication_RepositoryLayer.Interface
{
    public interface IPremiumPaymentService
    {
        bool IsAvailable();
        void ProcessPayment(PaymentInformation paymentInformation);
        void CheckConnection(PaymentInformation paymentInformation);
    }
}
