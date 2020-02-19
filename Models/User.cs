using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace massage.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255, ErrorMessage="Name may not be more than 255 characters long")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Username must be at least 2 characters long")]
        [MaxLength(29, ErrorMessage="Username must be less than 30 characters long")]
        public string Username { get; set; }

        [Required]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters in length.")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [NotMapped]
        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }

        public int Role { get; set; } = 0; // Set Role by default to 0 for unassigned (1 = Practitioner, 2 = Receptionist, 5 = Admin)
        
        public int PTemplateId { get; set; }
        public PTemplate PTemplate { get; set; }
        
        
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}