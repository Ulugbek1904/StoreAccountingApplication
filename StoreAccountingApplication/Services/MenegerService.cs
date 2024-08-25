using System.Linq.Expressions;

namespace StoreAccountingApplication.Services
{
    public class MenegerService : IMenegerService
    {
        ICreateMenegerService createMenegerService;
        public MenegerService()
        {
            createMenegerService = new CreateMenegerService();
        }
        public void LoadMenegerMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t======Menu======");
            bool continueProg = true;
            while (continueProg)
            {
                try
                {
                    Console.WriteLine("" +
                        "1. Sign in\n" +
                        "2. Create new one\n" +
                        "3. Back\n");

                    Console.Write("Choose one : ");
                    string input = Console.ReadLine();
                    int intInput = int.Parse(input);
                    switch (intInput)
                    {
                        case 1:
                            Console.WriteLine("Entering system");
                            break;
                        case 2:
                            createMenegerService.CreateMeneger();
                            break;
                        case 3:
                            Console.Clear();
                            continueProg = false;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Enter only 1 or 2 or 3");
                    }
                }
                catch (ArgumentOutOfRangeException exc)
                {
                    Console.WriteLine(exc.Message);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }
    }
}
