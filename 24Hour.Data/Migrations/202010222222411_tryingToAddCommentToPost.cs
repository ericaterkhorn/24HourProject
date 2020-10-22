namespace _24Hour.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingToAddCommentToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Like", "PostID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "PostID");
            AddForeignKey("dbo.Comment", "PostID", "dbo.Post", "PostID", cascadeDelete: true);
            DropColumn("dbo.Like", "LikedPost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Like", "LikedPost", c => c.String());
            DropForeignKey("dbo.Comment", "PostID", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "PostID" });
            DropColumn("dbo.Like", "PostID");
        }
    }
}
