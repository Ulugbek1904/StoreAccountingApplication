namespace StoreAccountingApplication.Services.MenegerServices
{
    public interface IAuthenticationService
    {
        void CheckPassword();
        void ChangePassword();
        bool isValidPassword(string passwordInput);
    }
}