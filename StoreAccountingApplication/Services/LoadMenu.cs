namespace StoreAccountingApplication.Services
{
    public class LoadMenu : ILoadMenu
    {
        IMenegerService menegerservice;
        public LoadMenu()
        {
            menegerservice = new MenegerService();
        }

        public void LoadExsitingMenu()
        {
            bool continueProgram = true;
            while (continueProgram)
            {
                try
                {
                    Console.WriteLine("" +
                        "1. Enter as an store Meneger\n"
                        + "2. Enter as a client\n" +
                        "3. Exit program\n");

                    Console.Write("Enter option : ");
                    string input = Console.ReadLine();
                    int intInput = int.Parse(input);
                    switch (intInput)
                    {
                        case 1:
                            menegerservice.LoadMenegerMenu();
                            break;
                        case 2:
                            Console.WriteLine("client");
                            break;
                        case 3:
                            continueProgram = false;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException
                                ("Enter only 1 or 2");
                    }
                }
                catch (ArgumentOutOfRangeException exc)
                {
                    Console.Clear();
                    Console.WriteLine($"{exc.Message}. Try again");
                }
                catch (Exception exc)
                {
                    Console.Clear();
                    Console.WriteLine($"{exc.Message} Enter an integer");
                }
            }

        }
    }
}
