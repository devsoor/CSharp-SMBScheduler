using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using massage.Models;
using Microsoft.AspNetCore.Http;

namespace massage.Controllers
{
    public class ReceptionistController : Controller
    {
        // database setup
        public ProjectContext dbContext;
        public ReceptionistController(ProjectContext context)
        {
            dbContext = context;

        }

        // all reservations
        [HttpGet]
        public IActionResult Dashboard()
        {

            ViewModel vm = new ViewModel();
            vm.CurrentUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            vm.AllUsers = dbContext.Users.ToList();
            vm.AllCustomers = dbContext.Customers.ToList();
            vm.AllInsurances = dbContext.Insurances.ToList();
            vm.AllServices = dbContext.Services.ToList();
            vm.AllTimeslots = dbContext.Timeslots.ToList();
            // List<Reservation> list = Query.AllThisWeeksReservations(dbContext);
            // var weeklyReservations = list;
            return View();
        }


        [HttpGet]
        public IActionResult AllReservations()
        {
            Query.AllReservations(dbContext);
            return View();
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateReservation(Reservation newReservation)
        {
            if (ModelState.IsValid)
            {
                Query.CreateReservation(newReservation, dbContext);
                return RedirectToAction("Dashboard", "Receptionist");
            }
            else
            {
                return View("newReservation");
            }
        }


        [HttpPost]
        public IActionResult CancelReservation(Reservation newReservation)
        {
            Query.DeleteReservation(newReservation.ReservationId, dbContext);
            return RedirectToAction("Dashboard", "Receptionist");
        }


        [HttpGet]
        public IActionResult AllCustomers()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(User customer)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(customer);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard", "Receptionist");
            }
            else
            {
                return View("NewCustomer");
            }
        }

        [HttpGet]
        public IActionResult MyProfile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdatedProfile(User receptionist)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(receptionist);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard", "Receptionist");
            }
            else
            {
                return View("EditProfile");
            }
        }






    }
}
