using Domain.Enum;

namespace Application.DTOs;

public class CreateStudentGroupDto
{
    public int StudentId {get; set;}
    public int GroupId {get; set;}
    public StudentGroupStatus Status {get; set;}
}
