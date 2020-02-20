using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace massage.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public int PractitionerId { get; set; }
        public User Practitioner { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        [Required]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Required]
        public int TimeslotId { get; set; }
        public Timeslot Timeslot { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}