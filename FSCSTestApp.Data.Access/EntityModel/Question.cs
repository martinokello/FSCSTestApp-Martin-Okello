using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCSTestApp.Data.Access.EntityModel
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        [ForeignKey("UIPage")]
        public int PageId { get; set; }
        public UIPage UIPage { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
