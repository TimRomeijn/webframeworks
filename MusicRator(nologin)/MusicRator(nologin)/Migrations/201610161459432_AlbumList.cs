namespace MusicRator_nologin_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlbumModels", "AlbumModel_Id", c => c.Int());
            CreateIndex("dbo.AlbumModels", "AlbumModel_Id");
            AddForeignKey("dbo.AlbumModels", "AlbumModel_Id", "dbo.AlbumModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlbumModels", "AlbumModel_Id", "dbo.AlbumModels");
            DropIndex("dbo.AlbumModels", new[] { "AlbumModel_Id" });
            DropColumn("dbo.AlbumModels", "AlbumModel_Id");
        }
    }
}
