using FirstDotnetApplication_ServiceLayer.Interface;
using FirstDotnetApplication_ServiceLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDotNetApplication.Controllers
{
    [ApiController]
    public class ProcessPaymentController: ControllerBase
    {
        private  IProcessPayment _processPayment { get; set; }

        public ProcessPaymentController(IProcessPayment processPayment)
        {
            _processPayment = processPayment;
        }

        [HttpPost("api/processpayment")]
        public IActionResult ProcessPayment(PaymentInformationDto paymentInformationDto)
        {
            try
            {
                _processPayment.ProcessAmount(paymentInformationDto);
                return Ok();
            }
            catch(Exception ex)
            {
                return (IActionResult)ex.GetBaseException();
            }
            
        }
    }
}
