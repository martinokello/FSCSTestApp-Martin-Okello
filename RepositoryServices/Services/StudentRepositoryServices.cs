using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCSTestApp.Data.Access.EntityModel;
using FSCSTestApp.Data.Access.Repository.Concretes;
using FSCSTestApp.Data.Access.UnitOfWork.Interfaces;

namespace RepositoryServices.Services
{
    public class StudentRepositoryServices : IStudentRepositorySegregator
    {
        private StudentRepository _StudentRepository;
        private QuestionRepository _QuestionRepository;
        public StudentRepositoryServices()
        {
            
        }

        public StudentRepositoryServices(IUnitOfWork unitOfWork)
        {
            _StudentRepository = new StudentRepository(unitOfWork);
            _QuestionRepository = new QuestionRepository(unitOfWork);
        }

        public virtual IEnumerable<Student> GetAllFaqStudents()
        {
            return _StudentRepository.GetAll();
        }

        public IEnumerable<StudentGradePerQuestionAnswer> GetStudentGradePerStudentAnswers(int studentId)
        {
            return _QuestionRepository.GetStudentGradePerQuestionAnswers(studentId);
        }

        public IEnumerable<StudentGradePerQuestionAnswer> GetAllStudentGradePerStudentAnswers()
        {
            return _QuestionRepository.GetAllStudentGradePerQuestionAnswers();
        }

        public int AddStudent(Student student)
        {
            return _StudentRepository.Add(student);
        }

        public bool UpdateStudent(Student student)
        {
            return _StudentRepository.Update(student);
        }
        public bool DeleteStudent(Student student)
        {
            return _StudentRepository.Delete(student.StudentId);
        }
    }

    public interface IStudentRepositorySegregator
    {
    }
}
