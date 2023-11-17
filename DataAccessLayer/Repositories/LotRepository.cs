using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class LotRepository : IRepository<Lot>
    {
        private readonly LotDBContext _context;

        public LotRepository(LotDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Lot> GetAll()
        {
            return SeedData();
        }

        private static IEnumerable<Lot> SeedData()
        {
            return new List<Lot>()
            {
                new Lot { Id = 1, SharesCount = 100, PricePerShare = 20, PurchaseDate = new DateTime(2023, 1, 1) },
                new Lot { Id = 2, SharesCount = 150, PricePerShare = 30, PurchaseDate = new DateTime(2023, 2, 1) },
                new Lot { Id = 3, SharesCount = 120, PricePerShare = 10, PurchaseDate = new DateTime(2023, 3, 1) }
            };
        }
    }
}
