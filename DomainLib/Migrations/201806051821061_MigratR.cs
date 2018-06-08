namespace DomainLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigratR : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instruments", "Srvicemn_Id", "dbo.Srvicemns");
            DropIndex("dbo.Instruments", new[] { "Srvicemn_Id" });
            DropColumn("dbo.Instruments", "Srvicemn_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instruments", "Srvicemn_Id", c => c.Int());
            CreateIndex("dbo.Instruments", "Srvicemn_Id");
            AddForeignKey("dbo.Instruments", "Srvicemn_Id", "dbo.Srvicemns", "Id");
        }
    }
}
