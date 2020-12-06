using FirstDotNetApplication_DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotNetApplication_RepositoryLayer.Interface
{
    public interface IExpensivePaymentGateway
    {
        void ProcessPayment(PaymentInformation paymentInformation);
        bool IsAvailable();
    }
}
