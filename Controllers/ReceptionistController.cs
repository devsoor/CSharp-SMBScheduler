// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Http;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Authorization;
// using massage.Models;


// namespace massage.Controllers
// {
//     [Authorize]
//     public class ReceptionistController : Controller
//     {
//         // database setup
//         public ProjectContext dbContext;
//         private readonly UserManager<User> _userManager;
//         private readonly SignInManager<User> _signInManager;
//         public ReceptionistController(
//             ProjectContext context,
//             UserManager<User> userManager,
//             SignInManager<User> signInManager)
//         {
//             dbContext = context;
//             _userManager = userManager;
//             _signInManager = signInManager;
//         }

//         [HttpGet]
//         public async Task<IActionResult> Dashboard()
//         {
//             User currentUser = await _userManager.GetUserAsync(HttpContext.User);
//             return View();
//         }

//         [HttpGet]
//         public async Task<IActionResult

//         [HttpPost]
//         public IActionResult CreateReservation(Reservation newReservation)
//         {
//             if (ModelState.IsValid)
//             {
//                 dbContext.Add(newReservation);
//                 dbContext.SaveChanges();
//                 return RedirectToAction("Dashboard", "Receptionist");
//             }
//         }

        

//     }
// }
