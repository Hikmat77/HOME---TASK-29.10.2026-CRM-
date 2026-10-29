using Domain.Models;

namespace Application.Interfaces;

public interface IStudentService
{
    void AddStudent(Students student);
    void UpdateStudent(Students student);
    void DeleteStudent(int studentId);
    void GetStudent(int studentId);
    void GetAllStudents();
}