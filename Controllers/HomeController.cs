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
    public class HomeController : Controller
    {
        // database setup
        public ProjectContext dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public HomeController(
            ProjectContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            dbContext = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // all reservations
        [HttpGet("allreservations")]
        public IActionResult GetAllReservations()
        {
            List<Reservation> allRs = dbContext.Reservations
                .Include(r => r.Customer)
                .Include(r => r.Practitioner)
                .Include(r => r.Creator)
                .Include(r => r.Service)
                .Include(r => r.Room)
                .Include(r => r.Timeslot)
                .ToList();
            ViewModel vm = new ViewModel();
            vm.AllReservations = allRs;
            return View("AllReservations", vm);
            
        }












        // Create New Entries
        public IActionResult NewService(Service newsvc)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(newsvc);
                dbContext.SaveChanges();
                List<Room> allRooms = dbContext.Rooms.ToList();
                foreach (Room r in allRooms)
                {
                    RoomService rs = new RoomService();
                    rs.RoomId = r.RoomId;
                    rs.ServiceId = newsvc.ServiceId;
                    dbContext.Add(rs);
                }
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult NewRoom(Room r)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(r);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult NewCustomer(Customer c)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(c);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult NewPSchedule(PSchedule ps)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(ps);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult NewInsurance(Insurance i)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(i);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult NewReservation(Reservation r)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(r);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Check if Generation is needed
        public void CheckTimeslots()
        {
            int daysAhead = 14; // this is the number of days in advance the system should keep timeslots built for
            Timeslot lastTS = dbContext.Timeslots.OrderByDescending(t => t.Date).FirstOrDefault();
            if (lastTS == null)
            {
                GenerateTimeslots(daysAhead, lastTS);
                return;
            }
            else
            {
                int daysToBuild = daysAhead - (int)(lastTS.Date - DateTime.Today).TotalDays; // difference between days we want to stay ahead and days the last existing timeslot is ahead of Now
                if (daysToBuild == 0)
                {
                    return;
                }
                else
                {
                    GenerateTimeslots(daysToBuild, lastTS);
                    return;
                }
            }
        }

        // Generate New Entries
        public void GenerateTimeslots(int daysToBuild, Timeslot lastTS)
        {
            System.Console.WriteLine($"Beginning Timeslot Generation at {DateTime.Now}");
            DateTime startTime = DateTime.Now;
            List<User> allPs = dbContext.Users.Include(u => u.PSchedules).Where(u => u.Role == 1).ToList(); // all practitioners (user role 1) including their schedules
            int minHour = 6;
            int maxHour = 18;
            for (int d=1; d<daysToBuild; d++)
            {
                for (int h=minHour; h<=maxHour; h++)
                {
                    // generate new timeslot for each hour of each day we are adding
                    Timeslot newTS = new Timeslot();
                    if (lastTS == null)
                    {
                        newTS.Date = DateTime.Today.AddDays(d);
                    }
                    else {
                        newTS.Date = lastTS.Date.AddDays(d);
                    }
                    newTS.Hour = h;
                    dbContext.Add(newTS);
                    // generate new PAvailTimes to connect practitioners to each timeslot if their PSchedule lists them as available at this time/day
                    foreach (User p in allPs)
                    {
                        foreach (PSchedule ps in p.PSchedules)
                        {
                            if (ps.DayOfWeek == newTS.Date.DayOfWeek.ToString())
                            {
                                // objName.GetType().GetProperty("propName").GetValue(objName); // this is code format for getting a property using a string for the property name
                                bool isPAvailNow = (bool)ps.GetType().GetProperty("t" + h).GetValue(ps); // adds the letter t to the integer of the timeslot's hour and gets that property value from the practitioner schedule to see if they are available
                                if (isPAvailNow)
                                {
                                    PAvailTime pat = new PAvailTime();
                                    pat.PractitionerId = ps.PractitionerId;
                                    pat.TimeslotId = newTS.TimeslotId;
                                    dbContext.Add(pat);
                                }
                            }
                        }
                    }
                }
            }
            dbContext.SaveChanges();        
            System.Console.WriteLine($"Timeslot Generation completed at {DateTime.Now}");
            System.Console.WriteLine($"Time taken: {(DateTime.Now - startTime).TotalSeconds} seconds");
        }



        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            ViewModel vm = new ViewModel();
            vm.CurrentUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            vm.AllUsers = dbContext.Users.ToList();
            vm.AllCustomers = dbContext.Customers.ToList();
            vm.AllInsurances = dbContext.Insurances.ToList();
            vm.AllReservations = dbContext.Reservations.ToList();
            vm.AllServices = dbContext.Services.ToList();
            vm.AllTimeslots = dbContext.Timeslots.ToList();
            return PartialView(vm);
        }

        [HttpGet("/calendar")]
        public IActionResult calendar()
        {
            return PartialView("Calendar");
        }

        [HttpGet("/userProfile")]
        public IActionResult userProfile()
        {
            ViewModel vm = new ViewModel();
            vm.CurrentUser = dbContext.Users.Include(u => u.PSchedules).Include(u => u.AvailTimes).Include(u => u.Appointments).FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            return PartialView("UserProfile", vm);
        }



        [HttpGet("Index")]
        public IActionResult Index()
        {
            // debugg stuffffffff
            User currUser = dbContext.Users.Include(u => u.PSchedules).FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            if (currUser.PSchedules.Count == 0)
            {
                PSchedule newPS = new PSchedule();
                newPS.PractitionerId = currUser.UserId;
                newPS.DayOfWeek = "Monday";
                dbContext.Add(newPS);
                PSchedule newPS2 = new PSchedule();
                newPS2.PractitionerId = currUser.UserId;
                newPS2.DayOfWeek = "Tuesday";
                dbContext.Add(newPS2);
                PSchedule newPS3 = new PSchedule();
                newPS3.PractitionerId = currUser.UserId;
                newPS3.DayOfWeek = "Wednesday";
                dbContext.Add(newPS3);
                PSchedule newPS4 = new PSchedule();
                newPS4.PractitionerId = currUser.UserId;
                newPS4.DayOfWeek = "Thursday";
                dbContext.Add(newPS4);
                PSchedule newPS5 = new PSchedule();
                newPS5.PractitionerId = currUser.UserId;
                newPS5.DayOfWeek = "Friday";
                dbContext.Add(newPS5);
                dbContext.SaveChanges();
            }
            
            CheckTimeslots();
            List<Customer> allCs = Query.AllCustomers(dbContext);
            List<Timeslot> allTimeslots = dbContext.Timeslots.Include(t => t.PsAvail).ThenInclude(pa => pa.Practitioner).OrderBy(t => t.Date).ThenBy(t => t.Hour).ToList();
            ViewModel vm = new ViewModel();
            vm.AllCustomers = allCs;
            vm.AllTimeslots = allTimeslots;
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
