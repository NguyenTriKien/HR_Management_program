namespace AssignmentSameIndex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
