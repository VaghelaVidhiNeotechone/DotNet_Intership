using Swashbuckle.AspNetCore.Filters;
using CRUD_with_WebAPI.Models;
using System;

public class UserExample : IExamplesProvider<User>
{
    public User GetExamples()
    {
        return new User
        {
            Id = 0,
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
            Role = "User"
        };
    }
}
