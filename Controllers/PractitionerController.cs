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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public PractitionerController(
            ProjectContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            dbContext = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

//////////////////////////////// GET ////////////////////////////////

        // Practitioner dashboard
        [HttpGet("dashboard")]
        public IActionResult Dash(){
            // stuff
            return View("Index");
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