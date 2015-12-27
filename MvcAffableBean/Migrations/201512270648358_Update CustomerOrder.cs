namespace MvcAffableBean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerOrders", "FirstName", c => c.String(nullable: false, maxLength: 160));
            AddColumn("dbo.CustomerOrders", "LastName", c => c.String(nullable: false, maxLength: 160));
            AddColumn("dbo.CustomerOrders", "Address", c => c.String(nullable: false, maxLength: 70));
            AddColumn("dbo.CustomerOrders", "City", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.CustomerOrders", "State", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.CustomerOrders", "PostalCode", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.CustomerOrders", "Country", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.CustomerOrders", "Phone", c => c.String(nullable: false, maxLength: 24));
            AddColumn("dbo.CustomerOrders", "Email", c => c.String(nullable: false));
            AddColumn("dbo.CustomerOrders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CustomerOrders", "ConfirmationNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerOrders", "ConfirmationNumber", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerOrders", "Total");
            DropColumn("dbo.CustomerOrders", "Email");
            DropColumn("dbo.CustomerOrders", "Phone");
            DropColumn("dbo.CustomerOrders", "Country");
            DropColumn("dbo.CustomerOrders", "PostalCode");
            DropColumn("dbo.CustomerOrders", "State");
            DropColumn("dbo.CustomerOrders", "City");
            DropColumn("dbo.CustomerOrders", "Address");
            DropColumn("dbo.CustomerOrders", "LastName");
            DropColumn("dbo.CustomerOrders", "FirstName");
        }
    }
}
