using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ToDoList.Common.Manager
{
    public class MySqlDataManager : IDataManager
    {
        private String connectionString;

        public MySqlDataManager()
        {
            connectionString = "Network Address=localhost;" +
                                 "Initial Catalog='ToDoListItems';" +
                                 "Persist Security Info=no;" +
                                 "User Name='root';" +
                                 "Password='password'";
        }

        public List<Item> GetToDoItems()
        {
            var adapter = new MySqlDataAdapter("select * from Items", new MySqlConnection(connectionString));
            var dataset = new DataSet("AllItems");
            adapter.Fill(dataset);
            return GetItemsFromDataset(dataset);
        }

        private List<Item> GetItemsFromDataset(DataSet dataset)
        {
            var items = new List<Item>();
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                var item = new Item(DateTime.Parse(row["Deadline"].ToString()))
                    {
                        Id = long.Parse(row["iditems"].ToString()),
                        Title = row["Title"].ToString(),
                        Description = row["Description"].ToString(),
                        Status = (Status)Enum.Parse(typeof(Status), row["Status"].ToString())
                    };
                items.Add(item);

            }
            return items;
        }

        public bool SaveItem(Item item)
        {
            int rowsAffected = 0;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    var command =
                        new MySqlCommand("insert into Items (Title,Description,Status,Deadline) values('" +
                                         item.Title + "','" +
                                         item.Description + "','" +
                                         item.Status.ToString() + "','" +
                                         item.Deadline.ToString("yyyy-MM-dd") + "')", connection);
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return rowsAffected > 0;
        }

        public bool SaveItems(List<Item> item)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetPendingItems()
        {
            var adapter = new MySqlDataAdapter("select * from Items where Status = 'Pending'", new MySqlConnection(connectionString));
            var dataset = new DataSet("AllItems");
            adapter.Fill(dataset);
            return GetItemsFromDataset(dataset);
        }

        public void DeleteItems(List<Item> items)
        {
            int rowsAffected = 0;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    var builder = new StringBuilder("delete from Items where iditems in (");

                    builder.Append(items[0].Id);
                    for (var i = 1; i < items.Count(); i++)
                    {
                        builder.Append(",");
                        builder.Append(items[i].Id);
                    }
                    builder.Append(")");

                    var command =
                        new MySqlCommand(builder.ToString(), connection);
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void UpdateItems(List<Item> items)
        {
            int rowsAffected = 0;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    var builder = new StringBuilder("update Items set Status = 'Done' where iditems in (");

                    builder.Append(items[0].Id);
                    for (var i = 1; i < items.Count(); i++)
                    {
                        builder.Append(",");
                        builder.Append(items[i].Id);
                    }
                    builder.Append(")");

                    var command =
                        new MySqlCommand(builder.ToString(), connection);
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
