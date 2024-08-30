namespace StoreAccountingApplication.Services
{
    public class LoggingService : ILoggingService
    {
        public int GetIntInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    return int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter a valid integer.");
                }
            }
        }

        public string GetStringInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public decimal GetDecimalInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    return decimal.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input for price! Please enter a valid decimal number.");
                }
            }
        }
    }
}
