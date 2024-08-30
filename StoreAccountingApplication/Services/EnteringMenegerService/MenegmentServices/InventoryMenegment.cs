﻿using StoreAccountingApplication.Models;

namespace StoreAccountingApplication.Services.EnteringMenegerService.MenegmentServices
{
    public class InventoryMenegment : IInventoryMenegment
    {
        ILoggingService loggingService;
        IFileService<Product> fileService;
        public InventoryMenegment()
        {
            loggingService = new LoggingService();
            fileService = new FileServiceForSavingProductData();
        }
        public void LoadMenu()
        {
            Console.Clear();
            bool continueProg = true;
            while (continueProg)
            {
                string menu = "" +
                    "1. Show product stock\n" +
                    "2. Search product\n" +
                    "3. Add new product\n" +
                    "4. Edit product data\n" +
                    "5. Remove product\n" +
                    "6.Back\n";

                try
                {
                    Console.WriteLine("\t\t\t\t -------Menu-------");
                    Console.WriteLine(menu);
                    int intInput = loggingService.GetIntInput("Choose an option : ");
                    switch (intInput)
                    {
                        case 1:
                            ShowProductStock();
                            break;
                        case 2:
                            SearchProduct();
                            break;
                        case 3:
                            AddNewProduct();
                            break;
                        case 4:
                            EditProductData();
                            break;
                        case 5:
                            RemoveProduct();
                            break;
                        case 6:
                            Console.Clear();
                            continueProg = false;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Enter one of them!!!");
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

        public void ShowProductStock()
        {
            Console.Clear ();
            List<Product> Products = fileService.ReadFiles();
            if (Products.Count is 0)
            {
                Console.WriteLine("Product stock is empty!!!");
            }
            else
            {
                for (int index = 0; index < Products.Count; index++)
                {
                    Console.WriteLine($"{index + 1}. {Products[index].ProductId}\t"+
                        $"[{Products[index].ProductName}]\t[{Products[index].ProductPrice}$]\t"+
                        $"[{Products[index].Quantity}(ta/sr)]\t[until : {Products[index].ExpiryDate}]"+
                        $"\t[company : {Products[index].Manufacturer}]\n");
                }
            }
        }

        public void SearchProduct()
        {
            Console.Clear();
            List<Product> products = fileService.ReadFiles();
            if (products.Count == 0)
            {
                Console.WriteLine
                    ("There are no products to edit.");

                return;
            }
            bool continueProg = true;
            while (continueProg)
            {
                try
                {
                    string input = loggingService.GetStringInput("Enter product ID or name : ");
                    if (int.TryParse(input, out int productId))
                    {
                        Product? product = products.FirstOrDefault
                            (product => product.ProductId == productId);

                        if (product is not null)
                        {
                            Console.WriteLine
                                ($"{product.ProductId}  [{product.ProductName}] " +
                                $" [{product.ProductPrice}$]  [{product.Quantity}(kg/sr)] " +
                                $" [until : {product.ExpiryDate}]  [company : {product.Manufacturer}]\n");
                            continueProg = false;
                        }
                        else
                            throw new InvalidOperationException("Product with the ID does not exist.");
                    }
                    else
                    {
                        Product? product = products.FirstOrDefault(product =>
                            product.ProductName.Equals(input, StringComparison.OrdinalIgnoreCase));

                        if (product is not null)
                        {
                            Console.WriteLine
                                ($"{product.ProductId}  [{product.ProductName}] " +
                                $" [{product.ProductPrice}$]  [{product.Quantity}(kg/sr)] " +
                                $" [until : {product.ExpiryDate}]  [company : {product.Manufacturer}]\n");
                            continueProg = false;
                        }
                        else
                            throw new InvalidOperationException("Product with the name does not exist");
                    }

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public void AddNewProduct()
        {
            Console.Clear();
            List<Product> products = fileService.ReadFiles();
            int productId = GetUniqueProductId(products);
            string productName = GetUniqueProductName(products);
            decimal price = loggingService.GetDecimalInput("Enter Product Price: ");
            int quantity = loggingService.GetIntInput("Enter the quantity of product: ");
            DateTime expiryDate = GetValidDateTime("Enter expiry date of product (mm/dd/yy hh:mm:ss): ");
            string manufacturer = loggingService.GetStringInput("Enter Manufacturer: ");

            Product newProduct = new Product
            {
                ProductId = productId,
                ProductName = productName,
                ProductPrice = price,
                Quantity = quantity,
                ExpiryDate = expiryDate,
                Manufacturer = manufacturer
            };

            products.Add(newProduct);
            fileService.WriteToFIle(newProduct);
            Console.WriteLine("Product successfully added.");
        }

        public void EditProductData()
        {
            Console.Clear();
            List<Product> products = fileService.ReadFiles();
            if (products.Count == 0)
            {
                Console.WriteLine
                    ("There are no products to edit.");

                return;
            }
            bool continueProg = true;
            while (continueProg)
            {
                try
                {
                    string input = loggingService.
                        GetStringInput("Enter product ID or name : ");

                    if (int.TryParse(input, out int productId))
                    {
                        Product? product = products.FirstOrDefault
                            (product => product.ProductId == productId);

                        if (product is not null)
                        {
                            products.Remove(product);
                            int productID = GetUniqueProductId(products);
                            string productName = GetUniqueProductName(products);
                            decimal price = loggingService.GetDecimalInput("Enter Product Price: ");
                            int quantity = loggingService.GetIntInput("Enter the quantity of product: ");
                            DateTime expiryDate = GetValidDateTime("Enter expiry date of product (mm/dd/yy hh:mm:ss): ");
                            string manufacturer = loggingService.GetStringInput("Enter Manufacturer: ");

                            Product newProduct = new Product
                            {
                                ProductId = productID,
                                ProductName = productName,
                                ProductPrice = price,
                                Quantity = quantity,
                                ExpiryDate = expiryDate,
                                Manufacturer = manufacturer
                            };
                            products.Add(newProduct);
                            fileService.SaveAllToFile(products);
                            Console.WriteLine("Product data was successfully changed.");
                            continueProg = false;
                        }
                        else
                            throw new InvalidOperationException("Product with the ID does not exist.");
                    }
                    else
                    {
                        Product? product = products.FirstOrDefault(product =>
                            product.ProductName.Equals(input, StringComparison.OrdinalIgnoreCase));

                        if (product is not null)
                        {
                            products.Remove(product);
                            int productID = GetUniqueProductId(products);
                            string productName = GetUniqueProductName(products);
                            decimal price = loggingService.GetDecimalInput("Enter Product Price: ");
                            int quantity = loggingService.GetIntInput("Enter the quantity of product: ");
                            DateTime expiryDate = GetValidDateTime("Enter expiry date of product (mm/dd/yy hh:mm:ss): ");
                            string manufacturer = loggingService.GetStringInput("Enter Manufacturer: ");

                            Product newProduct = new Product
                            {
                                ProductId = productID,
                                ProductName = productName,
                                ProductPrice = price,
                                Quantity = quantity,
                                ExpiryDate = expiryDate,
                                Manufacturer = manufacturer
                            };
                            products.Add(newProduct);
                            fileService.SaveAllToFile(products);
                            Console.WriteLine("Product data was successfully changed.");
                            continueProg = false;
                        }
                        else
                            throw new InvalidOperationException("Product with the name does not exist");
                    }

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public void RemoveProduct()
        {
            Console.Clear();
            List<Product> products = fileService.ReadFiles();
            if (products.Count == 0)
            {
                Console.WriteLine
                    ("There are no products to remove.");

                return;
            }
            bool continueProg = true;
            while (continueProg)
            {
                try
                {
                    string input = loggingService.
                        GetStringInput("Enter product ID or name : ");

                    if (int.TryParse(input, out int productId))
                    {
                        Product? product = products.FirstOrDefault
                            (product => product.ProductId == productId);

                        if (product is not null)
                        {
                            products.Remove(product);
                            fileService.SaveAllToFile(products);
                            Console.WriteLine("Product removed successfully");
                            continueProg = false;
                        }
                        else
                            throw new InvalidOperationException("Product with the ID does not exist.");
                    }
                    else
                    {
                        Product? product = products.FirstOrDefault(product =>
                            product.ProductName.Equals(input, StringComparison.OrdinalIgnoreCase));

                        if (product is not null)
                        {
                            products.Remove(product);
                            fileService.SaveAllToFile(products);
                            Console.WriteLine("Product removed successfully");
                            continueProg = false;
                        }
                        else
                            throw new InvalidOperationException("Product with the name does not exist");
                    }

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        private int GetUniqueProductId(List<Product> products)
        {
            while (true)
            {
                try
                {
                    int productId = loggingService.GetIntInput("Give unique Id for new Product: ");
                    if (products.Any(product => product.ProductId == productId))
                    {
                        throw new InvalidOperationException("This Id is already assigned to another Product! Try again.");
                    }
                    return productId;
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string GetUniqueProductName(List<Product> products)
        {
            while (true)
            {
                try
                {
                    string productName = loggingService.GetStringInput("Enter Product name: ");
                    if (products.Any(product => product.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new InvalidOperationException("This product already exists! Try again.");
                    }
                    return productName;
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private DateTime GetValidDateTime(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime dateTimeOffset))
                    {
                        return dateTimeOffset;
                    }
                    else
                    {
                        throw new FormatException("Invalid date format! Please enter the date in a valid format.");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}