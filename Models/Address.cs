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

    public Address(string type, string street, string city, string state, string zip)
    {
      _type = type;
      _street = street;
      _city = city;
      _state = state;
      _zip = zip;
      _addressList.Add(this);
      _id = _addressList.Count;
    }

    public string GetAddressType()
    {
      return _type;
    }

    public void SetAddressType(string newType)
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

    public int GetId()
    {
      return _id;
    }

    public void SetId(int newId)
    {
      _id = newId;
    }

    public static void RemoveSpecific(int id)
    {
      _addressList.RemoveAt(id - 1);

      for (int index = _addressList.Count; index > 0; index--)
      {
        _addressList[index - 1].SetId(index);
      }
    }

    public static Address Find(int searchId)
    {
      return _addressList[searchId - 1];
    }
  }
}
