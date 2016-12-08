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
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        PhotoID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photo", t => t.PhotoID, cascadeDelete: true)
                .Index(t => t.PhotoID);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        PhotoID = c.Guid(nullable: false),
                        Path = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        UploadedDate = c.DateTime(nullable: false),
                        Album_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.PhotoID)
                .ForeignKey("dbo.Album", t => t.Album_Id)
                .Index(t => t.Album_Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        ComID = c.Int(nullable: false, identity: true),
                        Comments = c.String(),
                        PhotoID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ComID)
                .ForeignKey("dbo.Photo", t => t.PhotoID, cascadeDelete: true)
                .Index(t => t.PhotoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "PhotoID", "dbo.Photo");
            DropForeignKey("dbo.Photo", "Album_Id", "dbo.Album");
            DropForeignKey("dbo.Album", "PhotoID", "dbo.Photo");
            DropIndex("dbo.Comment", new[] { "PhotoID" });
            DropIndex("dbo.Photo", new[] { "Album_Id" });
            DropIndex("dbo.Album", new[] { "PhotoID" });
            DropTable("dbo.Comment");
            DropTable("dbo.Photo");
            DropTable("dbo.Album");
        }
    }
}
