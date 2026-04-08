using System;
using System.Collections.Generic;

namespace testproject.Models;

public partial class Employe
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime HireDate { get; set; }

    public string Position { get; set; } = null!;
}
