using Microsoft.EntityFrameworkCore;
using NeuCarPlace.Domain.Entities;

namespace NeuCarPlace.Domain.Contexts
{
    public class NeuCarPlaceDbContext : DbContext
    {
        public NeuCarPlaceDbContext()
        {
        }
        public NeuCarPlaceDbContext(DbContextOptions<NeuCarPlaceDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<CarSpec> CarSpecs { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.; Database = NeuCarPlace; Trusted_Connection = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Car>()
             .HasOne<CarType>(ct => ct.CarType)
             .WithMany(ct => ct.Cars)
             .HasForeignKey(c => c.CarTypeId);

            modelBuilder.Entity<Purchase>()
            .HasOne<Car>(c => c.Car)
            .WithMany(c => c.Purchases)
            .HasForeignKey(c => c.CarId);

            modelBuilder.Entity<Purchase>()
            .HasOne<User>(u => u.User)
            .WithMany(u => u.Purchases)
            .HasForeignKey(u => u.UserId);

        }
    }

}


