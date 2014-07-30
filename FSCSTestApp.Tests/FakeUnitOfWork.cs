using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCSTestApp.Data.Access.UnitOfWork.Interfaces;

namespace FSCSTestApp.Tests
{
    public class FakeUnitOfWork:IUnitOfWork
    {

        public void SaveChanges()
        {
            
        }
    }
}
