namespace GuitarsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bodies",
                c => new
                    {
                        GuitarId = c.Int(nullable: false),
                        Wood = c.String(),
                        Cover = c.Boolean(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GuitarId)
                .ForeignKey("dbo.Guitars", t => t.GuitarId)
                .Index(t => t.GuitarId);
            
            CreateTable(
                "dbo.Guitars",
                c => new
                    {
                        GuitarId = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GuitarId);
            
            CreateTable(
                "dbo.Necks",
                c => new
                    {
                        GuitarId = c.Int(nullable: false),
                        Wood = c.String(),
                        FretsCount = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GuitarId)
                .ForeignKey("dbo.Guitars", t => t.GuitarId)
                .Index(t => t.GuitarId);
            
            CreateTable(
                "dbo.Pickups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        GuitarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guitars", t => t.GuitarId, cascadeDelete: true)
                .Index(t => t.GuitarId);
            
            CreateTable(
                "dbo.GuitarStrings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gauge = c.String(),
                        Metal = c.String(),
                        GuitarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guitars", t => t.GuitarId, cascadeDelete: true)
                .Index(t => t.GuitarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bodies", "GuitarId", "dbo.Guitars");
            DropForeignKey("dbo.GuitarStrings", "GuitarId", "dbo.Guitars");
            DropForeignKey("dbo.Pickups", "GuitarId", "dbo.Guitars");
            DropForeignKey("dbo.Necks", "GuitarId", "dbo.Guitars");
            DropIndex("dbo.GuitarStrings", new[] { "GuitarId" });
            DropIndex("dbo.Pickups", new[] { "GuitarId" });
            DropIndex("dbo.Necks", new[] { "GuitarId" });
            DropIndex("dbo.Bodies", new[] { "GuitarId" });
            DropTable("dbo.GuitarStrings");
            DropTable("dbo.Pickups");
            DropTable("dbo.Necks");
            DropTable("dbo.Guitars");
            DropTable("dbo.Bodies");
        }
    }
}
