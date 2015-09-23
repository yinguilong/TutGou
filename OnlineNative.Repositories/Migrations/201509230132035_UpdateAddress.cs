namespace OnlineNative.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddress : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "DeliveryAddress_UserId");
            DropColumn("dbo.Users", "ContactAddress_UserId");
            DropColumn("dbo.Users", "DeliveryAddress_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "DeliveryAddress_UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Users", "ContactAddress_UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Orders", "DeliveryAddress_UserId", c => c.Guid(nullable: false));
        }
    }
}
