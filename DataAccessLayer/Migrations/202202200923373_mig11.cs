namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "BlogRating", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "BlogRatingx");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "BlogRatingx", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "BlogRating");
        }
    }
}
