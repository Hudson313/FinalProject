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
            List<CarouselData> dotnet = new List<CarouselData>()
            { new CarouselData() {  linkUrl= "https://www.github.com", src=@"/Content/Images/github.jpg", alt="Owl Image"} ,
            new CarouselData() {  linkUrl= "https://social.msdn.microsoft.com/search/en-US", src=@"/Content/Images/MDSN.jpg", alt="MSDN"},
            new CarouselData() { linkUrl= "http://www.w3schools.com/", src=@"/Content/Images/W3Schools.jpg", alt="Owl Image"},
            new CarouselData() { linkUrl= "https://www.reddit.com/r/learnprogramming/", src=@"/Content/Images/Reddit.jpg", alt="Owl Image"}};


            List<CarouselData> java = new List<CarouselData>()
            { new CarouselData() { linkUrl= "https://www.reddit.com/r/learnprogramming/", src=@"/Content/Images/MDSN.jpg", alt="Owl Image"} ,
            new CarouselData() {  linkUrl= "https://social.msdn.microsoft.com/search/en-US", src=@"/Content/Images/MDSN.jpg", alt="MSDN"},
            new CarouselData() { linkUrl= "http://www.w3schools.com/", src=@"/Content/Images/W3Schools.jpg", alt="Owl Image"},
            new CarouselData() { linkUrl= "https://www.reddit.com/r/learnprogramming/", src=@"/Content/Images/Reddit.jpg", alt="Owl Image"}};


            List<CarouselData> everything = java;
            /*
             *   <div class="item"><a href="https://www.github.com" target="_blank"><img src="~/Content/Images/github.jpg" alt="Owl Image"></a></div>
        
        <div class="item"><a href="https://social.msdn.microsoft.com/search/en-US" target="_blank"><img src="~/Content/Images/MDSN.jpg" alt="Owl Image"></a></div>
        <div class="item"><a href="http://www.w3schools.com/" target="_blank"><img src="~/Content/Images/W3Schools.jpg" alt="Owl Image"></a></div>
     
       
        <div class="item"><a href="https://www.reddit.com/r/learnprogramming/" target="_blank"><img src="~/Content/Images/Reddit.jpg" alt="Owl Image"></a></div>
        <div class="item"><a href="http://stackoverflow.com/" target="_blank"><img src="~/Content/Images/StackOverflow.jpg" alt="Owl Image"></a></div>
        <div class="item"><a href="https://www.edx.org/course/subject/computer-science" target="_blank"><img src="~/Content/Images/EdX.jpg" alt="Owl Image"></a></div>
         <div class="item"><a href="https://www.codecademy.com/" target="_blank"><img src="~/Content/Images/Codeacademy.jpg" alt="Owl Image"></a></div>
        <div class="item"><a href="https://www.khanacademy.org/computing/computer-programming" target="_blank"><img src="~/Content/Images/KhanAcademy.jpg" alt="Owl Image"></a></div>
        <div class="item"><a href="http://lifehacker.com/" target="_blank"><img src="~/Content/Images/LifeHacker.jpg" alt="Owl Image"></a></div>

             * */
            ViewBag.everything = everything;

            return View(dbQuotes);
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
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
            List<CarouselData> dotnet = new List<CarouselData>()
            { new CarouselData() { linkUrl= "https://www.github.com", src=@"/Content/Images/github.jpg", alt="Owl Image"} ,
            new CarouselData() {  linkUrl= "https://social.msdn.microsoft.com/search/en-US", src=@"/Content/Images/MDSN.jpg", alt="MSDN"},
            new CarouselData() { linkUrl= "http://www.w3schools.com/", src=@"/Content/Images/W3Schools.jpg", alt="Owl Image"},
            new CarouselData() { linkUrl= "https://www.reddit.com/r/learnprogramming/", src=@"/Content/Images/Reddit.jpg", alt="Owl Image"}};


            List<CarouselData> java = new List<CarouselData>()
            {new CarouselData() { linkUrl= "https://www.reddit.com/r/learnprogramming/", src=@"/Content/Images/MDSN.jpg", alt="Owl Image"} ,
            new CarouselData() {  linkUrl= "https://social.msdn.microsoft.com/search/en-US", src=@"/Content/Images/MDSN.jpg", alt="MSDN"},
            new CarouselData() { linkUrl= "http://www.w3schools.com/", src=@"/Content/Images/W3Schools.jpg", alt="Owl Image"},
            new CarouselData() { linkUrl= "https://www.reddit.com/r/learnprogramming/", src=@"/Content/Images/Reddit.jpg", alt="Owl Image"}};

            List<CarouselData> all = new List<CarouselData>()
            {

            };
            List<CarouselData> everything ; ;
            switch (form["track"])
            {
                case "java":
                    everything = java;
                    break;
                case "net":
                    everything =dotnet;
                    break;
                default:
                    everything = all;
                    break;
            }

           
            /*
             *   <div class="item"><a href="https://www.github.com" target="_blank"><img src="~/Content/Images/github.jpg" alt="Owl Image"></a></div>
        
        <div class="item"><a href="https://social.msdn.microsoft.com/search/en-US" target="_blank"><img src="~/Content/Images/MDSN.jpg" alt="Owl Image"></a></div>
        <div class="item"><a href="http://www.w3schools.com/" target="_blank"><img src="~/Content/Images/W3Schools.jpg" alt="Owl Image"></a></div>
     
       
        <div class="item"><a href="https://www.reddit.com/r/learnprogramming/" target="_blank"><img src="~/Content/Images/Reddit.jpg" alt="Owl Image"></a></div>
        <div class="item"><a href="http://stackoverflow.com/" target="_blank"><img src="~/Content/Images/StackOverflow.jpg" alt="Owl Image"></a></div>
        <div class="item"><a href="https://www.edx.org/course/subject/computer-science" target="_blank"><img src="~/Content/Images/EdX.jpg" alt="Owl Image"></a></div>
         <div class="item"><a href="https://www.codecademy.com/" target="_blank"><img src="~/Content/Images/Codeacademy.jpg" alt="Owl Image"></a></div>
        <div class="item"><a href="https://www.khanacademy.org/computing/computer-programming" target="_blank"><img src="~/Content/Images/KhanAcademy.jpg" alt="Owl Image"></a></div>
        <div class="item"><a href="http://lifehacker.com/" target="_blank"><img src="~/Content/Images/LifeHacker.jpg" alt="Owl Image"></a></div>

             * */
            ViewBag.everything = everything;

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
            foreach (User name in dbContext.Users.ToList())
            {
                if ((name.UserName == admin.UserName) && (name.Password == admin.Password))
                {
                    return RedirectToAction("DisplayQuotes");
                }
                else
                {
                    ViewBag.InvalidLogIn = "Your username/password is incorrect";
                    return View();
                }
            }

            return View();
        }

        public ActionResult DisplayQuotes()
        {
            List<Apollo> dbQuotes = dbContext.Apolloes.ToList();

            return View(dbQuotes);
        }

        public ActionResult DeleteQuote(int id)
        {
            Apollo deleteQuote = dbContext.Apolloes.Find(id);

            if(deleteQuote == null)
            {
                ViewBag.EditStatus = "Quote not found";

                return View("DeleteQuote");
            }

            return View(deleteQuote);
        }

        [HttpPost, ActionName("DeleteQuote")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                Apollo deleteQuote = dbContext.Apolloes.Find(id);
                dbContext.Apolloes.Remove(deleteQuote);
                dbContext.SaveChanges();

                return RedirectToAction("DisplayQuotes");
            }
            catch
            {
                ViewBag.DeleteStatus = "Quote not deleted";
                return View();
            }
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
          [HttpGet]
        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Register(FormCollection Collection)
        {
            try
            {
                Student addStudent = new Student();
                addStudent.FirstName = Request.Form["FirstName"];
                addStudent.LastName = Request.Form["LastName"];
                addStudent.Email = Request.Form["Email"];
                //addStudent.Track = Request.Form["Track"];

                //if ((addStudent.Track.ToLower() == ".net") || (addStudent.Track.ToLower()== "java"))
                if ((Request.Form["Track"].ToLower() == ".net") || (Request.Form["Track"].ToLower() == "java"))
                {
                    addStudent.Track = Request.Form["Track"];


                }
                else
                {
                    ViewBag.StudentStatus = "Please enter .net or java";
                    return View("Register");
                }
                dbContext.Students.Add(addStudent);
                dbContext.SaveChanges();
                return View("ConfirmRegister", addStudent);

            }
            catch
            {
                ViewBag.StudentStatus = "You were not added please try again.";
                return View("Register");
            }
        }
        public ActionResult DisplayStudents()
        {
            List<Student> dbStudents = dbContext.Students.ToList();

            return View(dbStudents);
        }


    }
}
