using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList.Common
{
    public interface IDataManager
    {
        List<Item> GetToDoItems();
        bool SaveItem(Item item);
        bool SaveItems(List<Item> item);
        List<Item> GetPendingItems();
        void DeleteItems(List<Item> items);
        void UpdateItems(List<Item> items);
    }
}
