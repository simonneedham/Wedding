namespace Wedding.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RequestSong : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SongRequest",
                c => new
                    {
                        SongRequestId = c.Int(nullable: false, identity: true),
                        SongName = c.String(maxLength: 255),
                        ArtistName = c.String(maxLength: 100),
                        IPAddress = c.String(nullable: false, maxLength: 100),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SongRequestId);
            
        }
        
        public override void Down()
        {
            DropTable("SongRequest");
        }
    }
}
