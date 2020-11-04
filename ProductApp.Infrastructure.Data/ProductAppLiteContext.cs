using System;
using Microsoft.EntityFrameworkCore;
using ProductApp.Core.Entity;

namespace ProductApp.Infrastructure.SQLLite.Data
{
    public class ProductAppLiteContext: DbContext
    {
        public ProductAppLiteContext(DbContextOptions<ProductAppLiteContext> opt) : base(opt) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
