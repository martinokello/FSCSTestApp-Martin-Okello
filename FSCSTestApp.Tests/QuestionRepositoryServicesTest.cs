using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FAQManipulationServices.FAQManipulation;
using FSCSTestApp.Controllers;
using FSCSTestApp.Data.Access.EntityModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepositoryServices.Services;

namespace FSCSTestApp.Tests
{
    [TestClass]
    public class QuestionRepositoryServicesTest
    {
        private HomeController _controller;
        private Mock<QuestionRepositoryServices> _questionRepositoryServices;
        private Question[] _resultSet;

        [TestInitialize]
        public void StartUp()
        {
            _questionRepositoryServices = new Mock<QuestionRepositoryServices>();

            var q1 = new Question { PageId = 1, QuestionText = "Q1: Home Page" };
            var q2 = new Question { PageId = 1, QuestionText = "Q2: Home Page" };
            var q3 = new Question { PageId = 1, QuestionText = "Q3: Home Page" };


            var q11 = new Question { PageId = 2, QuestionText = "Q1: claims Page" };
            var q12 = new Question { PageId = 2, QuestionText = "Q2: claims Page" };
            var q13 = new Question { PageId = 2, QuestionText = "Q3: claims Page" };

            var q21 = new Question { PageId = 3, QuestionText = "Q1: coverage Page" };
            var q22 = new Question { PageId = 3, QuestionText = "Q2: coverage Page" };
            var q23 = new Question { PageId = 3, QuestionText = "Q3: coverage Page" };
            _resultSet = new Question[] { q1, q2, q3, q11, q12, q13, q21, q22, q23 };

            _controller = new HomeController();


        }
        [TestMethod]
        public void Test_HomeController_FAQ_Action_Returns_Correct_Model_Count()
        {
            _questionRepositoryServices.Setup(p => p.GetAllFaqQuestions()).Returns(_resultSet);
            _controller.QuestionRepositoryServices = _questionRepositoryServices.Object;

            var result = _controller.FAQ() as ViewResult;
            var model = result.Model as IEnumerable<Question>;
            Assert.AreEqual(model.Count(), 9);
        }
    }
}
