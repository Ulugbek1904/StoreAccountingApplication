using StoreAccountingApplication.Models;
using System.Text.RegularExpressions;

namespace StoreAccountingApplication.Services.MenegerServices
{
    public class AuthenticationService : IAuthenticationService
    {
        IFileService<Meneger> fileService;
        List<Meneger> meneger;
        public AuthenticationService()
        {
            fileService = new FileServiceForMeneger();
            meneger = fileService.ReadFiles();
        }
        public void CheckPassword()
        {   foreach (Meneger jsonMeneger in meneger)
            {
                int attempt = 1;
                bool continueProg = true;
                while (continueProg)
                {
                    if (attempt >= 4)
                    {
                        Console.Clear();
                        Console.WriteLine("Do you forget password?");
                        string respond = Console.ReadLine().ToLower();
                        if (respond == "yes" || respond == "y")
                        {
                            Console.Clear();
                            ChangePassword();
                        }
                        else
                        {
                            Console.Clear();
                            continue;
                        }
                    }
                    Console.Write("Enter email or phoneNumber(e.g : +998....) : ");
                    string emailOrNumber = Console.ReadLine();
                    Console.Write("Enter password : ");
                    string password = Console.ReadLine();
                    if (emailOrNumber == jsonMeneger.Email || emailOrNumber == jsonMeneger.PhoneNumber)
                    {
                        if (password == jsonMeneger.Password)
                        {
                            Console.WriteLine("Welcome to meneger site");
                            continueProg = false;
                        }
                        else
                        {
                            Console.WriteLine
                                ("Your password is not correct.Try again");

                            attempt++;
                        }

                    }
                    else
                        Console.WriteLine("email or phone Number is not correct");
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
                    if (phoneNumber == null && emailAddress == null)
                    {
                        if (phoneNumber == jsonMeneger.PhoneNumber && emailAddress == jsonMeneger.Email)
                        {
                            Console.Write("Enter new Password");
                            string newPassword = Console.ReadLine();
                            Console.Write("re enter new password : ");
                            string reenteredPassword = Console.ReadLine();
                            if (isValidPassword(newPassword) && reenteredPassword == newPassword)
                            {
                                jsonMeneger.Password = newPassword;
                                Console.WriteLine("password was successfully changed.");
                                continueProg = false;
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
