using Swashbuckle.AspNetCore.Filters;
using CRUD_with_WebAPI.DTOs;

public class LoginExample : IExamplesProvider<LoginRequestDTO>
{
    public LoginRequestDTO GetExamples()
    {
        return new LoginRequestDTO
        {
            Username = "Please enter Username",
            Password = "Please enter Password"
        };
    }
}
