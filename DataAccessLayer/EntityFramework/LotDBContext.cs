using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class LotDBContext : DbContext
    {
        public DbSet<Lot> Lot { get; set; }

        public LotDBContext(DbContextOptions<LotDBContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseInMemoryDatabase(databaseName: "MockStockDb");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lot>().HasData(
                new Lot { Id = 1, SharesCount = 100, PricePerShare = 20, PurchaseDate = new DateTime(2023, 1, 1) },
                new Lot { Id = 2, SharesCount = 150, PricePerShare = 30, PurchaseDate = new DateTime(2023, 2, 1) },
                new Lot { Id = 3, SharesCount = 120, PricePerShare = 10, PurchaseDate = new DateTime(2023, 3, 1) });
        }
    }
}
