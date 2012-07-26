using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoList.Common;
using ToDoList.Common.Manager;

namespace ToDoListWebForms
{
    public partial class _Default : Page
    {
        private MySqlDataManager dataManager;
        public List<Item> ToDoItems { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "New Title";
            dataManager = new MySqlDataManager();
            ToDoItems = dataManager.GetToDoItems();
        }
    }
}