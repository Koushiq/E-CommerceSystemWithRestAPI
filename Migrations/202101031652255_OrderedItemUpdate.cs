namespace E_CommerceSystemWithRestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderedItemUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderedItems", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderedItems", "CustomerId");
            AddForeignKey("dbo.OrderedItems", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedItems", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderedItems", new[] { "CustomerId" });
            DropColumn("dbo.OrderedItems", "CustomerId");
        }
    }
}
