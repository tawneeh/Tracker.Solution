using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracker.Models;
using System.Collections.Generic;
using System;

namespace Tracker.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("Test Vendor", "Test Description");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_VendorList()
    {
      List<Vendor> newList = new List<Vendor> { };
      List<Vendor> result = Vendor.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      string vendorName1 = "Test Vendor";
      string description1 = "Test Description";
      string vendorName2 = "Test Vendor 2";
      string description2 = "Test Description 2";
      Vendor newVendor1 = new Vendor(vendorName1, description1);
      Vendor newVendor2 = new Vendor(vendorName2, description2);
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };
      List<Vendor> result = Vendor.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      string vendorName1 = "Test Vendor";
      string description1 = "Test Description";
      string vendorName2 = "Test Vendor 2";
      string description2 = "Test Description 2";
      Vendor newVendor1 = new Vendor(vendorName1, description1);
      Vendor newVendor2 = new Vendor(vendorName2, description2);
      Vendor result = Vendor.Find(1);
      Assert.AreEqual(newVendor1, result);
    }

    [TestMethod]
    public void AddOrder_AssociatesOrderWithVendor_OrderList()
    {
      string title = "Order 1";
      string description = "One item";
      string price = "$5";
      string date = "December 18, 2020";
      Order newOrder = new Order(title, description, price, date);
      List<Order> newList = new List<Order> { newOrder };
      string vendorName = "Test Vendor";
      string vendorDescription = "Test Description";
      Vendor newVendor = new Vendor(vendorName, vendorDescription);
      newVendor.AddOrder(newOrder);
      List<Order> result = newVendor.Orders;
      CollectionAssert.AreEqual(newList, result);
    }

  }
}