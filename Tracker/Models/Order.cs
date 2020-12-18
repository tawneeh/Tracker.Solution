using System.Collections.Generic;

namespace Tracker.Models
{
  public class Order
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; } // set as string, can always Parse later...
    public string Date { get; set; }
    public int Id { get; }
    private static List<Order> _instances = new List<Order> {}; 

    public Order(string title, string description, int price, string date)
    {
      Title = title;
      Description = description;
      Price = price;
      Date = date;
      _instances.Add(this);
      Id = _instances.Count; 
    }

  }
}