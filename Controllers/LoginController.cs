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
using Microsoft.AspNetCore.Authorization;

namespace massage.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // database setup
        public ProjectContext dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public LoginController(
            ProjectContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            dbContext = context;
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> SubmitRegister(User newUser) {
            if (ModelState.IsValid) { // pass validations
                if (dbContext.Users.Any(u => u.UserName == newUser.UserName)) return View("Register");
                    else { // valid, UserName not in use, go ahead and register
                    IdentityResult result = await _userManager.CreateAsync(newUser, newUser.Password);
                    if(result.Succeeded) {
                        await _signInManager.SignInAsync(newUser, isPersistent: false);
                        return RedirectToAction("Dashboard", "Home");
                    } // CreateAsync failed
                    foreach(var error in result.Errors) ModelState.AddModelError("Password", error.Description );
                    return View("Register");
                }
            } else return View("Register");
        }
        [HttpPost("submitlogin")]
        public async Task<IActionResult> SubmitLogin(LoginUser loginUser) {
            if (ModelState.IsValid) {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.UserName == loginUser.UserName);
                if (userInDb == null) { // UserName not found in db
                    ModelState.AddModelError("UserName", "Invalid Username");
                    return View("Login");
                } else { // success
                    Microsoft.AspNetCore.Identity.SignInResult checkedUser = await _signInManager
                    .PasswordSignInAsync(
                        loginUser.UserName,
                        loginUser.Password,
                        isPersistent: false,
                        lockoutOnFailure: false
                    );
                    if (checkedUser.Succeeded) return RedirectToAction("Dashboard", "Home");
                    // checkedUser did not succeed
                    ModelState.AddModelError("Password", "Username and Password do not match");
                    return View("Login");
                }
            } else return View("Login");
        }
        [HttpGet("logout")]
        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
