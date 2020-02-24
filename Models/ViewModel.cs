using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace massage.Models
{
    public class ViewModel
    {
        public User CurrentUser { get; set; }

        public List<User> AllUsers { get; set; }

        public List<Timeslot> AllTimeslots { get; set; }

        public List<Insurance> AllInsurances { get; set; }

        public List<PSchedule> AllPSchdules { get; set; }

        public PSchedule onePSchdule { get; set; }

        public List<Customer> AllCustomers { get; set; }

        public List<Reservation> AllReservations { get; set; }

        public List<Service> AllServices { get; set; }

        public List<List<Timeslot>> OldQueries { get; set; }
    }
}