namespace CatsNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foodisout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodModels", "FoodIsOut", c => c.Boolean(nullable: false));
            AddColumn("dbo.FoodModels", "TimeStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.FoodModels", "TimeFinish", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodModels", "TimeFinish");
            DropColumn("dbo.FoodModels", "TimeStart");
            DropColumn("dbo.FoodModels", "FoodIsOut");
        }
    }
}
