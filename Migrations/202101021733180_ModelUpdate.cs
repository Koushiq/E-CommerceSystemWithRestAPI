namespace E_CommerceSystemWithRestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers");
            DropIndex("dbo.Orders", new[] { "ShipperId" });
            AddColumn("dbo.OrderedItems", "OderItemStatus", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "DateDelivered", c => c.DateTime());
            AlterColumn("dbo.Orders", "ShipperId", c => c.Int());
            CreateIndex("dbo.Orders", "ShipperId");
            AddForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers", "ShipperId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers");
            DropIndex("dbo.Orders", new[] { "ShipperId" });
            AlterColumn("dbo.Orders", "ShipperId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "DateDelivered", c => c.DateTime(nullable: false));
            DropColumn("dbo.OrderedItems", "OderItemStatus");
            CreateIndex("dbo.Orders", "ShipperId");
            AddForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers", "ShipperId", cascadeDelete: true);
        }
    }
}
