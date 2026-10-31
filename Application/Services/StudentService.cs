using Application.Interfaces;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;

namespace Application.Services;

public class StudentService(StudentRepository studentRepository) : IStudentService
{
    private StudentRepository _repository = studentRepository;
    public async Task AddStudentAsync(Students student)
    {
        var result = await _repository.AddStudentAsync(student);
        if(result) System.Console.WriteLine("Added successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public async Task DeleteStudentAsync(int studentId)
    {
        var result = await _repository.DeleteStudentAsync(studentId);
        if(result) System.Console.WriteLine("Deleted successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public async Task GetAllStudentsAsync()
    {
       var students = await _repository.GetStudentsAsync();
       foreach (var student in students)
       {
            System.Console.WriteLine(student.StudentID+" "+student.Fullname+" "+student.Email+" "+student.Phone+" "+student.EnrollmentDate);
       }
    }

    public async Task GetStudentAsync(int studentId)
    {
        var student = await _repository.GetStudentAsync(studentId);
        System.Console.WriteLine(student.StudentID+" "+student.Fullname+" "+student.Email+" "+student.Phone+" "+student.EnrollmentDate);
    }

    public async Task UpdateStudentAsync(Students student)
    {
        var result = await _repository.UpdateStudentAsync(student);
        if(result) System.Console.WriteLine("Updated successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public async Task GetStudentsWithGroupsAsync()
    {
       var students = await _repository.GetStudentsWithGroupsAsync();
       foreach (var student in students)
       {
            System.Console.WriteLine(student.studentid+" "+student.fullname+" "+student.groupname);
       }
    }

    public async Task GetStudentsWithoutGroupsAsync()
    {
       var students = await _repository.GetStudentsWithoutGroupsAsync();
       foreach (var student in students)
       {
            System.Console.WriteLine(student.StudentID+" "+student.Fullname+" "+student.Email+" "+student.Phone+" "+student.EnrollmentDate);
       }
    }

    public async Task GetDroppedOutStudentsAsync()
    {
       var students = await _repository.GetDroppedOutStudentsAsync();
       foreach (var student in students)
       {
            System.Console.WriteLine(student.StudentID+" "+student.Fullname+" "+student.Email+" "+student.Phone+" "+student.EnrollmentDate);
       }
    }

    public async Task GetGraduatedStudentsAsync()
    {
       var students = await _repository.GetGraduatedStudentsAsync();
       foreach (var student in students)
       {
            System.Console.WriteLine(student.StudentID+" "+student.Fullname+" "+student.Email+" "+student.Phone+" "+student.EnrollmentDate);
       }
    }
}