namespace OnlineNative.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NativeProducts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Description = c.String(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(maxLength: 255),
                        InitialAddress = c.String(),
                        IsNew = c.Boolean(nullable: false),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        DispatchedDate = c.DateTime(),
                        DeliveredDate = c.DateTime(),
                        DeliveryAddress_Id = c.Guid(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.DeliveryAddress_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.DeliveryAddress_Id)
                .Index(t => t.User_Id);
            
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
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Order_Id = c.Guid(nullable: false),
                        Product_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.NativeProducts", t => t.Product_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 80),
                        PhoneNumber = c.String(),
                        IsDisabled = c.Boolean(nullable: false),
                        RegisteredDate = c.DateTime(nullable: false),
                        LastLogonDate = c.DateTime(),
                        Contact = c.String(),
                        ContactAddress_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.ContactAddress_Id)
                .Index(t => t.ContactAddress_Id);
            
            CreateTable(
                "dbo.ProductCategorizations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CategoryId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ShoppingCartItems",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Guid(),
                        ShoopingCart_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NativeProducts", t => t.Product_Id)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoopingCart_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.ShoopingCart_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCartItems", "ShoopingCart_Id", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ShoppingCartItems", "Product_Id", "dbo.NativeProducts");
            DropForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "ContactAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.OrderItems", "Product_Id", "dbo.NativeProducts");
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "DeliveryAddress_Id", "dbo.Addresses");
            DropIndex("dbo.ShoppingCartItems", new[] { "ShoopingCart_Id" });
            DropIndex("dbo.ShoppingCartItems", new[] { "Product_Id" });
            DropIndex("dbo.ShoppingCarts", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "ContactAddress_Id" });
            DropIndex("dbo.OrderItems", new[] { "Product_Id" });
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "DeliveryAddress_Id" });
            DropTable("dbo.ShoppingCartItems");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.ProductCategorizations");
            DropTable("dbo.Users");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Addresses");
            DropTable("dbo.Orders");
            DropTable("dbo.NativeProducts");
            DropTable("dbo.Categories");
        }
    }
}
