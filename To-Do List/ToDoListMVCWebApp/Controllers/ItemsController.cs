using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Common;
using ToDoList.Common.Manager;

namespace ToDoListMVCWebApp.Controllers
{
    public class ItemsController : Controller
    {
        private IDataManager dataManager;

        public ItemsController()
        {
            dataManager = new MySqlDataManager();
        }

        public ActionResult Index()
        {
            var items = dataManager.GetPendingItems();
            ViewBag.Items = items;
            return View();
        }

        public ActionResult Create(string title, string description, DateTime deadline)
        {
          var item =  new Item(deadline)
                {
                    Title = title,
                    Description = description
                };
            dataManager.SaveItem(item);

            return Redirect("~/Home/Week");
        }

    }
}
