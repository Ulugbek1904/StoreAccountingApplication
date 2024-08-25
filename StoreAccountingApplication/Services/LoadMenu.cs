namespace StoreAccountingApplication.Services
{
    public class LoadMenu : ILoadMenu
    {

        public void LoadExsitingMenu()
        {
            bool continueProgram = true;
            while (continueProgram)
            {
                try
                {
                    Console.WriteLine("" +
                        "1. Enter as an store Meneger\n"
                        + "2. Enter as a client\n");

                    Console.Write("Enter option : ");
                    string input = Console.ReadLine();
                    int intInput = int.Parse(input);
                    switch (intInput)
                    {
                        case 1:
                            Console.WriteLine("owner");
                            continueProgram = false;
                            break;
                        case 2:
                            Console.WriteLine("client");
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
