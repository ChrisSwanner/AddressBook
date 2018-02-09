using System.Collections.Generic;

namespace Project.Models
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _name;
    private int _id;
    private List<Item> _items;

    public Contact(string contactName)
    {
      _name = contactName;
      _instances.Add(this);
      _id = _instances.Count;
      _items = new List<Item>{};
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId-1];
    }
		public List<Item> GetItems()
		{
  	return _items;
		}
		public void AddItem(Item item)
		{
  		_items.Add(item);
		}
		public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}
