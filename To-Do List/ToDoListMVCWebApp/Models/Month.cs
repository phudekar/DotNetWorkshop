using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Common;
using ToDoList.Common.Manager;

namespace ToDoListMVCWebApp.Models
{
    public class Month
    {
        private MySqlDataManager manager;

        public Month(DateTime date, MySqlDataManager manager)
        {
            this.manager = manager;
            Days = new SortedDictionary<DateTime, IList<Item>>();
            AddPreviousDays(date);
            Days.Add(date, GetItemsForDate(date));
            AddNextDays(date);
        }

        private List<Item> GetItemsForDate(DateTime date)
        {
            return manager.GetToDoItems().Where(x => x.Deadline.Date.Equals(date.Date)).ToList();
        }

        private void AddNextDays(DateTime date)
        {
            DateTime day1 =  date.AddDays(1);
            while (day1.Month == date.Month)
            {
                Days.Add(day1, GetItemsForDate(day1));
                day1 = day1.AddDays(1);
            }
        }

        private void AddPreviousDays(DateTime date)
        {
            var day1 =  date.AddDays(-1);
            while (day1.Month == date.Month)
            {
                Days.Add(day1, GetItemsForDate(day1));
                day1 = day1.AddDays(-1);

            }
        }

        public SortedDictionary<DateTime, IList<Item>> Days { get; set; }
    }
}