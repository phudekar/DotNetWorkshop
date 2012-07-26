using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Common
{
    class Program
    {
       static IDataManager dataManager;
        static void Main(string[] args)
        {
            Console.WriteLine("------- To-Do List --------");
            char option = '0';
            dataManager = new DataManager();
            do
            {
                option = ShowMenu();
                Console.Clear();
                switch (option)
                {
                    case '1':
                        var item = CreateItem();
                        Console.WriteLine(item);
                        break;
                    case '2':
                        ShowAllItems();
                        break;
                    case '3':
                        ShowPendingItems();
                        break;
                }
            } while (option != '9');
        }

        private static void ShowPendingItems()
        {
            Console.WriteLine("-------------- Displaying Pending Items -----------");
           ShowItems(dataManager.GetPendingItems());
        }

        private static void ShowAllItems()
        {
            Console.WriteLine("-------------- Displaying All Items -----------");
            ShowItems(dataManager.GetToDoItems());
        }

        private static void ShowItems(List<Item> items)
        {
          
            foreach (var item in items)
            {
                Console.WriteLine("\n{0}\n",item);
            }
        }

        private static Item CreateItem()
        {
            Console.WriteLine("\n------- Creating new item ------ ");
            Console.WriteLine("Enter title : ");
            var title = Console.ReadLine();
            Console.WriteLine("Enter description : ");
            var desciption = Console.ReadLine();
            Console.WriteLine("Enter deadline for task in mm/dd/yyyy format : ");
            DateTime deadline;
            if (DateTime.TryParse(Console.ReadLine(), out deadline))
            {
                var item = new Item(deadline)
                {
                    Title = title,
                    Description = desciption
                };

                
               dataManager.SaveItem(item);
               Console.Clear();
                Console.WriteLine("\nItem created");
                return item;
            }
            else
                Console.WriteLine("Sorry the deadline is INVALID. Try Again.");
            return CreateItem();
        }

        private static char ShowMenu()
        {
            Console.WriteLine("\nSelect operation");
            Console.WriteLine("1. Create new item");
            Console.WriteLine("2. View items");
            Console.WriteLine("3. View Pending items");
            Console.WriteLine("9. Exit");
            return Console.ReadKey().KeyChar;
        }

    }
}
