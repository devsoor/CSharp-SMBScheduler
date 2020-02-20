using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace massage.Models
{
    public static class QueryFilter
    {
        public static List<Timeslot> ByService(int SId, List<Timeslot> currentList, ProjectContext db)
        {
            List<Timeslot> pFilteredTimeslots = new List<Timeslot>();
            List<Timeslot> FinalFilter = new List<Timeslot>();
            List<Room> PossibleRooms = db.Rooms.Include(r => r.Services).Where(r => r.Services.Any(s => s.ServiceId == SId)).ToList(); // filter rooms by services possible in rooms
            List<User> filtPs = db.Users.Include(u => u.Services).Include(u => u.PSchedules).Where(u => u.Services.Any(s => s.ServiceId == SId)).ToList(); // filter practitioners by services they can perform
            List<Timeslot> AllTimeslots = db.Timeslots.ToList();
            // filter timeslots by practitioners schedules available
            bool isPAvail;
            foreach (Timeslot ts in currentList)
            {
                isPAvail = false;
                foreach (PAvailTime pat in ts.PsAvail)
                {
                    if (filtPs.IndexOf(pat.Practitioner) != -1) // if the practitioner in this timeslot's availability list is in our filtered acceptable practitioners list
                    {
                        isPAvail = true;
                    }
                }
                if (isPAvail == true) // if a practitioner that we can use for this service is available at this timeslot
                {
                    pFilteredTimeslots.Add(ts);
                }
            }
         
            // filter based on rooms available
            int count;
            foreach (Timeslot ts in pFilteredTimeslots)
            {
                count = 0;
                foreach (Reservation resv in ts.Reservations)
                {
                    if (PossibleRooms.IndexOf(resv.Room) != -1) // the room for this reservation is in our list of possible rooms for this service
                    {
                        count++;
                    }
                }
                if (count < PossibleRooms.Count)
                {
                    FinalFilter.Add(ts);
                }
            }
            return FinalFilter;
        }
    }
}