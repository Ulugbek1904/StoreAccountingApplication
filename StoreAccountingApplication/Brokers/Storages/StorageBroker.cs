using Microsoft.EntityFrameworkCore;
using StoreAccountingApplication.Models;
using STX.EFxceptions.SqlServer;

namespace StoreAccountingApplication.Brokers.Storages
{
    public class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        public StorageBroker()
        {
            this.Database.Migrate();
        }
        DbSet<Product> Products { get; set; }
        public async Task<Product> InsertProductAsync(Product product)
        {
            var storageBroker = new StorageBroker();
            await storageBroker.Products.AddAsync(product);
            await storageBroker.SaveChangesAsync();

            return product;
        }

        public async Task<List<Product>> RetrieveAllProductAsync()
        {
            var storageBroker = new StorageBroker();

            return await storageBroker.Products.ToListAsync();
        }

        public async Task<Product> RetrieveProductById(Guid productId)
        {
            var storageBroker = new StorageBroker();
            var product =  await storageBroker.Products.FindAsync(productId);
            await storageBroker.SaveChangesAsync();

            return product ?? new Product();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var storageBroker = new StorageBroker();
            storageBroker.Products.Update(product);
            await storageBroker.SaveChangesAsync();

            return product;
        }
        public async Task<Product> DeleteProductAsync(Product product)
        {
            var storageBroker = new StorageBroker();
            storageBroker.Products.Remove(product);
            await storageBroker.SaveChangesAsync();

            return product;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StoreAccountingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connectionString);            

        }
    }
}
