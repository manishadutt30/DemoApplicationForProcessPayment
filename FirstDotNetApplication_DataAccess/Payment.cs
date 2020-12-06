using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FirstDotNetApplication_DataAccess
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public PaymentStatus Status { get; set; }
    }

    public enum PaymentStatus
    {
        Pending,
        Processed,
        Failed
    }
}
