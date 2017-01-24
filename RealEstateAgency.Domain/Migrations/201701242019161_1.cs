namespace RealEstateAgency.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(nullable: false),
                        Offer_Type = c.String(nullable: false),
                        Market = c.String(),
                        Location = c.String(nullable: false),
                        Area = c.Int(nullable: false),
                        Rooms = c.Int(nullable: false),
                        Parcel_Type = c.String(),
                        Garage_Construction = c.String(),
                        Local_Purpose = c.String(),
                        Entered_DT = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Offers");
        }
    }
}
