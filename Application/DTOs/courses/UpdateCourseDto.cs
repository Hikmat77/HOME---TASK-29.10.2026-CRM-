namespace Application.DTOs;

public class UpdateCourseDto
{
    public string Title {get; set;}=null!;
    public string Description {get; set;}=null!;
    public int DurationWeeks {get; set;}
}
