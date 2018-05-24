namespace DomainLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmirgaton : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "AssServiceman_Id", "dbo.AssServicemen");
            DropIndex("dbo.Accounts", new[] { "AssServiceman_Id" });
            AddColumn("dbo.Accounts", "AccountingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accounts", "Date_ofderegistration", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accounts", "DecisionOprtn", c => c.String());
            AddColumn("dbo.Accounts", "SerialNumber", c => c.String());
            AddColumn("dbo.Accounts", "InventoryNumber", c => c.String());
            AddColumn("dbo.Accounts", "Condition", c => c.String());
            AddColumn("dbo.Accounts", "AddirionalInf", c => c.String());
            AddColumn("dbo.Accounts", "Serviceman_Id", c => c.Int());
            CreateIndex("dbo.Accounts", "Serviceman_Id");
            AddForeignKey("dbo.Accounts", "Serviceman_Id", "dbo.Servicemen", "Id");
            DropColumn("dbo.Accounts", "AssServiceman_Id");
            DropColumn("dbo.Instruments", "AccountingDate");
            DropColumn("dbo.Instruments", "Date_ofderegistration");
            DropColumn("dbo.Instruments", "DecisionOprtn");
            DropColumn("dbo.Instruments", "SerialNumber");
            DropColumn("dbo.Instruments", "InventoryNumber");
            DropColumn("dbo.Instruments", "Condition");
            DropColumn("dbo.Instruments", "AddirionalInf");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instruments", "AddirionalInf", c => c.String());
            AddColumn("dbo.Instruments", "Condition", c => c.String());
            AddColumn("dbo.Instruments", "InventoryNumber", c => c.String());
            AddColumn("dbo.Instruments", "SerialNumber", c => c.String());
            AddColumn("dbo.Instruments", "DecisionOprtn", c => c.String());
            AddColumn("dbo.Instruments", "Date_ofderegistration", c => c.DateTime(nullable: false));
            AddColumn("dbo.Instruments", "AccountingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accounts", "AssServiceman_Id", c => c.Int());
            DropForeignKey("dbo.Accounts", "Serviceman_Id", "dbo.Servicemen");
            DropIndex("dbo.Accounts", new[] { "Serviceman_Id" });
            DropColumn("dbo.Accounts", "Serviceman_Id");
            DropColumn("dbo.Accounts", "AddirionalInf");
            DropColumn("dbo.Accounts", "Condition");
            DropColumn("dbo.Accounts", "InventoryNumber");
            DropColumn("dbo.Accounts", "SerialNumber");
            DropColumn("dbo.Accounts", "DecisionOprtn");
            DropColumn("dbo.Accounts", "Date_ofderegistration");
            DropColumn("dbo.Accounts", "AccountingDate");
            CreateIndex("dbo.Accounts", "AssServiceman_Id");
            AddForeignKey("dbo.Accounts", "AssServiceman_Id", "dbo.AssServicemen", "Id");
        }
    }
}
