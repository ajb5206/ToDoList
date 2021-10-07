using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryTests : IDisposable
	{

		public void Dispose()
		{
			Category.ClearAll();
		}

		[TestMethod]
    public void CategoryConstructor_CreatesInstanceOfCategory_Category()
    {
      Category newCategory = new Category("test category", "test description");
      Assert.AreEqual(typeof(Category), newCategory.GetType());
    }

		[TestMethod]
		public void GetName_ReturnsName_String()
		{
			string name = "Test Category";
			string description = "test description";
			Category newCategory = new Category(name, description);
			string result = newCategory.Name;
			Assert.AreEqual(name, result);
		}

		[TestMethod]
		public void GetAll_ReturnsAllCategoryObjects_CategoryList()
		{
			string name01 = "Work";
			string name02 = "School";
			string description01 = "all day";
			string description02 = "play all day";
			Category newCategory1 = new Category(name01, description01);
			Category newCategory2 = new Category(name02, description02);
			List<Category> newList = new List<Category> { newCategory1, newCategory2};
			List<Category> result = Category.GetAll();
			CollectionAssert.AreEqual(newList, result);
		}

		// [TestMethod]
		// public void Find_ReturnsCorrectCategory_Category()
		// {
		// 	string name01 = "Work";
		// 	string name02 = "School";
		// 	Category newCategory1 = new Category(name01);
		// 	Category newCategory2 = new Category(name02);
		// 	Category result = Category.Find(2);
		// 	Assert.AreEqual(newCategory2, result);
		// }

		[TestMethod]
		public void AddItem_AssociatesItemWithCategory_ItemList()
		{
			string descriptionItem = "Walk the dog.";
			int price = 1;
			Item newItem = new Item(descriptionItem, price);
			List<Item> newList = new List<Item> { newItem };
			string name = "Work";
			string description = "all day";
			Category newCategory = new Category(name, description);
			newCategory.AddItem(newItem);
			List<Item> result = newCategory.Items;
			CollectionAssert.AreEqual(newList, result);
		}
  }
}