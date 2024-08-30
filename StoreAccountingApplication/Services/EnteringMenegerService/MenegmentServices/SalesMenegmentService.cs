namespace StoreAccountingApplication.Services.EnteringMenegerService.MenegmentServices
{
    public class SalesMenegmentService : ISalesMenegmentService
    {
        ILoggingService loggingService;
        public SalesMenegmentService()
        {
            loggingService = new LoggingService();
        }
        public void LoadExistingMenu()
        {
            Console.Clear();
            bool continueProg = true;
            while(continueProg)
            {
                try
                {
                    string menu = "1. Display sale history/n" +
                        "2. Display sale report\n" +
                        "";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
