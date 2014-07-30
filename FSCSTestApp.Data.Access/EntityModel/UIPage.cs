using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCSTestApp.Data.Access.EntityModel
{
    public class UIPage
    {
        [Key]
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public string PageUrl { get; set; }
        public ICollection<Question> Questions { get; set; } 
    }
}
