using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class CategoriesController : Controller
    {

      [HttpGet("/categories")]
      public ActionResult Index()
      {
          List<Category> allCategories = Category.GetAll();
          return View(allCategories);
      }

      [HttpGet("/categories/new")]
      public ActionResult CreateForm()
      {
          return View();
      }

      [HttpPost("/categories")]
      public ActionResult Create()
      {
          Category newCategory = new Category(Request.Form["category-name"]);
          List<Category> allCategories = Category.GetAll();
          return View("Index", allCategories);
      }

      [HttpGet("/categories/{id}")]
      public ActionResult Details(int id)
      {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Category selectedCategory = Category.Find(id);
          List<Item> categoryItems = selectedCategory.GetItems();
          model.Add("category", selectedCategory);
          model.Add("items", categoryItems);
          return View(model);
      }


      [HttpPost("/items")]
      public ActionResult CreateItem()
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category foundCategory = Category.Find(Int32.Parse(Request.Form["category-id"]));
        string itemDescription = Request.Form["item-description"];
        string itemDetails = Request.Form["item-details"];
        Item newItem = new Item(itemDescription, itemDetails);
        foundCategory.AddItem(newItem);
        List<Item> categoryItems = foundCategory.GetItems();
        model.Add("items", categoryItems);
        model.Add("category", foundCategory);
        System.Console.WriteLine(itemDetails);
        return View("Details", model);
      }
    }
}
