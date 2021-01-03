namespace E_CommerceSystemWithRestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "FilePath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "FilePath");
        }
    }
}
