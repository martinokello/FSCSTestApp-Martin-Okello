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
    public class QuestionRepositoryServices : IQuestionRepositorySegregator
    {
        private QuestionRepository _questionRepository;
        private GradeRepository _gradeRepository;

        public QuestionRepositoryServices()
        {
            
        }

        public QuestionRepositoryServices(IUnitOfWork unitOfWork)
        {
            _questionRepository = new QuestionRepository(unitOfWork);
            _gradeRepository = new GradeRepository(unitOfWork);
        }

        public virtual IEnumerable<Question> GetAllFaqQuestions()
        {
            return _questionRepository.GetAll();
        }

        public IEnumerable<StudentGradePerQuestionAnswer> GetStudentGradePerQuestionAnswers(int studentId)
        {
            return _questionRepository.GetStudentGradePerQuestionAnswers(studentId);
        }

        public IEnumerable<StudentGradePerQuestionAnswer> GetAllStudentGradePerQuestionAnswers()
        {
            return _questionRepository.GetAllStudentGradePerQuestionAnswers();
        }
        public int AddQuestion(Question question)
        {
            return _questionRepository.Add(question);
        }

        public int AddGrade(Grades grade)
        {
            return _gradeRepository.Add(grade);
        }
        public bool UpdateGrade(Grades grade)
        {
            return _gradeRepository.Update(grade);
        }
        public bool DeleteGrade(Grades grade)
        {
            return _gradeRepository.Delete(grade.GradeId);
        }
    }

    public interface IQuestionRepositorySegregator
    {
    }
}
