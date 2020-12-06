using FirstDotNetApplication_DataLayer;
using FirstDotNetApplication_RepositoryLayer.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace FirstDotNetApplication_RepositoryLayer.Implementation
{
    public class PremiumPaymentService : IPremiumPaymentService
    {
        private DbPaymentProcess _dbPaymentProcess { get; set; }

        public PremiumPaymentService(DbPaymentProcess dbPaymentProcess)
        {
            _dbPaymentProcess = dbPaymentProcess;
        }
        public bool IsAvailable()
        {
            return true;
            //return false;
        }
        public void ProcessPayment(PaymentInformation paymentInformation)
        {
            using (IDbContextTransaction transaction = _dbPaymentProcess.Database.BeginTransaction())
            {
                try
                {
                    PaymentInformation paymentAmount = _dbPaymentProcess.PaymentInformations.FirstOrDefault(x => x.CreditCardNumber == paymentInformation.CreditCardNumber
                                    && x.CardHolderName == paymentInformation.CardHolderName);
                    paymentAmount.Amount = paymentAmount.Amount - paymentInformation.Amount;
                    _dbPaymentProcess.PaymentInformations.Update(paymentAmount);
                    _dbPaymentProcess.SaveChanges();

                    Payment payment = new Payment();
                    payment.CardHolderName = paymentInformation.CardHolderName;
                    payment.CreditCardNumber = paymentInformation.CreditCardNumber;
                    payment.Status = PaymentStatus.Processed;
                    _dbPaymentProcess.Payments.Add(payment);
                    _dbPaymentProcess.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public void CheckConnection(PaymentInformation paymentInformation)
        {
            int i = 0;
            for(i=1; i<4; i++)
            {
                if (IsAvailable())
                {
                    ProcessPayment(paymentInformation);
                }
            }
            
            if(i == 4)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }                           
        }
    }
}
