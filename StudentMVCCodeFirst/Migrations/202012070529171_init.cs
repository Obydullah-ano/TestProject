namespace StudentMVCCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUser",
                c => new
                    {
                        AppUserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.AppUserId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        IsSitAvailable = c.Boolean(nullable: false),
                        CourseFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageName = c.String(),
                        ImageUrl = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.tblRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        UserId = c.Int(nullable: false),
                        tblUsers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUser", t => t.tblUsers_Id)
                .Index(t => t.tblUsers_Id);
            
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPassword = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblRole", "tblUsers_Id", "dbo.tblUser");
            DropForeignKey("dbo.Student", "CourseId", "dbo.Course");
            DropIndex("dbo.tblRole", new[] { "tblUsers_Id" });
            DropIndex("dbo.Student", new[] { "CourseId" });
            DropTable("dbo.tblUser");
            DropTable("dbo.tblRole");
            DropTable("dbo.Student");
            DropTable("dbo.Course");
            DropTable("dbo.AppUser");
        }
    }
}
