using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using FAQManipulationServices.FAQManipulation;
using FSCSTestApp.Data.Access.EntityModel;
using FSCSTestApp.Data.Access.Repository.Concretes;
using FSCSTestApp.Data.Access.UnitOfWork.Concretes;
using FSCSTestApp.Models;
using Microsoft.Ajax.Utilities;
using RepositoryServices.Services;

namespace FSCSTestApp.Controllers
{
    public class HomeController : Controller
    {
        private FaqManipulation _faqManipulationServices;
        private QuestionRepositoryServices _questionRepositoryServices;
        private StudentRepositoryServices _studentRepositoryServices;

        public HomeController()
        {
            var unitOfWork = new UnitOfWork();
            _faqManipulationServices = new FaqManipulation(new QuestionRepository(unitOfWork), new AnswerRepository(unitOfWork), new UIPageRepository(unitOfWork), 3);
            _questionRepositoryServices = new QuestionRepositoryServices(unitOfWork);
            _studentRepositoryServices = new StudentRepositoryServices(unitOfWork);
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
        [HttpGet]
        public ActionResult Index()
        {
            return View(new List<StudentGradePerQuestionAnswer>());
        }
        [HttpPost]
        public ActionResult Index(int studentId)
        {
            var resultsSet = _questionRepositoryServices.GetStudentGradePerQuestionAnswers(studentId);
            return View(resultsSet);
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

        [HttpGet]
        public ActionResult StudentGradeForQuestions()
        {
            var model = GetViewModel();
            if (model == null)
            {
                model = new List<StudentsGradesViewModel>();
            }

            return View("StudentGradePerQuestion", model);
        }
        [HttpPost]
        public ActionResult StudentGradeForQuestions(StudentsGradesViewModel item, FormCollection form)
        {
            if (form["Insert"] != null)
            {
                //deal with insert
                int studentId = _studentRepositoryServices.AddStudent(item.Student);
                foreach (var grade in item.Grades)
                {
                    grade.StudentId = studentId;
                    _questionRepositoryServices.AddGrade(grade);
                }


            }
            else if (form["Update"] != null)
            {
                //deal with update
                _studentRepositoryServices.UpdateStudent(item.Student);
                foreach (var grade in item.Grades)
                {
                    grade.StudentId = item.Student.StudentId;
                    _questionRepositoryServices.UpdateGrade(grade);
                }
            }
            else if (form["Delete"] != null)
            {
                //deal with delete
                _studentRepositoryServices.DeleteStudent(item.Student);
                foreach (var grade in item.Grades)
                {
                    grade.StudentId = item.Student.StudentId;
                    _questionRepositoryServices.DeleteGrade(grade);
                }
            }
            return RedirectToAction("StudentGradeForQuestions");
        }

        private IList<StudentsGradesViewModel> GetViewModel()
        {
            var model = new List<StudentsGradesViewModel>();
            var tmpModel = _questionRepositoryServices.GetAllStudentGradePerQuestionAnswers();
            var maxStudentId = tmpModel.Max(p => p.StudentId);
            for (var stId = 1; stId <= maxStudentId; stId++)
            {
                IList<Grades> stGrades = null;
                foreach (var it in tmpModel)
                {
                    Student student = null;
                    if (!model.Contains(new StudentsGradesViewModel { Student = new Student { StudentId = it.StudentId } }) && it.StudentId == stId)
                    {
                        student = new Student { StudentId = it.StudentId, FirstName = it.FirstName, LastName = it.LastName };
                        stGrades = new List<Grades>();
                        stGrades.Add(new Grades { Grade = it.Grade, QuestionId = it.QuestionId, StudentId = it.StudentId, Student = student });
                        var item = new StudentsGradesViewModel { Student = student, Grades = stGrades };
                        model.Add(item);
                    }
                    else if (it.StudentId == stId)
                    {
                        student = new Student { StudentId = it.StudentId, FirstName = it.FirstName, LastName = it.LastName };
                        stGrades.Add(new Grades { Grade = it.Grade, QuestionId = it.QuestionId, StudentId = it.StudentId, Student = student });
                    }
                }
            }
            return model;
        }
    }
}