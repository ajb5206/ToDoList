using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
	public class Item
	{
		public string Description { get; set; }
		public int Price {get; set; }
		public int Id { get; set; }

		public Item(string description, int price)
		{
			Description = description;
			Price = price;
		}

		public Item(string description, int price, int id)
		{
			Description = description;
			Price = price;
			Id = id;
		}

		public override bool Equals(System.Object otherItem)
		{
			if (!(otherItem is Item))
			{
				return false;
			}
			else
			{
				Item newItem = (Item) otherItem;
				bool idEquality = (this.Id == newItem.Id);
				bool descriptionEquality = (this.Description == newItem.Description);
				bool priceEquality = (this.Price == newItem.Price);
				return (idEquality && descriptionEquality && priceEquality);
			}
		}

		public void Save()
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"INSERT INTO items (description, price) VALUES (@ItemDescription, @ItemPrice);";
			MySqlParameter description = new MySqlParameter();
			description.ParameterName = "@ItemDescription";
			description.Value = this.Description;
			cmd.Parameters.Add(description);
			MySqlParameter price = new MySqlParameter();
			price.ParameterName = "@ItemPrice";
			price.Value = this.Price;
			cmd.Parameters.Add(price);
			cmd.ExecuteNonQuery();
			Id = (int) cmd.LastInsertedId;
			conn.Close();
			if (conn != null)
			{
				conn.Dispose();
			}
		}

		public static List<Item> GetAll()
		{
			List<Item> allItems = new List<Item> { };
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT * FROM items;";
			MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
			while (rdr.Read())
			{
				int itemId = rdr.GetInt32(0);
				string itemDescription = rdr.GetString(1);
				int itemPrice = rdr.GetInt32(2);
				Item newItem = new Item(itemDescription, itemPrice, itemId);
				allItems.Add(newItem);
			}
			conn.Close();
			if (conn != null)
			{
				conn.Dispose();
			}
			return allItems;
		}

		public static void ClearAll()
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"DELETE FROM items;";
			cmd.ExecuteNonQuery();
			conn.Close();
			if (conn != null)
			{
				conn.Dispose();
			}
		}

		public static Item Find(int searchId)
		{
			// Temporarily returning placeholder item to get beyond compiler errors until we refactor to work with database.
    Item placeholderItem = new Item("placeholder item", 0);
    return placeholderItem;
		}
	}
}