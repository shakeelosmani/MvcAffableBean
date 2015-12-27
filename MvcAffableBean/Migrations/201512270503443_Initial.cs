namespace MvcAffableBean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            
            
            
          
            
            CreateTable(
                "dbo.OrderedProducts",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        CustomerOrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.CustomerOrderId })
                .ForeignKey("dbo.CustomerOrders", t => t.CustomerOrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerOrderId);
            
            CreateTable(
                "dbo.CustomerOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ConfirmationNumber = c.Int(nullable: false),
                        CustomerUserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerUserName)
                .Index(t => t.CustomerUserName);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerUserName = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 45),
                        Email = c.String(nullable: false),
                        Mobile = c.String(),
                        Address = c.String(maxLength: 45),
                        State = c.String(maxLength: 2),
                        CreditcardNumber = c.String(maxLength: 19),
                    })
                .PrimaryKey(t => t.CustomerUserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderedProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderedProducts", "CustomerOrderId", "dbo.CustomerOrders");
            DropForeignKey("dbo.CustomerOrders", "CustomerUserName", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.CustomerOrders", new[] { "CustomerUserName" });
            DropIndex("dbo.OrderedProducts", new[] { "CustomerOrderId" });
            DropIndex("dbo.OrderedProducts", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerOrders");
            DropTable("dbo.OrderedProducts");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
        }
    }
}
