using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ToDoList.Common
{
    public class DataManager : IDataManager
    {
        const string FILE_PATH = "Resources/ToDoList.txt";
        private XmlSerializer xmlSerializer;

        public DataManager()
        {
          xmlSerializer =  new XmlSerializer(typeof(List<Item>));
        }

        public List<Item> GetToDoItems()
        {
            var items = new List<Item>();
            if (!File.Exists(FILE_PATH))
                return items;
            FileStream fileStream = null;
            try
            {
                fileStream = File.OpenRead(FILE_PATH);
                items = (List<Item>)xmlSerializer.Deserialize(fileStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            } 

            return items;
        }

        public bool SaveItem(Item item)
        {
            FileStream fileStream = null;
            try
            {
                if (!File.Exists(FILE_PATH))
                    File.Create(FILE_PATH);
                var toDoItems = GetToDoItems();
                toDoItems.Add(item);
                fileStream = File.Open(FILE_PATH,FileMode.Open);
                xmlSerializer.Serialize(fileStream, toDoItems);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            } 
        }

        public List<Item> GetPendingItems()
        {
            var pendingItems = GetToDoItems().Where(item => IsPendingItem(item)).ToList();
            pendingItems.Sort();
            return pendingItems;
        }

        public void DeleteItems(List<Item> items)
        {
            var toDoItems = GetToDoItems();
            items.ForEach(item => toDoItems.Remove(item));
            SaveItems(toDoItems);
        }

        public void UpdateItems(List<Item> items)
        {
 
        }

        public bool SaveItems(List<Item> items)
        {
            FileStream fileStream = null;
            try
            {
                if (!File.Exists(FILE_PATH))
                    File.Create(FILE_PATH);
                fileStream = File.Open(FILE_PATH,FileMode.Truncate);
                xmlSerializer.Serialize(fileStream, items);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            } 
        }

        private bool IsPendingItem(Item item)
        {
           return item.Status == Status.Pending;
        }
    }
}
