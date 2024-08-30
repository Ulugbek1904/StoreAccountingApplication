namespace StoreAccountingApplication.Services.EnteringMenegerService.MenegmentServices
{
    public interface IInventoryMenegment
    {
        void LoadMenu();
        void ShowProductStock();
        void SearchProduct();
        void AddNewProduct();
        void RemoveProduct();
        void EditProductData();
    }
}