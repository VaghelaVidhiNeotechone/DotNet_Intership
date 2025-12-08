using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_with_WebAPI.Validators
{
    public class CustomBirthYearAttribute : ValidationAttribute
    {
        private readonly int _minYear;

        public CustomBirthYearAttribute(int minYear)
        {
            _minYear = minYear;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime birthDate)
            {
                if (birthDate.Year < _minYear)
                {
                    return new ValidationResult($"Birth year must be {_minYear} or later");
                }
            }

            return ValidationResult.Success;
        }
    }
}
