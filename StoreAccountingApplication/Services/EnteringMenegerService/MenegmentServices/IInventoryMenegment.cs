namespace StoreAccountingApplication.Services.EnteringMenegerService.MenegmentServices
{
    public interface IInventoryMenegment
    {
        Task LoadMenu();
        Task ShowProductStock();
        Task SearchProduct();
        Task AddNewProduct();
        Task RemoveProduct();
        Task EditProductData();
    }
}