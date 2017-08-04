using System.Collections.Generic;

namespace AddressBook.Models
{
  public class Contact
  {
    private string _name;
    private string _phone;
    private int _id;
    private List<Address> _addresses;

    private static List<Contact> _contactList = new List<Contact>{};

    public Contact(string name, string phone, Address address)
    {
      _name = name;
      _phone = phone;
      _addresses = new List<Address>{address};

      _contactList.Add(this);
      _id = _contactList.Count;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public string GetPhone()
    {
      return _phone;
    }

    public void SetPhone(string newPhone)
    {
      _name = newPhone;
    }

    public List<Address> GetAddresses()
    {
      return _addresses;
    }

    public void AddAddress(Address newAddress)
    {
      _addresses.Add(newAddress);
    }

    public int GetId()
    {
      return _id;
    }

    public void SetId(int newId)
    {
      _id = newId;
    }

    public static List<Contact> GetAllContacts()
    {
      return _contactList;
    }

    public static void ClearAll()
    {
      _contactList.Clear();
    }

    public static void RemoveSpecific(int id)
    {
      _contactList.RemoveAt(id - 1);

      for (int index = _contactList.Count; index > 0; index--)
      {
        _contactList[index - 1].SetId(index);
      }
    }

    public static Contact Find(int searchId)
    {
      return _contactList[searchId - 1];
    }
  }
}
