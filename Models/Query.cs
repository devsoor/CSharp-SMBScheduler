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
        // Practitioner Availability
        public static List<PAvailTime> AllPractitionerAvailabilities(ProjectContext db)
        {
            return db.PAvailTimes
                .Include(pat => pat.Practitioner)
                .Include(pat => pat.Timeslot)
                .ToList();
        }
        public static List<PAvailTime> OnePractitionersAvailabilities(int pID, ProjectContext db)
        {
            return db.PAvailTimes
                .Include(pat => pat.Practitioner)
                .Include(pat => pat.TimeSlot)
                .Where(pat => pat.PractitionerId == pID)
                .ToList();
        }
        public static PAvailTime CreatePractitionerAvailability(int pID, int tsID, ProjectContext db)
        {
            PAvailTime newPAT = new PAvailTime();
            newPAT.PractitionerId = pID;
            newPAT.TimeslotId = tsID;
            db.Add(newPAT);
            db.SaveChanges();
            return db.PAvailTimes
                .Include(pat => pat.Practitioner)
                .Include(pat => pat.TimeSlot)
                .Where(pat => pat.PractitionerId == pID)
                .FirstOrDefault(pat => pat.TimeslotId == tsID);
        }
        public static void DeletePractitionerAvailability(int patID, ProjectContext db)
        {
            PAvailTime patToDel = db.PAvailTimes.FirstOrDefault(pat => pat.PAvailTimeId == patID);
            db.Remove(patToDel);
            db.SaveChanges();
            return;
        }
        public static List<PAvailTime> UpdateAllOfOnePsAvails(int pID, List<PAvailTime> updatedPATs, ProjectContext db)
        {
            List<PAvailTime> oldPats = db.PAvailTimes.Where(pat => pat.PractitionerId == pID).ToList();
            foreach (PAvailTime oldPat in oldPats)
            {
                PAvailTime patToDel = db.PAvailTimes.FirstOrDefault(pat => pat.PAvailTimeId == oldPat.PAvailTimeId);
                db.Remove(patToDel);
            }
            db.SaveChanges();
            foreach (PAvailTime updatedPat in updatedPATs)
            {
                PAvailTime newPAT = new PAvailTime();
                newPAT.PractitionerId = updatedPat.PractitionerId;
                newPAT.TimeslotId = updatedPat.TimeslotId;
                db.Add(newPAT);
            }
            db.SaveChanges();
            return db.PAvailTimes
                .Include(pat => pat.Practitioner)
                .Include(pat => pat.TimeSlot)
                .Where(pat => pat.PractitionerId == pID)
                .ToList();
        }
        // Practitioner's Services Queries
        public static List<PService> OnePsServices(int pID, ProjectContext db)
        {
            return db.PServices
                .Include(ps => ps.Practitioner)
                .Include(ps => ps.Service)
                .ToList();
        }
        public static PService OnePService(int psID, ProjectContext db)
        {
            return db.PServices
                .Include(ps => ps.Practitioner)
                .Include(ps => ps.Service)
                .FirstOrDefault(ps => ps.PServiceId == psID);
        }
        public static PService CreatePService(PService newPS, ProjectContext db)
        {
            db.Add(newPS);
            db.SaveChanges();
            return newPS;
        }
        public static void DeletePService(int psID, ProjectContext db)
        {
            PService psToDel = db.PServices.FirstOrDefault(ps => ps.PServiceId == psID);
            db.Remove(psToDel);
            db.SaveChanges();
            return;
        }
        public static List<PService> UpdateAllOfOnePsServices(int pID, List<PService> updatedPServices, ProjectContext db)
        {
            List<PService> oldPServices = db.PServices.Where(ps => ps.PractitionerId == pID).ToList();
            foreach (PService oldPS in oldPServices)
            {
                PService psToDel = db.PServices.FirstOrDefault(ps => ps.PServiceId == oldPS.PServiceId);
                db.Remove(psToDel);
            }
            db.SaveChanges();
            foreach (PService updatedPS in updatedPServices)
            {
                PService newPS = new PService();
                newPS.PractitionerId = updatedPS.PractitionerId;
                newPS.ServiceId = updatedPS.ServiceId;
                db.Add(newPS);
            }
            db.SaveChanges();
            return db.PServices
                .Include(ps => ps.Practitioner)
                .Include(ps => ps.Service)
                .ToList();
        }
        // Practitioner Insurance Queries
        public static List<PInsurance> OnePsInsurances(int pID, ProjectContext db)
        {
            return db.PInsurances
                .Include(pi => pi.Insurance)
                .Include(pi => pi.Practitioner)
                .Where(pi => pi.PractitionerId == pID)
                .ToList();
        }
        public static PInsurance OnePInsurance(int piID, ProjectContext db)
        {
            return db.PInsurances
                .Include(pi => pi.Insurance)
                .Include(pi => pi.Practitioner)
                .FirstOrDefault(pi => pi.PInsuranceId == piID);
        }
        public static PInsurance CreatePInsurance(PInsurance newPI, ProjectContext db)
        {
            db.Add(newPI);
            db.SaveChanges();
            return newPI;
        }
        public static void DeletePInsurance(int piID, ProjectContext db)
        {
            PInsurance piToDel = db.PInsurances.FirstOrDefault(pi => pi.PInsuranceId == piID);
            db.Remove(piToDel);
            db.SaveChanges();
            return;
        }
        public static List<PInsurance> UpdateAllOfOnePsInsurances(int pID, List<PInsurance> updatedPIs, ProjectContext db)
        {
            List<PInsurance> oldPInsurances = db.PInsurances.Where(pi => pi.PractitionerId == pID).ToList();
            foreach (PInsurance oldPI in oldPInsurances)
            {
                PInsurance piToDel = db.PInsurances.FirstOrDefault(pi => pi.PInsuranceId == oldPI.PInsuranceId);
                db.Remove(piToDel);
            }
            db.SaveChanges();
            foreach (PInsurance updatedPI in updatedPIs)
            {
                PInsurance newPI = new PInsurance();
                newPI.PractitionerId = updatedPI.PractitionerId;
                newPI.InsuranceId = updatedPI.InsuranceId;
                db.Add(newPI);
            }
            db.SaveChanges();
            return db.PInsurances
                .Include(pi => pi.Insurance)
                .Include(pi => pi.Practitioner)
                .Where(pi => pi.PractitionerId == pID)
                .ToList();
        }

    }
}