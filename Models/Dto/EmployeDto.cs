namespace testproject.Models.Dto;

public class EmployeDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public DateTime HireDate { get; set; }
    public string Position { get; set; } = null!;
}
