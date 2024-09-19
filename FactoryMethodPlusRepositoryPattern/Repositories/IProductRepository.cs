using FactoryMethodPlusRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPlusRepositoryPattern.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
    }
}
