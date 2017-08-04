using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using AddressBook.Models;

namespace AddressBook.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View(Contact.GetAllContacts());
    }

    [HttpGet("/contact/create")]
    public ActionResult ContactNewForm()
    {
      return View();
    }

    [HttpGet("/contact/{id}")]
    public ActionResult ContactDetail(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};

      Contact myContact = Contact.Find(id);
      List<Address> addresses = myContact.GetAddresses();

      model.Add("contact", myContact);
      model.Add("addresses", addresses);

      return View(model);
    }

    [HttpGet("contact/{id}/address")]
    public ActionResult ContactNewAddress(int id)
    {
      Contact currentContact = Contact.Find(id);

      return View(currentContact);
    }

    [HttpPost("contact/{id}")]
    public ActionResult ContactNewAddressPost(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};

      string type = Request.Form["address-type"];
      string street = Request.Form["address-street"];
      string city = Request.Form["address-city"];
      string state = Request.Form["address-state"];
      string zip = Request.Form["address-zip"];

      Contact currentContact = Contact.Find(id);
      Address newAddress = new Address(type, street, city, state, zip);
      currentContact.AddAddress(newAddress);

      model.Add("contact", currentContact);
      model.Add("addresses", currentContact.GetAddresses());

      return View("contactDetail", model);

    }

    [HttpPost("/contact/new")]
    public ActionResult ContactCreated()
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};

      string name = Request.Form["contact-name"];
      string phone = Request.Form["contact-phone"];
      string type = Request.Form["address-type"];
      string street = Request.Form["address-street"];
      string city = Request.Form["address-city"];
      string state = Request.Form["address-state"];
      string zip = Request.Form["address-zip"];

      Address newAddress = new Address(type, street, city, state, zip);
      Contact newContact = new Contact(name, phone, newAddress);

      model.Add("address", newAddress);
      model.Add("contact", newContact);

      return View(model);
    }

    [HttpPost("/contact/clear")]
    public ActionResult ContactClear()
    {
      Contact.ClearAll();

      return View();
    }

    [HttpPost("/contact/remove/{id}")]
    public ActionResult ContactRemoved(int id)
    {
      Contact.RemoveSpecific(id);

      return View(Contact.GetAllContacts());
    }


  }
}
