namespace PoELadder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_db_sets_for_depth_and_challanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Challenges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Depths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Solo = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Accounts", "Challenges_Id", c => c.Int());
            AddColumn("dbo.Characters", "Depth_Id", c => c.Int());
            CreateIndex("dbo.Accounts", "Challenges_Id");
            CreateIndex("dbo.Characters", "Depth_Id");
            AddForeignKey("dbo.Accounts", "Challenges_Id", "dbo.Challenges", "Id");
            AddForeignKey("dbo.Characters", "Depth_Id", "dbo.Depths", "Id");
            DropColumn("dbo.Accounts", "Challenges_Total");
            DropColumn("dbo.Characters", "Depth_Solo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Characters", "Depth_Solo", c => c.Int());
            AddColumn("dbo.Accounts", "Challenges_Total", c => c.Int(nullable: false));
            DropForeignKey("dbo.Characters", "Depth_Id", "dbo.Depths");
            DropForeignKey("dbo.Accounts", "Challenges_Id", "dbo.Challenges");
            DropIndex("dbo.Characters", new[] { "Depth_Id" });
            DropIndex("dbo.Accounts", new[] { "Challenges_Id" });
            DropColumn("dbo.Characters", "Depth_Id");
            DropColumn("dbo.Accounts", "Challenges_Id");
            DropTable("dbo.Depths");
            DropTable("dbo.Challenges");
        }
    }
}
