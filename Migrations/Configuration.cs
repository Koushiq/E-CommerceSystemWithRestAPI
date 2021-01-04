namespace E_CommerceSystemWithRestAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<E_CommerceSystemWithRestAPI.Models.ECommerceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(E_CommerceSystemWithRestAPI.Models.ECommerceDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Categories.AddOrUpdate(p => p.CategoryId,
                                  new Models.Category { CategoryId = 1, CategoryName = "Electronics", CreatedAt = DateTime.Now },
                                  new Models.Category { CategoryId = 2, CategoryName = "Beauty", CreatedAt = DateTime.Now }
                                  );
            context.Admins.AddOrUpdate(p => p.AdminId,
                new Models.Admin { AdminId=1,Username="admin1",Password="1234", FirstName="Mush",LastName="Khus", CreatedAt=DateTime.Now, Role="00001" },
                 new Models.Admin { AdminId = 2, Username = "admin2", Password = "1234", FirstName = "Lush", LastName = "Mhus", CreatedAt = DateTime.Now, Role = "00001" }
                );
            // product seed
            Models.Product KLipStick = new Models.Product { ProductName = "KLipStick", Quantity = 10, Price = 100, Description = "lorem lorem lorem",FilePath="xyz", CreatedAt = DateTime.Now, CategoryId = 2 };
            Models.Product AsusHeadphone = new Models.Product { ProductName = "AsusHeadphone", Quantity = 5, Price = 400, Description = "lorem asdasdsa lorem",FilePath="asd", CreatedAt = DateTime.Now, CategoryId = 1 };
            context.Products.AddOrUpdate(p => p.ProductId, AsusHeadphone, KLipStick);
        }
    }
}
