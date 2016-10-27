namespace MusicRator_nologin_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registratieinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.UserModels", "Password", c => c.String());
            AlterColumn("dbo.UserModels", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.UserModels", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserModels", "LastName", c => c.String());
            AlterColumn("dbo.UserModels", "FirstName", c => c.String());
            DropColumn("dbo.UserModels", "Password");
            DropColumn("dbo.UserModels", "UserName");
        }
    }
}
