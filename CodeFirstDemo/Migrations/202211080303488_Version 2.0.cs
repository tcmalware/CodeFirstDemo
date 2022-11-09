namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        DNI = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        InvoiceDetailID = c.Int(nullable: false, identity: true),
                        CantProd = c.String(),
                        Local = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceDetailID);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        IDVendedor = c.String(),
                    })
                .PrimaryKey(t => t.SellerID);
            
            CreateTable(
                "dbo.InvoiceCustomers",
                c => new
                    {
                        Invoice_InvoiceID = c.Int(nullable: false),
                        Customer_CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Invoice_InvoiceID, t.Customer_CustomerID })
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID, cascadeDelete: true)
                .Index(t => t.Invoice_InvoiceID)
                .Index(t => t.Customer_CustomerID);
            
            CreateTable(
                "dbo.InvoiceDetailInvoices",
                c => new
                    {
                        InvoiceDetail_InvoiceDetailID = c.Int(nullable: false),
                        Invoice_InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InvoiceDetail_InvoiceDetailID, t.Invoice_InvoiceID })
                .ForeignKey("dbo.InvoiceDetails", t => t.InvoiceDetail_InvoiceDetailID, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID, cascadeDelete: true)
                .Index(t => t.InvoiceDetail_InvoiceDetailID)
                .Index(t => t.Invoice_InvoiceID);
            
            CreateTable(
                "dbo.SellerInvoices",
                c => new
                    {
                        Seller_SellerID = c.Int(nullable: false),
                        Invoice_InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Seller_SellerID, t.Invoice_InvoiceID })
                .ForeignKey("dbo.Sellers", t => t.Seller_SellerID, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID, cascadeDelete: true)
                .Index(t => t.Seller_SellerID)
                .Index(t => t.Invoice_InvoiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellerInvoices", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.SellerInvoices", "Seller_SellerID", "dbo.Sellers");
            DropForeignKey("dbo.InvoiceDetailInvoices", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceDetailInvoices", "InvoiceDetail_InvoiceDetailID", "dbo.InvoiceDetails");
            DropForeignKey("dbo.InvoiceCustomers", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.InvoiceCustomers", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.SellerInvoices", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.SellerInvoices", new[] { "Seller_SellerID" });
            DropIndex("dbo.InvoiceDetailInvoices", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.InvoiceDetailInvoices", new[] { "InvoiceDetail_InvoiceDetailID" });
            DropIndex("dbo.InvoiceCustomers", new[] { "Customer_CustomerID" });
            DropIndex("dbo.InvoiceCustomers", new[] { "Invoice_InvoiceID" });
            DropTable("dbo.SellerInvoices");
            DropTable("dbo.InvoiceDetailInvoices");
            DropTable("dbo.InvoiceCustomers");
            DropTable("dbo.Sellers");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Customers");
        }
    }
}
