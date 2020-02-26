using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using massage.Models;


namespace massage.Controllers
{
    [Authorize]
    [Route("prac")]
    public class PractitionerController : Controller
    {
        public ProjectContext dbContext;
        public PractitionerController(ProjectContext context)
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
                return RedirectToAction("Dashboard", "Home");
            } else if (ActiveUser.Role == 2) {
                return RedirectToAction("Dashboard", "Receptionist");
            }
            return null;
        }

//////////////////////////////// GET ////////////////////////////////
        
        // Practitioner dashboard
        [HttpGet("dashboard")]
        public IActionResult Dashboard(){
            
            ViewModel vm = new ViewModel();
            User currUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            vm.AllReservations = Query.OnePTodaysReservations(currUser.UserId, dbContext);
            vm.CurrentUser = currUser;
            return View("Index", vm);
        }

        // Practitioner Schedule View w/ current
        [HttpGet("schedule")]
        public IActionResult PracSched(){
            // stuff
            return View();
        }

        // Practitioner Template View FORM
        [HttpGet("template")]
        public IActionResult PracTemplate(){
            // stuff
            return View();
        }

        // Practitioner Profile View
        [HttpGet("profile")]
        public IActionResult PracProfile(){
            // stuff
            return View();
        }

        // Practitioner Update Profile FORM
        [HttpGet("update_profile")]
        public IActionResult UpdatePracProf(){
            // stuff
            return View();
        }

//////////////////////////////// POST ////////////////////////////////

        // Practitioner: template FORM ON-SUBMIT
        [HttpPost]
        public IActionResult PracTemplateSubmit(){
            if(ModelState.IsValid){
                // stuff
                return RedirectToAction("Dash");
            }
            else {
                return View("UserProfile");
            }
        }

        // Practitioner: profile FORM ON-SUBMIT
        [HttpPost]
        public IActionResult PracProfileSubmit(){
            if(ModelState.IsValid){
                // stuff
                return RedirectToAction("PracProfile");
            }
            else {
                return View("UserProfile");
            }
        }
    }   // END CONTROLLER
}   // END ALL