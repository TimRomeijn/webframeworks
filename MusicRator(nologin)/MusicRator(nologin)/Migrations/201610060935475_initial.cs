namespace MusicRator_nologin_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        Title = c.String(),
                        Artist = c.String(),
                        ReleaseYear = c.Int(nullable: false),
                        Description = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GenreModels", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.GenreModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReviewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewText = c.String(),
                        Rating = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        GenreModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AlbumModels", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.GenreModels", t => t.GenreModel_Id)
                .Index(t => t.UserId)
                .Index(t => t.AlbumId)
                .Index(t => t.GenreModel_Id);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlbumModels", "GenreId", "dbo.GenreModels");
            DropForeignKey("dbo.ReviewModels", "GenreModel_Id", "dbo.GenreModels");
            DropForeignKey("dbo.ReviewModels", "UserId", "dbo.UserModels");
            DropForeignKey("dbo.ReviewModels", "AlbumId", "dbo.AlbumModels");
            DropIndex("dbo.ReviewModels", new[] { "GenreModel_Id" });
            DropIndex("dbo.ReviewModels", new[] { "AlbumId" });
            DropIndex("dbo.ReviewModels", new[] { "UserId" });
            DropIndex("dbo.AlbumModels", new[] { "GenreId" });
            DropTable("dbo.UserModels");
            DropTable("dbo.ReviewModels");
            DropTable("dbo.GenreModels");
            DropTable("dbo.AlbumModels");
        }
    }
}
