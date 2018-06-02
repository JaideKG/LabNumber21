using LabNumber21.Models;
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
			CoffeeEntities orm = new CoffeeEntities();

			ViewBag.Items = orm.Items.ToList();
            return View();
        }

        public ActionResult About(int ID) 
        {
			CoffeeEntities orm = new CoffeeEntities();

			ViewBag.Users = orm.Users.ToList();
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
        //public ActionResult Welcome(int input = 0)
        //{
        //    ViewBag.data = input;
        //    return View();
        //}

        //parameters are automatically parsed in from query string
        public ActionResult Register(string Name = "", string CoffeeType = "", string Drinkware="")
        {
			CoffeeEntities orm = new CoffeeEntities();
	
			User user = new User();

			user.Name = Name;
			user.CoffeeType = CoffeeType;
			user.Drinkware = Drinkware;

			if (ModelState.IsValid)
			{
				//if the model is valid then we add to our DB
				orm.Users.Add(user);
				//we have to save our changes or they won't stay in our DB
				orm.SaveChanges();
				ViewBag.message = $"{user.Name} has been added";
			}
			else
			{
				ViewBag.message = "Item is not valid, cannot add to DB.";
			}


			ViewBag.Name = Name;
            ViewBag.CoffeeType = CoffeeType;
            ViewBag.Drinkware = Drinkware;

			
            return View();
        }
    }
}