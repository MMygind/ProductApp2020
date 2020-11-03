using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using ProductApp.Core.Entity;
using ProductApp.Infrastructure.SQLLite.Data.Helpers;

namespace ProductApp.Infrastructure.SQLLite.Data
{
    public class DBInitializer: IDBInitializer
    {
        private IAuthenticationHelper authenticationHelper;
        public DBInitializer(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }
        public void SeedDB(ProductAppLiteContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            if (ctx.TodoItems.Any())
            {
                return;
                //ctx.Database.ExecuteSqlRaw("DROP TABLE Pets");
                //ctx.Database.ExecuteSqlRaw("DROP Table Owner");
                //ctx.Database.ExecuteSqlRaw("DROP Table Todo");
                //ctx.Database.ExecuteSqlRaw("DROP Table Token");
                //ctx.Database.EnsureCreated();
            }

            ctx.Products.Add(new Product()
            {
                Name = "Hulk Hogan",
                Price = 1500,
                Color = "Yellow",
                Type = "Wrestler"
            });

            ctx.Products.Add(new Product()
            {
                Name = "John Cena",
                Price = 1500,
                Color = "Blue",
                Type = "Wrestler"
            });

            ctx.Products.Add(new Product()
            {
                Name = "Sting",
                Price = 1500,
                Color = "Black",
                Type = "Wrestler"
            });

            List<TodoItem> items = new List<TodoItem>
            {
                new TodoItem { IsComplete=true, Name="Make homework"},
                new TodoItem { IsComplete=false, Name="Sleep"}
            };

            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            authenticationHelper.CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            authenticationHelper.CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };

            ctx.TodoItems.AddRange(items);
            ctx.Users.AddRange(users);

            ctx.SaveChanges();
        }
    }
}
