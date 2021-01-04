namespace E_CommerceSystemWithRestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product_Update_FilePath : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "FilePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "FilePath", c => c.String(nullable: false));
        }
    }
}
