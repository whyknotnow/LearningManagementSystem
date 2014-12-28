namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LMSEntitites : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Kod = c.String(nullable: false, maxLength: 3),
                        OgretimGorevlisiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OgretimGorevlisis", t => t.OgretimGorevlisiId, cascadeDelete: true)
                .Index(t => t.OgretimGorevlisiId);
            
            CreateTable(
                "dbo.OgrenciDers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DersID = c.Int(nullable: false),
                        OgrenciId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ders", t => t.DersID, cascadeDelete: true)
                .ForeignKey("dbo.Ogrencis", t => t.OgrenciId, cascadeDelete: true)
                .Index(t => t.DersID)
                .Index(t => t.OgrenciId);
            
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Soyad = c.String(nullable: false),
                        KimlikNo = c.String(nullable: false, maxLength: 11),
                        EPosta = c.String(nullable: false),
                        DogumTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OgretimGorevlisis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Soyad = c.String(nullable: false),
                        KimlikNo = c.String(nullable: false, maxLength: 11),
                        EPosta = c.String(nullable: false),
                        DogumTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ders", "OgretimGorevlisiId", "dbo.OgretimGorevlisis");
            DropForeignKey("dbo.OgrenciDers", "OgrenciId", "dbo.Ogrencis");
            DropForeignKey("dbo.OgrenciDers", "DersID", "dbo.Ders");
            DropIndex("dbo.OgrenciDers", new[] { "OgrenciId" });
            DropIndex("dbo.OgrenciDers", new[] { "DersID" });
            DropIndex("dbo.Ders", new[] { "OgretimGorevlisiId" });
            DropTable("dbo.OgretimGorevlisis");
            DropTable("dbo.Ogrencis");
            DropTable("dbo.OgrenciDers");
            DropTable("dbo.Ders");
        }
    }
}
