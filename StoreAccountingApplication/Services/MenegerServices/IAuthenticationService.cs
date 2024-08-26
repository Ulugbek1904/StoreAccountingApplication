namespace StoreAccountingApplication.Services.MenegerServices
{
    public interface IAuthenticationService
    {
        void CheckPassword();
        void ChangePassword();
    }
}