using NPOI.SS.Formula.Functions;
using StoreAccountingApplication.Brokers;
using StoreAccountingApplication.Models;
using StoreAccountingApplication.Services;

namespace StoreAccountingApplication
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IStorageBroker broker = new StorageBroker();
            IStorageBroker storageBroker = new StorageBroker();
            ILoadMenu loadMenu = new LoadMenu();

            Console.WriteLine("\t\t\t\t" +
                "Welcome to the Store account application." +
                ""+ Environment.NewLine);

            Console.WriteLine("\t\t\t\t\t=====Menu=====\n");            
            loadMenu.LoadExsitingMenu();
        }
    }
}
