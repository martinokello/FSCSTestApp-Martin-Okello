using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FSCSTestApp.Data.Access.EntityModel;
using FSCSTestApp.Data.Access.Factories;
using FSCSTestApp.Data.Access.Repository.Abstracts;
using FSCSTestApp.Data.Access.UnitOfWork.Interfaces;

namespace FSCSTestApp.Data.Access.Repository.Concretes
{
    public class StudentRepository: AbstractRepository<Student,int>
    {
        private IUnitOfWork _unitOfWork;

        public StudentRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override Student GetById(int key)
        {
           return DBContextFactory.GetDbContextInstance().Students.SingleOrDefault(p => p.StudentId == key);
        }

        public override bool Delete(int key)
        {
            try
            {
                var entity = GetById(key);
                DBContextFactory.GetDbContextInstance().Students.Remove(entity);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override int Add(Student instance)
        {
            DBContextFactory.GetDbContextInstance().Students.Add(instance);
            _unitOfWork.SaveChanges();
            return instance.StudentId;
        }
        public override bool Update(Student instance)
        {
            try
            {
                var entity = GetById(instance.StudentId);
                if (instance.StudentId > 0)
                    entity.StudentId = instance.StudentId;
                if (!string.IsNullOrEmpty(instance.FirstName))
                    entity.FirstName = instance.FirstName;
                if (!string.IsNullOrEmpty(instance.LastName))
                    entity.LastName = instance.LastName;
                if (instance.StudentId > 0)
                    entity.StudentId = instance.StudentId;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
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
