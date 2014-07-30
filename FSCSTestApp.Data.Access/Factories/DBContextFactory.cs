using System.Web;
using FSCSTestApp.Data.Access.Entity.Context;

namespace FSCSTestApp.Data.Access.Factories
{
    public class DBContextFactory
    {
        private static FAQEntityContext _dbContext;
        private static readonly object LockOjbect = new object();
        public static FAQEntityContext GetDbContextInstance()
        {
            _dbContext = HttpContext.Current.Application.Get("DBContextObject") != null
                   ? (FAQEntityContext)HttpContext.Current.Application.Get("DBContextObject")
                   : null;

            if (_dbContext == null)
            {
                _dbContext = new FAQEntityContext();

                HttpContext.Current.Application.Set("DBContextObject", _dbContext);
            }

            return _dbContext;
        }
    }
}
