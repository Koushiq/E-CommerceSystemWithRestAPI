namespace E_CommerceSystemWithRestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WalletUpdate : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Balance", c => c.Single(nullable: false));
            AddColumn("dbo.Shippers", "Phonenumber", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "Wallet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Wallet", c => c.Single(nullable: false));
            DropForeignKey("dbo.WalletEntries", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.WalletEntries", "AdminId", "dbo.Admins");
            DropIndex("dbo.WalletEntries", new[] { "AdminId" });
            DropIndex("dbo.WalletEntries", new[] { "CustomerId" });
            DropColumn("dbo.Shippers", "Phonenumber");
            DropColumn("dbo.Customers", "Balance");
            DropColumn("dbo.Customers", "Address");
            DropTable("dbo.WalletEntries");
        }
    }
}
