namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RootDb_v2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Brands", new[] { "Name" });
            DropIndex("dbo.Products", new[] { "Name" });
            DropIndex("dbo.Users", new[] { "Name" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Users", "Name");
            CreateIndex("dbo.Products", "Name");
            CreateIndex("dbo.Brands", "Name");
        }
    }
}
