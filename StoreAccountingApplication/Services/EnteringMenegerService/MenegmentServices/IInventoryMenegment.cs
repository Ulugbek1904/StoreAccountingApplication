namespace StoreAccountingApplication.Services.EnteringMenegerService.MenegmentServices
{
    public interface IInventoryMenegment
    {
        void LoadMenu();
        Task ShowProductStock();
        Task SearchProduct();
        Task AddNewProduct();
        Task RemoveProduct();
        Task EditProductData();
    }
}