namespace Warships.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Battles",
                c => new
                    {
                        BattleId = c.Int(nullable: false, identity: true),
                        BattleName = c.String(),
                    })
                .PrimaryKey(t => t.BattleId);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipId = c.Int(nullable: false, identity: true),
                        ShipName = c.String(),
                        ShipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipId)
                .ForeignKey("dbo.ShipTypes", t => t.ShipTypeId, cascadeDelete: true)
                .Index(t => t.ShipTypeId);
            
            CreateTable(
                "dbo.ShipTypes",
                c => new
                    {
                        ShipTypeId = c.Int(nullable: false, identity: true),
                        ShipTypeName = c.String(),
                    })
                .PrimaryKey(t => t.ShipTypeId);
            
            CreateTable(
                "dbo.ShipBattles",
                c => new
                    {
                        Ship_ShipId = c.Int(nullable: false),
                        Battle_BattleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ship_ShipId, t.Battle_BattleId })
                .ForeignKey("dbo.Ships", t => t.Ship_ShipId, cascadeDelete: true)
                .ForeignKey("dbo.Battles", t => t.Battle_BattleId, cascadeDelete: true)
                .Index(t => t.Ship_ShipId)
                .Index(t => t.Battle_BattleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ships", "ShipTypeId", "dbo.ShipTypes");
            DropForeignKey("dbo.ShipBattles", "Battle_BattleId", "dbo.Battles");
            DropForeignKey("dbo.ShipBattles", "Ship_ShipId", "dbo.Ships");
            DropIndex("dbo.ShipBattles", new[] { "Battle_BattleId" });
            DropIndex("dbo.ShipBattles", new[] { "Ship_ShipId" });
            DropIndex("dbo.Ships", new[] { "ShipTypeId" });
            DropTable("dbo.ShipBattles");
            DropTable("dbo.ShipTypes");
            DropTable("dbo.Ships");
            DropTable("dbo.Battles");
        }
    }
}
