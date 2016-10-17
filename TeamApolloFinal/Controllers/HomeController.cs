using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using TeamApolloFinal.Models;

namespace TeamApolloFinal.Controllers
{
    public class HomeController : Controller
    {
        private MotivationaldbEntities dbContext = new MotivationaldbEntities();


        public ActionResult Index()
        {
            List<Apollo> dbQuotes = dbContext.Apolloes.ToList();
            //List<Apollo> quoteDisplayed = new List<Apollo>();

            RandomNumberGenerator randNum = new RandomNumberGenerator();
            int randQuoteID = randNum.NumberBetween(1, dbQuotes.Count());

            foreach (Apollo quote in dbQuotes)
            {
                if (quote.QuoteID == randQuoteID)
                {
                    //quoteDisplayed.Add(quote);

                    //return View(quoteDisplayed);
                    ViewBag.Quote = quote.Motivation.ToString();
                }
            }

            return View(dbQuotes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User admin)
        {
            foreach(User name in dbContext.Users.ToList())
            {
                if((name.UserName == admin.UserName) && (name.Password == admin.Password))
                {
                    return RedirectToAction("AddQuote");
                }
                else
                {
                    ViewBag.InvalidLogIn = "Your username/password is incorrect";
                    return View();
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult AddQuote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddQuote(FormCollection collection)
        {
            try
            {
                Apollo newQuote = new Apollo();

                newQuote.Motivation = Request.Form["Motivation"];

                dbContext.Apolloes.Add(newQuote);
                dbContext.SaveChanges();

                ViewBag.AddQuoteStatus = "You have added a new quote";

                return View("AddQuote");
            }
            catch
            {
                ViewBag.AddQuoteStatus = "The quote was not added";

                return View("AddQuote");
            }
        }

        public ActionResult Register()
        {
            return View();

        }
    }
}