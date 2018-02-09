using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class ContactsController : Controller
    {

      [HttpGet("/contacts")]
      public ActionResult Index()
      {
          List<Contact> allContacts = Contact.GetAll();
          return View(allContacts);
      }

      [HttpGet("/contacts/new")]
      public ActionResult CreateForm()
      {
          return View();
      }

      [HttpPost("/contacts")]
      public ActionResult Create()
      {
          Contact newContact = new Contact(Request.Form["contact-name"]);
          List<Contact> allContacts = Contact.GetAll();
          return View("Index", allContacts);
      }

      [HttpGet("/contacts/{id}")]
      public ActionResult Details(int id)
      {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Contact selectedContact = Contact.Find(id);
          List<Item> contactItems = selectedContact.GetItems();
          model.Add("contact", selectedContact);
          model.Add("items", contactItems);
          return View(model);
      }


      [HttpPost("/items")]
      public ActionResult CreateItem()
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact foundContact = Contact.Find(Int32.Parse(Request.Form["contact-id"]));
        string itemDescription = Request.Form["person-name"];
        string itemDetails = Request.Form["person-address"];
        string itemPhone = Request.Form["item-phone"];
        Item newItem = new Item(itemDescription, itemDetails, itemPhone);
        foundContact.AddItem(newItem);
        List<Item> contactItems = foundContact.GetItems();
        model.Add("items", contactItems);
        model.Add("contact", foundContact);
        System.Console.WriteLine(itemDetails);
        return View("Details", model);
      }
    }
}
