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
    public class UIPageRepository: AbstractRepository<UIPage,int>
    {
        private IUnitOfWork _unitOfWork;

        public UIPageRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override UIPage GetById(int key)
        {
           return DBContextFactory.GetDbContextInstance().UIPages.SingleOrDefault(p => p.PageId == key);
        }

        public override bool Delete(int key)
        {
            try
            {
                var entity = GetById(key);
                DBContextFactory.GetDbContextInstance().UIPages.Remove(entity);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool Update(UIPage instance)
        {
            try
            {
                var entity = GetById(instance.PageId);
                DBContextFactory.GetDbContextInstance().UIPages.Remove(entity);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public UIPage GetPageByPageTitle(string title)
        {
            return DBContextFactory.GetDbContextInstance().UIPages.SingleOrDefault(p => p.PageTitle == title);
        }

    }
}
