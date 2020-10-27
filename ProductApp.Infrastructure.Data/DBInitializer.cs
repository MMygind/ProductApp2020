using System;
using System.Collections.Generic;
using System.Text;
using ProductApp.Core.Entity;

namespace ProductApp.Infrastructure.SQLLite.Data
{
    public class DBInitializer: IDBInitializer
    {
        public void SeedDB(ProductAppLiteContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            ctx.Products.Add(new Product()
            {
                Name = "Hulk Hogan",
                Price = 1500,
                Color = "Yellow",
                Type = "Wrestler",
                CreatedDate = new DateTime(2019, 05, 05)
            });
            ctx.SaveChanges();
        }
    }
}
