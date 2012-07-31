using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Common;

namespace ToDoListMVCWebApp.Models
{
    public class Week
    {
        private IDataManager manager;

        public Week(DateTime date, IDataManager manager)
        {
            this.manager = manager;
            Days = new SortedDictionary<DateTime, IList<Item>>();
            AddPreviousDays(date);
            Days.Add(date, GetItemsForDate(date));
            AddNextDays(date);
        }

        private List<Item> GetItemsForDate(DateTime date)
        {
            return manager.GetToDoItems().Where(x=>x.Deadline.Date.Equals(date.Date)).ToList();
        }

        private void AddNextDays(DateTime date)
        {
           DateTime day1 = date;
            while (day1.DayOfWeek != DayOfWeek.Saturday)
            {
                day1 = day1.AddDays(1);
                Days.Add(day1,GetItemsForDate(day1));
            }
        }

        private void AddPreviousDays(DateTime date)
        {
            var day1 = date;
            while (day1.DayOfWeek != DayOfWeek.Sunday)
            {
                day1 = day1.AddDays(-1);
                Days.Add(day1, GetItemsForDate(day1));
            }
        }

        public SortedDictionary<DateTime,IList<Item>> Days { get; set; }
    }
}