namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productv3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ShoppingBaskets", name: "userId_CategoryId", newName: "userId_Id");
            RenameIndex(table: "dbo.ShoppingBaskets", name: "IX_userId_CategoryId", newName: "IX_userId_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ShoppingBaskets", name: "IX_userId_Id", newName: "IX_userId_CategoryId");
            RenameColumn(table: "dbo.ShoppingBaskets", name: "userId_Id", newName: "userId_CategoryId");
        }
    }
}
