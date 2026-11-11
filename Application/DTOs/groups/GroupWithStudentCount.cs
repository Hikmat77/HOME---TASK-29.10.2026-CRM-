namespace Application.DTOs;

public class GroupWithStudentCount
{
    public int GroupId {get; set;}
    public string GroupName {get; set;}=null!;
    public int StudentCount {get; set;}
}
