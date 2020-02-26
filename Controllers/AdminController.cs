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
    [Route("admin")]
    public class AdminController : Controller
    {
        // database setup
        public ProjectContext dbContext;
        public AdminController(ProjectContext context)
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
            } else if (ActiveUser.Role == 2) {
                return RedirectToAction("Dashboard", "Receptionist");
            } else if (ActiveUser.Role == 1) {
                return RedirectToAction("Dashboard", "Practitioner");
            }
            return null;
        }

//////////////////////////////// GET ////////////////////////////////
        
        [HttpGet("dashboard")]
        public IActionResult Dashboard(){
            AccessCheck();
            ViewModel vm = new ViewModel();
            vm.CurrentUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            vm.AllUsers = dbContext.Users.ToList();
            vm.AllCustomers = dbContext.Customers.ToList();
            vm.AllInsurances = dbContext.Insurances.ToList();
            vm.AllReservations = dbContext.Reservations.ToList();
            vm.AllServices = dbContext.Services.ToList();
            vm.AllTimeslots = dbContext.Timeslots.ToList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddTestUsers()
        {
            Testing.CreateUser(dbContext);
            return RedirectToAction("Dashboard");
        }

        // logout user clear session
        [HttpGet("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddTestServices()
        {
            Testing.CreateServices(dbContext);
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult AddTestCustomers()
        {
            Testing.CreateCustomers(dbContext);
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult AddTestPSchedule()
        {
            Testing.CreatePSchedule(dbContext, 2);
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult AddTestTimeslots()
        {
            Testing.CreateTimeslots(dbContext);
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult AddTestInsurances()
        {
            Testing.CreateInsurances(dbContext);
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("practitioner/{PracId}")]
        public IActionResult PractitionerProfile(int PracId)
        {
            ViewModel vm = new ViewModel();
            vm.CurrentUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            vm.OneUser = dbContext.Users.SingleOrDefault(p => p.UserId == PracId);
            vm.PSDict = QConvert.ScheduleFromQuery(Query.OnePsSchedules(vm.OneUser.UserId, dbContext));
            vm.AllPSchedules = Query.OnePsSchedules(vm.OneUser.UserId, dbContext);
            return View(vm);
        }

        [HttpPost]
        public IActionResult NewPSchedule()
        {
            if (ModelState.IsValid)
            {
                // stuff
                return RedirectToAction("UserProfile");
            }
            else
            {
                return View("UserProfile");
            }
        }





        // SERVICE
        // Admin: New Service FORM
        [HttpGet("new/service")]
        public IActionResult NewService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateService(Service newService)
        {
            User currentUser = dbContext.Users.Where(u => u.UserId == HttpContext.Session.GetInt32("UserId")).SingleOrDefault();
            if (ModelState.IsValid)
            {
                dbContext.Add(newService);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("newService");
            }
        }

        // INSURANCE
        // Admin: Add new insurance FORM
        [HttpGet("new/insurance")]
        public IActionResult NewInsurance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateInsurance(Insurance newInsurance)
        {
            User currentUser = dbContext.Users.Where(u => u.UserId == HttpContext.Session.GetInt32("UserId")).SingleOrDefault();
            if (ModelState.IsValid)
            {
                dbContext.Add(newInsurance);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("NewInsurance");
            }
        }


        // CUSTOMER
        // Admin: New Customer FORM
        [HttpGet("new/customer")]
        public IActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer newCustomer)
        {
            User currentUser = dbContext.Users.Where(u => u.UserId == HttpContext.Session.GetInt32("UserId")).SingleOrDefault();
            if (ModelState.IsValid)
            {
                dbContext.Add(newCustomer);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("NewCustomer");
            }
        }




        

        // Admin: DELETE
        [HttpGet("del_insurance/{insurId}")]  // this can be post of u REALLY want it to be.....
        public IActionResult DeleteInsurance(){
            return View();
        }

//////////////////////////////// POST ////////////////////////////////
        
        // Admin: Employee Profile FORM-SUBMIT
        [HttpPost]
        public IActionResult UserProfileSubmit(){
            if(ModelState.IsValid){
                // stuff
                return RedirectToAction("UserProfile");
            }
            else {
                return View("UserProfile");

            }
        }

        // Admin: Employee template FORM-SUBMIT
        [HttpPost]
        public IActionResult UserTemplateSubmit(){
            if(ModelState.IsValid){
                // stuff
                return RedirectToAction("UserProfile");
            }
            else {
                return View("UserProfile");
            }
        }

        // Admin: Add new insurance FORM-SUBMIT
        [HttpPost]
        public IActionResult CreateInsuranceSubmit(){
            if(ModelState.IsValid){
                // stuff
                return RedirectToAction("AllInsurance");
            }
            else {
                return View("UserProfile");
            }
        }

        // Admin: Updating insurance FORM-SUBMIT
        [HttpPost]
        public IActionResult UpdateInsuranceSubmit(){
            if(ModelState.IsValid){
                // stuff
                return RedirectToAction("AllInsurance");
            }
            else {
                return View("UserProfile");
            }
        }

    }   // END CONTROLLER
}   // END ALL