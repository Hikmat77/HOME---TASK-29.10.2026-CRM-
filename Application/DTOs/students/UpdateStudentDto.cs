namespace Application.DTOs;

public class UpdateStudentDto
{
    public string Fullname {get; set;}=null!;
    public string Email {get; set;}=null!;
    public string Phone {get; set;}=null!;
    public DateOnly EnrollmentDate {get; set;}
}
