namespace _24Hour.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        PostID = c.Int(nullable: false),
                        CommentText = c.String(nullable: false, maxLength: 50),
                        ReplyCommentID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentID);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        LikeID = c.Int(nullable: false, identity: true),
                        LikedPost = c.String(),
                        UserID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LikeID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            AddColumn("dbo.Post", "UserID", c => c.Guid(nullable: false));
            DropColumn("dbo.Post", "AuthorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "AuthorID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Like", "UserID", "dbo.User");
            DropIndex("dbo.Like", new[] { "UserID" });
            DropColumn("dbo.Post", "UserID");
            DropTable("dbo.User");
            DropTable("dbo.Like");
            DropTable("dbo.Comment");
        }
    }
}
