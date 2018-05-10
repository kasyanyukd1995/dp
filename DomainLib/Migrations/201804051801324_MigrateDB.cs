namespace DomainLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssServiceman_Id = c.Int(),
                        Instrument_Id = c.Int(),
                        Service_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssServicemen", t => t.AssServiceman_Id)
                .ForeignKey("dbo.Instruments", t => t.Instrument_Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .Index(t => t.AssServiceman_Id)
                .Index(t => t.Instrument_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.AssServicemen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date_Ass = c.DateTime(nullable: false),
                        Date_UnAss = c.DateTime(nullable: false),
                        Instrument_Id = c.Int(),
                        Serviceman_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instruments", t => t.Instrument_Id)
                .ForeignKey("dbo.Servicemen", t => t.Serviceman_Id)
                .Index(t => t.Instrument_Id)
                .Index(t => t.Serviceman_Id);
            
            CreateTable(
                "dbo.Instruments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameInstrument = c.String(),
                        Description = c.String(),
                        AccountingDate = c.DateTime(nullable: false),
                        YearIssue = c.String(),
                        Date_ofderegistration = c.DateTime(nullable: false),
                        DecisionOprtn = c.String(),
                        SerialNumber = c.String(),
                        InventoryNumber = c.String(),
                        Condition = c.String(),
                        AddirionalInf = c.String(),
                        Characteristic = c.String(),
                        Service_Id = c.Int(),
                        Serviceman_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .ForeignKey("dbo.Servicemen", t => t.Serviceman_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.Serviceman_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameService = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servicemen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Surname = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Accounts", "Instrument_Id", "dbo.Instruments");
            DropForeignKey("dbo.Accounts", "AssServiceman_Id", "dbo.AssServicemen");
            DropForeignKey("dbo.AssServicemen", "Serviceman_Id", "dbo.Servicemen");
            DropForeignKey("dbo.AssServicemen", "Instrument_Id", "dbo.Instruments");
            DropForeignKey("dbo.Instruments", "Serviceman_Id", "dbo.Servicemen");
            DropForeignKey("dbo.Instruments", "Service_Id", "dbo.Services");
            DropIndex("dbo.Instruments", new[] { "Serviceman_Id" });
            DropIndex("dbo.Instruments", new[] { "Service_Id" });
            DropIndex("dbo.AssServicemen", new[] { "Serviceman_Id" });
            DropIndex("dbo.AssServicemen", new[] { "Instrument_Id" });
            DropIndex("dbo.Accounts", new[] { "Service_Id" });
            DropIndex("dbo.Accounts", new[] { "Instrument_Id" });
            DropIndex("dbo.Accounts", new[] { "AssServiceman_Id" });
            DropTable("dbo.Servicemen");
            DropTable("dbo.Services");
            DropTable("dbo.Instruments");
            DropTable("dbo.AssServicemen");
            DropTable("dbo.Accounts");
        }
    }
}
