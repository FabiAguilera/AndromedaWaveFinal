namespace AndromedaWave.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductMigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Product");
            DropColumn("dbo.Product", "ProdId");
            DropColumn("dbo.Product", "ProdName");
            DropColumn("dbo.Product", "ProdPrice");
            DropColumn("dbo.Product", "ProdStatus");
            AddColumn("dbo.Product", "TicketId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Product", "EventName", c => c.String(nullable: false));
            AddColumn("dbo.Product", "TicketPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Product", "Admission", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "StatusOfTicket", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Product", "TicketId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Product");
            DropColumn("dbo.Product", "StatusOfTicket");
            DropColumn("dbo.Product", "Admission");
            DropColumn("dbo.Product", "TicketPrice");
            DropColumn("dbo.Product", "EventName");
            DropColumn("dbo.Product", "TicketId");
            AddColumn("dbo.Product", "ProdStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "ProdPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Product", "ProdName", c => c.String(nullable: false));
            AddColumn("dbo.Product", "ProdId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Product", "ProdId");
        }
    }
}
