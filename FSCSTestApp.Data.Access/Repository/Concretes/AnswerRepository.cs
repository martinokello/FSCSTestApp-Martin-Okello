using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCSTestApp.Data.Access.EntityModel;
using FSCSTestApp.Data.Access.Factories;
using FSCSTestApp.Data.Access.Repository.Abstracts;
using FSCSTestApp.Data.Access.UnitOfWork.Interfaces;

namespace FSCSTestApp.Data.Access.Repository.Concretes
{
    public class AnswerRepository : AbstractRepository<Answer,int>
    {
        private IUnitOfWork _unitOfWork;

        public AnswerRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override Answer GetById(int key)
        {
           return DBContextFactory.GetDbContextInstance().Answers.SingleOrDefault(p => p.AnswerId == key);
        }

        public override int Add(Answer instance)
        {
            DBContextFactory.GetDbContextInstance().Answers.Add(instance);
            _unitOfWork.SaveChanges();
            return instance.AnswerId;
        }

        public override bool Delete(int key)
        {
            try
            {
                var entity = GetById(key);
                DBContextFactory.GetDbContextInstance().Answers.Remove(entity);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool Update(Answer instance)
        {
            try
            {
                var entity = GetById(instance.AnswerId);
                if(instance.QuestionId > 0)
                entity.QuestionId = instance.QuestionId;
                if(!string.IsNullOrEmpty(instance.AnswerText))
                    entity.AnswerText = instance.AnswerText;
                if(instance.Question != null)
                entity.Question = instance.Question;
                if (instance.QuestionId > 0)
                    entity.QuestionId = instance.QuestionId;
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
