using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCSTestApp.Data.Access.EntityModel
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
        public string Grade { get; set; }
    }
}
