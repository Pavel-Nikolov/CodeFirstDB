namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Brand_ID", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "Brand_ID" });
            AlterColumn("dbo.Brands", "Name", c => c.String(nullable: false, maxLength: 40, unicode: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Products", "Brand_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 75, unicode: false));
            CreateIndex("dbo.Brands", "Name");
            CreateIndex("dbo.Products", "Name");
            CreateIndex("dbo.Products", "Brand_ID");
            CreateIndex("dbo.Users", "Name");
            AddForeignKey("dbo.Products", "Brand_ID", "dbo.Brands", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Brand_ID", "dbo.Brands");
            DropIndex("dbo.Users", new[] { "Name" });
            DropIndex("dbo.Products", new[] { "Brand_ID" });
            DropIndex("dbo.Products", new[] { "Name" });
            DropIndex("dbo.Brands", new[] { "Name" });
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Brand_ID", c => c.Int());
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Brands", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Products", "Brand_ID");
            AddForeignKey("dbo.Products", "Brand_ID", "dbo.Brands", "ID");
        }
    }
}
