using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.Expressions;
using FSCSTestApp.Data.Access.EntityModel;

namespace FSCSTestApp.Models
{
    public class StudentsGradesViewModel
    {
        public Student Student { get; set; }
        public IList<Grades> Grades { get; set; }
        public Grades Grade { get; set; }
        public string Insert { get; set; }
        public string Update { get; set; }
        public string Delete { get; set; }
        public override int GetHashCode()
        {
            return Student.StudentId;
        }

        public override bool Equals(object obj)
        {
            return Student.StudentId == (obj as StudentsGradesViewModel).Student.StudentId;
        }
    }
}