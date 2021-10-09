using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
	public class ToDoListContext : AddDbContext
	{
		public DbSet<Item> Items { get; set; }

		public ToDoListContext(DbContextOptions options) : base(options) { }
	}
}
