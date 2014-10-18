namespace FSCSTestApp.Data.Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGradeEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.Students", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Students", new[] { "QuestionId" });
            DropIndex("dbo.Students", new[] { "AnswerId" });
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        Grade = c.String(),
                        StudentId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.QuestionId);
            
            AddColumn("dbo.Students", "FirstName", c => c.String());
            AddColumn("dbo.Students", "LastName", c => c.String());
            DropColumn("dbo.Students", "QuestionId");
            DropColumn("dbo.Students", "AnswerId");
            DropColumn("dbo.Students", "Grade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Grade", c => c.String());
            AddColumn("dbo.Students", "AnswerId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "QuestionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Grades", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Grades", new[] { "QuestionId" });
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropColumn("dbo.Students", "LastName");
            DropColumn("dbo.Students", "FirstName");
            DropTable("dbo.Grades");
            CreateIndex("dbo.Students", "AnswerId");
            CreateIndex("dbo.Students", "QuestionId");
            AddForeignKey("dbo.Students", "QuestionId", "dbo.Questions", "QuestionId");
            AddForeignKey("dbo.Students", "AnswerId", "dbo.Answers", "AnswerId", cascadeDelete: true);
        }
    }
}
