using System;
using System.Collections.Generic;
using System.Text;
using ProductApp.Core.Entity;

namespace ProductApp.Core.ApplicationServices
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product UpdateProduct(Product updateProduct);
        Product FindProductById(int id);
        Product DeleteProduct(int id);
        Product NewProduct(string name, double price, string color, string type);
        Product CreateProduct(Product product);
    }
}
