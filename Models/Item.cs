using System.Collections.Generic;

namespace Project.Models
{
  public class Item
  {
    private string _description;
    private string _details;
    private int _id;
    private string _phone;
    private static List<Item> _instances = new List<Item> {};

    public Item(string description, string details, string phone)
    {
      _description = description;
      _details = details;
      _phone = phone;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetDetails()
    {
      return _details;
    }

    public void SetDetails(string newDetails)
    {
      _details = newDetails;
    }

    public string GetPhone()
    {
      return _phone;
    }
    public void SetPhone(string newPhone)
    {
      _phone = newPhone;
    }

    public string GetDescription()
    {
      return _description;
    }

    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Item> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Item Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
