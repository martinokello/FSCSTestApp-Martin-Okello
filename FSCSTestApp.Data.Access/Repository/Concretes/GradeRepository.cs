using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FSCSTestApp.Data.Access.EntityModel;
using FSCSTestApp.Data.Access.Factories;
using FSCSTestApp.Data.Access.Repository.Abstracts;
using FSCSTestApp.Data.Access.UnitOfWork.Interfaces;

namespace FSCSTestApp.Data.Access.Repository.Concretes
{
    public class GradeRepository : AbstractRepository<Grades, int>
    {
        private IUnitOfWork _unitOfWork;

        public GradeRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override Grades GetById(int key)
        {
            return DBContextFactory.GetDbContextInstance().Grades.SingleOrDefault(p => p.GradeId == key);
        }

        public Grades[] GetGradeByName(string gradeName)
        {
            gradeName = gradeName.ToUpper();
            return DBContextFactory.GetDbContextInstance().Grades.Where(p => p.Grade == gradeName).ToArray();
        }

        public Grades[] GetGradesByStudentId(int studentId)
        {
            return DBContextFactory.GetDbContextInstance().Grades.Where(p => p.StudentId == studentId).ToArray();
        }
        public override bool Delete(int key)
        {
            try
            {
                var entity = GetById(key);
                DBContextFactory.GetDbContextInstance().Grades.Remove(entity);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override int Add(Grades instance)
        {
            DBContextFactory.GetDbContextInstance().Grades.Add(instance);
            _unitOfWork.SaveChanges();
            return instance.GradeId;
        }
        public override bool Update(Grades instance)
        {
            try
            {
                var entity = GetById(instance.GradeId);
                if (instance.QuestionId > 0)
                    entity.QuestionId = instance.QuestionId;
                if (!string.IsNullOrEmpty(instance.Grade))
                    entity.Grade = instance.Grade;
                if (instance.Student != null)
                    entity.Student = instance.Student;
                if (instance.Question != null)
                    entity.Question = instance.Question;
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


    }
}