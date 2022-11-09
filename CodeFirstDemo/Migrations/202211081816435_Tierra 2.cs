namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tierra2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceCustomers", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceCustomers", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.InvoiceDetailInvoices", "InvoiceDetail_InvoiceDetailID", "dbo.InvoiceDetails");
            DropForeignKey("dbo.InvoiceDetailInvoices", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.ProductInvoices", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductInvoices", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.SellerInvoices", "Seller_SellerID", "dbo.Sellers");
            DropForeignKey("dbo.SellerInvoices", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.InvoiceCustomers", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.InvoiceCustomers", new[] { "Customer_CustomerID" });
            DropIndex("dbo.InvoiceDetailInvoices", new[] { "InvoiceDetail_InvoiceDetailID" });
            DropIndex("dbo.InvoiceDetailInvoices", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.ProductInvoices", new[] { "Product_ProductID" });
            DropIndex("dbo.ProductInvoices", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.SellerInvoices", new[] { "Seller_SellerID" });
            DropIndex("dbo.SellerInvoices", new[] { "Invoice_InvoiceID" });
            AddColumn("dbo.Customers", "Invoice_InvoiceID", c => c.Int());
            CreateIndex("dbo.Customers", "Invoice_InvoiceID");
            AddForeignKey("dbo.Customers", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID");
            DropTable("dbo.InvoiceCustomers");
            DropTable("dbo.InvoiceDetailInvoices");
            DropTable("dbo.ProductInvoices");
            DropTable("dbo.SellerInvoices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SellerInvoices",
                c => new
                    {
                        Seller_SellerID = c.Int(nullable: false),
                        Invoice_InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Seller_SellerID, t.Invoice_InvoiceID });
            
            CreateTable(
                "dbo.ProductInvoices",
                c => new
                    {
                        Product_ProductID = c.Int(nullable: false),
                        Invoice_InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductID, t.Invoice_InvoiceID });
            
            CreateTable(
                "dbo.InvoiceDetailInvoices",
                c => new
                    {
                        InvoiceDetail_InvoiceDetailID = c.Int(nullable: false),
                        Invoice_InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InvoiceDetail_InvoiceDetailID, t.Invoice_InvoiceID });
            
            CreateTable(
                "dbo.InvoiceCustomers",
                c => new
                    {
                        Invoice_InvoiceID = c.Int(nullable: false),
                        Customer_CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Invoice_InvoiceID, t.Customer_CustomerID });
            
            DropForeignKey("dbo.Customers", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.Customers", new[] { "Invoice_InvoiceID" });
            DropColumn("dbo.Customers", "Invoice_InvoiceID");
            CreateIndex("dbo.SellerInvoices", "Invoice_InvoiceID");
            CreateIndex("dbo.SellerInvoices", "Seller_SellerID");
            CreateIndex("dbo.ProductInvoices", "Invoice_InvoiceID");
            CreateIndex("dbo.ProductInvoices", "Product_ProductID");
            CreateIndex("dbo.InvoiceDetailInvoices", "Invoice_InvoiceID");
            CreateIndex("dbo.InvoiceDetailInvoices", "InvoiceDetail_InvoiceDetailID");
            CreateIndex("dbo.InvoiceCustomers", "Customer_CustomerID");
            CreateIndex("dbo.InvoiceCustomers", "Invoice_InvoiceID");
            AddForeignKey("dbo.SellerInvoices", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID", cascadeDelete: true);
            AddForeignKey("dbo.SellerInvoices", "Seller_SellerID", "dbo.Sellers", "SellerID", cascadeDelete: true);
            AddForeignKey("dbo.ProductInvoices", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID", cascadeDelete: true);
            AddForeignKey("dbo.ProductInvoices", "Product_ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.InvoiceDetailInvoices", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID", cascadeDelete: true);
            AddForeignKey("dbo.InvoiceDetailInvoices", "InvoiceDetail_InvoiceDetailID", "dbo.InvoiceDetails", "InvoiceDetailID", cascadeDelete: true);
            AddForeignKey("dbo.InvoiceCustomers", "Customer_CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.InvoiceCustomers", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID", cascadeDelete: true);
        }
    }
}
