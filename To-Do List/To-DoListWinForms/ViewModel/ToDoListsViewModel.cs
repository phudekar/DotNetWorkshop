using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Common;

namespace To_DoListWinForms.ViewModel
{
    public class ToDoListsViewModel : INotifyPropertyChanged
    {
        private Item selectedItem;
        public Item Item
        {
            get { return selectedItem; }
            set
            {
                if (value.Equals(selectedItem))
                    return;
                this.selectedItem = value;
                OnPropertyChanged("Item");
            }
        }
        private List<Item> items;
        public List<Item> Items
        {
            get { return items; }
            set
            {
                if (this.items.Equals(value))
                    return;
                this.items = value;
                OnPropertyChanged("Items");
            }
        }

        public ToDoListsViewModel()
        {
            this.items = new List<Item>();
            this.Item = new Item();
        }

        public void SetSelectedItem(Item item)
        {
            this.Item = item;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
