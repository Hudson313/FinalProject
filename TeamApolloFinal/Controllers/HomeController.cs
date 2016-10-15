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
    }
}