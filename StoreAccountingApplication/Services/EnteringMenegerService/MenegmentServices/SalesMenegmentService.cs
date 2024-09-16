using StoreAccountingApplication.Models;

namespace StoreAccountingApplication.Services.EnteringMenegerService.MenegmentServices
{
    public class SalesMenegmentService : ISalesMenegmentService
    {
        private List<Sale> Sales = new List<Sale>();
        ILoggingService loggingService;
        public SalesMenegmentService()
        {
            loggingService = new LoggingService();
        }
        public void LoadExistingMenu()
        {
            Console.Clear();
            bool continueProg = true;
            while(continueProg)
            {
                try
                {
                    string menu = "1. Display sale history/n" +
                        "2. Display sale report\n" +
                        "";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void AddSale(Sale sale)
        {
            Sales.Add(sale);
            Console.WriteLine("Sale added successfully.");
        }

        public void DisplaySalesHistory()
        {
            foreach (var sale in Sales)
            {
                Console.WriteLine($"ID: {sale.SaleId}, Date: {sale.Saledate}, Total: {sale.TotalAmount}, Seller: {sale.SellerName}");
                foreach (var product in sale.Products)
                {
                    Console.WriteLine($"\tProduct: {product.ProductName}, Quantity: {product.Quantity}, Price: {product.ProductPrice}");
                }
            }
        }

        public void DisplaySalesReport(DateTime startDate, DateTime endDate)
        {
            var filteredSales = Sales.Where(sale => sale.Saledate>= startDate && sale.Saledate <= endDate);
            decimal totalRevenue = filteredSales.Sum(s => s.TotalAmount);

            Console.WriteLine($"Sales report from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}:");
            Console.WriteLine($"Total Revenue: {totalRevenue}");

            foreach (var sale in filteredSales)
            {
                Console.WriteLine($"ID: {sale.SaleId}, Date: {sale.Saledate}, Total: {sale.TotalAmount}, Seller: {sale.SellerName}");
            }
        }
    }
}
