using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabNumber21.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "The GC Coffee Shop is a new cafe epicenter in the city of Detroit. We strive to provide the best quality of robust coffee so that you are ready to accomplish the day with enthusiasm! Our web app now available, offers our clients the perks of free coffee and other cool prizes when registered. All it takes is a few seconds before your next free cup of espresso!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //this will go to my registration view
        //this will go to my registration view
        //where I will take user input
        public ActionResult Registration()
        {
            
            return View();
        }
        //this link is on the registration page
        //which sends the user input here
        //and then displays the view named Welcome
        public ActionResult Welcome(int input = 0)
        {
            ViewBag.data = input;
            return View();
        }

        //parameters are automatically parsed in from query string
        public ActionResult Register(string FirstName = "",
            string LastName = "", string PhoneNumber="", string Email = "",  string Password = "")
        {
            ViewBag.FirstName = FirstName;
            ViewBag.LastName = LastName;
            ViewBag.PhoneNumber = PhoneNumber;
            ViewBag.Email = Email;
            ViewBag.Password = Password;

            return View();
        }
    }
}