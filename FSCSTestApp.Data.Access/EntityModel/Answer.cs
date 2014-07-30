using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCSTestApp.Data.Access.EntityModel
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public Question Question { get; set; }
    }
}
