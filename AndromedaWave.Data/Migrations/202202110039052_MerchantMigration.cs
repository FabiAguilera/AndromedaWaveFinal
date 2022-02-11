namespace AndromedaWave.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MerchantMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Merchant",
                c => new
                    {
                        MerchantId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.MerchantId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Merchant");
        }
    }
}
