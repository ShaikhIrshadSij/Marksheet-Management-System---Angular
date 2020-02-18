namespace MarksheetApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Name = c.String(),
                        ImageUrl = c.String(),
                        CreatedBy = c.String(),
                        CreatedTime = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
