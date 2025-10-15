using System;
using System.ComponentModel.DataAnnotations;

namespace Test_Santiagorestrepoarismendy.Validations
{
    public class BirthDateValid : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime birthDate)
            {
                var today = DateTime.Today;
                var age = today.Year - birthDate.Year;

                if (birthDate.Date > today.AddYears(-age))
                    age--;

                if (birthDate > today)
                    return new ValidationResult("Birth date cannot be in the future.");

                if (age <= 0)
                    return new ValidationResult("The birth date is invalid.");

                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid birth date format.");
        }
    }
}