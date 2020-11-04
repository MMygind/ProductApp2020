using ProductApp.Core.DomainServices;
using ProductApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Core.ApplicationServices.Services
{
    public class ProductTypeService: IProductTypeService
    {
        private readonly IProductTypeRepository _prodTypeRepo;
        private readonly IProductRepository _prodRepo;

        public ProductTypeService(IProductTypeRepository productTypeRepository, IProductRepository productRepository)
        {
            _prodTypeRepo = productTypeRepository;
            _prodRepo = productRepository;
        }

        public ProductType CreateProductType(ProductType productType)
        {
            return _prodTypeRepo.Create(productType);
        }

        public ProductType NewProductType(string name)
        {
            var productType = new ProductType()
            {
                Name = name
            };
            return productType;
        }
    }
}
