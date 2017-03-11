namespace LAB_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePhoto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AlbumName = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        UserID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        PhotoID = c.Guid(nullable: false),
                        Path = c.String(),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        UploadedDate = c.DateTime(),
                        DateChanged = c.DateTime(),
                        UserID = c.Guid(nullable: false),
                        AlbumID = c.Guid(),
                    })
                .PrimaryKey(t => t.PhotoID)
                .ForeignKey("dbo.Album", t => t.AlbumID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.AlbumID);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        ComID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Comments = c.String(),
                        DateCreated = c.DateTime(),
                        DateChanged = c.DateTime(),
                        PhotoID = c.Guid(),
                        UserID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ComID)
                .ForeignKey("dbo.Photo", t => t.PhotoID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.PhotoID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        isAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photo", "UserID", "dbo.User");
            DropForeignKey("dbo.Comment", "UserID", "dbo.User");
            DropForeignKey("dbo.Album", "UserID", "dbo.User");
            DropForeignKey("dbo.Comment", "PhotoID", "dbo.Photo");
            DropForeignKey("dbo.Photo", "AlbumID", "dbo.Album");
            DropIndex("dbo.Comment", new[] { "UserID" });
            DropIndex("dbo.Comment", new[] { "PhotoID" });
            DropIndex("dbo.Photo", new[] { "AlbumID" });
            DropIndex("dbo.Photo", new[] { "UserID" });
            DropIndex("dbo.Album", new[] { "UserID" });
            DropTable("dbo.User");
            DropTable("dbo.Comment");
            DropTable("dbo.Photo");
            DropTable("dbo.Album");
        }
    }
}
