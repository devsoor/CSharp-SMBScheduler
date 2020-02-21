﻿using System;
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
    public class HomeController : Controller
    {
        // database setup
        public ProjectContext dbContext;
        public HomeController(ProjectContext context)
        {
            dbContext = context;
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
                dbContext.Add(Reservation);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Generate New Entries
        public void GenerateTimeslots()
        {
            int daysAhead = 14; // this is the number of days in advance the system should keep timeslots built for
            List<Timeslot> existingTS = dbContext.Timeslots.OrderByDescending(t => t.Date).ToList(); // all existing timeslots with the furthest in the future ordered first
            int daysToBuild = (daysAhead - (int)(existingTS[0].Date - DateTime.Now).TotalDays); // difference between days we want to stay ahead and days the last existing timeslot is ahead of Now
            List<User> allPs = dbContext.Users.Include(u => u.PSchedules).Where(u => u.Role == 1).ToList(); // all practitioners (user role 1) including their schedules
            int minHour = 6;
            int maxHour = 18;
            for (int d=1; d<daysToBuild; d++)
            {
                for (int h=minHour; h<=maxHour; h++)
                {
                    // generate new timeslot for each hour of each day we are adding
                    Timeslot newTS = new Timeslot();
                    newTS.Date = existingTS[0].Date.AddDays(d);
                    newTS.Hour = h;
                    dbContext.Add(newTS);
                    // generate new PAvailTimes to connect practitioners to each timeslot if their PSchedule lists them as available at this time/day
                    
                }
            }
        
        }







        public IActionResult Index()
        {
            return View();
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
