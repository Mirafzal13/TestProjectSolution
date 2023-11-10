using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TestProject.Common.Utility;
using TestProject.Domain.Entities;

namespace TestProject.Infrastructure.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Accounts.Any())
                {
                    var hasher = PasswordHasher.Hash("123");
                    context.Accounts.AddRange(new List<AccountEntity>()
                    {
                        new AccountEntity()
                        {
                            Id = hasher.Salt,
                            UserName = "admin",
                            PasswordHash = hasher.Hash,
                            FirstName = "Admin",
                            LastName = "Admin"
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<ProductEntity>()
                    {
                        new ProductEntity()
                        {
                            Id = Guid.NewGuid(),
                            Title = "HDD 1TB",
                            Quantity = 55,
                            Price = 74.09
                        },
                        new ProductEntity()
                        {
                            Id = Guid.NewGuid(),
                            Title = "HDD SSD 512GB",
                            Quantity = 102,
                            Price = 190.99
                        },
                        new ProductEntity()
                        {
                            Id = Guid.NewGuid(),
                            Title = "RAM DDR4 16GB",
                            Quantity = 47,
                            Price = 80.32
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
