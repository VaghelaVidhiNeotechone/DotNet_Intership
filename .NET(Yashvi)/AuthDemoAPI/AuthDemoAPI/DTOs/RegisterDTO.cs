using System.ComponentModel.DataAnnotations;
public class RegisterDto
{
    public string FullName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;

    public int Age { get; set; }
    public DateTime BirthDate { get; set; }

    public string MobileNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;

    public bool MarriedStatus { get; set; }
    public string ImageUrl { get; set; } = string.Empty;


}
