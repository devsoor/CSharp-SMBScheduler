using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using massage.Models;
using Microsoft.AspNetCore.Identity;

namespace massage.Controllers
{
    public class LoginController : Controller
    {
        // database setup
        public ProjectContext dbContext;
        public LoginController(ProjectContext context)
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

        // routes
        [HttpGet("login")]
        [HttpGet("")]
        public IActionResult Login(){
            return View();
        }
        [HttpGet("register")]
        public IActionResult Register(){
            return View();
        }
        [HttpPost("submitregister")]
        public IActionResult SubmitRegister(User newUser) {
            if (ModelState.IsValid) 
            { // pass validations
                if (dbContext.Users.Any(u => u.UserName == newUser.UserName)){ //user in db already
                    ModelState.AddModelError("UserName", "Username already in use!");
                    return View("Register");
                }
                else
                {//user not in db, can register
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                    dbContext.Add(newUser);
                    dbContext.SaveChanges();
                    User thisUser = dbContext.Users.FirstOrDefault(u => u.UserName == newUser.UserName);
                    HttpContext.Session.SetInt32("UserId", thisUser.UserId);
                    return RedirectToAction("Dashboard", "Admin");
                }
            } 
            //failed validations
            return View("Register");
        }
        [HttpPost("submitlogin")]
        public IActionResult SubmitLogin(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.UserName == loginUser.UserName);
                if (userInDb == null)
                { // Username not found in db
                    ModelState.AddModelError("Username", "Invalid Username/Password");
                    return View("Login");
                }
                PasswordHasher<LoginUser> Hasher = new PasswordHasher<LoginUser>();
                var result = Hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.Password);
                if (result == 0)
                { // password doesn't match
                    ModelState.AddModelError("Username", "Invalid Username/Password");
                    return View("Login");
                }
                else
                { // success
                    HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                    return RedirectToAction("Dashboard", "Admin");
                }
            }
            //failed validations
            return View("Login");
        }
        [HttpGet("logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
