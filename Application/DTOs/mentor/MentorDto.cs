namespace Application.DTOs;

public class MentorDto
{
    public int MentorId {get; set;}
    public string FullName {get; set;}=null!;
    public string Email {get; set;}=null!;
    public string Phone {get; set;}=null!;
    public string Specialization {get; set;}=null!;
}
