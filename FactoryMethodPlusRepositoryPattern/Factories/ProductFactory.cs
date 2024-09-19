using FactoryMethodPlusRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPlusRepositoryPattern.Factories
{
    // Factories/ProductFactory.cs
    public class ProductFactory : IProductFactory
    {
        public Product CreateProduct(int id, string name, decimal price)
        {
            return new Product(id, name, price);
        }
    }
}
