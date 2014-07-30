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
        }
    }
}
