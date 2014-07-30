using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCSTestApp.Data.Access.EntityModel;
using FSCSTestApp.Data.Access.Repository.Concretes;
using FSCSTestApp.Data.Access.UnitOfWork.Interfaces;

namespace RepositoryServices.Services
{
    public class QuestionRepositoryServices : IQuestionRepositorySegregator
    {
        private QuestionRepository _questionRepository;

        public QuestionRepositoryServices()
        {
            
        }

        public QuestionRepositoryServices(IUnitOfWork unitOfWork)
        {
            _questionRepository = new QuestionRepository(unitOfWork);
        }

        public virtual IEnumerable<Question> GetAllFaqQuestions()
        {
            return _questionRepository.GetAll();
        }
    }

    public interface IQuestionRepositorySegregator
    {
    }
}
