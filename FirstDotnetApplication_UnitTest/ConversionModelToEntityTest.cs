using FirstDotnetApplication_ServiceLayer.Implementation;
using FirstDotnetApplication_ServiceLayer.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDotnetApplication_UnitTest
{
    public class ConversionModelToEntityTest
    {
        private ConversionModelToEntity _conversionModelToEntity;

        [SetUp]
        public void Setup()
        {
            _conversionModelToEntity = new ConversionModelToEntity();
        }

        [Test]
        public void When_PaymentInformationDto_Is_null()
        {
            //Given: When PaymentInformationDto is null
            PaymentInformationDto paymentInformationDto = null;

            //When: calls ConvertModelToEntity method
            var result = _conversionModelToEntity.ConvertModelToEntity(paymentInformationDto);

            //Then: Model is null
            Assert.IsNull(result);

        }

        [Test]
        public void When_PaymentInformationDto_Is_Empty()
        {
            //Given: When PaymentInformationDto is null
            PaymentInformationDto paymentInformationDto = new PaymentInformationDto();

            //When: calls ConvertModelToEntity method
            var result = _conversionModelToEntity.ConvertModelToEntity(paymentInformationDto);

            //Then: Model is null
           Assert.IsNull(result.CreditCardNumber);
           Assert.IsNull(result.CreditCardNumber);
           Assert.IsNull(result.CreditCardNumber);
        }

        [Test]
        public void When_PaymentInformationDto_Is_Not_Null_And_Empty()
        {
            //Given: When PaymentInformationDto is null
            PaymentInformationDto paymentInformationDto = new PaymentInformationDto();
            paymentInformationDto.CreditCardNumber = "76755463723459876";
            paymentInformationDto.CardHolderName = "ABC";
            paymentInformationDto.ExpirationDate = DateTime.Now.AddYears(2);
            paymentInformationDto.SecurityCode = "123";
            paymentInformationDto.Amount = 19;

            //When: calls ConvertModelToEntity method
            var result = _conversionModelToEntity.ConvertModelToEntity(paymentInformationDto);

            //Then: result is not null;
            Assert.IsNotNull(result);

        }
    }
}
