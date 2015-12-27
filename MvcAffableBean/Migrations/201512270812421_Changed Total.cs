namespace MvcAffableBean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTotal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerOrders", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerOrders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
