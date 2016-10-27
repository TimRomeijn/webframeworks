namespace MusicRator_nologin_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inlogtabel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginViewModels",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.LoginId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoginViewModels");
        }
    }
}
