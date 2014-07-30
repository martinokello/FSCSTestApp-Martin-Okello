using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                DBContextFactory.GetDbContextInstance().Questions.Remove(entity);
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
    }
}
