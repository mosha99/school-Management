namespace ConsoleApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vol1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.classrooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        classroom_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.classrooms", t => t.classroom_Id)
                .Index(t => t.classroom_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.classrooms", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Students", "classroom_Id", "dbo.classrooms");
            DropIndex("dbo.Students", new[] { "classroom_Id" });
            DropIndex("dbo.classrooms", new[] { "Teacher_Id" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.classrooms");
        }
    }
}
