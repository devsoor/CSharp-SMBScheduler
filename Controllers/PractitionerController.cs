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
    [Route("practitioner")]
    public class PractitionerController : Controller
    {
        // Database setup
        public ProjectContext dbContext;
        public PractitionerController(ProjectContext context)
        {
            dbContext = context;
        }

        // UserId session to keep track who is logged in!!
        private int UserIdSession {
            get {
                    if(HttpContext.Session.GetInt32("userId") != null ) {
                        return (int)HttpContext.Session.GetInt32("userId");
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

//////////////////////////////// GET ////////////////////////////////

        // logout user clear session
        [HttpGet("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        
        // Practitioner dashboard
        [HttpGet("dashboard")]
        public IActionResult Dash(){
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