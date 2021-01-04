namespace E_CommerceSystemWithRestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ECommerceDB_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Role = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.WalletEntries",
                c => new
                    {
                        WalletEntryId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                        AdminId = c.Int(),
                        RequestedAt = c.DateTime(nullable: false),
                        ActionAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.WalletEntryId)
                .ForeignKey("dbo.Admins", t => t.AdminId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        Balance = c.Single(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        TotalCost = c.Single(nullable: false),
                        Express = c.Int(nullable: false),
                        Status = c.String(nullable: false),
                        DateOrdered = c.DateTime(nullable: false),
                        DateDelivered = c.DateTime(),
                        CustomerId = c.Int(nullable: false),
                        ShipperId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Shippers", t => t.ShipperId)
                .Index(t => t.CustomerId)
                .Index(t => t.ShipperId);
            
            CreateTable(
                "dbo.OrderedItems",
                c => new
                    {
                        OrderedItemId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        OderItemStatus = c.String(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderedItemId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        CategoryId = c.Int(nullable: false),
                        OfferId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Offers", t => t.OfferId)
                .Index(t => t.CategoryId)
                .Index(t => t.OfferId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        OfferName = c.String(nullable: false),
                        DiscountRate = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OfferId);
            
            CreateTable(
                "dbo.WishlistItems",
                c => new
                    {
                        WishlistItemId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WishlistItemId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phonenumber = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShipperId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WalletEntries", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers");
            DropForeignKey("dbo.WishlistItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.WishlistItems", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderedItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderedItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.WalletEntries", "AdminId", "dbo.Admins");
            DropIndex("dbo.WishlistItems", new[] { "CustomerId" });
            DropIndex("dbo.WishlistItems", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "OfferId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.OrderedItems", new[] { "OrderId" });
            DropIndex("dbo.OrderedItems", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "ShipperId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.WalletEntries", new[] { "AdminId" });
            DropIndex("dbo.WalletEntries", new[] { "CustomerId" });
            DropTable("dbo.Shippers");
            DropTable("dbo.WishlistItems");
            DropTable("dbo.Offers");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.OrderedItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.WalletEntries");
            DropTable("dbo.Admins");
        }
    }
}
