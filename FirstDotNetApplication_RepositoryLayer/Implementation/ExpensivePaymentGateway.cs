using FirstDotNetApplication_DataLayer;
using FirstDotNetApplication_RepositoryLayer.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstDotNetApplication_RepositoryLayer.Implementation
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        private DbPaymentProcess _dbPaymentProcess { get; set; }

        public ExpensivePaymentGateway(DbPaymentProcess dbPaymentProcess)
        {
            _dbPaymentProcess = dbPaymentProcess;
        }
        public bool IsAvailable()
        {
            return true;
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
    }
}
