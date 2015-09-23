namespace OnlineNative.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "DeliveryAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.Users", "ContactAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.Users", "DeliveryAddress_Id", "dbo.Addresses");
            DropIndex("dbo.Orders", new[] { "DeliveryAddress_Id" });
            DropIndex("dbo.Users", new[] { "ContactAddress_Id" });
            DropIndex("dbo.Users", new[] { "DeliveryAddress_Id" });
            AddColumn("dbo.Orders", "DeliveryAddress_Country", c => c.String());
            AddColumn("dbo.Orders", "DeliveryAddress_State", c => c.String());
            AddColumn("dbo.Orders", "DeliveryAddress_City", c => c.String());
            AddColumn("dbo.Orders", "DeliveryAddress_Street", c => c.String());
            AddColumn("dbo.Orders", "DeliveryAddress_Zip", c => c.String());
            AddColumn("dbo.Orders", "DeliveryAddress_UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Users", "ContactAddress_Country", c => c.String());
            AddColumn("dbo.Users", "ContactAddress_State", c => c.String());
            AddColumn("dbo.Users", "ContactAddress_City", c => c.String());
            AddColumn("dbo.Users", "ContactAddress_Street", c => c.String());
            AddColumn("dbo.Users", "ContactAddress_Zip", c => c.String());
            AddColumn("dbo.Users", "ContactAddress_UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Users", "DeliveryAddress_Country", c => c.String());
            AddColumn("dbo.Users", "DeliveryAddress_State", c => c.String());
            AddColumn("dbo.Users", "DeliveryAddress_City", c => c.String());
            AddColumn("dbo.Users", "DeliveryAddress_Street", c => c.String());
            AddColumn("dbo.Users", "DeliveryAddress_Zip", c => c.String());
            AddColumn("dbo.Users", "DeliveryAddress_UserId", c => c.Guid(nullable: false));
            DropColumn("dbo.Orders", "DeliveryAddress_Id");
            DropColumn("dbo.Users", "ContactAddress_Id");
            DropColumn("dbo.Users", "DeliveryAddress_Id");
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        Zip = c.String(),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "DeliveryAddress_Id", c => c.Guid());
            AddColumn("dbo.Users", "ContactAddress_Id", c => c.Guid());
            AddColumn("dbo.Orders", "DeliveryAddress_Id", c => c.Guid());
            DropColumn("dbo.Users", "DeliveryAddress_UserId");
            DropColumn("dbo.Users", "DeliveryAddress_Zip");
            DropColumn("dbo.Users", "DeliveryAddress_Street");
            DropColumn("dbo.Users", "DeliveryAddress_City");
            DropColumn("dbo.Users", "DeliveryAddress_State");
            DropColumn("dbo.Users", "DeliveryAddress_Country");
            DropColumn("dbo.Users", "ContactAddress_UserId");
            DropColumn("dbo.Users", "ContactAddress_Zip");
            DropColumn("dbo.Users", "ContactAddress_Street");
            DropColumn("dbo.Users", "ContactAddress_City");
            DropColumn("dbo.Users", "ContactAddress_State");
            DropColumn("dbo.Users", "ContactAddress_Country");
            DropColumn("dbo.Orders", "DeliveryAddress_UserId");
            DropColumn("dbo.Orders", "DeliveryAddress_Zip");
            DropColumn("dbo.Orders", "DeliveryAddress_Street");
            DropColumn("dbo.Orders", "DeliveryAddress_City");
            DropColumn("dbo.Orders", "DeliveryAddress_State");
            DropColumn("dbo.Orders", "DeliveryAddress_Country");
            CreateIndex("dbo.Users", "DeliveryAddress_Id");
            CreateIndex("dbo.Users", "ContactAddress_Id");
            CreateIndex("dbo.Orders", "DeliveryAddress_Id");
            AddForeignKey("dbo.Users", "DeliveryAddress_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Users", "ContactAddress_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Orders", "DeliveryAddress_Id", "dbo.Addresses", "Id");
        }
    }
}
