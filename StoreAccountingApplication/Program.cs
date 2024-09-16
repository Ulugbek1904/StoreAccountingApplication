using StoreAccountingApplication.Brokers.Storages;
using StoreAccountingApplication.Models;
using StoreAccountingApplication.Services;

namespace StoreAccountingApplication
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //IStorageBroker broker = new StorageBroker();
            //ILoggingService loggingService = new LoggingService();

            //string name = loggingService.GetStringInput("enter name : ");
            //string manufacturer = loggingService.GetStringInput("enter manufacturer : ");
            //decimal price = loggingService.GetDecimalInput("enter price : ");
            //int amount = loggingService.GetIntInput("enter amount : ");


            //Product product = new Product()
            //{
            //    ProductId = Guid.NewGuid(),
            //    ProductName = name,
            //    Manufacturer = manufacturer,
            //    ProductPrice = price,
            //    Quantity = amount
            //    ,
            //    ExpiryDate = DateTime.Now,
            //};
            //await broker.InsertProductAsync(product);

            //List<Product> Products = await broker.RetrieveAllProductAsync();
            //foreach(var innerproduct in Products)
            //{
            //    Console.WriteLine($"{innerproduct.ProductId} : {innerproduct.ProductName} : {innerproduct.Manufacturer}" +
            //        $": {innerproduct.ProductPrice} : {innerproduct.Quantity} : {innerproduct.ExpiryDate}");
            //}

            ILoadMenu loadMenu = new LoadMenu();

            Console.WriteLine("\t\t\t\t" +
                "Welcome to the Store account application." +
                "" + Environment.NewLine);

            Console.WriteLine("\t\t\t\t\t=====Menu=====\n");
            loadMenu.LoadExsitingMenu();
        }
    }
}
