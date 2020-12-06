using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FirstDotNetApplication_DataLayer
{
    public class PaymentInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public String SecurityCode { get; set; }
        public Decimal Amount { get; set; }
    }
}
