namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Parent_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.Parent_CategoryId)
                .Index(t => t.Parent_CategoryId);
            
            AddColumn("dbo.Products", "categoryId_CategoryId", c => c.Int());
            CreateIndex("dbo.Products", "categoryId_CategoryId");
            AddForeignKey("dbo.Products", "categoryId_CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "categoryId_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Parent_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "categoryId_CategoryId" });
            DropIndex("dbo.Categories", new[] { "Parent_CategoryId" });
            DropColumn("dbo.Products", "categoryId_CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
