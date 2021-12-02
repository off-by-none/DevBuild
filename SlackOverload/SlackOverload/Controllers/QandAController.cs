using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SlackOverload.Models;
using Microsoft.AspNetCore.Http;

namespace SlackOverload.Controllers
{
    public class QandAController : Controller
    {
        private DAL dal;

        public QandAController(IConfiguration config)
        {
            dal = new DAL(config.GetConnectionString("default"));
        }

        public IActionResult Index()
        {
            //get the most recent questions
            IEnumerable<Question> results = dal.GetQuestionsMostRecent();

            ViewData["Questions"] = results;

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                return View(new Question());
            }
            else
            {
                return View("../Sessions/Index");
            }
        }

        [HttpPost]
        public IActionResult Add(Question q)
        {
            string login = HttpContext.Session.GetString("Username");
            int result = dal.CreateQuestion(q, login);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddAnswer()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                return View(new Answer());
            }
            else
            {
                return View("../Sessions/Index");
            }
        }

        [HttpPost]
        public IActionResult AddAnswer(Answer a, int id)
        {
            string login = HttpContext.Session.GetString("Username");
            int result = dal.CreateAnswer(a, id, login);

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            //first get the question detail
            Question question = dal.GetQuestionById(id);

            //then get the relevant answers
            IEnumerable<Answer> answers = dal.GetAnswersByQuestionId(id);

            ViewData["Answers"] = answers;

            return View(question);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Question question = dal.GetQuestionById(id);

            return View(question);
        }

        [HttpPost]
        public IActionResult Edit(Question q)
        {
            int result = dal.EditQuestionById(q);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAnswer(int id)
        {
            Answer answer = dal.GetAnswerById(id);

            return View(answer);
        }

        [HttpPost]
        public IActionResult EditAnswer(Answer a)
        {
            int result = dal.EditAnswerById(a);

            return RedirectToAction("Index");
        }

        public IActionResult Search(string search)
        {
            IEnumerable<Question> results = dal.Search(search);

            ViewData["Search Results"] = results;

            return View();
        }
    }
}