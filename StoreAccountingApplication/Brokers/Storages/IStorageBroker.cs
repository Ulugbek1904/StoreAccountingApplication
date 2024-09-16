using StoreAccountingApplication.Models;

namespace StoreAccountingApplication.Brokers.Storages
{
    public interface IStorageBroker
    {
        Task<Product> InsertProductAsync(Product product);
        Task<List<Product>> RetrieveAllProductAsync();
        Task<Product> RetrieveProductById(Guid productId);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> DeleteProductAsync(Product product);
    }
}