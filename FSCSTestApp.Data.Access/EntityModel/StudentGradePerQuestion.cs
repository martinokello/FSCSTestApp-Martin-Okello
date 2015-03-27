using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCSTestApp.Data.Access.EntityModel
{
    public class StudentGradePerQuestionAnswer
    {
        public int StudentId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }
        public int GradeId { get; set; }
    }

    public class Grades
    {
        [Key]
        public int GradeId { get; set; }
        public string Grade { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public Student Student { get; set; }
    }
}
