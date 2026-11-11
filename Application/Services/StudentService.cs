using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    private IStudentRepository repository = studentRepository;
    public async Task<ApiResponse<bool>> AddStudentAsync(CreateStudentDto dto)
    {
        var student = new Students()
        {
            Fullname = dto.Fullname,
            Email = dto.Email,
            Phone = dto.Phone,
            EnrollmentDate = dto.EnrollmentDate
        };
        var res = await repository.AddStudentAsync(student);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteStudentAsync(int studentId)
    {
        var res = await repository.DeleteStudentAsync(studentId);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<StudentDto>> GetStudentAsync(int studentId)
    {
        var student = await repository.GetStudentAsync(studentId);
        var res = new StudentDto()
        {
            StudentID = student.StudentID,
            Fullname = student.Fullname,
            Email = student.Email,
            Phone = student.Phone,
            EnrollmentDate = student.EnrollmentDate
        };
        return new ApiResponse<StudentDto>(HttpStatusCode.OK, "Student with given id.", res);
    }

    public async Task<ApiResponse<List<StudentDto>>> GetAllStudentsAsync()
    {
        var students = await repository.GetStudentsAsync();
        var res = students.Select(x=>new StudentDto()
        {
            StudentID = x.StudentID,
            Fullname = x.Fullname,
            Email = x.Email,
            Phone = x.Phone,
            EnrollmentDate = x.EnrollmentDate
        }).ToList();
        return new ApiResponse<List<StudentDto>>(HttpStatusCode.OK, "List of students.", res);
    }

    public async Task<ApiResponse<List<StudentWithGroup>>> GetStudentsWithGroupsAsync()
    {
        var students = await repository.GetStudentsWithGroupsAsync();
        var res = students.Select(x=>new StudentWithGroup()
        {
            StudentID = x.studentid,
            Fullname = x.fullname,
            GroupName = x.groupname
        }).ToList();
        return new ApiResponse<List<StudentWithGroup>>(HttpStatusCode.OK, "Students with groups.", res);
    }

    public async Task<ApiResponse<List<StudentDto>>> GetStudentsWithoutGroupsAsync()
    {
        var students = await repository.GetStudentsWithoutGroupsAsync();
        var res = students.Select(x=>new StudentDto()
        {
            StudentID = x.StudentID,
            Fullname = x.Fullname,
            Email = x.Email,
            Phone = x.Phone,
            EnrollmentDate = x.EnrollmentDate
        }).ToList();
        return new ApiResponse<List<StudentDto>>(HttpStatusCode.OK, "Students without groups.", res);
    }

    public async Task<ApiResponse<List<StudentDto>>> GetDroppedOutStudentsAsync()
    {
        var students = await repository.GetDroppedOutStudentsAsync();
        var res = students.Select(x=>new StudentDto()
        {
            StudentID = x.StudentID,
            Fullname = x.Fullname,
            Email = x.Email,
            Phone = x.Phone,
            EnrollmentDate = x.EnrollmentDate
        }).ToList();
        return new ApiResponse<List<StudentDto>>(HttpStatusCode.OK, "Dropped out students.", res);
    }

    public async Task<ApiResponse<List<StudentDto>>> GetGraduatedStudentsAsync()
    {
        var students = await repository.GetGraduatedStudentsAsync();
        var res = students.Select(x=>new StudentDto()
        {
            StudentID = x.StudentID,
            Fullname = x.Fullname,
            Email = x.Email,
            Phone = x.Phone,
            EnrollmentDate = x.EnrollmentDate
        }).ToList();
        return new ApiResponse<List<StudentDto>>(HttpStatusCode.OK, "Graduated students.", res);
    }
    public async Task<ApiResponse<bool>> UpdateStudentAsync(int studentId, UpdateStudentDto dto)
    {
        var student = new Students()
        {
            StudentID = studentId,
            Fullname = dto.Fullname,
            Email = dto.Email,
            Phone = dto.Phone,
            EnrollmentDate = dto.EnrollmentDate
        };
        var res = await repository.UpdateStudentAsync(student);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}
