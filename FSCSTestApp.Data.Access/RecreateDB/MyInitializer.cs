using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCSTestApp.Data.Access.Entity.Context;
using FSCSTestApp.Data.Access.EntityModel;

namespace FSCSTestApp.Data.Access.RecreateDB
{
    public class MyInitializer : DropCreateDatabaseAlways<FAQEntityContext>
    {
        protected override void Seed(FAQEntityContext context)
        {
            // seed database here
            var home = new UIPage { PageTitle = "Home", PageUrl = "~/Home/Home" };
            context.UIPages.Add(home);
            var claims = new UIPage { PageTitle = "Claims", PageUrl = "~/Home/Claims" };
            context.UIPages.Add(claims);
            var coverage = new UIPage { PageTitle = "Coverage", PageUrl = "~/Home/Coverage" };
            context.UIPages.Add(coverage);
            var faq = new UIPage { PageTitle = "FAQ", PageUrl = "~/Home/FAQ" };
            context.UIPages.Add(faq);
            context.SaveChanges();


            var q1 = new Question { PageId = home.PageId, QuestionText = "Q1: Home Page" };
            context.Questions.Add(q1);
            var q2 = new Question { PageId = home.PageId, QuestionText = "Q2: Home Page" };
            context.Questions.Add(q2);
            var q3 = new Question { PageId = home.PageId, QuestionText = "Q3: Home Page" };
            context.Questions.Add(q3);
            context.SaveChanges();


            var q11 = new Question { PageId = claims.PageId, QuestionText = "Q1: claims Page" };
            context.Questions.Add(q11);
            var q12 = new Question { PageId = claims.PageId, QuestionText = "Q2: claims Page" };
            context.Questions.Add(q12);
            var q13 = new Question { PageId = claims.PageId, QuestionText = "Q3: claims Page" };
            context.Questions.Add(q13);
            context.SaveChanges();

            var q21 = new Question { PageId = coverage.PageId, QuestionText = "Q1: coverage Page" };
            context.Questions.Add(q21);
            var q22 = new Question { PageId = coverage.PageId, QuestionText = "Q2: coverage Page" };
            context.Questions.Add(q22);
            var q23 = new Question { PageId = coverage.PageId, QuestionText = "Q3: coverage Page" };
            context.Questions.Add(q23);
            context.SaveChanges();

            var a1 = new Answer { AnswerText = "Ans 1: Home Page", QuestionId = q1.QuestionId };
            context.Answers.Add(a1);
            var a2 = new Answer { AnswerText = "Ans 2: Home Page", QuestionId = q2.QuestionId };
            context.Answers.Add(a2);
            var a3 = new Answer { AnswerText = "Ans 3: Home Page", QuestionId = q3.QuestionId };
            context.Answers.Add(a3);
            context.SaveChanges();

            var a11 = new Answer { AnswerText = "Ans 1: claims Page", QuestionId = q11.QuestionId };
            context.Answers.Add(a11);
            var a12 = new Answer { AnswerText = "Ans 2: claims Page", QuestionId = q12.QuestionId };
            context.Answers.Add(a12);
            var a13 = new Answer { AnswerText = "Ans 3: claims Page", QuestionId = q13.QuestionId };
            context.Answers.Add(a13);
            context.SaveChanges();

            var a21 = new Answer { AnswerText = "Ans 1: coverage Page", QuestionId = q21.QuestionId };
            context.Answers.Add(a21);
            var a22 = new Answer { AnswerText = "Ans 2: coverage Page", QuestionId = q22.QuestionId };
            context.Answers.Add(a22);
            var a23 = new Answer { AnswerText = "Ans 3: coverage Page", QuestionId = q23.QuestionId };
            context.Answers.Add(a23);
            context.SaveChanges();

            var st = new Student { FirstName = "Martin", LastName = "Okello" };
            context.Students.Add(st);
            context.SaveChanges();
            st = new Student { FirstName = "Leon", LastName = "Okello" };
            context.Students.Add(st);
            context.SaveChanges();
            st = new Student { FirstName = "Joanne", LastName = "Okello" };
            context.Students.Add(st);
            context.SaveChanges();


            var st2 = new Student { FirstName = "Angela", LastName = "Ferrer" };
            context.Students.Add(st2);
            context.SaveChanges();
            st2 = new Student { FirstName = "Samuel", LastName = "Kilman" };
            context.Students.Add(st2);
            context.SaveChanges();
            st2 = new Student { FirstName = "Peggy", LastName = "Layoo" };
            context.Students.Add(st2);
            context.SaveChanges();

            var grd = new Grades { Grade = "B", QuestionId = 1, StudentId = 1 };
            context.Grades.Add(grd);
            grd = new Grades { Grade = "D", QuestionId = 2, StudentId = 1 };
            context.Grades.Add(grd);
            grd = new Grades { Grade = "D", QuestionId = 3, StudentId = 1 };
            context.Grades.Add(grd);
            grd = new Grades { Grade = "A", QuestionId = 1, StudentId = 2 };
            context.Grades.Add(grd);
            grd = new Grades { Grade = "B", QuestionId = 2, StudentId = 2 };
            context.Grades.Add(grd);
            grd = new Grades { Grade = "C", QuestionId = 3, StudentId = 2 };
            context.Grades.Add(grd);
            grd = new Grades { Grade = "D", QuestionId = 1, StudentId = 3 };
            context.Grades.Add(grd);
            grd = new Grades { Grade = "B", QuestionId = 2, StudentId = 3 };
            context.Grades.Add(grd);
            grd = new Grades { Grade = "E", QuestionId = 3, StudentId = 3 };
            context.Grades.Add(grd);

            var storedProc = @"
            CREATE PROCEDURE [dbo].[GetResultsStudentGradesPerQuestion] 
	            -- Add the parameters for the stored procedure here
	            @studentId int
            AS
            BEGIN
	            -- SET NOCOUNT ON added to prevent extra result sets from
	            -- interfering with SELECT statements.
	            SET NOCOUNT ON;

                -- Insert statements for procedure here
	            select * from Students s 
	            where s.studentId = @studentId;
	
	            select s.*,q.QuestionId,q.questionText,a.answerText,g.grade
	            from questions q inner join Answers a on q.questionId = a.questionid
	            inner join grades g on g.questionId = q.questionId 
	            inner join students s on s.studentId = g.studentId
	            where s.studentId = @studentId;
            END
            ";

            var con = context.Database.Connection;

            try
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = storedProc;

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
            }
            finally
            {
                con.Close();
            }

            var storedProc2 = @"
            CREATE PROCEDURE [dbo].[GetAllResultsStudentGradesPerQuestion]
	            -- Add the parameters for the stored procedure here
            AS
            BEGIN
	            -- SET NOCOUNT ON added to prevent extra result sets from
	            -- interfering with SELECT statements.
	            SET NOCOUNT ON;

                -- Insert statements for procedure here
	            select * from Students s 
	
	            select distinct  s.*,q.QuestionId,q.questionText,g.grade,g.gradeId
	            from questions q inner join Answers a on q.questionId = a.questionid
	            inner join grades g on g.questionId = q.questionId 
                inner join students s on s.studentId = g.studentId
                order by s.StudentId asc
            END
            ";

            try
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = storedProc2;

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
            }
            finally
            {
                con.Close();

            }
        }
    }
}
