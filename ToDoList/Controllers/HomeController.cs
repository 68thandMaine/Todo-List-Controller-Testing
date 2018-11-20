using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {

        [Route("/items")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            return View(allItems);
        }

        [Route("/items/form")]
        public ActionResult CreateForm()
        {
            return View();
        }
        [Route("/items/new")]
        public ActionResult Create(string description)
        {
            Item myItem = new Item(description);
            myItem.Save();
            return RedirectToAction("Index");
        }
    }
}
