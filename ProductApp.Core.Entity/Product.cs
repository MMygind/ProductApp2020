using System;
using System.Security.Authentication.ExtendedProtection;

namespace ProductApp.Core.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
    }
}
