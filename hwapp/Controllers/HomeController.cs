using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using hwapp.Models;

namespace hwapp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Registrations customer)
        {
            if(ModelState.IsValid)
            {
                using (var dbContext = new RegisterContext())
                {
                    dbContext.Registrations.Add(new Registrations() {
                        LastName = customer.LastName,
                        FirstName = customer.FirstName,
                        Address1 = customer.Address1,
                        Address2 = customer.Address2,
                        City = customer.City,
                        State = customer.State,
                        Country = customer.Country,
                        Zip = customer.Zip,
                        Date = DateTime.Now
                    });

                    try
                    {
                        dbContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        //log this error
                        return Redirect("Home/ValidationError");
                    }
                }
                return View("Confirmation");
            }
            else
            {
                return View();
            }
        }
        public IActionResult RegisteredUserReport()
        {
            var records = new List<Registrations>();
            using (var dbContext = new RegisterContext())
            {
                records = dbContext.Registrations.OrderByDescending(x => x.Date).ToList();
            }
            return View(records);
        }
        public IActionResult ValidationError()
        {
            return View();
        }
        public IActionResult Confirmation()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
