using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCSTestApp.Data.Access.Factories;
using FSCSTestApp.Data.Access.UnitOfWork.Interfaces;

namespace FSCSTestApp.Data.Access.UnitOfWork.Concretes
{
    public class UnitOfWork: IUnitOfWork
    {
        public void SaveChanges()
        {
            DBContextFactory.GetDbContextInstance().SaveChanges();
        }
    }
}
