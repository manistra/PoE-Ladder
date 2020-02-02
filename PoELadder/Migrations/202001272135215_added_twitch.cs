namespace PoELadder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_twitch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Twitch_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Twitch_Name");
        }
    }
}
