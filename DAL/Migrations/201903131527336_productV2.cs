namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productV2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "category_CategoryId" });
            RenameColumn(table: "dbo.Products", name: "category_CategoryId", newName: "categoryId");
            AlterColumn("dbo.Products", "categoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "categoryId");
            AddForeignKey("dbo.Products", "categoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "categoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "categoryId" });
            AlterColumn("dbo.Products", "categoryId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "categoryId", newName: "category_CategoryId");
            CreateIndex("dbo.Products", "category_CategoryId");
            AddForeignKey("dbo.Products", "category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
