using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace massage.Models
{
    public class PSchedule
    {
        [Key]
        public int PScheduleId { get; set; }

        public int PractitionerId { get; set; }

        public User Practitioner { get; set; }

        public string DayOfWeek { get; set; } // Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
        
        // times available

        public bool t6 { get; set; } // 6am
        public bool t7 { get; set; } // 7am
        public bool t8 { get; set; } // 8am
        public bool t9 { get; set; } // 9am
        public bool t10 { get; set; } // 10am
        public bool t11 { get; set; } // 11am
        public bool t12 { get; set; } // noon
        public bool t13 { get; set; } // 1pm
        public bool t14 { get; set; } // 2pm
        public bool t15 { get; set; } // 3pm
        public bool t16 { get; set; } // 4pm
        public bool t17 { get; set; } // 5pm
        public bool t18 { get; set; } // 6pm

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}