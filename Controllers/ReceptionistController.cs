using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using massage.Models;


namespace massage.Controllers
{
    [Authorize]
    public class ReceptionistController : Controller
    {
        // database setup
        public ProjectContext dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public ReceptionistController(
            ProjectContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            dbContext = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            User currentUser = await _userManager.GetUserAsync(HttpContext.User);
            return View();
        }


        [HttpGet]
        public IActionResult AllReservations()
        {
            Query.AllReservations(dbContext);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> NewReservation()
        {
            User currentUser = await _userManager.GetUserAsync(HttpContext.User);
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
