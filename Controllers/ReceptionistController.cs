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

        // User session to keep track who is logged in!!
        private int UserIdSession {
            get {
                    if(HttpContext.Session.GetInt32("UserId") != null ) {
                        return (int)HttpContext.Session.GetInt32("UserId");
                    }
                    else {
                        return -1;
                    }
                }
            set {HttpContext.Session.SetInt32("userId", (int)value);}
        } 

        // User's Role session to keep track their roles
        private int UserRoleSession {
            get {
                    if(HttpContext.Session.GetInt32("Role") != null ) {
                        return (int)HttpContext.Session.GetInt32("Role");
                    }
                    else {
                        return -1;
                    }
                }
            set {HttpContext.Session.SetInt32("Role", (int)value);}
        }

        // Routes

        // logout user clear session
        [HttpGet("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult RDashboard()
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





    }
}
