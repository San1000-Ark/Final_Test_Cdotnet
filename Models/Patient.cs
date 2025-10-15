using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Test_Santiagorestrepoarismendy.Validations;

namespace Test_Santiagorestrepoarismendy.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "The name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The last name is required")]
        public string? Lastname { get; set; }

        [Required(ErrorMessage = "The birth date is required")]
        [DataType(DataType.Date)]
        [BirthDateValid]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The symptom is required")]
        public string? Symptom { get; set; }

        [Required(ErrorMessage = "The phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must contain exactly 10 digits")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The phone number must be exactly 10 digits")]
        public string? PhoneNumber { get; set; }

        public List<Appointment>? Appointments { get; set; } = new();
    }
}