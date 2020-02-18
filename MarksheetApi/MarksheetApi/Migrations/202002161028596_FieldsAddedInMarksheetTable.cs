namespace MarksheetApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldsAddedInMarksheetTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marksheets", "ApprovedTime", c => c.DateTime());
            AddColumn("dbo.Marksheets", "DisapprovedTime", c => c.DateTime());
            AddColumn("dbo.Marksheets", "ApprovedBy", c => c.String());
            AddColumn("dbo.Marksheets", "DisApprovedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Marksheets", "DisApprovedBy");
            DropColumn("dbo.Marksheets", "ApprovedBy");
            DropColumn("dbo.Marksheets", "DisapprovedTime");
            DropColumn("dbo.Marksheets", "ApprovedTime");
        }
    }
}
