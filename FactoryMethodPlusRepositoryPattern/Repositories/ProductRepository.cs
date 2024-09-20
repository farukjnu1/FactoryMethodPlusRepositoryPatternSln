using FactoryMethodPlusRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPlusRepositoryPattern.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            var _product = _products.FirstOrDefault(p => p.Id == product.Id);
            if (_product != null)
            {
                _product.Name = product.Name;
                _product.Price = product.Price;
            }
        }

        public void Remove(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null) 
            {
                _products.Remove(product);
            }
        }
    }
}
