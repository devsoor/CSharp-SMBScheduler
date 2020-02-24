using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
namespace massage.Models
{
    public static class Query
    {
        // Customer Queries
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
        public static Customer OneCustomer(int custID, ProjectContext db)
        {
            return db.Customers
                .Include(c => c.Insurance)
                .Include(c => c.Reservations)
                .Include(c => c.Reservations.Select(r => r.Practitioner))
                .Include(c => c.Reservations.Select(r => r.Creator))
                .Include(c => c.Reservations.Select(r => r.Service))
                .Include(c => c.Reservations.Select(r => r.Room))
                .Include(c => c.Reservations.Select(r => r.Timeslot))
                .FirstOrDefault(c => c.CustomerId == custID);
        }
        public static Customer CreateCustomer(Customer newC, ProjectContext db)
        {
            db.Add(newC);
            db.SaveChanges();
            return newC;
        }
        public static Customer EditCustomer(Customer editedC, ProjectContext db)
        {
            Customer cToEdit = db.Customers.FirstOrDefault(c => c.CustomerId == editedC.CustomerId);
            cToEdit.Address1 = editedC.Address1;
            cToEdit.Address2 = editedC.Address2;
            cToEdit.City = editedC.City;
            cToEdit.Email = editedC.Email;
            cToEdit.FirstName = editedC.FirstName;
            cToEdit.InsuranceId = editedC.InsuranceId;
            cToEdit.LastName = editedC.LastName;
            cToEdit.Notes = editedC.Notes;
            cToEdit.Phone = editedC.Phone;
            cToEdit.State = editedC.State;
            cToEdit.UpdatedAt = DateTime.Now;
            cToEdit.Zip = editedC.Zip;
            db.SaveChanges();
            return db.Customers
                .Include(c => c.Insurance)
                .Include(c => c.Reservations)
                .Include(c => c.Reservations.Select(r => r.Practitioner))
                .Include(c => c.Reservations.Select(r => r.Creator))
                .Include(c => c.Reservations.Select(r => r.Service))
                .Include(c => c.Reservations.Select(r => r.Room))
                .Include(c => c.Reservations.Select(r => r.Timeslot))
                .FirstOrDefault(c => c.CustomerId == cToEdit.CustomerId);
        }
        public static void DeleteCustomer(int custID, ProjectContext db)
        {
            Customer cToRemove = db.Customers.FirstOrDefault(c => c.CustomerId == custID);
            db.Remove(cToRemove);
            db.SaveChanges();
            return;
        }
        // Insurance Queries
        public static List<Insurance> AllInsurances(ProjectContext db)
        {
            return db.Insurances
                .Include(i => i.Customers)
                .Include(i => i.Practitioners)
                .ToList();
        }
        public static Insurance OneInsurance(int insID, ProjectContext db)
        {
            return db.Insurances
                .Include(i => i.Customers)
                .Include(i => i.Practitioners)
                .FirstOrDefault(i => i.InsuranceId == insID);
        }
        public static Insurance EditInsurance(Insurance editedIns, ProjectContext db)
        {
            Insurance insToEdit = db.Insurances.FirstOrDefault(i => i.InsuranceId == editedIns.InsuranceId);
            insToEdit.Name = editedIns.Name;
            insToEdit.UpdatedAt = DateTime.Now;
            db.SaveChanges();
            return db.Insurances
                .Include(i => i.Customers)
                .Include(i => i.Practitioners)
                .FirstOrDefault(i => i.InsuranceId == insToEdit.InsuranceId);
        }
        public static Insurance CreateInsurance(Insurance newIns, ProjectContext db)
        {
            db.Add(newIns);
            db.SaveChanges();
            return newIns;
        }
        public static void DeleteInsurance(int insID, ProjectContext db)
        {
            Insurance insToDelete = db.Insurances.FirstOrDefault(i => i.InsuranceId == insID);
            db.Remove(insToDelete);
            db.SaveChanges();
            return;
        }
        // User Queries
        public static List<User> AllUsers(ProjectContext db)
        {
            return db.Users
                .Include(u => u.PSchedules)
                .Include(u => u.AvailTimes)
                .ThenInclude(pat => pat.TimeSlot)
                .Include(u => u.CreatedReservations)
                .Include(u => u.Appointments)
                .Include(u => u.Services)
                .Include(u => u.InsurancesAccepted)
                .ToList();
        }
        public static List<User> AllPractitioners(ProjectContext db)
        {
            return db.Users
                .Include(u => u.PSchedules)
                .Include(u => u.AvailTimes)
                .ThenInclude(pat => pat.TimeSlot)
                .Include(u => u.Appointments)
                .Include(u => u.Services)
                .Include(u => u.InsurancesAccepted)
                .Where(u => u.Role == 1)
                .ToList();
        }
        public static List<User> AllReceptionists(ProjectContext db)
        {
            return db.Users
                .Include(u => u.CreatedReservations)
                .Where(u => u.Role == 2)
                .ToList();
        }
        public static User OnePractitioner(int pID, ProjectContext db)
        {
            return db.Users
                .Include(u => u.PSchedules)
                .Include(u => u.AvailTimes)
                .ThenInclude(pat => pat.TimeSlot)
                .Include(u => u.Appointments)
                .Include(u => u.Services)
                .Include(u => u.InsurancesAccepted)
                .Where(u => u.Role == 1)
                .FirstOrDefault(u => u.UserId == pID);
        }
        public static User OneReceptionist(int rID, ProjectContext db)
        {
            return db.Users
                .Include(u => u.CreatedReservations)
                .Where(u => u.Role == 2)
                .FirstOrDefault(u => u.UserId == rID);
        }
        public static User EditUser(User editedUser, ProjectContext db)
        {
            User userToEdit = db.Users.FirstOrDefault(u => u.UserId == editedUser.UserId);
            userToEdit.FirstName = editedUser.FirstName;
            userToEdit.LastName = editedUser.LastName;
            if (editedUser.Password.Length > 7) {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                userToEdit.Password = Hasher.HashPassword(editedUser, editedUser.Password);
            }
            userToEdit.Role = editedUser.Role;
            userToEdit.UpdatedAt = DateTime.Now;
            userToEdit.Username = editedUser.Username;
            db.SaveChanges();
            return db.Users
                .Include(u => u.PSchedules)
                .Include(u => u.AvailTimes)
                .ThenInclude(pat => pat.TimeSlot)
                .Include(u => u.CreatedReservations)
                .Include(u => u.Appointments)
                .Include(u => u.Services)
                .Include(u => u.InsurancesAccepted)
                .FirstOrDefault(u => u.UserId == userToEdit.UserId);
        }
        public static void DeleteUser(int userID, ProjectContext db)
        {
            User userToDel = db.Users.FirstOrDefault(u => u.UserId == userID);
            db.Remove(userToDel);
            db.SaveChanges();
            return;
        }
    }
}