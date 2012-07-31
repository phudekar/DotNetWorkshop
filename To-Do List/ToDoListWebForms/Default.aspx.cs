using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoList.Common;
using ToDoList.Common.Manager;
using ToDoListWebForms.Controls;

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

            foreach (var item in ToDoItems)
            {
                var itemControl = (ItemControl) Page.LoadControl("~/Controls/ItemControl.ascx");
                itemControl.Title = item.Title;
                itemControl.Description = item.Description;
                itemControl.Deadline = item.Deadline.ToShortDateString();
                itemsList.Controls.Add(itemControl);
            }
            
        }

    }
}