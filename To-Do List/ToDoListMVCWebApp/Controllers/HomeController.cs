using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Common.Manager;
using ToDoListMVCWebApp.Models;

namespace ToDoListMVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        private MySqlDataManager dataManager;
        //
        // GET: /Home/

        public HomeController()
        {
            dataManager = new MySqlDataManager();
        }

        public ActionResult Index()
        {
            var items = dataManager.GetToDoItems();
            return View(items);
        }

        public ActionResult Week(string datetime)
        {
//            dataManager = new MySqlDataManager();
//            var items = dataManager.GetToDoItems();
            ViewBag.Duration = Duration.Week;
            var date = DateTime.Now;
            if (!String.IsNullOrEmpty(datetime))
            {
                date = DateTime.Parse(datetime);
            }
            return View(new Week(date,dataManager));
        }

        public ActionResult Month()
        {
            ViewBag.Duration = Duration.Month;
            return View(new Month(DateTime.Now, dataManager));
        }

        public ActionResult Day(string datetime)
        {
            ViewBag.Duration = Duration.Day;
            var date = DateTime.Now;
            if(!String.IsNullOrEmpty(datetime))
            {
                date = DateTime.Parse(datetime);
            }
            return View(dataManager.GetToDoItems().Where(x=>x.Deadline.Date.Equals(date.Date)).ToList());
        }
/*
        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
 * */
    }
}
