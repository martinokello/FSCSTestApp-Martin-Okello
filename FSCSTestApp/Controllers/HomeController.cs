using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FAQManipulationServices.FAQManipulation;
using FSCSTestApp.Data.Access.Repository.Concretes;
using FSCSTestApp.Data.Access.UnitOfWork.Concretes;
using RepositoryServices.Services;

namespace FSCSTestApp.Controllers
{
    public class HomeController : Controller
    {
        private FaqManipulation _faqManipulationServices;
        private QuestionRepositoryServices _questionRepositoryServices;

        public HomeController()
        {
            var unitOfWork = new UnitOfWork();
            _faqManipulationServices = new FaqManipulation(new QuestionRepository(unitOfWork),new AnswerRepository(unitOfWork),new UIPageRepository(unitOfWork),3);
            _questionRepositoryServices = new QuestionRepositoryServices(unitOfWork);
        }

        [ChildActionOnly]
        public PartialViewResult FaqBlock(string pageTitle = "Home")
        {
            var model = _faqManipulationServices.SelectRandomFaq(pageTitle);
            return PartialView("_PartialFaqBlock", model);
        }

        public ActionResult Claims()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            var model = _questionRepositoryServices.GetAllFaqQuestions();
            return View(model);
        }
                
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Coverage()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public FaqManipulation FaqManipulation
        {
            get { return _faqManipulationServices; }
            set { _faqManipulationServices = value; }
        }

        public QuestionRepositoryServices QuestionRepositoryServices
        {
            get { return _questionRepositoryServices; }
            set { _questionRepositoryServices = value; }
        }
    }
}