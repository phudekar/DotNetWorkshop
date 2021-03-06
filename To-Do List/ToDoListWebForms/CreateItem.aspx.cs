﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoList.Common;
using ToDoList.Common.Manager;

namespace ToDoListWebForms
{
    public partial class About : Page
    {
        private MySqlDataManager dataManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            dataManager = new MySqlDataManager();
        }

        protected void CreateItem(object sender, EventArgs e)
        {
            var item = new Item(DateTime.Parse(txtDeadline.Text));

            item.Title = txtTitle.Text;
            item.Description = txtDescription.Text;

            dataManager.SaveItem(item);
            Response.Redirect("~/Default.aspx");
        }
    }
}