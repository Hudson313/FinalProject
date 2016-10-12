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
            List<Apollo> dbquotes = dbContext.Apolloes.ToList();
            return View(dbquotes);
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