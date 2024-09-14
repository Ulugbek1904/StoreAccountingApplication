using Microsoft.EntityFrameworkCore;
using StoreAccountingApplication.Models;
using STX.EFxceptions.SqlServer;

namespace StoreAccountingApplication.Brokers
{
    internal class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        public StorageBroker()
        {
            this.Database.Migrate();
        }
        public DbSet<Product> Products { get; set; }
        public async Task<Product> AddNewProductAsync(Product product)
        {
            StorageBroker storageBroker = new StorageBroker();
            await storageBroker.Products.AddAsync(product);
            await storageBroker.SaveChangesAsync();

            return product;
        }

        public async Task<Product> EditProductDataAsync(Product product)
        {
            StorageBroker storageBroker = new StorageBroker();
            storageBroker.Products.Update(product);
            await storageBroker.SaveChangesAsync();

            return product;
        }

        public async Task<Product> RemoveProductAsync(Product product)
        {
            StorageBroker storageBroker = new StorageBroker();
            storageBroker.Products.Remove(product);
            await storageBroker.SaveChangesAsync();

            return product;
        }

        public async Task<List<Product>> RetrieveProductsAsync()
        {
            StorageBroker storageBroker = new StorageBroker();
            
            return await storageBroker.Products.ToListAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StorageAccountingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
