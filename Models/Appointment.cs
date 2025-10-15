using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Test_Santiagorestrepoarismendy.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        public TimeSpan Hour { get; set; }

        public string? Observations { get; set; }

        [Required]
        [RegularExpression("^(Pendent|Seen|Canceled)$", ErrorMessage = "Invalid state")]
        public string? State { get; set; }

        // --- RELATIONS ---
        [Required]
        public int PatientId { get; set; }

        [ValidateNever]
        public Patient? Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [ValidateNever]
        public Doctor? Doctor { get; set; }
    }
}