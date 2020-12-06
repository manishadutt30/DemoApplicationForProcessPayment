using Microsoft.EntityFrameworkCore;

namespace FirstDotNetApplication_DataLayer
{
    public class DbPaymentProcess: DbContext
    {
        public DbSet<PaymentInformation> PaymentInformations { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbPaymentProcess(DbContextOptions<DbPaymentProcess> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .Property(x => x.Status)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
    
}
