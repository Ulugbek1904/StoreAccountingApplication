namespace StoreAccountingApplication.Models
{
    public class Sale
    {
        public Guid SaleId { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Saledate { get; set; }
        public string SellerName { get; set; }
    }
}
