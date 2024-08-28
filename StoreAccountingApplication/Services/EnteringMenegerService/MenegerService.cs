namespace StoreAccountingApplication.Services.MenegerServices
{
    public class MenegerService : IMenegerService
    {
        public void LoadMenegerMenu()
        {
            Console.Clear();
            bool continueProg = true;
            while (continueProg)
            {
                string menu = "" +
                    "1. Sales Management:\n" +
                    "2. Personnel Management:\n" +
                    "3. Customer Management:\n" +
                    "4. Price Management:\n" +
                    "5. Inventory Management:\n" +
                    "6. Back \n";

                Console.WriteLine("\t\t\t=====Menu======");
                Console.WriteLine(menu);
                try
                {
                    Console.Write("choose option : ");
                    string input = Console.ReadLine();
                    int intInput = int.Parse(input);
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
                            Console.WriteLine("g");
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
