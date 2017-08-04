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
      Contact myContact = Contact.Find(id);

      return View(myContact);
    }

    [HttpPost("/contact/new")]
    public ActionResult ContactCreated()
    {
      string name = Request.Form["contact-name"];
      string phone = Request.Form["contact-phone"];
      string address = Request.Form["contact-address"];

      Contact newContact = new Contact(name, phone, address);

      return View(newContact);
    }

    [HttpPost("/contact/clear")]
    public ActionResult ContactClear()
    {
      Contact.ClearAll();

      return View();
    }

    [HttpPost("/contact/remove/{id}")]
    public ActionResult ContactRemove(int id)
    {
      Contact.RemoveSpecific(id);

      return View("index", Contact.GetAllContacts());
    }
  }
}
