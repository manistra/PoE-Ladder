namespace PoELadder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_RootObject : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Rootobjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rootobjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
