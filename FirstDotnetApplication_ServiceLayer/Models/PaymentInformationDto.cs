using FirstDotnetApplication_ServiceLayer.CustomDataAnnotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstDotnetApplication_ServiceLayer.Models
{
    public class PaymentInformationDto
    {
        [Required(ErrorMessage = "Enter valid Credit Number.")]
        [System.ComponentModel.DataAnnotations.CreditCard]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Enter your Name.")]
        public string CardHolderName { get; set; }

        [Required(ErrorMessage = "Enter valid expiry month and date of credit card.")]
        [FutureDatetime(ErrorMessage = "Expire date should be greater than current date")]
        public DateTime ExpirationDate { get; set; }

        public String SecurityCode { get; set; }

        [Required(ErrorMessage = "Enter Amount.")]
        [PositiveAmount(ErrorMessage = "Enter a valid(positive) value.")]
        public Decimal Amount { get; set; }
    }
}
