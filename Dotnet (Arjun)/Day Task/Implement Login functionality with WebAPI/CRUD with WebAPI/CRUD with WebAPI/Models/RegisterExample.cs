using Swashbuckle.AspNetCore.Filters;
using CRUD_with_WebAPI.DTOs;
using System;

public class RegisterExample : IExamplesProvider<RegisterRequestDTO>
{
    public RegisterRequestDTO GetExamples()
    {
        return new RegisterRequestDTO
        {
            FullName = "Please enter your fullname",
            Username = "Please enter Username",
            Email = "Please enter your Email",
            Password = "Please enter Password",
            ConfirmPassword = "Please enter Confirm Password",
            Age = 0,
            BirthDate = DateTime.Now,
            MobileNumber = "Please Enter Your number",
            City = "Please enter your City",
            State = "Please enter your state",
            Country = "Please enter your Country",
            Gender = "Please enter your Gender",
            MarriedStatus = "Please enter your married status",
            ImageUrl = "https://example.com/sample.jpg",
        };
    }
}
