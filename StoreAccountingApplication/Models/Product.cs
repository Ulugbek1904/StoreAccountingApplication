namespace StoreAccountingApplication.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        public string Manufacturer { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }        
    }
}
