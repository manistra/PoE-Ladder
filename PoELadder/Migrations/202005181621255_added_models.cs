﻿namespace PoELadder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrentLeagueSSFPlayers",
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
            
            CreateTable(
                "dbo.StandardHCSSFPlayers",
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
            DropTable("dbo.StandardHCSSFPlayers");
            DropTable("dbo.CurrentLeagueSSFPlayers");
        }
    }
}
