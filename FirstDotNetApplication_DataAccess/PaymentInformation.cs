using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotNetApplication_DataAccess
{
    public class PaymentInformation
    {
        public string CreditCardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public String SecurityCode { get; set; }
        public Decimal Amount { get; set; }
    }
}
