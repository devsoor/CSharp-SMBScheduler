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
    [Route("admin")]
    public class AdminController : Controller
    {
        // Database setup
        public ProjectContext dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AdminController(
            ProjectContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            dbContext = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

//////////////////////////////// GET ////////////////////////////////

        // Admin: dashboard
        [HttpGet("dashboard")]
        public IActionResult Dash(){
            // stuff
            return View("Index");
        }

        // EMPLOYEE
        // Admin: Employee Profile FORM
        [HttpGet("user_profile/{userId}")]
        public IActionResult UserProfile(int userId){
            // stuff
            return View();
        }

        // Admin: Employee template FORM
        [HttpGet("user_template/{userId}")]
        public IActionResult UserTemplate(int userId){
            // stuff
            return View();
        }

        // Admin: Employee Current Schedule
        [HttpGet("user_current_sched/{userId}")]
        public IActionResult UserCurrentSched(int userId){
            // stuff
            return View();
        }

        // INSURANCE
        // Admin: View list of all insurance LIST
        [HttpGet("insurances")]
        public IActionResult AllInsurance(){
            // stuff
            return View();
        }

        // Admin: Add new insurance FORM
        [HttpGet("new_insurance")]
        public IActionResult NewInsurance(){
            // stuff
            return View();
        }

        // Admin: Edit insurance FORM
        [HttpGet("edit_insurance/{insurId}")]
        public IActionResult EditInsurance(){
            // stuff
            return View();
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