namespace MusicRator_nologin_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReviewViewModels",
                c => new
                    {
                        rvId = c.Int(nullable: false, identity: true),
                        AlbumModel_Id = c.Int(),
                        ReviewModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.rvId)
                .ForeignKey("dbo.AlbumModels", t => t.AlbumModel_Id)
                .ForeignKey("dbo.ReviewModels", t => t.ReviewModel_Id)
                .Index(t => t.AlbumModel_Id)
                .Index(t => t.ReviewModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReviewViewModels", "ReviewModel_Id", "dbo.ReviewModels");
            DropForeignKey("dbo.ReviewViewModels", "AlbumModel_Id", "dbo.AlbumModels");
            DropIndex("dbo.ReviewViewModels", new[] { "ReviewModel_Id" });
            DropIndex("dbo.ReviewViewModels", new[] { "AlbumModel_Id" });
            DropTable("dbo.ReviewViewModels");
        }
    }
}
