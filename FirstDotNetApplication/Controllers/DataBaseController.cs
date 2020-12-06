using FirstDotNetApplication_DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDotNetApplication.Controllers
{
    [ApiController]
    public class DataBaseController: ControllerBase
    {
        private readonly DbPaymentProcess _dbPaymentProcess;
        public DataBaseController(DbPaymentProcess dbPaymentProcess)
        {
            _dbPaymentProcess = dbPaymentProcess ?? throw new ArgumentNullException(nameof(_dbPaymentProcess));
        }


        [HttpGet("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }

        [HttpPost("api/paymentInformation")]
        public IActionResult InsertTable(PaymentInformation paymentInformation)
        {
            try
            {
                _dbPaymentProcess.PaymentInformations.Add(paymentInformation);
                _dbPaymentProcess.SaveChanges();                
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
