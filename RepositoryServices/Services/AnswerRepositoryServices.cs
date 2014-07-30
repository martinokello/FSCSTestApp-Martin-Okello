using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCSTestApp.Data.Access.Repository.Concretes;
using FSCSTestApp.Data.Access.UnitOfWork.Interfaces;

namespace RepositoryServices.Services
{
    public class AnswerRepositoryServices : IAnswerRepositorySegregator
    {
        private AnswerRepository _repository;

        public AnswerRepositoryServices(IUnitOfWork unitOfWork)
        {
           _repository = new AnswerRepository(unitOfWork); 
        }
    }

    public interface IAnswerRepositorySegregator
    {
    }
}
