using FactoryMethodPlusRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPlusRepositoryPattern.Factories
{
    // Factories/IProductFactory.cs
    public interface IProductFactory
    {
        Product CreateProduct(int id, string name, decimal price);
        Product UpdateProduct(int id, string name, decimal price);
    }
}
