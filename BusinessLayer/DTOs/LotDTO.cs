namespace BusinessLayer.DTOs
{
    public class LotDTO
    {
        public int Id { get; set; }
        public int SharesCount { get; set; }
        public decimal PricePerShare { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
