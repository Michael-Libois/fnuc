namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "categoryId_CategoryId", newName: "category_CategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_categoryId_CategoryId", newName: "IX_category_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_category_CategoryId", newName: "IX_categoryId_CategoryId");
            RenameColumn(table: "dbo.Products", name: "category_CategoryId", newName: "categoryId_CategoryId");
        }
    }
}
