namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "RatingForBlog", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "BlogRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "BlogRating", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "RatingForBlog");
        }
    }
}
