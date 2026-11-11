namespace Application.DTOs;

public class CourseWithStudentCount
{
    public int CourseId {get; set;}
    public string Title {get; set;}=null!;
    public int StudentCount {get; set;}
}
