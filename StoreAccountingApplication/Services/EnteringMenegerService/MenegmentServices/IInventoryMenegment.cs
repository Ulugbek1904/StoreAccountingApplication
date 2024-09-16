namespace StoreAccountingApplication.Services.EnteringMenegerService.MenegmentServices
{
    public interface IInventoryMenegment
    {
        void LoadMenu();
        Task AddNewProduct();
        Task ShowProductStock();
        void SearchProduct();
        Task EditProductData();
        Task RemoveProduct();
    }
}