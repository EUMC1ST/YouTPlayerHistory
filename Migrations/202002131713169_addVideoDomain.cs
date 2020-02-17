namespace YouTPlayerHistory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVideoDomain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImageURL = c.String(),
                        VideoId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Videos");
        }
    }
}
