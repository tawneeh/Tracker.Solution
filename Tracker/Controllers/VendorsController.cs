using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tracker.Models;

namespace Tracker.Controllers
{
  public class VendorsController : Controller
  {

    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string name, string description)
    {
      Vendor newVendor = new Vendor(name, description);
      return RedirectToAction("Index");
    }

    [HttpPost()]
    public ActionResult Create(int vendorId, string orderTitle, string orderDescription, string orderPrice, string orderDate)
    {
      Dictionary<string, object> tracker = new Dictionary<string, object>();
      Vendor specificVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(orderTitle, orderDescription, orderPrice, orderDate);
      specificVendor.AddOrder(newOrder);
      List<Order> vendorOrders = specificVendor.Orders;
      tracker.Add("orders", vendorOrders);
      tracker.Add("vendor", specificVendor);
      return View("Show", tracker);
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> tracker = new Dictionary<string, object>();
      Vendor specificVendor = Vendor.Find(id);
      List<Order> vendorOrders = specificVendor.Orders;
      tracker.Add("vendor", specificVendor);
      tracker.Add("orders", vendorOrders);
      return View(tracker);
    }

  }
}