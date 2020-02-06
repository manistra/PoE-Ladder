namespace PoELadder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_StandardPlayer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StandardPlayers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rank = c.Int(nullable: false),
                        Dead = c.Boolean(nullable: false),
                        Online = c.Boolean(nullable: false),
                        AccountName = c.String(),
                        TotalChallenges = c.Int(nullable: false),
                        CharacterName = c.String(),
                        CharacterLevel = c.Int(nullable: false),
                        CharacterClass = c.String(),
                        CharacterDepthSolo = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StandardPlayers");
        }
    }
}
