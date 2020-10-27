using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductApp.Core.DomainServices;
using ProductApp.Core.Entity;

namespace ProductApp.Core.ApplicationServices.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }


        public List<Product> GetAllProducts()
        {
            return _productRepo.ReadAll().ToList();
        }

        public Product UpdateProduct(Product updateProduct)
        {
            return _productRepo.Update(updateProduct);
        }

        public Product FindProductById(int id)
        {
            return _productRepo.ReadById(id);
        }

        public Product DeleteProduct(int id)
        {
            return _productRepo.Delete(id);
        }

        public Product NewProduct(string name, double price, string color, string type, DateTime createdDate)
        {
            var product = new Product()
            {
                Name = name,
                Price = price,
                Color = color,
                Type = type,
                CreatedDate = createdDate
            };
            return product;
        }

        public Product CreateProduct(Product product)
        {
            return _productRepo.Create(product);
        }
    }
}
