using Microsoft.EntityFrameworkCore;
using Railway_Reservationsystem_WebAPI.Models;

namespace Railway_Reservationsystem_WebAPI.Data
{
    public class LoginDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        //public DbSet<Login> loginModels { get; set; }
        public DbSet<Registration> registrationModels { get; set; }
       public DbSet<TrainDetails> TrainDetailsModels { get; set; }
        public DbSet<BookingDetails> BookingDetailsModels { get; set; }
        public DbSet<PaymentDetail> paymentDetailModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Login>().ToTable("LoginTable");
            modelBuilder.Entity<Registration>().ToTable("PassengerProfile");
            modelBuilder.Entity<TrainDetails>().ToTable("TrainDetails");
            modelBuilder.Entity<BookingDetails>().ToTable("BookingDetails");
            modelBuilder.Entity<PaymentDetail>().ToTable("PaymentDetails");
        }
    }
}
