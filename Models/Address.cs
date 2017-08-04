using System.Collections.Generic;

namespace AddressBook.Models
{
  public class Address
  {
    private string _type;
    private string _street;
    private string _city;
    private string _state;
    private string _zip;
    private int _id;

    private static List<Address> _addressList = new List<Address>{};

    public Address(street, city, state, zip)
    {
      _street = street;
      _city = city;
      _state = state;
      _zip = zip;
      _addressList.Add(this);
      _id = _addressList.Count;
    }

    public string GetType()
    {
      return _type;
    }

    public void SetType(string newType)
    {
      _type = newType;
    }

    public string GetStreet()
    {
      return _street;
    }

    public void SetStreet(string newStreet)
    {
      _street = newStreet;
    }

    public string GetCity()
    {
      return _city;
    }

    public void SetCity(string newCity)
    {
      _city = newCity;
    }

    public string GetState()
    {
      return _state;
    }

    public void SetState(string newState)
    {
      _state = newState;
    }

    public string GetZip()
    {
      return _zip;
    }

    public void SetZip(string newZip)
    {
      _zip = newZip;
    }

    public string GetId()
    {
      return _id;
    }

    public void SetId(int newId)
    {
      _id = newId;
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
