using StoreAccountingApplication.Models;

namespace StoreAccountingApplication.Brokers
{
    public interface IStorageBroker
    {
        Task<List<Product>> RetrieveProductsAsync();
        Task<Product> AddNewProductAsync(Product product);
        Task<Product> RemoveProductAsync(Product product);
        Task<Product> EditProductDataAsync(Product product);
    }
}