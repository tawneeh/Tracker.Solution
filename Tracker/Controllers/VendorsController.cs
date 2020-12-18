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

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string title, string description, string price, string date)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor specificVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(title, description, price, date);
      specificVendor.AddOrder(newOrder);
      List<Order> vendorOrders = specificVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendor", specificVendor);
      return View("Show", model);
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