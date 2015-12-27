namespace MvcAffableBean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerOrders", "CustomerUserName", "dbo.Customers");
            DropIndex("dbo.CustomerOrders", new[] { "CustomerUserName" });
            DropPrimaryKey("dbo.Customers");
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CustomerOrders", "CustomerUserName", c => c.String());
            AddPrimaryKey("dbo.Customers", "Id");
            DropColumn("dbo.Customers", "CustomerUserName");
            DropColumn("dbo.Customers", "Name");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Mobile");
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "CreditcardNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CreditcardNumber", c => c.String(maxLength: 19));
            AddColumn("dbo.Customers", "State", c => c.String(maxLength: 2));
            AddColumn("dbo.Customers", "Address", c => c.String(maxLength: 45));
            AddColumn("dbo.Customers", "Mobile", c => c.String());
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 45));
            AddColumn("dbo.Customers", "CustomerUserName", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.CustomerOrders", "CustomerUserName", c => c.String(maxLength: 128));
            DropColumn("dbo.Customers", "Id");
            AddPrimaryKey("dbo.Customers", "CustomerUserName");
            CreateIndex("dbo.CustomerOrders", "CustomerUserName");
            AddForeignKey("dbo.CustomerOrders", "CustomerUserName", "dbo.Customers", "CustomerUserName");
        }
    }
}
