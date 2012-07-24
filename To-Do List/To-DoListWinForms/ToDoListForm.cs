
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ToDoList.Common;
using ToDoList.Common.Manager;
using To_DoListWinForms.ViewModel;

namespace To_DoListWinForms
{
    public partial class ToDoListForm : Form
    {
        private IDataManager dataManager;
        private List<Item> allItems;
        private ToDoListsViewModel model;

        public ToDoListForm()
        {
            InitializeComponent();
//            toDoItemsGridView.CellFormatting += FormatStatusCell;
            toDoItemsGridView.DataBindingComplete += ItemsGridView_DataBindingComplete;
            toDoItemsGridView.SelectionChanged +=ItemSelected;
//            dataManager = new DataManager();
            dataManager = new MySqlDataManager();
            deadlinePicker.Value = DateTime.Now.Date;
            model = new ToDoListsViewModel();

            titleTextBox.DataBindings.Add(new Binding("Text", model, "Item.Title"));
            descriptionTextbox.DataBindings.Add(new Binding("Text", model, "Item.Description"));
            deadlinePicker.DataBindings.Add(new Binding("Value", model, "Item.Deadline"));
            toDoItemsGridView.DataBindings.Add(new Binding("DataSource", model, "Items"));

        }

        private void ItemSelected(object sender, EventArgs e)
        {
          var rows =  toDoItemsGridView.SelectedRows;
            if(rows.Count != 1)
                return;
            var source = (List<Item>) toDoItemsGridView.DataSource;
            var item = source[rows[0].Index];
            model.SetSelectedItem(item);
        }


        void ItemsGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in toDoItemsGridView.Rows)
            {
                var statusCell = row.Cells["Status"];
                if (ToDoList.Common.Status.Pending.Equals(statusCell.Value))
                    statusCell.Style.BackColor = Color.BurlyWood;
                else
                    statusCell.Style.BackColor = Color.GreenYellow;
            }
        }

//        private void FormatStatusCell(object sender, DataGridViewCellFormattingEventArgs e)
//        {
//            var index = e.RowIndex;
//            var row = toDoItemsGridView.Rows[index];
//            if (!toDoItemsGridView.Columns[e.ColumnIndex].HeaderText.Equals("Status"))
//                return;
//
//            var item = allItems[index];
//            Color color;
//            if (item.Status == ToDoList.Common.Status.Pending)
//                color = Color.BurlyWood;
//            else
//                color = Color.GreenYellow;
//            row.Cells["Status"].Style.BackColor = color;
//        }

        private void OnLoad(object sender, System.EventArgs e)
        {
            allItems = dataManager.GetPendingItems();
           model.Items = allItems;
        }

        private void ResetText(object sender, System.EventArgs e)
        {
            titleTextBox.Text = "";
            titleError.Text = "";
            descriptionTextbox.Text = "";
            deadlinePicker.Value = DateTime.Now.Date;
        }

        private void CreateItem(object sender, EventArgs e)
        {
            var title = titleTextBox.Text.Trim();
            if (title.Length == 0)
            {
                titleError.Text = "Empty Title";
                return;
            }

            var description = descriptionTextbox.Text.Trim();
            var deadline = deadlinePicker.Value;

            var item = new Item(deadline)
                           {
                               Title = title,
                               Description = description
                           };
            dataManager.SaveItem(item);
            ResetText(this,e);
            ReloadGridData();
        }

        private void ShowAllItems(object sender, EventArgs e)
        {
           model.Items = dataManager.GetToDoItems();
        }

        private void ShowPendingItems(object sender, EventArgs e)
        {
            model.Items = dataManager.GetPendingItems();
        }

        private void DeleteItems(object sender, EventArgs e)
        {
            var items = GetSelectedItems();
            dataManager.DeleteItems(items);
            ReloadGridData();
        }

        private void ReloadGridData()
        {
            List<Item> itmes;
            if (showAllButton.Checked)
                itmes = dataManager.GetToDoItems();
            else
                itmes = dataManager.GetPendingItems();
           model.Items = itmes;
        }

        private List<Item> GetSelectedItems()
        {
            var rows = toDoItemsGridView.SelectedRows;
            var items = new List<Item>();
            foreach (DataGridViewRow row in rows)
            {
                items.Add(new Item(DateTime.Parse(row.Cells["Deadline"].Value.ToString()))
                              {
                                  Id = long.Parse(row.Cells["Id"].Value.ToString()),
                                  Title = row.Cells["Title"].Value.ToString(),
                                  Description = row.Cells["Description"].Value.ToString(),
                                  Status = (Status)Enum.Parse(typeof(Status), row.Cells["Status"].Value.ToString())

                              });
            }

            return items;
        }

        private void CompleteItems(object sender, EventArgs e)
        {
            var items = GetSelectedItems();
            items.ForEach(x=>x.Status = ToDoList.Common.Status.Done);
            dataManager.UpdateItems(items);
            ReloadGridData();
        }

        private void gridContenxtMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
           var rows = toDoItemsGridView.SelectedRows;
           if (rows.Count == 0)
               e.Cancel = true;
        }

    }
}
