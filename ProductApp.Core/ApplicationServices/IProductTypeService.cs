using ProductApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Core.ApplicationServices
{
    public interface IProductTypeService
    {
        ProductType NewProductType(string name);

        ProductType CreateProductType(ProductType productType);
    }
}
