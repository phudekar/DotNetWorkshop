using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Common
{
    public class Item : IComparable<Item>
    {
        public long Id { get; set; }
        private String title;
        public String Title { get { return title; } set { this.title = value; } }
        public String Description { get; set; }
        public Status Status { get; set; }
        public DateTime Deadline { get; set; }

        public Item()
        {
            Title = "";
            Description = "";
            Deadline = DateTime.Now;
        }

        public Item(String title, String description, DateTime deadline):this(deadline)
        {
            Title = title;
            Description = description;
        }

        public Item(DateTime deadline)
        {
            this.Status = Status.Pending;
            this.Deadline = deadline;
        }

        public int CompareTo(Item other)
        {
            return this.Deadline.CompareTo(other.Deadline);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Title : " + Title);
            builder.AppendLine("Description : " + Description);
            builder.AppendLine("Status : " + Status);
            builder.AppendLine("Deadline : " + Deadline.ToShortDateString());

            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Item) obj);
        }

        protected bool Equals(Item other)
        {
            return String.Equals(title, other.title)
                   && String.Equals(Description, other.Description)
                   && DateTime.Equals(Deadline, other.Deadline)
                   && this.Status.Equals(other.Status);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Status.GetHashCode();
                hashCode = (hashCode * 397) ^ Deadline.GetHashCode();
                return hashCode;
            }
        }
    }
}
