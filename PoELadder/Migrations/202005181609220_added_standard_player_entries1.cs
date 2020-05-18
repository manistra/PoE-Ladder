namespace PoELadder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_standard_player_entries1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StandardSFFPlayers", newName: "StandardSSFPlayers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.StandardSSFPlayers", newName: "StandardSFFPlayers");
        }
    }
}
