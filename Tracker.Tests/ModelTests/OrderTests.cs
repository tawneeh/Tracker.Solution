using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracker.Models;
using System.Collections.Generic;
using System; 

namespace Tracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("Order 1", "One item", "$5", "December 18, 2020");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      List<Order> newList = new List<Order> { };
      List<Order> result = Order.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsOrders_OrderList()
    {
      string title = "Order 1";
      string description = "One item";
      string price = "$5";
      string date = "December 18, 2020";
      Order newOrder = new Order(title, description, price, date);
      List<Order> newList = new List<Order> { newOrder };
      List<Order> result = Order.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
      string title1 = "Order 1";
      string description1 = "One item";
      string price1 = "$5";
      string date1 = "December 18, 2020";
      Order newOrder1 = new Order(title1, description1, price1, date1);
      string title2 = "Order 2";
      string description2 = "One item";
      string price2 = "$5";
      string date2 = "December 18, 2020";
      Order newOrder2 = new Order(title2, description2, price2, date2);
      Order result = Order.Find(1);
      Assert.AreEqual(newOrder2, result);
    }

  }
}