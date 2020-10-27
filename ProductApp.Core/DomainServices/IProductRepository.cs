using System;
using System.Collections.Generic;
using System.Text;
using ProductApp.Core.Entity;

namespace ProductApp.Core.DomainServices
{
    public interface IProductRepository
    {
        IEnumerable<Product> ReadAll();
        Product Create(Product product);
        Product ReadById(int id);
        Product Update(Product updateProduct);
        Product Delete(int id);
    }
}
