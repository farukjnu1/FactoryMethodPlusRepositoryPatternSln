using FactoryMethodPlusRepositoryPattern.Factories;
using FactoryMethodPlusRepositoryPattern.Models;
using FactoryMethodPlusRepositoryPattern.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FactoryMethodPlusRepositoryPattern.Services
{
    // Services/ProductService.cs
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductFactory _productFactory;

        public ProductService(IProductRepository productRepository, IProductFactory productFactory)
        {
            _productRepository = productRepository;
            _productFactory = productFactory;
        }

        public void AddProduct(int id, string name, decimal price)
        {
            var product = _productFactory.CreateProduct(id, name, price);
            _productRepository.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void UpdateProduct(int id, string name, decimal price)
        {
            var product = _productFactory.UpdateProduct(id, name, price);
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Remove(id);
        }

    }

}
