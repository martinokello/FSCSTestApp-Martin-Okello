using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCSTestApp.Data.Access.Repository.Concretes;
using FSCSTestApp.Data.Access.UnitOfWork.Interfaces;

namespace RepositoryServices
{
    public class UIPageRepositoryService : IUiPageRepositorySegregator
    {
        private UIPageRepository _uiPageRepository;

        public UIPageRepositoryService(IUnitOfWork unitOfWork)
        {
            _uiPageRepository = new UIPageRepository(unitOfWork);
        }
    }

    public interface IUiPageRepositorySegregator
    {
    }
}
