namespace DomainLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationBD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountingDate = c.DateTime(nullable: false),
                        Date_ofderegistration = c.DateTime(nullable: false),
                        DecisionOprtn = c.String(),
                        SerialNumber = c.String(),
                        InventoryNumber = c.String(),
                        Condition = c.String(),
                        AddirionalInf = c.String(),
                        Instrument_Id = c.Int(),
                        Service_Id = c.Int(),
                        Srvicemn_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instruments", t => t.Instrument_Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .ForeignKey("dbo.Srvicemns", t => t.Srvicemn_Id)
                .Index(t => t.Instrument_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.Srvicemn_Id);
            
            CreateTable(
                "dbo.Instruments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameInstrument = c.String(),
                        Description = c.String(),
                        YearIssue = c.String(),
                        Characteristic = c.String(),
                        Service_Id = c.Int(),
                        Srvicemn_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .ForeignKey("dbo.Srvicemns", t => t.Srvicemn_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.Srvicemn_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameService = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Srvicemns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SN = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssSrvicemns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date_Ass = c.DateTime(nullable: false),
                        Date_UnAss = c.DateTime(nullable: false),
                        Instrument_Id = c.Int(),
                        Srvicemn_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instruments", t => t.Instrument_Id)
                .ForeignKey("dbo.Srvicemns", t => t.Srvicemn_Id)
                .Index(t => t.Instrument_Id)
                .Index(t => t.Srvicemn_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssSrvicemns", "Srvicemn_Id", "dbo.Srvicemns");
            DropForeignKey("dbo.AssSrvicemns", "Instrument_Id", "dbo.Instruments");
            DropForeignKey("dbo.Accounts", "Srvicemn_Id", "dbo.Srvicemns");
            DropForeignKey("dbo.Instruments", "Srvicemn_Id", "dbo.Srvicemns");
            DropForeignKey("dbo.Accounts", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Accounts", "Instrument_Id", "dbo.Instruments");
            DropForeignKey("dbo.Instruments", "Service_Id", "dbo.Services");
            DropIndex("dbo.AssSrvicemns", new[] { "Srvicemn_Id" });
            DropIndex("dbo.AssSrvicemns", new[] { "Instrument_Id" });
            DropIndex("dbo.Instruments", new[] { "Srvicemn_Id" });
            DropIndex("dbo.Instruments", new[] { "Service_Id" });
            DropIndex("dbo.Accounts", new[] { "Srvicemn_Id" });
            DropIndex("dbo.Accounts", new[] { "Service_Id" });
            DropIndex("dbo.Accounts", new[] { "Instrument_Id" });
            DropTable("dbo.AssSrvicemns");
            DropTable("dbo.Srvicemns");
            DropTable("dbo.Services");
            DropTable("dbo.Instruments");
            DropTable("dbo.Accounts");
        }
    }
}
