namespace PoELadder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_twitch : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Accounts", "Twitch_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Twitch_Name", c => c.String());
        }
    }
}
