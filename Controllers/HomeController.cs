using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using massage.Models;
using Microsoft.AspNetCore.Http;

namespace massage.Controllers
{
    public class HomeController : Controller
    {
        // database setup
        public ProjectContext dbContext;
        public HomeController(ProjectContext context)
        {
            dbContext = context;

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
        [HttpGet("generatefakecontent")] // debug path to make fake content for testing purposes
        public IActionResult GenerateFakeContent()
        {
            Insurance newIns = new Insurance();
            newIns.Name = "Cash";
            dbContext.Add(newIns);
            dbContext.SaveChanges();
            Insurance newIns2 = new Insurance();
            newIns2.Name = "Blue Cross/Blue Shield";
            dbContext.Add(newIns2);
            dbContext.SaveChanges();
            Customer newCust = new Customer();
            newCust.Address1 = "123 Fake St";
            newCust.Address2 = "Apt 4";
            newCust.City = "Boston";
            newCust.Email = "fakeUser@fake.com";
            newCust.FirstName = "Bob";
            newCust.LastName = "Barker";
            newCust.Notes = "this guy always cancels";
            newCust.Phone = "1234567890";
            newCust.State = "MA";
            newCust.Zip = 02115;
            newCust.Insurance = newIns;
            dbContext.Add(newCust);
            dbContext.SaveChanges();
            Customer newCust2 = new Customer();
            newCust2.Address1 = "4324 bleh ave";
            newCust2.Address2 = "Apt 1";
            newCust2.City = "San Francisco";
            newCust2.Email = "SomePerson@aol.com";
            newCust2.FirstName = "Mary";
            newCust2.LastName = "Sue";
            newCust2.Notes = "so friendly!";
            newCust2.Phone = "9087654321";
            newCust2.State = "CA";
            newCust2.Zip = 94611;
            newCust2.Insurance = newIns2;
            dbContext.Add(newCust2);
            dbContext.SaveChanges();
            User pract1 = new User();
            pract1.Password = "AQAAAAEAACcQAAAAEOfdJHYZmxEQpJaWvaD4c7z4CiXIa5ZPfplYWFuCOPYYbXAUxjGKOM3zhm0plujL5g=="; // password hash for Password1!
            pract1.FirstName = "John";
            pract1.LastName = "Smith";
            pract1.Role = 1;
            pract1.UserName = "JohnSmith";
            dbContext.Add(pract1);
            dbContext.SaveChanges();
            User pract2 = new User();
            pract2.Password = "AQAAAAEAACcQAAAAEOfdJHYZmxEQpJaWvaD4c7z4CiXIa5ZPfplYWFuCOPYYbXAUxjGKOM3zhm0plujL5g=="; // password hash for Password1!
            pract2.FirstName = "Chris";
            pract2.LastName = "Rodger";
            pract2.Role = 1;
            pract2.UserName = "ChrisRodger";
            dbContext.Add(pract2);
            dbContext.SaveChanges();
            User recep1 = new User();
            recep1.Password = "AQAAAAEAACcQAAAAEOfdJHYZmxEQpJaWvaD4c7z4CiXIa5ZPfplYWFuCOPYYbXAUxjGKOM3zhm0plujL5g=="; // password hash for Password1!
            recep1.FirstName = "Jane";
            recep1.LastName = "Doe";
            recep1.Role = 2;
            recep1.UserName = "ChrisRodger";
            dbContext.Add(recep1);
            dbContext.SaveChanges();
            User recep2 = new User();
            recep2.Password = "AQAAAAEAACcQAAAAEOfdJHYZmxEQpJaWvaD4c7z4CiXIa5ZPfplYWFuCOPYYbXAUxjGKOM3zhm0plujL5g=="; // password hash for Password1!
            recep2.FirstName = "Jane";
            recep2.LastName = "Doe";
            recep2.Role = 2;
            recep2.UserName = "ChrisRodger";
            dbContext.Add(recep2);
            dbContext.SaveChanges();
            Service serv1 = new Service();
            serv1.Name = "Deep Tissue Massage";
            dbContext.Add(serv1);
            dbContext.SaveChanges();
            Service serv2 = new Service();
            serv2.Name = "Foot Massage";
            dbContext.Add(serv2);
            dbContext.SaveChanges();
            Service serv3 = new Service();
            serv3.Name = "Accupuncture";
            dbContext.Add(serv3);
            dbContext.SaveChanges();
            Room room1 = new Room();
            dbContext.Add(room1);
            dbContext.SaveChanges();
            Room room2 = new Room();
            dbContext.Add(room2);
            dbContext.SaveChanges();
            Room room3 = new Room();
            dbContext.Add(room3);
            dbContext.SaveChanges();
            Room room4 = new Room();
            dbContext.Add(room4);
            dbContext.SaveChanges();
            Room room5 = new Room();
            dbContext.Add(room5);
            dbContext.SaveChanges();
            Room room6 = new Room();
            dbContext.Add(room6);
            dbContext.SaveChanges();
            List<Room> allRooms = new List<Room>(){room1, room2, room3, room4, room5, room6};
            List<Service> allServices = new List<Service>(){serv1, serv2, serv3};
            foreach (Room room in allRooms)
            {
                foreach (Service serv in allServices)
                {
                    RoomService rs = new RoomService();
                    rs.RoomId = room.RoomId;
                    rs.ServiceId = serv.ServiceId;
                    dbContext.Add(rs);
                    dbContext.SaveChanges();
                }
            }
            dbContext.SaveChanges();
            PService ps = new PService();
            ps.ServiceId = serv1.ServiceId;
            ps.PractitionerId = pract1.Id;
            dbContext.Add(ps);
            dbContext.SaveChanges();
            PService ps2 = new PService();
            ps2.ServiceId = serv2.ServiceId;
            ps2.PractitionerId = pract1.Id;
            dbContext.Add(ps2);
            dbContext.SaveChanges();
            PService ps3 = new PService();
            ps3.ServiceId = serv3.ServiceId;
            ps3.PractitionerId = pract1.Id;
            dbContext.Add(ps3);
            dbContext.SaveChanges();
            PService ps4 = new PService();
            ps4.ServiceId = serv2.ServiceId;
            ps4.PractitionerId = pract2.Id;
            dbContext.Add(ps4);
            dbContext.SaveChanges();
            PService ps5 = new PService();
            ps5.ServiceId = serv3.ServiceId;
            ps5.PractitionerId = pract2.Id;
            dbContext.Add(ps5);
            dbContext.SaveChanges();
            PInsurance pi1 = new PInsurance();
            pi1.PractitionerId = pract1.Id;
            pi1.InsuranceId = newIns.InsuranceId;
            dbContext.Add(pi1);
            dbContext.SaveChanges();
            PInsurance pi2 = new PInsurance();
            pi2.PractitionerId = pract1.Id;
            pi2.InsuranceId = newIns2.InsuranceId;
            dbContext.Add(pi2);
            dbContext.SaveChanges();
            PInsurance pi3 = new PInsurance();
            pi3.PractitionerId = pract2.Id;
            pi3.InsuranceId = newIns.InsuranceId;
            dbContext.Add(pi3);
            dbContext.SaveChanges();
            Query.OnePsSchedules(pract1.Id, dbContext);
            Query.OnePsSchedules(pract2.Id, dbContext);
            CheckTimeslots();
            Timeslot tsToday = dbContext.Timeslots.OrderByDescending(t => t.Hour).FirstOrDefault(t => t.Date == DateTime.Today);
            Reservation newResToday = new Reservation();
            newResToday.CreatorId = recep1.Id;
            newResToday.CustomerId = newCust.CustomerId;
            newResToday.Notes = "Important VIP Reservation!!!!!!";
            newResToday.PractitionerId = pract1.Id;
            newResToday.RoomId = room1.RoomId;
            newResToday.ServiceId = serv1.ServiceId;
            newResToday.TimeslotId = tsToday.TimeslotId;
            dbContext.Add(newResToday);
            dbContext.SaveChanges();
            Reservation newResToday2 = new Reservation();
            newResToday2.CreatorId = recep2.Id;
            newResToday2.CustomerId = newCust2.CustomerId;
            newResToday2.Notes = "Will they show up?";
            newResToday2.PractitionerId = pract2.Id;
            newResToday2.RoomId = room2.RoomId;
            newResToday2.ServiceId = serv3.ServiceId;
            newResToday2.TimeslotId = tsToday.TimeslotId;
            dbContext.Add(newResToday2);
            dbContext.SaveChanges();
            Timeslot tsTomorrow = dbContext.Timeslots.OrderByDescending(t => t.Hour).FirstOrDefault(t => t.Date == DateTime.Today.AddDays(1));
            Reservation newResTomorrow = new Reservation();
            newResTomorrow.CreatorId = recep1.Id;
            newResTomorrow.CustomerId = newCust.CustomerId;
            newResTomorrow.Notes = "Important VIP Reservation!!!!!!";
            newResTomorrow.PractitionerId = pract1.Id;
            newResTomorrow.RoomId = room1.RoomId;
            newResTomorrow.ServiceId = serv1.ServiceId;
            newResTomorrow.TimeslotId = tsTomorrow.TimeslotId;
            dbContext.Add(newResTomorrow);
            dbContext.SaveChanges();
            Reservation newResTomorrow2 = new Reservation();
            newResTomorrow2.CreatorId = recep2.Id;
            newResTomorrow2.CustomerId = newCust2.CustomerId;
            newResTomorrow2.Notes = "Will they show up?";
            newResTomorrow2.PractitionerId = pract2.Id;
            newResTomorrow2.RoomId = room2.RoomId;
            newResTomorrow2.ServiceId = serv3.ServiceId;
            newResTomorrow2.TimeslotId = tsTomorrow.TimeslotId;
            dbContext.Add(newResTomorrow2);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
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
                GenerateTodaysTimeslots();
                GenerateTimeslots(daysAhead, lastTS);
                return;
            }
            else
            {
                if (lastTS.Date < DateTime.Today)
                {
                    GenerateTodaysTimeslots();
                }
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
        public void GenerateTodaysTimeslots()
        {
            List<User> allPs = dbContext.Users.Include(u => u.PSchedules).Where(u => u.Role == 1).ToList(); // all practitioners (user role 1) including their schedules
            int minHour = 6;
            int maxHour = 18;
            for (int h=minHour; h<=maxHour; h++)
            {
                Timeslot newTS = new Timeslot();
                newTS.Date = DateTime.Today;
                newTS.Hour = h;
                dbContext.Add(newTS);
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
            dbContext.SaveChanges();
            return;
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
            // vm.CurrentUser = dbContext.Users.FirstOrDefault(u => u.Id == HttpContext.Session.GetInt32("Id"));
            vm.AllUsers = dbContext.Users.ToList();
            vm.AllCustomers = dbContext.Customers.ToList();
            vm.AllInsurances = dbContext.Insurances.ToList();
            vm.AllReservations = dbContext.Reservations.ToList();
            vm.AllServices = dbContext.Services.ToList();
            vm.AllTimeslots = dbContext.Timeslots.ToList();
            return RedirectToAction("Dashboard","Admin");
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
            // vm.CurrentUser = dbContext.Users.Include(u => u.PSchedules).Include(u => u.AvailTimes).Include(u => u.Appointments).FirstOrDefault(u => u.Id == HttpContext.Session.GetInt32("Id"));
            return PartialView("UserProfile", vm);
        }

    // [HttpGet("index")]
    //     public IActionResult Index()
    //     {
    //         // debugg stuffffffff
    //         // User currUser = dbContext.Users.Include(u => u.PSchedules).FirstOrDefault(u => u.Id == HttpContext.Session.GetInt32("Id"));
    //         if (currUser.PSchedules.Count == 0)
    //         {
    //             PSchedule newPS = new PSchedule();
    //             newPS.PractitionerId = currUser.Id;
    //             newPS.DayOfWeek = "Monday";
    //             dbContext.Add(newPS);
    //             PSchedule newPS2 = new PSchedule();
    //             newPS2.PractitionerId = currUser.Id;
    //             newPS2.DayOfWeek = "Tuesday";
    //             dbContext.Add(newPS2);
    //             PSchedule newPS3 = new PSchedule();
    //             newPS3.PractitionerId = currUser.Id;
    //             newPS3.DayOfWeek = "Wednesday";
    //             dbContext.Add(newPS3);
    //             PSchedule newPS4 = new PSchedule();
    //             newPS4.PractitionerId = currUser.Id;
    //             newPS4.DayOfWeek = "Thursday";
    //             dbContext.Add(newPS4);
    //             PSchedule newPS5 = new PSchedule();
    //             newPS5.PractitionerId = currUser.Id;
    //             newPS5.DayOfWeek = "Friday";
    //             dbContext.Add(newPS5);
    //             dbContext.SaveChanges();
    //         }
    //         ViewBag.User = dbContext.Users.First(); //// REMOVE
    //         CheckTimeslots();
    //         List<Customer> allCs = Query.AllCustomers(dbContext);
    //         List<Timeslot> allTimeslots = dbContext.Timeslots.Include(t => t.PsAvail).ThenInclude(pa => pa.Practitioner).OrderBy(t => t.Date).ThenBy(t => t.Hour).ToList();
    //         ViewModel vm = new ViewModel();
    //         vm.AllCustomers = allCs;
    //         vm.AllTimeslots = allTimeslots;
    //         return View(vm);
    //     }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("clearusers")]
        public IActionResult clearusers() {
            foreach (object u in dbContext.Users) {
                dbContext.Remove(u);
            }
            dbContext.SaveChanges();
            return Redirect("login");
        }
    }
}
