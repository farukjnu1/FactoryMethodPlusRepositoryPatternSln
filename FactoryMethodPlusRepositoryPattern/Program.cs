using FactoryMethodPlusRepositoryPattern.Factories;
using FactoryMethodPlusRepositoryPattern.Models;
using FactoryMethodPlusRepositoryPattern.Repositories;
using FactoryMethodPlusRepositoryPattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FactoryMethodPlusRepositoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProductRepository productRepository = new ProductRepository();
            IProductFactory productFactory = new ProductFactory();
            ProductService productService = new ProductService(productRepository, productFactory);

            /*productService.AddProduct(1, "Laptop", 999.99m);
            productService.AddProduct(2, "Smartphone", 499.99m);

            foreach (var product in productService.GetAllProducts())
            {
                Console.WriteLine($"{product.Name}: ${product.Price}");
            }*/

            AddCommands();
            bool isRunning = true;
            while (isRunning)
            {
                try
                {
                    var command = Console.ReadLine().ToLower();
                    if (command == "y")
                    {
                        Console.Clear();
                        AddCommands();
                    }
                    else if (command == "x")
                    {
                        isRunning = false;
                    }
                    else if (command == "r")
                    {
                        Console.WriteLine("Type 'a' to read one product or type 'all' to read all products");
                        command = Console.ReadLine();
                        if (command == "a")
                        {
                            Console.WriteLine("Type a product id");
                            var id = Convert.ToInt32(Console.ReadLine());
                            var product = productService.GetById(id);
                            if (product != null)
                            {
                                Console.WriteLine($"{product.Name}: ${product.Price}");
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                            }
                        }
                        else if (command == "all")
                        {
                            // Read and display product
                            Console.WriteLine("Reading all products");
                            foreach (var product in productService.GetAllProducts())
                            {
                                Console.WriteLine($"{product.Name}: ${product.Price}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("'" + command + "'" + " is not a valid command.");
                        }
                    }
                    else if (command == "c")
                    {
                        Console.WriteLine("Type a product id");
                        var id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Type a product name");
                        var name = Console.ReadLine();
                        Console.WriteLine("Type a product price");
                        var price = Convert.ToDecimal(Console.ReadLine());
                        // Create a new product
                        productService.AddProduct(id, name, price);
                        Console.WriteLine("'" + name + "' as product, created successfully.");
                    }
                    else if (command == "u")
                    {
                        Console.WriteLine("Type a product id");
                        var id = Convert.ToInt32(Console.ReadLine());
                        var product = productService.GetById(id);
                        if (product != null)
                        {
                            Console.WriteLine("Reading a product");
                            Console.WriteLine($"{product.Name}: ${product.Price}");

                            Console.WriteLine("Type a product name");
                            var name = Console.ReadLine();
                            Console.WriteLine("Type a product price");
                            var price = Convert.ToDecimal(Console.ReadLine());
                            // Update a product
                            productService.UpdateProduct(id, name, price);
                            Console.WriteLine("'" + name + "' as product, updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                    }
                    else if (command == "d")
                    {
                        Console.WriteLine("Type a product id");
                        var id = Convert.ToInt32(Console.ReadLine());
                        var product = productService.GetById(id);
                        if (product != null)
                        {
                            Console.WriteLine("Reading a product");
                            Console.WriteLine($"{product.Name}: ${product.Price}");

                            // Confirm deletion
                            productService.DeleteProduct(id);
                            Console.WriteLine("'" + product.Name + "' as product, deletd successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("'" + command + "'" + " is not a valid command.");
                    }
                }
                catch { }
            }
        }

        static void AddCommands()
        {
            Console.WriteLine("Press 'C' for creation of product");
            Console.WriteLine("Press 'R' for read a product");
            Console.WriteLine("Press 'U' for update of product");
            Console.WriteLine("Press 'D' for deletion of product");
            Console.WriteLine("Press 'Y' for clear window and 'X' for exit");
            Console.WriteLine("-------------------------------------------");
        }
    }
}
