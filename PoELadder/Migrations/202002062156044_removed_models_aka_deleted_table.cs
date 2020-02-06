namespace PoELadder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_models_aka_deleted_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "Challenges_Id", "dbo.Challenges");
            DropForeignKey("dbo.Characters", "Depth_Id", "dbo.Depths");
            DropForeignKey("dbo.Entries", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Entries", "Character_Id", "dbo.Characters");
            DropIndex("dbo.Accounts", new[] { "Challenges_Id" });
            DropIndex("dbo.Characters", new[] { "Depth_Id" });
            DropIndex("dbo.Entries", new[] { "Account_Id" });
            DropIndex("dbo.Entries", new[] { "Character_Id" });
            DropTable("dbo.Accounts");
            DropTable("dbo.Challenges");
            DropTable("dbo.Characters");
            DropTable("dbo.Depths");
            DropTable("dbo.Entries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rank = c.Int(nullable: false),
                        Dead = c.Boolean(nullable: false),
                        Online = c.Boolean(nullable: false),
                        Account_Id = c.Int(),
                        Character_Id = c.Int(),
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
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.Int(nullable: false),
                        Class = c.String(),
                        Experience = c.String(),
                        Depth_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Challenges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Challenges_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Entries", "Character_Id");
            CreateIndex("dbo.Entries", "Account_Id");
            CreateIndex("dbo.Characters", "Depth_Id");
            CreateIndex("dbo.Accounts", "Challenges_Id");
            AddForeignKey("dbo.Entries", "Character_Id", "dbo.Characters", "Id");
            AddForeignKey("dbo.Entries", "Account_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Characters", "Depth_Id", "dbo.Depths", "Id");
            AddForeignKey("dbo.Accounts", "Challenges_Id", "dbo.Challenges", "Id");
        }
    }
}
