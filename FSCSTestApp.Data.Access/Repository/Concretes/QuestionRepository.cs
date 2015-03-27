using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using FSCSTestApp.Data.Access.EntityModel;
using FSCSTestApp.Data.Access.Factories;
using FSCSTestApp.Data.Access.Repository.Abstracts;
using FSCSTestApp.Data.Access.UnitOfWork.Interfaces;

namespace FSCSTestApp.Data.Access.Repository.Concretes
{
    public class QuestionRepository: AbstractRepository<Question,int>
    {
        private IUnitOfWork _unitOfWork;

        public QuestionRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override Question GetById(int key)
        {
           return DBContextFactory.GetDbContextInstance().Questions.SingleOrDefault(p => p.QuestionId == key);
        }
        public override int Add(Question instance)
        {
            DBContextFactory.GetDbContextInstance().Questions.Add(instance);
            _unitOfWork.SaveChanges();
            return instance.QuestionId;
        }
        public override bool Delete(int key)
        {
            try
            {
                var entity = GetById(key);
                DBContextFactory.GetDbContextInstance().Questions.Remove(entity);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool Update(Question instance)
        {
            try
            {
                var entity = GetById(instance.QuestionId); 
                if (instance.QuestionId > 0)
                    entity.QuestionId = instance.QuestionId;
                if (!string.IsNullOrEmpty(instance.QuestionText))
                    entity.QuestionText = instance.QuestionText;
                if (instance.Answers != null)
                    entity.Answers = instance.Answers;
                if (instance.UIPage != null)
                    entity.UIPage = instance.UIPage;
                if (instance.PageId > 0)
                    entity.PageId = instance.PageId;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Question> GetAnswersWithQuestionsForPageTitle(string pageTitle)
        {
            var page = (new UIPageRepository(new UnitOfWork.Concretes.UnitOfWork())).GetPageByPageTitle(pageTitle);
            if (page != null) {
            var questions = GetAll().Where(p => p.PageId == page.PageId);

            return questions;
            }
            return new List<Question>();
        }

        public IEnumerable<StudentGradePerQuestionAnswer> GetStudentGradePerQuestionAnswers(int studentId)
        {
            var db = DBContextFactory.GetDbContextInstance().Database;
            var cmd = db.Connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[GetResultsStudentGradesPerQuestion]";
            SqlParameter parameter = new SqlParameter{ParameterName = "@studentId"};
            parameter.Value = studentId;
            cmd.Parameters.Add(parameter);
            try
            {
                var con = cmd.Connection;
                db.Connection.Open();

                var reader = cmd.ExecuteReader();

                //Two result sets: returned from reader:
                var students = ((IObjectContextAdapter)DBContextFactory.GetDbContextInstance()).ObjectContext.Translate<Student>(reader);

                foreach (var st in students)
                {

                }
                reader.NextResult();

                var studentQuestionAnswerGrades =
                    ((IObjectContextAdapter)DBContextFactory.GetDbContextInstance()).ObjectContext.Translate<StudentGradePerQuestionAnswer>(reader);

                return studentQuestionAnswerGrades.ToList();
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                db.Connection.Close();
            }
            return null;
        }

        public IEnumerable<StudentGradePerQuestionAnswer> GetAllStudentGradePerQuestionAnswers()
        {
            var db = DBContextFactory.GetDbContextInstance().Database;
            var cmd = db.Connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[GetAllResultsStudentGradesPerQuestion]";
            try
            {
                var con = cmd.Connection;
                db.Connection.Open();

                var reader = cmd.ExecuteReader();

                //Two result sets: returned from reader:
                var students = ((IObjectContextAdapter)DBContextFactory.GetDbContextInstance()).ObjectContext.Translate<Student>(reader);

                foreach (var st in students)
                {

                }
                reader.NextResult();

                var studentQuestionAnswerGrades =
                    ((IObjectContextAdapter)DBContextFactory.GetDbContextInstance()).ObjectContext.Translate<StudentGradePerQuestionAnswer>(reader);

                return studentQuestionAnswerGrades.ToList();
            }
            catch (Exception e)
            {

            }
            finally
            {
                db.Connection.Close();
            }
            return null;
        }
    }
}
