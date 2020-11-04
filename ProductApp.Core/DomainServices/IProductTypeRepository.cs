using ProductApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Core.DomainServices
{
    public interface IProductTypeRepository
    {
        ProductType Create(ProductType productType);
    }
}
