using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagementApp.BLL.Models;
using StudentManagementApp.DAL;
using StudentManagementApp.DAL.Entities;

namespace StudentManagementApp.BLL
{
    /// <summary>Business rules and mapping between the WinForms view models and DAL entities.</summary>
    public sealed class StudentManagementService
    {
        private readonly SchoolRepository repository;

        public StudentManagementService() : this(new SchoolRepository())
        {
        }

        public StudentManagementService(SchoolRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public bool Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password)) return false;
            return repository.ValidateLogin(username, password);
        }

        public List<StudentRecord> GetStudents()
        {
            return repository.GetStudents().Select(x => new StudentRecord
            {
                StudentID = x.StudentID, StudentName = x.StudentName, DateOfBirth = x.DateOfBirth,
                City = x.City, Age = x.Age, YearOfEnroll = x.YearOfEnroll, Major = x.Major, GPA = x.GPA
            }).ToList();
        }

        public void AddStudent(StudentRecord student)
        {
            ValidateStudent(student);
            repository.AddStudent(ToEntity(student));
        }

        public void UpdateStudent(StudentRecord student)
        {
            ValidateStudent(student);
            repository.UpdateStudent(ToEntity(student));
        }

        public void DeleteStudent(int studentID) { repository.DeleteStudent(studentID); }

        public List<CourseRecord> GetCourses()
        {
            return repository.GetCourses().Select(x => new CourseRecord
            {
                CourseID = x.CourseID, CourseName = x.CourseName, Credits = x.Credits,
                DepartmentID = x.DepartmentID, InstructorID = x.InstructorID
            }).ToList();
        }

        public void AddCourse(CourseRecord course)
        {
            ValidateCourse(course);
            repository.AddCourse(ToEntity(course));
        }

        public void UpdateCourse(CourseRecord course)
        {
            ValidateCourse(course);
            repository.UpdateCourse(ToEntity(course));
        }

        public void DeleteCourse(int courseID) { repository.DeleteCourse(courseID); }

        public List<InstructorRecord> GetInstructors()
        {
            return repository.GetInstructors().Select(x => new InstructorRecord
            {
                InstructorID = x.InstructorID, InstructorName = x.InstructorName, DepartmentID = x.DepartmentID
            }).ToList();
        }

        public void AddInstructor(InstructorRecord instructor)
        {
            ValidateInstructor(instructor);
            repository.AddInstructor(ToEntity(instructor));
        }

        public void UpdateInstructor(InstructorRecord instructor)
        {
            ValidateInstructor(instructor);
            repository.UpdateInstructor(ToEntity(instructor));
        }

        public void DeleteInstructor(int instructorID) { repository.DeleteInstructor(instructorID); }

        public List<DepartmentRecord> GetDepartments()
        {
            return repository.GetDepartments().Select(x => new DepartmentRecord
            {
                DepartmentID = x.DepartmentID, DepartmentName = x.DepartmentName
            }).ToList();
        }

        public void AddDepartment(DepartmentRecord department)
        {
            ValidateDepartment(department);
            repository.AddDepartment(ToEntity(department));
        }

        public void UpdateDepartment(DepartmentRecord department)
        {
            ValidateDepartment(department);
            repository.UpdateDepartment(ToEntity(department));
        }

        public void DeleteDepartment(int departmentID) { repository.DeleteDepartment(departmentID); }

        public List<EnrollmentRecord> GetEnrollments()
        {
            return repository.GetEnrollments().Select(ToRecord).ToList();
        }

        public List<EnrollmentRecord> GetEnrollmentsForCourse(int courseID)
        {
            return repository.GetEnrollmentsForCourse(courseID).Select(ToRecord).ToList();
        }

        public void AddEnrollment(int studentID, int courseID)
        {
            if (studentID <= 0 || courseID <= 0) throw new ArgumentOutOfRangeException("Enrollment IDs must be positive.");
            repository.AddEnrollment(studentID, courseID);
        }

        public void MoveEnrollment(int studentID, int oldCourseID, int newCourseID)
        {
            if (studentID <= 0 || oldCourseID <= 0 || newCourseID <= 0)
                throw new ArgumentOutOfRangeException("Enrollment IDs must be positive.");
            repository.MoveEnrollment(studentID, oldCourseID, newCourseID);
        }

        public void DeleteEnrollment(int studentID, int courseID)
        {
            repository.DeleteEnrollment(studentID, courseID);
        }

        private static StudentEntity ToEntity(StudentRecord x)
        {
            return new StudentEntity
            {
                StudentID = x.StudentID, StudentName = x.StudentName, DateOfBirth = x.DateOfBirth,
                City = x.City, Age = x.Age, YearOfEnroll = x.YearOfEnroll, Major = x.Major, GPA = x.GPA
            };
        }

        private static CourseEntity ToEntity(CourseRecord x)
        {
            return new CourseEntity
            {
                CourseID = x.CourseID, CourseName = x.CourseName, Credits = x.Credits,
                DepartmentID = x.DepartmentID, InstructorID = x.InstructorID
            };
        }

        private static InstructorEntity ToEntity(InstructorRecord x)
        {
            return new InstructorEntity
            {
                InstructorID = x.InstructorID, InstructorName = x.InstructorName, DepartmentID = x.DepartmentID
            };
        }

        private static DepartmentEntity ToEntity(DepartmentRecord x)
        {
            return new DepartmentEntity { DepartmentID = x.DepartmentID, DepartmentName = x.DepartmentName };
        }

        private static EnrollmentRecord ToRecord(EnrollmentEntity x)
        {
            return new EnrollmentRecord { StudentID = x.StudentID, CourseID = x.CourseID };
        }

        private static void ValidateStudent(StudentRecord student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            if (string.IsNullOrWhiteSpace(student.StudentName)) throw new ArgumentException("Student name is required.");
            if (student.GPA < 0m || student.GPA > 4.0m) throw new ArgumentOutOfRangeException(nameof(student.GPA), "GPA must be between 0 and 4.0.");
        }

        private static void ValidateCourse(CourseRecord course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));
            if (string.IsNullOrWhiteSpace(course.CourseName)) throw new ArgumentException("Course name is required.");
            if (course.Credits <= 0) throw new ArgumentOutOfRangeException(nameof(course.Credits), "Credits must be positive.");
        }

        private static void ValidateInstructor(InstructorRecord instructor)
        {
            if (instructor == null) throw new ArgumentNullException(nameof(instructor));
            if (string.IsNullOrWhiteSpace(instructor.InstructorName)) throw new ArgumentException("Instructor name is required.");
        }

        private static void ValidateDepartment(DepartmentRecord department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department));
            if (string.IsNullOrWhiteSpace(department.DepartmentName)) throw new ArgumentException("Department name is required.");
        }
    }
}