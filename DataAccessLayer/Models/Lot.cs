using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Lot
    {
        public int Id { get; set; }
        public int SharesCount { get; set; }
        public decimal PricePerShare { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
