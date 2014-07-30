using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCSTestApp.Data.Access.EntityModel;
using FSCSTestApp.Data.Access.RecreateDB;

namespace FSCSTestApp.Data.Access.Entity.Context
{
    public class FAQEntityContext: DbContext
    {
        public FAQEntityContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UIPage> UIPages { get; set; }
    }
}
