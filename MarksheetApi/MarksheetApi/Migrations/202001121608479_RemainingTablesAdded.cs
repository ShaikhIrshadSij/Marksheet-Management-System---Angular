namespace MarksheetApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemainingTablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BunchCounters",
                c => new
                    {
                        BunchCounterId = c.Int(nullable: false, identity: true),
                        BunchNumber = c.Int(nullable: false),
                        BunchUploadedBy = c.String(),
                        BunchUploadTime = c.DateTime(nullable: false),
                        BunchTotal = c.Int(nullable: false),
                        BunchType = c.String(),
                    })
                .PrimaryKey(t => t.BunchCounterId);
            
            CreateTable(
                "dbo.MarksheetErrors",
                c => new
                    {
                        MarksheetErrorId = c.Int(nullable: false, identity: true),
                        EnrollmentNo = c.String(),
                        Semester = c.String(),
                        Month = c.String(),
                        Year = c.String(),
                        Department = c.String(),
                        StatementNo = c.String(),
                        BunchNumber = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedTime = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.MarksheetErrorId);
            
            CreateTable(
                "dbo.Marksheets",
                c => new
                    {
                        MarksheetId = c.Int(nullable: false, identity: true),
                        EnrollementNo = c.String(),
                        Department = c.String(),
                        StatementNo = c.String(),
                        Year = c.String(),
                        Month = c.String(),
                        UploadType = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        DisapprovedReason = c.String(),
                        IsApprovedMailSent = c.Boolean(nullable: false),
                        IsDisapprovedMailSent = c.Boolean(nullable: false),
                        Semester = c.Int(nullable: false),
                        BunchNumber = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedTime = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.MarksheetId);
            
            CreateTable(
                "dbo.StudentErrors",
                c => new
                    {
                        StudentErrorId = c.Int(nullable: false, identity: true),
                        EnrollmentNo = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Semester = c.Int(nullable: false),
                        Department = c.String(),
                        BunchNumber = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedTime = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.StudentErrorId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        EnrollementNo = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UploadType = c.String(),
                        Department = c.String(),
                        Email = c.String(),
                        Semester = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        TransferBy = c.String(),
                        TransferTime = c.DateTime(),
                        BunchNumber = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedTime = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
            DropTable("dbo.StudentErrors");
            DropTable("dbo.Marksheets");
            DropTable("dbo.MarksheetErrors");
            DropTable("dbo.BunchCounters");
        }
    }
}
