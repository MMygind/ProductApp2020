using ProductApp.Core.DomainServices;
using ProductApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Infrastructure.SQLLite.Data.Repositories
{
    public class ProductTypeRepository: IProductTypeRepository
    {
        private ProductAppLiteContext _ctx;

        public ProductTypeRepository(ProductAppLiteContext ctx)
        {
            _ctx = ctx;
        }

        public ProductType Create(ProductType productType)
        {
            var productTypeSaved = _ctx.ProductTypes.A
        }
    }
}
