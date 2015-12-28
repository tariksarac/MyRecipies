namespace MyRecipies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FriendId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FriendId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.FriendId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.IngredientId)
                .Index(t => t.RecipeId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeItems", "UnitId", "dbo.Units");
            DropForeignKey("dbo.RecipeItems", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "UserId", "dbo.Users");
            DropForeignKey("dbo.RecipeItems", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.FriendLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.FriendLists", "FriendId", "dbo.Users");
            DropIndex("dbo.Recipes", new[] { "UserId" });
            DropIndex("dbo.RecipeItems", new[] { "UnitId" });
            DropIndex("dbo.RecipeItems", new[] { "RecipeId" });
            DropIndex("dbo.RecipeItems", new[] { "IngredientId" });
            DropIndex("dbo.FriendLists", new[] { "UserId" });
            DropIndex("dbo.FriendLists", new[] { "FriendId" });
            DropTable("dbo.Units");
            DropTable("dbo.Recipes");
            DropTable("dbo.RecipeItems");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Users");
            DropTable("dbo.FriendLists");
        }
    }
}
