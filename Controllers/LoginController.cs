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
        [HttpGet("")]
        [Route("loginRoute")]
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

                System.Console.WriteLine("************MODEL STATE VALID*************");
                System.Console.WriteLine("*************************");
                System.Console.WriteLine("*************************");
                System.Console.WriteLine("*************************");
                if (dbContext.Users.Any(u => u.UserName == newUser.UserName))
                { // UserName in use
                    System.Console.WriteLine("************USERNAME IN USE*************");
                    System.Console.WriteLine("*************************");
                    System.Console.WriteLine("*************************");
                    System.Console.WriteLine("*************************");
                    ModelState.AddModelError("UserName", "UserName already in use!");
                    return View("Register");
                }
                else { // valid, UserName not in use, go ahead and register

                    System.Console.WriteLine("************USERNAME NOT IN USE************");
                    System.Console.WriteLine("*************************");
                    System.Console.WriteLine("*************************");
                    System.Console.WriteLine("*************************");
                    IdentityResult result = await _userManager.CreateAsync(newUser, newUser.Password);

                    if(result.Succeeded)
                    {
                        System.Console.WriteLine("***********MADE IT TO SUCCEED**************");
                        System.Console.WriteLine("*************************");
                        System.Console.WriteLine("*************************");
                        System.Console.WriteLine("*************************");
                        await _signInManager.SignInAsync(newUser, isPersistent: false);
                        return RedirectToAction("Dashboard", "Home");
                    }

                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("ConfirmPassword", error.Description );
                    }
                    return View("Register");
                }
            }
            else { // failed validations
                return View("Register");
            }
        }
        [HttpPost("submitlogin")]
        public async Task<IActionResult> SubmitLogin(LoginUser loginUser) {
            if (ModelState.IsValid) {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.UserName == loginUser.UserName);
                if (userInDb == null) { // UserName not found in db
                    ModelState.AddModelError("UserName", "Invalid Username");
                    return View("Login");
                }
                else { // success
                    User registeredUser = dbContext.Users.FirstOrDefault(u => u.UserName == loginUser.UserName);
                    Microsoft.AspNetCore.Identity.SignInResult checkedUser = await _signInManager.PasswordSignInAsync(registeredUser.UserName, registeredUser.Password, isPersistent: false, lockoutOnFailure: false);
                    if (checkedUser.Succeeded)
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }

                    ModelState.AddModelError("Password", "Username and Password do not match");

                    return View("Login");
                }

            }
            else { // failed validations
                return View("Login");
            }
        }
        [HttpGet("logout")]
        public async Task<IActionResult> Logout(){
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
