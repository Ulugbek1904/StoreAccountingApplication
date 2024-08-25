using StoreAccountingApplication.Services;

namespace StoreAccountingApplication
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            ILoadMenu loadMenu = new LoadMenu();

            Console.WriteLine("\t\t\t\t" +
                "Welcome to the Store account application." +
                ""+ Environment.NewLine);

            Console.WriteLine("=====Menu=====\n");            
            loadMenu.LoadExsitingMenu();
            ICreateMenegerService service = new CreateMenegerService();
            service.CreateMeneger();
        }
    }
}
