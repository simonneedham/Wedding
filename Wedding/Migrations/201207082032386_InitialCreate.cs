namespace Wedding.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        PostContent = c.String(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "Tag",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "TagPost",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Post_PostId })
                .ForeignKey("Tag", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("Post", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Post_PostId);
            
        }
        
        public override void Down()
        {
            DropIndex("TagPost", new[] { "Post_PostId" });
            DropIndex("TagPost", new[] { "Tag_TagId" });
            DropForeignKey("TagPost", "Post_PostId", "Post");
            DropForeignKey("TagPost", "Tag_TagId", "Tag");
            DropTable("TagPost");
            DropTable("Tag");
            DropTable("Post");
        }
    }
}
