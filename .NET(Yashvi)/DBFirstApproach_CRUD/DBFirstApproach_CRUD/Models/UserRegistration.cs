using System;
using System.Collections.Generic;

namespace DBFirstApproach_CRUD.Models;

public partial class UserRegistration
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Skills { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Address { get; set; } = null!;
}
