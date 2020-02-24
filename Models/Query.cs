using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace massage.Models
{
    public static class Query
    {
        public static List<Customer> AllCustomers(ProjectContext db)
        {
            return db.Customers
                .Include(c => c.Insurance)
                .Include(c => c.Reservations)
                .Include(c => c.Reservations.Select(r => r.Practitioner))
                .Include(c => c.Reservations.Select(r => r.Creator))
                .Include(c => c.Reservations.Select(r => r.Service))
                .Include(c => c.Reservations.Select(r => r.Room))
                .Include(c => c.Reservations.Select(r => r.Timeslot))
                .ToList();
        }
    }
}