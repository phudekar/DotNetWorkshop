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
        public ActionResult Index()
        {
            dataManager = new MySqlDataManager();
            var items = dataManager.GetPendingItems();
            ViewBag.Items = items;
            return View();
        }

    }
}
