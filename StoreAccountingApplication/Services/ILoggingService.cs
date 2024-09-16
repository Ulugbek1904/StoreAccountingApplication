namespace StoreAccountingApplication.Services
{
    public interface ILoggingService
    {
        int GetIntInput(string prompt);
        string GetStringInput(string prompt);
        decimal GetDecimalInput(string prompt);
        Guid GetGuidID(string prompt);
    }
}