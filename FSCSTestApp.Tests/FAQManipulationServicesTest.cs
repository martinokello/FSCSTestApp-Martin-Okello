using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FAQManipulationServices.FAQManipulation;
using FSCSTestApp.Controllers;
using FSCSTestApp.Data.Access.EntityModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FAQManipulationServices.FAQManipulation.Interfaces;

namespace FSCSTestApp.Tests
{
    [TestClass]
    public class FAQManipulationServicesTest
    {
        private HomeController _controller;
        private Mock<FaqManipulation> _faqManipulationSerices;
        private Question[] _randomResults;
        private Question[] _resultSet;

        [TestInitialize]
        public void StartUp()
        {
            _faqManipulationSerices = new Mock<FaqManipulation>();

            var q1 = new Question { PageId = 1, QuestionText = "Q1: Home Page" };
            var q2 = new Question { PageId = 1, QuestionText = "Q2: Home Page" };
            var q3 = new Question { PageId = 1, QuestionText = "Q3: Home Page" };


            var q11 = new Question { PageId = 2, QuestionText = "Q1: claims Page" };
            var q12 = new Question { PageId = 2, QuestionText = "Q2: claims Page" };
            var q13 = new Question { PageId = 2, QuestionText = "Q3: claims Page" };

            var q21 = new Question { PageId = 3, QuestionText = "Q1: coverage Page" };
            var q22 = new Question { PageId = 3, QuestionText = "Q2: coverage Page" };
            var q23 = new Question { PageId = 3, QuestionText = "Q3: coverage Page" };
             _resultSet = new Question[] {q1, q2, q3, q11, q12, q13, q21, q22, q23};
            var randomResults = _resultSet.Where(p => p.PageId == 2);

            _faqManipulationSerices.Setup(p => p.SelectRandomFaq(It.IsAny<string>())).Returns(randomResults);
            
            _controller = new HomeController();

            _controller.FaqManipulation = _faqManipulationSerices.Object;

        }
        [TestMethod]
        public void Test_HomeController_FAQ_Action_Returns_Correct_Result()
        {
            var result = _controller.FaqBlock() as PartialViewResult;

            Assert.AreEqual(result.ViewName, "_PartialFaqBlock");
        }

        [TestMethod]
        public void Test_HomeController_FAQ_Action_Returns_Correct_Model()
        {
            var result = _controller.FaqBlock();

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void Test_HomeController_FAQBlock_Action_Returns_Correct_Model_Count()
        {
            var result = _controller.FaqBlock();
            var model = result.Model as IEnumerable<Question>;
            Assert.AreEqual(model.Count(), 3);
        }

        [TestMethod]
        public void Test_FAQManipulationService_Get_SelectRandomFaq()
        {
            _faqManipulationSerices.Setup(p => p.GetAllQuestionsForPageTitle(It.IsAny<string>())).Returns(_resultSet);
            var result = _controller.FaqManipulation.SelectRandomFaq("Home");

            Assert.AreEqual(3,result.Count());

        }
    }
}
