using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace massage.Models
{
    public class Timeslot
    {
        [Key]
        public long TimeslotId { get; set; }

        [Range(6,20)]
        public int Hour { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public List<PAvailTime> PsAvail { get; set; } // Practitioners available
    }
}