using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentRepository
{
    bool AddStudent(Students student);
    bool UpdateStudent(Students student);
    bool DeleteStudent(int studentId);
    Students GetStudent(int studentId);
    List<Students> GetStudents();
}