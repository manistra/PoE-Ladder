namespace PoELadder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Challenges_added_depth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Challenges_Total", c => c.Int(nullable: false));
            AddColumn("dbo.Characters", "Depth_Solo", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "Depth_Solo");
            DropColumn("dbo.Accounts", "Challenges_Total");
        }
    }
}
