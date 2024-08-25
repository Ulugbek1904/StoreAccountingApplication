using StoreAccountingApplication.Models;
using System.Text.RegularExpressions;

namespace StoreAccountingApplication.Services
{
    public class CreateMenegerService : ICreateMenegerService
    {
        private Meneger meneger;
        public CreateMenegerService()
        {
            meneger = new Meneger();
        }

        public void CreateMeneger()
        {
            bool continueProgram = true;
            while (continueProgram)
            {
                try
                {
                    Console.WriteLine("Enter passport series : ");
                    string passportNumber = Console.ReadLine();

                    if (!string.IsNullOrEmpty(passportNumber))
                    {
                        if (passportNumber == meneger.PassportNumber)
                        {
                            LoadInnerCode();
                            continueProgram = false;
                        }
                        else
                        {
                            Console.WriteLine("Passport number does not match.");
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException("Incorrect Passport number!");
                    }
                }
                catch (ArgumentNullException exc)
                {
                    Console.WriteLine(exc.Message);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }

        private void LoadInnerCode()
        {
            bool continueInnerProg = true;
            string phoneNumber = null;
            string emailAdress = null;
            string password = null;
            string reEnteredPassword = null;

            while (continueInnerProg)
            {
                try
                {
                    if (phoneNumber == null)
                    {
                        bool validPhoneNumber = false;
                        while (!validPhoneNumber)
                        {
                            Console.Write("Enter Phone Number (e.g., +998....): ");
                            phoneNumber = Console.ReadLine();
                            if (isValidNumber(phoneNumber))
                                validPhoneNumber = true;
                            else
                                Console.WriteLine("Invalid phone number. Please try again.");
                        }
                    }

                    if (emailAdress == null)
                    {
                        bool validEmail = false;
                        while (!validEmail)
                        {
                            Console.Write("Enter Email address: ");
                            emailAdress = Console.ReadLine();
                            if (isValidEmail(emailAdress))
                                validEmail = true;
                            else
                                Console.WriteLine("Invalid email address. Please try again.");
                        }
                    }

                    if (password == null)
                    {
                        bool validPassword = false;
                        while (!validPassword)
                        {
                            Console.Write("Enter password: ");
                            password = Console.ReadLine();
                            if (isValidPassword(password))
                                validPassword = true;
                        }
                    }

                    Console.Write("Re-enter the password: ");
                    reEnteredPassword = Console.ReadLine();
                    if (reEnteredPassword == password)
                    {
                        Meneger newMeneger = new Meneger()
                        {
                            Password = password,
                            PhoneNumber = phoneNumber,
                            Email = emailAdress,
                            PassportNumber = "AD0248194"
                        };
                        meneger = newMeneger;
                        continueInnerProg = false;
                        Console.WriteLine("Manager was created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Passwords do not match. Please try again.");
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }



        private bool isValidNumber(string number)
        {
            string pattern = @"^\+998\d{9}$";
            return Regex.IsMatch(number, pattern);
        }

        private bool isValidEmail(string emailInput)
        {
            string pattern = @"^\w+@gmail\.(uz|ru|com)$";
            return Regex.IsMatch(emailInput, pattern);
        }

        private bool isValidPassword(string passwordInput)
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
