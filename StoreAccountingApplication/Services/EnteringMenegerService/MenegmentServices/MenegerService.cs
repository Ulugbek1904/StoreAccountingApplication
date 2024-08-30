namespace StoreAccountingApplication.Services.EnteringMenegerService.MenegmentServices
{
    public class MenegerService : IMenegerService
    {
        ILoggingService loggingService;
        IInventoryMenegment inventoryMenegment;
        public MenegerService()
        {
            loggingService = new LoggingService();
            inventoryMenegment = new InventoryMenegment();
        }
        public void LoadMenegerMenu()
        {
            Console.Clear();
            bool continueProg = true;
            while (continueProg)
            {
                string menu = "" +
                    "1. Sales Management Menu.\n" +
                    "2. Personnel Management Menu.\n" +
                    "3. Customer Management Menu.\n" +
                    "4. Price Management Menu.\n" +
                    "5. Inventory Management Menu.\n" +
                    "6. Back \n";

                Console.WriteLine("\t\t\t=====Menu======");
                Console.WriteLine(menu);
                try
                {
                    int intInput = loggingService.
                        GetIntInput("Choose ana optin : ");

                    switch (intInput)
                    {
                        case 1:
                            Console.WriteLine("c");
                            break;
                        case 2:
                            Console.WriteLine("d");
                            break;
                        case 3:
                            Console.WriteLine("e");
                            break;
                        case 4:
                            Console.WriteLine("f");
                            break;
                        case 5:
                            inventoryMenegment.LoadMenu();
                            break;
                        case 6:
                            Console.Clear();
                            continueProg = false;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Only choose one of them");
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
