using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryTest : IDisposable
  {
    public void Dispose()
    {
      Category.ClearAll();
    }
    [TestMethod]
    public void CategoryConstructor_CreatesInstanceOfCategory_Category()
    {
      Category newCategory = new Category("test category");
      Assert.AreEqual(typeof(Category), newCategory.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Category";
      Category newCategory = new Category(name);

      //Act
      string result = newCategory.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetId_ReturnsCategoryId_Int()
    {
      //Arrange
      string name = "Test Category";
      Category newCategory = new Category(name);

      //Act
      int result = newCategory.GetId();

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllCategoryObjects_CategoryList()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      Category newCategory1 = new Category(name01);
      Category newCategory2 = new Category(name02);
      List<Category> newList = new List<Category> {newCategory1, newCategory2};

      //Act
      List<Category> result = Category.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
     [TestMethod]
     public void Find_ReturnsCorrectCategory_Category()
     {
       //Arrange
       Category newCategory1 = new Category("work");
       Category newCategory2 = new Category("School");

       //Act
       Category result = Category.Find(2);

       //Assert
       Assert.AreEqual (newCategory2, result);
     }
     [TestMethod]
     public void GetItems_ReturnsEmptyItemList_ItemList()
     {
       //Arrange
       string name= "work";
       Category newCategory = new Category("work");
       List<Item> newList = new List<Item>{};

       //Act
       List<Item> result = newCategory.GetItems();

       //Assert
       CollectionAssert.AreEqual(newList, result);
     }

     [TestMethod]
     public void AddItem_AssociatesItemWithCategory_ItemList()
     {
       //Arrange
       Item newItem = new Item("Walk the dog");
       List<Item> newList = new List<Item> { newItem };
       Category newCategory = new Category("Work");
       newCategory.AddItem(newItem);

       //Act
       List<Item> result = newCategory.GetItems();

       //Assert
       CollectionAssert.AreEqual(newList, result);
     }
  }
}
