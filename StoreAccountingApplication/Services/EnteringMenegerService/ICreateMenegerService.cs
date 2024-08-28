namespace StoreAccountingApplication.Services.MenegerServices
{
    public interface ICreateMenegerService
    {
        void CreateMeneger();
        void LoadInnerCode();
        bool isValidPassword(string passwordInput);
        bool isValidEmail(string emailInput);
        bool isValidNumber(string number);
    }
}