namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.Categories", t => t.ParentId)
                .Index(t => t.ParentId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        publicationDate = c.DateTime(nullable: false),
                        categoryId_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.categoryId_CategoryId)
                .Index(t => t.categoryId_CategoryId);
            
            CreateTable(
                "dbo.ShoppingBaskets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.userId_Id)
                .Index(t => t.userId_Id);
            
            CreateTable(
                "dbo.ShoppingProducts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        productId_id = c.Int(),
                        ShoppingBasketId_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.productId_id)
                .ForeignKey("dbo.ShoppingBaskets", t => t.ShoppingBasketId_id)
                .Index(t => t.productId_id)
                .Index(t => t.ShoppingBasketId_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingBaskets", "userId_Id", "dbo.Users");
            DropForeignKey("dbo.ShoppingProducts", "ShoppingBasketId_id", "dbo.ShoppingBaskets");
            DropForeignKey("dbo.ShoppingProducts", "productId_id", "dbo.Products");
            DropForeignKey("dbo.Products", "categoryId_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.ShoppingProducts", new[] { "ShoppingBasketId_id" });
            DropIndex("dbo.ShoppingProducts", new[] { "productId_id" });
            DropIndex("dbo.ShoppingBaskets", new[] { "userId_Id" });
            DropIndex("dbo.Products", new[] { "categoryId_CategoryId" });
            DropIndex("dbo.Categories", new[] { "Category_CategoryId" });
            DropIndex("dbo.Categories", new[] { "ParentId" });
            DropTable("dbo.Users");
            DropTable("dbo.ShoppingProducts");
            DropTable("dbo.ShoppingBaskets");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
