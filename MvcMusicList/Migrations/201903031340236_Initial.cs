namespace MvcMusicList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MusicLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Artiste = c.String(),
                        Album = c.String(),
                        Genre = c.String(),
                        Annee = c.Int(nullable: false),
                        Vues = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MusicLists");
        }
    }
}
