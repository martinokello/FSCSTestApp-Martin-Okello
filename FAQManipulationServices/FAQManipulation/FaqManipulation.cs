using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FAQManipulationServices.FAQManipulation.Interfaces;
using FSCSTestApp.Data.Access.EntityModel;
using FSCSTestApp.Data.Access.Repository.Concretes;

namespace FAQManipulationServices.FAQManipulation
{
    public class FaqManipulation:IFaqManipulationInterfaceSegregator
    {
        private QuestionRepository _questionRepository;
        private AnswerRepository _answerRepository;
        private UIPageRepository _uiPageRepository;
        private int _numberOfFaqsPerPage;

        public FaqManipulation()
        {
            
        }
        public FaqManipulation(QuestionRepository questionRepository, AnswerRepository answerRepository,
            UIPageRepository uiPageRepository, int numberOfFaqsPerPage)
        {
            this._answerRepository = answerRepository;
            this._questionRepository = questionRepository;
            this._uiPageRepository = uiPageRepository;
            this._numberOfFaqsPerPage = numberOfFaqsPerPage;
        }

        public virtual IEnumerable<Question> GetAllQuestionsForPageTitle(string pageTitle)
        {
            return _questionRepository.GetAnswersWithQuestionsForPageTitle(pageTitle);
        }

        public virtual IEnumerable<Question> SelectRandomFaq(string pageTitle)
        {
            var questions = GetAllQuestionsForPageTitle(pageTitle);
            var selectedQuestions = new List<Question>();
            var indexes = new List<int>();

            if (questions.Any())
            {
                var total = questions.Count();

                var random = new Random(DateTime.Now.Millisecond);

                while (selectedQuestions.Count() < _numberOfFaqsPerPage)
                {
                    var index = random.Next(0, total);
                    if (indexes.Contains(index)) continue;
                    indexes.Add(index);

                    selectedQuestions.Add(questions.ElementAt(index));
                }
            }

            return selectedQuestions;
        }
    }
}
