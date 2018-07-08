using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/categories/{categoryId}/items/new")]
     public ActionResult CreateForm(int categoryId)
     {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category category = Category.Find(categoryId);
        return View(category);
     }
     [HttpGet("/categories/{categoryId}/items/{itemId}")]
     public ActionResult Details(int categoryId, int itemId)
     {
        Item item = Item.Find(itemId);
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category category = Category.Find(categoryId);
        model.Add("item", item);
        model.Add("category", category);
        return View(item);
     }
    [HttpGet("/items")]
    public ActionResult Index()
    {
        List<Item> allItems = Item.GetAll();
        return View(allItems);
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }
  }
}
