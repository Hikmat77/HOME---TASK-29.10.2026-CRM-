namespace Application.DTOs;

public class CourseDto
{
    public int CourseId {get; set;}
    public string Title {get; set;}=null!;
    public string Description {get; set;}=null!;
    public int DurationWeeks {get; set;}
}
