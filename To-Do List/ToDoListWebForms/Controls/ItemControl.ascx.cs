using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ToDoList.Common;

namespace ToDoListWebForms.Controls
{
    public partial class ItemControl : System.Web.UI.UserControl
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public String Deadline { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var dayRemaining = 0;
            if (!String.IsNullOrEmpty(Deadline))
            {
                dayRemaining = DateTime.Parse(Deadline).Date.Subtract(DateTime.Now).Days;
            }

            itemDeadline.Text = dayRemaining > 0 ? dayRemaining + " days remaining" : "already passed deadline";
            var cssClass = "";
            if (dayRemaining > 4)
                cssClass = "relaxDeadline";
            else if (dayRemaining > 1)
                cssClass = "fairDeadline";
            else
                cssClass = "shortDeadline";

            itemDiv.Attributes.Add("class", cssClass);

            itemTitle.Text = Title;
            itemDescription.Text = Description;
        }
    }
}

