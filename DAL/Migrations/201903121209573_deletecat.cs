namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentId", "dbo.Categories");
            DropForeignKey("dbo.Products", "categoryId_CategoryId", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "ParentId" });
            DropIndex("dbo.Categories", new[] { "Category_CategoryId" });
            DropIndex("dbo.Products", new[] { "categoryId_CategoryId" });
            DropColumn("dbo.Products", "categoryId_CategoryId");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Products", "categoryId_CategoryId", c => c.Int());
            CreateIndex("dbo.Products", "categoryId_CategoryId");
            CreateIndex("dbo.Categories", "Category_CategoryId");
            CreateIndex("dbo.Categories", "ParentId");
            AddForeignKey("dbo.Products", "categoryId_CategoryId", "dbo.Categories", "CategoryId");
            AddForeignKey("dbo.Categories", "ParentId", "dbo.Categories", "CategoryId");
            AddForeignKey("dbo.Categories", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
