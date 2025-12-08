using CRUD_with_WebAPI.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_with_WebAPI.DTOs
{
    public class RegisterRequestDTO
    {
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, ErrorMessage = "Full Name should not exceed 50 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(30)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 100, ErrorMessage = "Validate Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        [CustomBirthYear(2000)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Enter a valid mobile number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Select Valid Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Married Status is required")]
        [RegularExpression("^(Married|Unmarried)$", ErrorMessage = "Select a valid married status")]
        public string MarriedStatus { get; set; }

        [Required(ErrorMessage = "Image Url is required")]
        [RegularExpression(@"^(https?:\/\/.*\.(?:png|jpg|jpeg|gif|bmp|webp))$", ErrorMessage = "Please enter a valid image URL")]
        public string ImageUrl { get; set; }

        // NOTE: intentionally NO Role property here — UI won't show role
    }
}
