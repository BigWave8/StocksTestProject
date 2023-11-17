using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class SaleSharesDTO
    {
        public int Id { get; set; } // for other types of calculation
        public int SharesCount { get; set; }
        public decimal PricePerShare { get; set; }
        public DateTime PurchaseDate { get; set; } // for other types of calculation
    }
}
