namespace Wedding.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddRsvp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Rsvp",
                c => new
                    {
                        RsvpId = c.Int(nullable: false, identity: true),
                        Invitees = c.String(nullable: false, maxLength: 255),
                        Email = c.String(maxLength: 255),
                        NoOfAttendees = c.Int(nullable: false),
                        DietaryRequirements = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.RsvpId);
            
        }
        
        public override void Down()
        {
            DropTable("Rsvp");
        }
    }
}
