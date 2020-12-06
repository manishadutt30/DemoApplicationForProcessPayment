using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotnetApplication_Repository.Interface
{
    public interface IExpensivePaymentGateway
    {
        void ProcessPayment();
    }
}
