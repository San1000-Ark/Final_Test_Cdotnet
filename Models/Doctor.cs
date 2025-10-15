using System.ComponentModel.DataAnnotations;

namespace Test_Santiagorestrepoarismendy.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The last name is required")]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email address format is not valid")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Specialty is required")]
        public string? Specialty { get; set; }
    }
}