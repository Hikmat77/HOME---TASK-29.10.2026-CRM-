namespace Domain.Models;

public class Courses
{
    public int CourseId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DurationWeeks { get; set; }
}