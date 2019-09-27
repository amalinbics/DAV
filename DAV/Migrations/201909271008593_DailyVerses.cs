namespace DAV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DailyVerses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyVerses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VerseDate = c.DateTime(nullable: false),
                        VerseTitle = c.String(nullable: false, maxLength: 250),
                        Verse = c.String(nullable: false, maxLength: 2500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DailyVerses");
        }
    }
}
