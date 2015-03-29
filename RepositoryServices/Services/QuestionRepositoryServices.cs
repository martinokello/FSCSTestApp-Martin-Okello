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
        private AnswerRepository _answerRepository;
        private UIPageRepository _uiPageRepository;

        public QuestionRepositoryServices()
        {
            
        }

        public QuestionRepositoryServices(IUnitOfWork unitOfWork)
        {
            _questionRepository = new QuestionRepository(unitOfWork);
            _gradeRepository = new GradeRepository(unitOfWork);
            _answerRepository = new AnswerRepository(unitOfWork);
            _uiPageRepository = new UIPageRepository(unitOfWork);
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

        public Grades[] GetGradesByStudentId(int studentId)
        {
            return _gradeRepository.GetGradesByStudentId(studentId);
        }
        public UIPage GetPageById(int pageId)
        {
            return _uiPageRepository.GetById(pageId);
        }
        public Question GetQuestionById(int questionId)
        {
            return _questionRepository.GetById(questionId);
        }
        public int AddQuestion(Question question)
        {
            return _questionRepository.Add(question);
        }

        public Grades[] GetGradeByName(string gradeName)
        {
            return _gradeRepository.GetGradeByName(gradeName);
        }
        public bool UpdateAnswer(Answer answer)
        {
            return _answerRepository.Update(answer);
        }
        public int AddAnswer(Answer answer)
        {
            return _answerRepository.Add(answer);
        }
        public bool UpdateQuestion(Question question)
        {
            return _questionRepository.Update(question);
        }
        public int AddGrade(Grades grade)
        {
            return _gradeRepository.Add(grade);
        }
        public bool UpdateGrade(Grades grade)
        {
            return _gradeRepository.Update(grade);
        }

        public bool DeleteQuestion(Question question)
        {
            return _questionRepository.Delete(question.QuestionId);
        }
        public Grades GetGradeById(int gradeId)
        {
            return _gradeRepository.GetById(gradeId);
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
