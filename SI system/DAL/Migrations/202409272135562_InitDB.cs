namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20),
                        SId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.SId, cascadeDelete: true)
                .Index(t => t.SId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        age = c.Int(nullable: false),
                        Grade = c.String(nullable: false),
                        address = c.String(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parents", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.ClassSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false, maxLength: 100),
                        ClassDay = c.String(nullable: false, maxLength: 20),
                        ClassTime = c.String(nullable: false, maxLength: 20),
                        SId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.SId, cascadeDelete: true)
                .Index(t => t.SId);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FatherName = c.String(nullable: false),
                        MotherName = c.String(nullable: false),
                        phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 10, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        Role = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "SId", "dbo.Students");
            DropForeignKey("dbo.Students", "ParentId", "dbo.Parents");
            DropForeignKey("dbo.ClassSchedules", "SId", "dbo.Students");
            DropIndex("dbo.ClassSchedules", new[] { "SId" });
            DropIndex("dbo.Students", new[] { "ParentId" });
            DropIndex("dbo.Attendances", new[] { "SId" });
            DropTable("dbo.Users");
            DropTable("dbo.Parents");
            DropTable("dbo.ClassSchedules");
            DropTable("dbo.Students");
            DropTable("dbo.Attendances");
        }
    }
}
