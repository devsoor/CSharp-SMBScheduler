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
    [Route("rec")]
    public class ReceptionistController : Controller
    {
        // database setup
        public ProjectContext dbContext;
        public ReceptionistController(ProjectContext context)
        {
            dbContext = context;

        }
        // User session to keep track who is logged in!!
        private User UserSession {
            get {return dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));}
            set {HttpContext.Session.SetInt32("UserId", value.UserId);}
        }
        private IActionResult AccessCheck() {
            User ActiveUser = UserSession;
            if(ActiveUser == null) {
                return RedirectToAction("Login", "Login");
            } else if (ActiveUser.Role == 0) {
                ////////// REPLACE WITH A REDIRECT TO DEFAULT DASHBOARD //////////
                return RedirectToAction("Logout", "Login");
            } else if (ActiveUser.Role == 1) {
                return RedirectToAction("Dashboard", "Practitioner");
            }
            return null;
        }

        // Routes
        
<<<<<<< Updated upstream
        [HttpGet]
        public IActionResult RDashboard()
=======
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
>>>>>>> Stashed changes
        {
            AccessCheck();
            ViewModel vm = new ViewModel();
            vm.CurrentUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            vm.AllUsers = dbContext.Users.ToList();
            vm.AllCustomers = dbContext.Customers.ToList();
            vm.AllInsurances = dbContext.Insurances.ToList();
            vm.AllServices = dbContext.Services.ToList();
            vm.AllTimeslots = dbContext.Timeslots.ToList();
            // List<Reservation> list = Query.AllThisWeeksReservations(dbContext);
            // var weeklyReservations = list;
            return View(vm);
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
            ViewModel vm = new ViewModel();
            vm.CurrentUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            vm.AllUsers = dbContext.Users.ToList();
            vm.AllCustomers = dbContext.Customers.ToList();
            vm.AllInsurances = dbContext.Insurances.ToList();
            vm.AllServices = dbContext.Services.ToList();
            vm.AllTimeslots = dbContext.Timeslots.ToList();
            return View(vm);
        }


        [HttpPost]
        public IActionResult CreateReservation(ViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Query.CreateReservation(vm.OneReservation, dbContext);
                return RedirectToAction("RDashboard", "Receptionist");
            }
            else
            {
                return View("NewReservation");
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
            ViewModel vm = new ViewModel();
            vm.CurrentUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            vm.AllUsers = dbContext.Users.ToList();
            vm.AllCustomers = dbContext.Customers.ToList();
            vm.AllInsurances = dbContext.Insurances.ToList();
            vm.AllServices = dbContext.Services.ToList();
            vm.AllTimeslots = dbContext.Timeslots.ToList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateCustomer(ViewModel vm)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(vm.OneCustomer);
                dbContext.SaveChanges();
                return RedirectToAction("RDashboard", "Receptionist");
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
<<<<<<< Updated upstream

        [HttpGet]
        public IActionResult OneDayAvailability(DateTime day)
        {
            ViewModel vm = new ViewModel();
            vm.AllTimeslots = Query.OneDaysTimeslots(day, dbContext);
            return View("DayViewTimeslots", vm);
        }
        
        [HttpGet]
        public IActionResult TodaysAvailability()
        {
            ViewModel vm = new ViewModel();
            vm.AllTimeslots = Query.TodaysTimeslots(dbContext);
            return View("DayViewTimeslots", vm);
        }

        [HttpGet]
        public IActionResult ThisWeeksAvailability()
        {
            ViewModel vm = new ViewModel();
            vm.AllTimeslots = Query.ThisWeeksTimeslots(dbContext);
            return View("WeekViewTimeslots", vm);
        }
        [HttpGet]
        public IActionResult ThisMonthsAvailability()
        {
            ViewModel vm = new ViewModel();
            vm.AllTimeslots = Query.ThisMonthsTimeslots(dbContext);
            return View("MonthViewTimeslots", vm);
        }
        
        [HttpGet]
        public IActionResult OneWeeksAvailability(DateTime startDay)
        {
            ViewModel vm = new ViewModel();
            vm.AllTimeslots = Query.OneWeeksTimeslots(startDay, dbContext);
            return View("WeekViewTimeslots", vm);
        }

        [HttpGet]
        public IActionResult OneMonthsAvailability(DateTime dayInMonth)
        {
            ViewModel vm = new ViewModel();
            vm.AllTimeslots = Query.OneMonthsTimeslots(dayInMonth, dbContext);
            return View("MonthViewTimeslots", vm);
        }





=======
>>>>>>> Stashed changes
    }
}
