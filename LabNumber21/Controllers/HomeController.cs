using LabNumber21.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
		public ActionResult About()
		{
			return View();
		}
		
        public ActionResult Contact(int ID)
        {
			CoffeeEntities ORM = new CoffeeEntities();
			//we build this object so that we can make a transaction
			DbContextTransaction DeleteCustomerTransaction = ORM.Database.BeginTransaction();
			Item temp = new Item();
			try
			{
				//we first find the specific item by the items id
				temp = ORM.Items.Find(ID);
				ORM.Items.Remove(temp);
				ORM.SaveChanges();
				DeleteCustomerTransaction.Commit(); //if the remove was successful we commit the transaction
				ViewBag.Message = $"{temp.Description} was removed";
			}
			catch (Exception)
			{
				//if the remove was unsuccessful then we 
				//roll back the transaction so no data is lost
				DeleteCustomerTransaction.Rollback();
				ViewBag.Message = "Item could not be removed";
			}

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
		public ActionResult RegisterItem()
		{
			return View();
		}
		public ActionResult AddItem(string Name = "", string Description = "", string Quantity = "", string Price = "")
		{
			CoffeeEntities orm = new CoffeeEntities();

			Item item = new Item();
			item.Name = Name;
			item.Description = Description;
			item.Quantity = Quantity;
			item.Price = Price;

			if (ModelState.IsValid)
			{
				//if the model is valid then we add to our DB
				orm.Items.Add(item);
				//we have to save our changes or they won't stay in our DB
				orm.SaveChanges();
				//ViewBag.message = $"{item.Name} has been added";
				
			}
			else
			{
				ViewBag.message = "Item is not valid, cannot add to DB.";
			}

			ViewBag.Name = Name;
			ViewBag.Description = Description;
			ViewBag.Quantity = Quantity;
			ViewBag.Price = Price;

			return View();
		
		}
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
				//ViewBag.message = $"{item.Name} has been added";
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
