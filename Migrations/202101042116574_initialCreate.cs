namespace E_CommerceSystemWithRestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WalletEntries", "ActionAt", c => c.DateTime());
            AddColumn("dbo.WalletEntries", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WalletEntries", "Status");
            DropColumn("dbo.WalletEntries", "ActionAt");
        }
    }
}
