using FactoryMethodPlusRepositoryPattern.Factories;
using FactoryMethodPlusRepositoryPattern.Repositories;
using FactoryMethodPlusRepositoryPattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPlusRepositoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProductRepository productRepository = new ProductRepository();
            IProductFactory productFactory = new ProductFactory();
            ProductService productService = new ProductService(productRepository, productFactory);

            productService.AddProduct(1, "Laptop", 999.99m);
            productService.AddProduct(2, "Smartphone", 499.99m);

            foreach (var product in productService.GetAllProducts())
            {
                Console.WriteLine($"{product.Name}: ${product.Price}");
            }
        }
    }
}
