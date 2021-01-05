namespace E_CommerceSystemWithRestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WalletEntryUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.WalletEntries", name: "AdminId", newName: "Admin_AdminId");
            RenameIndex(table: "dbo.WalletEntries", name: "IX_AdminId", newName: "IX_Admin_AdminId");
            AddColumn("dbo.WalletEntries", "Status", c => c.String());
            AlterColumn("dbo.WalletEntries", "RequestedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WalletEntries", "RequestedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.WalletEntries", "Status");
            RenameIndex(table: "dbo.WalletEntries", name: "IX_Admin_AdminId", newName: "IX_AdminId");
            RenameColumn(table: "dbo.WalletEntries", name: "Admin_AdminId", newName: "AdminId");
        }
    }
}
