namespace OnlineNative.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "LoginAccount", c => c.String());
            AddColumn("dbo.Users", "DeliveryAddress_Id", c => c.Guid());
            CreateIndex("dbo.Users", "DeliveryAddress_Id");
            AddForeignKey("dbo.Users", "DeliveryAddress_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "DeliveryAddress_Id", "dbo.Addresses");
            DropIndex("dbo.Users", new[] { "DeliveryAddress_Id" });
            DropColumn("dbo.Users", "DeliveryAddress_Id");
            DropColumn("dbo.Users", "LoginAccount");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
        }
    }
}
