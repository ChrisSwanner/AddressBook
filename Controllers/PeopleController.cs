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

        [HttpGet("/contacts/{contactId}/items/new")]
        public ActionResult CreateForm(int contactId)
        {
          Contact contact = Contact.Find(contactId);
          return View(contact);
        }


        [HttpGet("/contacts/{contactId}/items/{id}")]
        public ActionResult ContentsDetails(int contactId, int id)
        {

          Contact contact = Contact.Find(contactId);
          Item item = Item.Find(id);
          return View(item);
        }

        [HttpPost("/items/delete")]
        public ActionResult DeleteAll()
        {
          Contact.ClearAll();
          Item.ClearAll();
          return View();
        }

    }
}
