namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "InvoiceDetail_InvoiceDetailID", c => c.Int());
            AddColumn("dbo.Invoices", "Product_ProductID", c => c.Int());
            AddColumn("dbo.Invoices", "Seller_SellerID", c => c.Int());
            CreateIndex("dbo.Invoices", "InvoiceDetail_InvoiceDetailID");
            CreateIndex("dbo.Invoices", "Product_ProductID");
            CreateIndex("dbo.Invoices", "Seller_SellerID");
            AddForeignKey("dbo.Invoices", "InvoiceDetail_InvoiceDetailID", "dbo.InvoiceDetails", "InvoiceDetailID");
            AddForeignKey("dbo.Invoices", "Product_ProductID", "dbo.Products", "ProductID");
            AddForeignKey("dbo.Invoices", "Seller_SellerID", "dbo.Sellers", "SellerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "Seller_SellerID", "dbo.Sellers");
            DropForeignKey("dbo.Invoices", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.Invoices", "InvoiceDetail_InvoiceDetailID", "dbo.InvoiceDetails");
            DropIndex("dbo.Invoices", new[] { "Seller_SellerID" });
            DropIndex("dbo.Invoices", new[] { "Product_ProductID" });
            DropIndex("dbo.Invoices", new[] { "InvoiceDetail_InvoiceDetailID" });
            DropColumn("dbo.Invoices", "Seller_SellerID");
            DropColumn("dbo.Invoices", "Product_ProductID");
            DropColumn("dbo.Invoices", "InvoiceDetail_InvoiceDetailID");
        }
    }
}
