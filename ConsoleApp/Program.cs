using System.Formats.Tar;
using Application.Services;
using Domain.Enum;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;

var appDbContext = new AppDbContext();

var studentRepository = new StudentRepository(appDbContext);
var studentService = new StudentService(studentRepository);

var courseRepository = new CourseRepository(appDbContext);
var courseService = new CourseService(courseRepository);

var groupRepository = new GroupRepository(appDbContext);
var groupService = new GroupService(groupRepository);

var mentorRepository = new MentorRepository(appDbContext);
var mentorService = new MentorService(mentorRepository);

var studentGroupRepository = new StudentGroupRepository(appDbContext);
var studentGroupService = new StudentGroupService(studentGroupRepository);

var statisticsRepository = new StatisticsRepository(appDbContext);
var statisticsService = new StatisticsService(statisticsRepository);

var analyticsRepository = new AnalyticsRepository(appDbContext);
var analyticsService = new AnalyticsService(analyticsRepository);

while (true)
{
    System.Console.WriteLine("==================================");
    System.Console.WriteLine(@"1 - Students.
2 - Courses.
3 - Groups.
4 - Mentors.
5 - Student groups.
6 - Statistics.
7 - Analytics.
0 - Exit.");
    var mainOption = Console.ReadLine();
    System.Console.WriteLine("==================================");

    switch (mainOption)
    {
        case "1":
            await StudentsMenu();
            break;
        case "2":
            await CoursesMenu();
            break;
        case "3":
            await GroupsMenu();
            break;
        case "4":
            await MentorsMenu();
            break;
        case "5":
            await StudentGroupsMenu();
            break;
        case "6":
            await StatisticsMenu();
            break;
        case "7":
            await AnalyticsMenu();
            break;
        case "0":
            System.Console.WriteLine("Exiting ...");
            return;
    }
}

async Task StudentsMenu()
{
    while (true)
    {
        System.Console.WriteLine("==================================");
        System.Console.WriteLine(@"1 - Show all students.
2 - Show student.
3 - Add new student.
4 - Update student.
5 - Delete student.
6 - Show students with groups.
7 - Show students without groups.
8 - Show dropped out students.
9 - Show graduated students.
0 - Back.");
        var option = Console.ReadLine();
        System.Console.WriteLine("==================================");

        switch (option)
        {
            case "1":
                await studentService.GetAllStudentsAsync();
                break;
            case "2":
                System.Console.Write("Enter id: ");
                var student_id = Convert.ToInt32(Console.ReadLine());
                await studentService.GetStudentAsync(student_id);
                break;
            case "3":
                System.Console.Write("Enter fullname: ");
                var fullname = Console.ReadLine()!;
                System.Console.Write("Enter email: ");
                var email = Console.ReadLine()!;
                System.Console.Write("Enter phone: ");
                var phone = Console.ReadLine()!;
                System.Console.Write("Enter enrollment date: ");
                var enrollmentDate = Convert.ToDateTime(Console.ReadLine());
                var student = new Students()
                {
                    Fullname = fullname,
                    Email = email,
                    Phone = phone,
                    EnrollmentDate = DateOnly.FromDateTime(enrollmentDate)
                };
                await studentService.AddStudentAsync(student);
                break;
            case "4":
                System.Console.Write("Enter id: ");
                var uStudentId = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter fullname: ");
                var uFullname = Console.ReadLine()!;
                System.Console.Write("Enter email: ");
                var uEmail = Console.ReadLine()!;
                System.Console.Write("Enter phone: ");
                var uPhone = Console.ReadLine()!;
                System.Console.Write("Enter enrollment date: ");
                var uEnrollmentDate = Convert.ToDateTime(Console.ReadLine());
                var uStudent = new Students()
                {
                    StudentID= uStudentId,
                    Fullname = uFullname,
                    Email = uEmail,
                    Phone = uPhone,
                    EnrollmentDate = DateOnly.FromDateTime(uEnrollmentDate)
                };
                await studentService.UpdateStudentAsync(uStudent);
                break;
            case "5":
                System.Console.Write("Enter id: ");
                var dStudentId = Convert.ToInt32(Console.ReadLine());
                await studentService.DeleteStudentAsync(dStudentId);
                break;
            case "6":
                await studentService.GetStudentsWithGroupsAsync();
                break;
            case "7":
                await studentService.GetStudentsWithoutGroupsAsync();
                break;
            case "8":
                await studentService.GetDroppedOutStudentsAsync();
                break;
            case "9":
                await studentService.GetGraduatedStudentsAsync();
                break;
            case "0":
                return;
        }
    }
}

async Task CoursesMenu()
{
    while (true)
    {
        System.Console.WriteLine("==================================");
        System.Console.WriteLine(@"1 - Show all courses.
2 - Show course.
3 - Add new course.
4 - Update course.
5 - Delete course.
6 - Show students per course.
7 - Show most popular course.
8 - Show least popular courses.
9 - Show top three courses.
0 - Back.");
        var option = Console.ReadLine();
        System.Console.WriteLine("==================================");

        switch (option)
        {
            case "1":
                await courseService.GetAllCoursesAsync();
                break;
            case "2":
                System.Console.Write("Enter id: ");
                var course_id = Convert.ToInt32(Console.ReadLine());
                await courseService.GetCourseAsync(course_id);
                break;
            case "3":
                System.Console.Write("Enter title: ");
                var title = Console.ReadLine()!;
                System.Console.Write("Enter description: ");
                var description = Console.ReadLine()!;
                System.Console.Write("Enter duration weeks: ");
                var durationWeeks = Convert.ToInt32(Console.ReadLine());
                var course = new Courses()
                {
                    Title = title,
                    Description = description,
                    DurationWeeks = durationWeeks
                };
                await courseService.AddCourseAsync(course);
                break;
            case "4":
                System.Console.Write("Enter id: ");
                var uCourseId = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter title: ");
                var uTitle = Console.ReadLine()!;
                System.Console.Write("Enter description: ");
                var uDescription = Console.ReadLine()!;
                System.Console.Write("Enter duration weeks: ");
                var uDurationWeeks = Convert.ToInt32(Console.ReadLine());
                var uCourse = new Courses()
                {
                    CourseId = uCourseId,
                    Title = uTitle,
                    Description = uDescription,
                    DurationWeeks = uDurationWeeks
                };
                await courseService.UpdateCourseAsync(uCourse);
                break;
            case "5":
                System.Console.Write("Enter id: ");
                var dCourseId = Convert.ToInt32(Console.ReadLine());
                await courseService.DeleteCourseAsync(dCourseId);
                break;
            case "6":
                await courseService.GetStudentsPerCourseAsync();
                break;
            case "7":
                await courseService.GetMostPopularCourseAsync();
                break;
            case "8":
                await courseService.GetLeastPopularCoursesAsync();
                break;
            case "9":
                await courseService.GetTopThreeCoursesAsync();
                break;
            case "0":
                return;
        }
    }
}

async Task GroupsMenu()
{
    while (true)
    {
        System.Console.WriteLine("==================================");
        System.Console.WriteLine(@"1 - Show all groups.
2 - Show group.
3 - Add new group.
4 - Update group.
5 - Delete group.
6 - Show students per group.
7 - Show empty groups.
0 - Back.");
        var option = Console.ReadLine();
        System.Console.WriteLine("==================================");

        switch (option)
        {
            case "1":
                await groupService.GetAllGroupsAsync();
                break;
            case "2":
                System.Console.Write("Enter id: ");
                var group_id = Convert.ToInt32(Console.ReadLine());
                await groupService.GetGroupAsync(group_id);
                break;
            case "3":
                System.Console.Write("Enter group name: ");
                var groupName = Console.ReadLine()!;
                System.Console.Write("Enter course id: ");
                var courseId = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter mentor id: ");
                var mentorId = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter start date: ");
                var startDate = Convert.ToDateTime(Console.ReadLine());
                System.Console.Write("Enter end date: ");
                var endDate = Convert.ToDateTime(Console.ReadLine());
                var group = new Groups()
                {
                    GroupName = groupName,
                    CourseId = courseId,
                    MentorId = mentorId,
                    StartDate = DateOnly.FromDateTime(startDate),
                    EndDate = DateOnly.FromDateTime(endDate)
                };
                await groupService.AddGroupAsync(group);
                break;
            case "4":
                System.Console.Write("Enter id: ");
                var uGroupId = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter group name: ");
                var uGroupName = Console.ReadLine()!;
                System.Console.Write("Enter course id: ");
                var uCourseId = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter mentor id: ");
                var uMentorId = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter start date: ");
                var uStartDate = Convert.ToDateTime(Console.ReadLine());
                System.Console.Write("Enter end date: ");
                var uEndDate = Convert.ToDateTime(Console.ReadLine());
                var uGroup = new Groups()
                {
                    GroupId = uGroupId,
                    GroupName = uGroupName,
                    CourseId = uCourseId,
                    MentorId = uMentorId,
                    StartDate = DateOnly.FromDateTime(uStartDate),
                    EndDate = DateOnly.FromDateTime(uEndDate)
                };
                await groupService.UpdateGroupAsync(uGroup);
                break;
            case "5":
                System.Console.Write("Enter id: ");
                var dGroupId = Convert.ToInt32(Console.ReadLine());
                await groupService.DeleteGroupAsync(dGroupId);
                break;
            case "6":
                await groupService.GetStudentsPerGroupAsync();
                break;
            case "7":
                await groupService.GetEmptyGroupsAsync();
                break;
            case "0":
                return;
        }
    }
}

async Task MentorsMenu()
{
    while (true)
    {
        System.Console.WriteLine("==================================");
        System.Console.WriteLine(@"1 - Show all mentors.
2 - Show mentor.
3 - Add new mentor.
4 - Update mentor.
5 - Delete mentor.
6 - Show mentor with most students.
7 - Show mentors with multiple courses.
0 - Back.");
        var option = Console.ReadLine();
        System.Console.WriteLine("==================================");

        switch (option)
        {
            case "1":
                await mentorService.GetAllMentorsAsync();
                break;
            case "2":
                System.Console.Write("Enter id: ");
                var mentor_id = Convert.ToInt32(Console.ReadLine());
                await mentorService.GetMentorAsync(mentor_id);
                break;
            case "3":
                System.Console.Write("Enter fullname: ");
                var fullname = Console.ReadLine()!;
                System.Console.Write("Enter email: ");
                var email = Console.ReadLine()!;
                System.Console.Write("Enter phone: ");
                var phone = Console.ReadLine()!;
                System.Console.Write("Enter specialization: ");
                var specialization = Console.ReadLine()!;
                var mentor = new Mentors()
                {
                    FullName = fullname,
                    Email = email,
                    Phone = phone,
                    Specialization = specialization
                };
                await mentorService.AddMentorAsync(mentor);
                break;
            case "4":
                System.Console.Write("Enter id: ");
                var uMentorId = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter fullname: ");
                var uFullname = Console.ReadLine()!;
                System.Console.Write("Enter email: ");
                var uEmail = Console.ReadLine()!;
                System.Console.Write("Enter phone: ");
                var uPhone = Console.ReadLine()!;
                System.Console.Write("Enter specialization: ");
                var uSpecialization = Console.ReadLine()!;
                var uMentor = new Mentors()
                {
                    MentorId = uMentorId,
                    FullName = uFullname,
                    Email = uEmail,
                    Phone = uPhone,
                    Specialization = uSpecialization
                };
                await mentorService.UpdateMentorAsync(uMentor);
                break;
            case "5":
                System.Console.Write("Enter id: ");
                var dMentorId = Convert.ToInt32(Console.ReadLine());
                await mentorService.DeleteMentorAsync(dMentorId);
                break;
            case "6":
                await mentorService.GetMentorWithMostStudentsAsync();
                break;
            case "7":
                await mentorService.GetMentorsWithMultipleCoursesAsync();
                break;
            case "0":
                return;
        }
    }
}

async Task StudentGroupsMenu()
{
    while (true)
    {
        System.Console.WriteLine("==================================");
        System.Console.WriteLine(@"1 - Show all student groups.
2 - Show student group.
3 - Add new student group.
4 - Update student group.
5 - Delete student group.
0 - Back.");
        var option = Console.ReadLine();
        System.Console.WriteLine("==================================");

        switch (option)
        {
            case "1":
                await studentGroupService.GetAllStudentGroupsAsync();
                break;
            case "2":
                System.Console.Write("Enter id: ");
                var studentGroup_id = Convert.ToInt32(Console.ReadLine());
                await studentGroupService.GetStudentGroupAsync(studentGroup_id);
                break;
            case "3":
                System.Console.Write("Enter student id: ");
                var studentId = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter group id: ");
                var groupId = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter status (Active, Left, Finished): ");
                var status = Enum.Parse<StudentGroupStatus>(Console.ReadLine()!, true);
                var studentGroup = new StudentGroups()
                {
                    StudentId = studentId,
                    GroupId = groupId,
                    Status = status
                };
                await studentGroupService.AddStudentGroupAsync(studentGroup);
                break;
            case "4":
                System.Console.Write("Enter id: ");
                var uStudentGroupId = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter student id: ");
                var uStudentId = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter group id: ");
                var uGroupId = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter status (Active, Left, Finished): ");
                var uStatus = Enum.Parse<StudentGroupStatus>(Console.ReadLine()!, true);
                var uStudentGroup = new StudentGroups()
                {
                    StudentGroupId = uStudentGroupId,
                    StudentId = uStudentId,
                    GroupId = uGroupId,
                    Status = uStatus
                };
                await studentGroupService.UpdateStudentGroupAsync(uStudentGroup);
                break;
            case "5":
                System.Console.Write("Enter id: ");
                var dStudentGroupId = Convert.ToInt32(Console.ReadLine());
                await studentGroupService.DeleteStudentGroupAsync(dStudentGroupId);
                break;
            case "0":
                return;
        }
    }
}

async Task StatisticsMenu()
{
    while (true)
    {
        System.Console.WriteLine("==================================");
        System.Console.WriteLine(@"1 - Total students count.
2 - Total groups count.
3 - Total courses count.
4 - Total mentors count.
5 - All start dates.
0 - Back.");
        var option = Console.ReadLine();
        System.Console.WriteLine("==================================");

        switch (option)
        {
            case "1":
                await statisticsService.GetTotalStudentsCountAsync();
                break;
            case "2":
                await statisticsService.GetTotalGroupsCountAsync();
                break;
            case "3":
                await statisticsService.GetTotalCoursesCountAsync();
                break;
            case "4":
                await statisticsService.GetTotalMentorsCountAsync();
                break;
            case "5":
                await statisticsService.GetAllStartDatesAsync();
                break;
            case "0":
                return;
        }
    }
}

async Task AnalyticsMenu()
{
    while (true)
    {
        System.Console.WriteLine("==================================");
        System.Console.WriteLine(@"1 - Completion rate.
0 - Back.");
        var option = Console.ReadLine();
        System.Console.WriteLine("==================================");

        switch (option)
        {
            case "1":
                await analyticsService.GetCompletionRateAsync();
                break;
            case "0":
                return;
        }
    }
}