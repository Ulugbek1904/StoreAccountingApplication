using StoreAccountingApplication.Models;
using StoreAccountingApplication.Services.EnteringMenegerService.MenegmentServices;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace StoreAccountingApplication.Services.MenegerServices
{
    public class AuthenticationService : IAuthenticationService
    {
        ILoggingService loggingService;
        IMenegerService menegerService;
        IFileService<Meneger> fileService;
        List<Meneger> meneger;
        public AuthenticationService()
        {
            loggingService = new LoggingService();
            menegerService = new MenegerService();
            fileService = new FileServiceForMeneger();
            meneger = fileService.ReadFiles();
        }
        public void CheckPassword()
        {   foreach (Meneger jsonMeneger in meneger)
            {
                int attempt = 0;
                bool continueProg = true;
                while (continueProg)
                {
                    attempt++;
                    if (attempt >= 4)
                    {
                        Console.Clear();
                        string respond = loggingService.GetStringInput("Do you forget password?\n").ToLower();
                        if (respond == "yes" || respond == "y")
                        {
                            Console.Clear();
                            ChangePassword();
                            continueProg = false;
                        }
                        else
                        {
                            Console.Clear();
                            return;
                        }
                    }
                    else
                    {
                        string emailOrNumber = loggingService.
                            GetStringInput("Enter email or phoneNumber(e.g : +998....) : "); 
;
                        string password = loggingService.GetStringInput("Enter password : ");
                        if (emailOrNumber == jsonMeneger.Email || emailOrNumber == jsonMeneger.PhoneNumber)
                        {
                            if (password == jsonMeneger.Password)
                            {
                                menegerService.LoadMenegerMenu();
                                continueProg = false;
                            }
                            else
                            {
                                Console.WriteLine
                                    ("Your password is not correct.Try again");
                            }

                        }
                        else
                            Console.WriteLine("email or phone Number is not correct");
                    }
                }
            }
        }

        public void ChangePassword()
        {
            foreach (Meneger jsonMeneger in meneger)
            {
                bool continueProg = true;
                while (continueProg)
                {
                    Console.Write("Enter phone number : ");
                    string phoneNumber = Console.ReadLine();
                    Console.Write("Enter email address : ");
                    string emailAddress = Console.ReadLine();
                    if (phoneNumber != null && emailAddress != null)
                    {
                        if (phoneNumber == jsonMeneger.PhoneNumber && emailAddress == jsonMeneger.Email)
                        {
                            Console.Write("Enter new Password : ");
                            string newPassword = Console.ReadLine();
                            Console.Write("re enter new password : ");
                            string reenteredPassword = Console.ReadLine();
                            if (isValidPassword(newPassword) && reenteredPassword == newPassword)
                            {
                                jsonMeneger.Password = newPassword;
                                Console.WriteLine("password was successfully changed.");
                                string updatedJson = JsonSerializer.Serialize(meneger);
                                File.WriteAllText("../../../MenegerFayl.json", updatedJson);
                                continueProg = false;
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Phone number or email is incorrect. Try again");
                            continueProg = true;
                        }
                    }
                    else
                        Console.WriteLine("email or number must not be null.Try again.");
                }
            }
            
        }

        public bool isValidPassword(string passwordInput)
        {
            if (string.IsNullOrEmpty(passwordInput))
            {
                Console.WriteLine("This space must be filled.");
                return false;
            }

            if (!Regex.IsMatch(passwordInput, @"[A-Z]"))
            {
                Console.WriteLine("Password must contain at least one uppercase letter.");
                return false;
            }

            if (!Regex.IsMatch(passwordInput, @"\d"))
            {
                Console.WriteLine("Password must contain at least one number.");
                return false;
            }

            return true;
        }
    }
}
