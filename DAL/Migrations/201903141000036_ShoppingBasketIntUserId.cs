namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingBasketIntUserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingBaskets", "userId_Id", "dbo.Users");
            DropIndex("dbo.ShoppingBaskets", new[] { "userId_Id" });
            RenameColumn(table: "dbo.ShoppingBaskets", name: "userId_Id", newName: "userId");
            AlterColumn("dbo.ShoppingBaskets", "userId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingBaskets", "userId");
            AddForeignKey("dbo.ShoppingBaskets", "userId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingBaskets", "userId", "dbo.Users");
            DropIndex("dbo.ShoppingBaskets", new[] { "userId" });
            AlterColumn("dbo.ShoppingBaskets", "userId", c => c.Int());
            RenameColumn(table: "dbo.ShoppingBaskets", name: "userId", newName: "userId_Id");
            CreateIndex("dbo.ShoppingBaskets", "userId_Id");
            AddForeignKey("dbo.ShoppingBaskets", "userId_Id", "dbo.Users", "Id");
        }
    }
}
