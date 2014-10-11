namespace FSCSTestApp.Data.Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentAddColumnGrade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Grade", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Grade");
        }
    }
}
