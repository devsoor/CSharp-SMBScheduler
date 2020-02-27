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
        // Database setup
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
        // Redirects non-practitioner users to their respective dashboards
        // see PractitionerController.AccessCheck for details
        private string[] AccessCheck() {
            User ActiveUser = UserSession;
            if(ActiveUser == null) return new string[]{"Login", "Login"};
            else if (ActiveUser.Role == 0) return new string[]{"Dashboard", "Home"};
            else if (ActiveUser.Role == 1) return new string[]{"Dashboard", "Practitioner"};
            return null;
        }

        // ROUTES

        // REC DASHBOARD
        // Access from Receptionst: "dashboard"
        // Access from anywhere else: "/rec/dashboard"
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            // Checks User's role and login
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            ViewModel vm = new ViewModel();
            vm.CurrentUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            vm.AllUsers = dbContext.Users.ToList();
            vm.AllCustomers = dbContext.Customers.ToList();
            vm.AllInsurances = dbContext.Insurances.ToList();
            vm.AllServices = dbContext.Services.ToList();
            vm.AllTimeslots = dbContext.Timeslots.ToList();
            vm.AllPractitioners = Query.AllPractitioners(dbContext);
            return View("RDashboard",vm);
        }

        // ALL RESERVATIONS
        [HttpGet("all_res")]
        public IActionResult AllReservations()
        {
            // Checks User's role and login
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            Query.AllReservations(dbContext);
            return View();
        }

        // FORM PAGE??
        [HttpGet("NewReservation")]
        public IActionResult NewReservation()
        {
            // Checks User's role and login
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            ViewModel vm = new ViewModel();
            vm.CurrentUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            vm.AllUsers = dbContext.Users.ToList();
            vm.AllCustomers = dbContext.Customers.ToList();
            vm.AllInsurances = dbContext.Insurances.ToList();
            vm.AllServices = dbContext.Services.ToList();
            vm.AllTimeslots = dbContext.Timeslots.ToList();
            vm.AllPractitioners = Query.AllPractitioners(dbContext);
            vm.OneReservation = new Reservation();
            vm.OneReservation.CreatorId = vm.CurrentUser.UserId;
            return View(vm);
        }

        // Create Reservation from timeslot id
        [HttpPost("CreateReservation")]
        public IActionResult CreateReservation(ViewModel vm)
        {
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            Timeslot thisTS = Query.OneTimeslot(vm.OneReservation.TimeslotId, dbContext);
            int roomID = 1;
            List<int> roomIDList = new List<int>();
            foreach (Reservation resv in thisTS.Reservations)
            {
                roomIDList.Add(resv.RoomId);
            }
            while (roomIDList.IndexOf(roomID) != -1)
            {
                roomID ++;
            }
            vm.OneReservation.RoomId = roomID;
            vm.OneTimeslot = thisTS;
            vm.AllPractitioners = Query.AllPractitioners(dbContext);
            vm.OneCustomer = Query.OneCustomer(vm.OneReservation.CustomerId, dbContext);
            vm.OneService = Query.OneService(vm.OneReservation.ServiceId, dbContext);
            vm.OneInsurance = Query.OneInsurance(vm.OneCustomer.InsuranceId, dbContext);
            return View("ReservationForm", vm);
        }
        [HttpPost("SubmitReservation")]
        public IActionResult SubmitReservation(ViewModel vm)
        {
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            if (ModelState.IsValid)
            {
                // manual validations
                if (vm.OneReservation.CreatorId == 0 || vm.OneReservation.CustomerId == 0 || vm.OneReservation.PractitionerId == 0 || vm.OneReservation.RoomId == 0 || vm.OneReservation.ServiceId == 0 || vm.OneReservation.TimeslotId == 0)
                {
                    ViewBag.CustomError = "An association value was 0, an error has occured";
                }
                Query.CreateReservation(vm.OneReservation, dbContext);
                return RedirectToAction("Dashboard");
            }
            else {
                return View("ReservationForm", vm);
            }
        }

        // SUBMIT: cancel res
        [HttpPost]
        public IActionResult CancelReservation(Reservation newReservation)
        {
            Query.DeleteReservation(newReservation.ReservationId, dbContext);
            return RedirectToAction("Dashboard", "Receptionist");
        }

        // VIEW ALL CUSTOMER
        [HttpGet]
        public IActionResult AllCustomers()
        {
            // Checks User's role and login
            // Checks User's role and login
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            return View();
        }

        // NEW CUSTOMER FORM?
        [HttpGet("NewCustomer")]
        public IActionResult NewCustomer()
        {
            // Checks User's role and login
            // Checks User's role and login
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            ViewModel vm = new ViewModel();
            vm.CurrentUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            vm.AllUsers = dbContext.Users.ToList();
            vm.AllCustomers = dbContext.Customers.ToList();
            vm.AllInsurances = dbContext.Insurances.ToList();
            vm.AllServices = dbContext.Services.ToList();
            vm.AllTimeslots = dbContext.Timeslots.ToList();
            return View(vm);
        }

        // SUBMIT: create new customer
        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer(ViewModel vm)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(vm.OneCustomer);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("NewCustomer");
            }
        }

        [HttpGet("PractitionerShow/{id}")]
        public IActionResult PractitionerShow(int userId)
        {
            // Checks User's role and login
            return RedirectToAction("Dashboard");;
        }
        // MY PROFILE
        [HttpGet]
        public IActionResult MyProfile()
        {
            // Checks User's role and login
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            return View();
        }

        // FORM: edit profile
        [HttpGet]
        public IActionResult EditProfile()
        {
            // Checks User's role and login
            AccessCheck();
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
        public IActionResult OneDayAvailability(DateTime oneDay)
        {
            // Checks User's role and login
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            ViewModel vm = new ViewModel();
            vm.AllTimeslots = Query.OneDaysTimeslots(oneDay, dbContext);
            return View("DayViewTimeslots", vm);
        }
        
        [HttpGet]
        public IActionResult TodaysAvailability()
        {
            // Checks User's role and login
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            ViewModel vm = new ViewModel();
            vm.AllTimeslots = Query.TodaysTimeslots(dbContext);
            return View("DayViewTimeslots", vm);
        }

        [HttpGet]
        public IActionResult ThisWeeksAvailability()
        {
            // Checks User's role and login
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            ViewModel vm = new ViewModel();
            vm.AllTimeslots = Query.ThisWeeksTimeslots(dbContext);
            return View("WeekViewTimeslots", vm);
        }
        [HttpGet]
        public IActionResult ThisMonthsAvailability()
        {
              // Checks User's role and login
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            ViewModel vm = new ViewModel();
            vm.AllTimeslots = Query.ThisMonthsTimeslots(dbContext);
            return View("MonthViewTimeslots", vm);
        }
        
        [HttpGet]
        public IActionResult OneWeeksAvailability(DateTime startDay)
        {
            // Checks User's role and login
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            ViewModel vm = new ViewModel();
            vm.AllTimeslots = Query.OneWeeksTimeslots(startDay, dbContext);
            return View("WeekViewTimeslots", vm);
        }

        [HttpGet]
        public IActionResult OneMonthsAvailability(DateTime dayInMonth)
        {
            // Checks User's role and login
            string[] check = AccessCheck();
            if(check != null) return RedirectToAction(check[0], check[1]);
            ViewModel vm = new ViewModel();
            vm.AllTimeslots = Query.OneMonthsTimeslots(dayInMonth, dbContext);
            return View("MonthViewTimeslots", vm);
        }
    }
}
