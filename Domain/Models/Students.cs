namespace Domain.Models;

public class Students
{
    public int StudentID { get; set; }
    public string Fullname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateOnly EnrollmentDate { get; set; }
}