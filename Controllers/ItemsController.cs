using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class ItemsController : Controller
    {
        [HttpGet("/items")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            return View();
        }

        [HttpGet("/categories/{categoryId}/items/new")]
        public ActionResult CreateForm(int categoryId)
        {
          Category category = Category.Find(categoryId);
          return View(category);
        }


        [HttpGet("/category/{categoryId}/items/{id}")]
        public ActionResult ContentsDetails(int categoryId, int id)
        {

          Category category = Category.Find(categoryId);
          Item item = Item.Find(id);
          return View(item);
        }

        [HttpPost("/items/delete")]
        public ActionResult DeleteAll()
        {
          Category.ClearAll();
          Item.ClearAll();
          return View();
        }

    }
}
