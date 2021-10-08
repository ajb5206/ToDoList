using MySql.Data.MySqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;


namespace ToDoList.Tests
{
	[TestClass]
	public class ItemTests : IDisposable
	{

		public void Dispose()
		{
			Item.ClearAll();
		}

		public ItemTests()
		{
			DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=to_do_list_test;";
		}

		[TestMethod]
		public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
		{
			Item firstItem = new Item("Mow the lawn", 1);
			Item secondItem = new Item("Mow the lawn", 1);
			Assert.AreEqual(firstItem, secondItem);
		}

		[TestMethod]
		public void Save_SavesToDatabase_ItemList()
		{
			Item testItem = new Item("Mow the lawn", 1);
			testItem.Save();
			List<Item> result = Item.GetAll();
			List<Item> testList = new List<Item>{testItem};
			CollectionAssert.AreEqual(testList, result);
		}
// 		[TestMethod]
// 		public void ItemConstructor_CreatesInstanceOfItem_Item()
// 		{
// 			Item newItem = new Item("test", 0);
// 			Assert.AreEqual(typeof(Item), newItem.GetType());
// 		}

// 		[TestMethod]
// 		public void GetDescription_ReturnsDescription_String()
// 		{
// 			string description = "Walk the dog.";
// 			int price = 0;
// 			Item newItem = new Item(description, price);
// 			string result = newItem.Description;
// 			//int resultPrice = newItem.Price;
// 			Assert.AreEqual(description, result);
// 		}
// 		[TestMethod]
// 		public void SetDescription_SetDescription_String()
// 		{
// 			string description = "Walk the dog.";
// 			int price = 1;
// 			Item newItem = new Item(description, price);
// 			string updatedDescription = "Do the dishes.";
// 			newItem.Description = updatedDescription;
// 			string result = newItem.Description;
// 			Assert.AreEqual(updatedDescription, result);
// 		}

		[TestMethod]
		public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
		{
			List<Item> newList = new List<Item> { };
			List<Item> result = Item.GetAll();
			CollectionAssert.AreEqual(newList, result);
		}

		[TestMethod]
		public void GetAll_ReturnsItems_ItemList()
		{
			int price01 = 1;
			string description01 = "Walk the dog";
			int price02 = 2;
			string description02 = "Wash the dishes";
			Item newItem1 = new Item(description01, price01);
			newItem1.Save();
			Item newItem2 = new Item(description02, price02);
			newItem2.Save();
			List<Item> newList = new List<Item> { newItem1, newItem2 };
			List<Item> result = Item.GetAll();
			CollectionAssert.AreEqual(newList, result);
		}

// 		[TestMethod]
// 		public void GetId_TemsInstantiateWithanIdAndGetterReturns_Int()
// 		{
// 			string description= "Walk the dog.";
// 			int price = 1;
// 			Item newItem = new Item(description, price);
// 			int result = newItem.Id;
// 			Assert.AreEqual(1, result);
// 		}

		[TestMethod]
		public void Find_ReturnsCorrectItemFromDatabase_Item()
		{
			Item newItem = new Item("Mow the lawn", 1);
			newItem.Save();
			Item newItem2 = new Item("Wash the dishes", 1);
			newItem2.Save()
			Item foundItem = Item.Find(newItem.Id);
			Assert.AreEqual(newItem, foundItem);
			
		}
	}
}