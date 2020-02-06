namespace PoELadder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edited_the_model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StandardLeague", "CharacterLevel", c => c.Int(nullable: false));
            AddColumn("dbo.StandardLeague", "CharacterClass", c => c.String());
            AddColumn("dbo.StandardLeague", "CharacterDepthSolo", c => c.Int());
            DropColumn("dbo.StandardLeague", "Level");
            DropColumn("dbo.StandardLeague", "Class");
            DropColumn("dbo.StandardLeague", "DepthSolo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StandardLeague", "DepthSolo", c => c.Int());
            AddColumn("dbo.StandardLeague", "Class", c => c.String());
            AddColumn("dbo.StandardLeague", "Level", c => c.Int(nullable: false));
            DropColumn("dbo.StandardLeague", "CharacterDepthSolo");
            DropColumn("dbo.StandardLeague", "CharacterClass");
            DropColumn("dbo.StandardLeague", "CharacterLevel");
        }
    }
}
