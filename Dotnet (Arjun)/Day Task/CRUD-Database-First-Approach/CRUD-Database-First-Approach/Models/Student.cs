using System;
using System.Collections.Generic;

namespace CRUD_Database_First_Approach.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? City { get; set; }
}
