namespace OnlineNative.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "LoginAccount", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Users", "LoginAccount", c => c.String());
        }
    }
}
