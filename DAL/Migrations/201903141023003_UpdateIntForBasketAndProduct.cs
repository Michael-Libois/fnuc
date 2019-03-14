namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIntForBasketAndProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingProducts", "ShoppingBasketId_id", "dbo.ShoppingBaskets");
            DropForeignKey("dbo.ShoppingProducts", "productId_id", "dbo.Products");
            DropIndex("dbo.ShoppingProducts", new[] { "productId_id" });
            DropIndex("dbo.ShoppingProducts", new[] { "ShoppingBasketId_id" });
            RenameColumn(table: "dbo.ShoppingProducts", name: "ShoppingBasketId_id", newName: "shoppingBasketId");
            RenameColumn(table: "dbo.ShoppingProducts", name: "productId_id", newName: "productId");
            AlterColumn("dbo.ShoppingProducts", "productId", c => c.Int(nullable: false));
            AlterColumn("dbo.ShoppingProducts", "shoppingBasketId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingProducts", "productId");
            CreateIndex("dbo.ShoppingProducts", "shoppingBasketId");
            AddForeignKey("dbo.ShoppingProducts", "shoppingBasketId", "dbo.ShoppingBaskets", "id", cascadeDelete: true);
            AddForeignKey("dbo.ShoppingProducts", "productId", "dbo.Products", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingProducts", "productId", "dbo.Products");
            DropForeignKey("dbo.ShoppingProducts", "shoppingBasketId", "dbo.ShoppingBaskets");
            DropIndex("dbo.ShoppingProducts", new[] { "shoppingBasketId" });
            DropIndex("dbo.ShoppingProducts", new[] { "productId" });
            AlterColumn("dbo.ShoppingProducts", "shoppingBasketId", c => c.Int());
            AlterColumn("dbo.ShoppingProducts", "productId", c => c.Int());
            RenameColumn(table: "dbo.ShoppingProducts", name: "productId", newName: "productId_id");
            RenameColumn(table: "dbo.ShoppingProducts", name: "shoppingBasketId", newName: "ShoppingBasketId_id");
            CreateIndex("dbo.ShoppingProducts", "ShoppingBasketId_id");
            CreateIndex("dbo.ShoppingProducts", "productId_id");
            AddForeignKey("dbo.ShoppingProducts", "productId_id", "dbo.Products", "id");
            AddForeignKey("dbo.ShoppingProducts", "ShoppingBasketId_id", "dbo.ShoppingBaskets", "id");
        }
    }
}
