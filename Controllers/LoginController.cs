using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using massage.Models;

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
        // routes
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
            if (ModelState.IsValid) { // pass validations
                if (dbContext.Users.Any(u => u.Username == newUser.Username))
                { // Username in use
                    ModelState.AddModelError("Username", "Username already in use!");
                    return View("Register");
                }
                else { // valid, Username not in use, go ahead and register
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                    dbContext.Add(newUser);
                    dbContext.SaveChanges();
                    User thisUser = dbContext.Users.FirstOrDefault(u => u.Username == newUser.Username);
                    HttpContext.Session.SetInt32("UserId", thisUser.UserId);
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            else { // failed validations
                return View("Register");
            }
        }
        [HttpPost("submitlogin")]
        public IActionResult SubmitLogin(LoginUser loginUser) {
            if (ModelState.IsValid) {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Username == loginUser.Username);
                if (userInDb == null) { // Username not found in db
                    ModelState.AddModelError("Username", "Invalid Username/Password");
                    return View("Login");
                }
                PasswordHasher<LoginUser> Hasher = new PasswordHasher<LoginUser>();
                var result = Hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.Password);
                if (result == 0) { // password doesn't match
                    ModelState.AddModelError("Username", "Invalid Username/Password");
                    return View("Login");
                }
                else { // success
                    HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            else { // failed validations
                return View("Login");
            }
        }
        [HttpGet("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
