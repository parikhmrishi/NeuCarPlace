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

    }
}

