namespace MvcMusicList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MusicLists", "Artiste", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.MusicLists", "Album", c => c.String(nullable: false));
            AlterColumn("dbo.MusicLists", "Genre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MusicLists", "Genre", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.MusicLists", "Album", c => c.String());
            AlterColumn("dbo.MusicLists", "Artiste", c => c.String(maxLength: 60));
        }
    }
}
