using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StudentManagementApp.DAL.Entities;

namespace StudentManagementApp.DAL
{
    /// <summary>EF-backed data access for the existing SchoolDB schema.</summary>
    public sealed class SchoolRepository
    {
        public bool ValidateLogin(string username, string password)
        {
            using (var db = new SchoolDbContext())
                return db.Users.Any(x => x.Username == username && x.Password == password);
        }

        public List<StudentEntity> GetStudents()
        {
            using (var db = new SchoolDbContext())
                return db.Students.AsNoTracking().OrderBy(x => x.StudentID).ToList();
        }

        public void AddStudent(StudentEntity student)
        {
            using (var db = new SchoolDbContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public void UpdateStudent(StudentEntity changes)
        {
            using (var db = new SchoolDbContext())
            {
                var row = db.Students.Find(changes.StudentID);
                if (row == null) throw new KeyNotFoundException("The selected student no longer exists.");
                row.StudentName = changes.StudentName;
                row.DateOfBirth = changes.DateOfBirth;
                row.City = changes.City;
                row.Age = changes.Age;
                row.YearOfEnroll = changes.YearOfEnroll;
                row.Major = changes.Major;
                row.GPA = changes.GPA;
                db.SaveChanges();
            }
        }

        public void DeleteStudent(int studentID)
        {
            using (var db = new SchoolDbContext())
            {
                var row = db.Students.Find(studentID);
                if (row == null) return;
                db.Students.Remove(row);
                db.SaveChanges();
            }
        }

        public List<CourseEntity> GetCourses()
        {
            using (var db = new SchoolDbContext())
                return db.Courses.AsNoTracking().OrderBy(x => x.CourseID).ToList();
        }

        public void AddCourse(CourseEntity course)
        {
            using (var db = new SchoolDbContext())
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }
        }

        public void UpdateCourse(CourseEntity changes)
        {
            using (var db = new SchoolDbContext())
            {
                var row = db.Courses.Find(changes.CourseID);
                if (row == null) throw new KeyNotFoundException("The selected course no longer exists.");
                row.CourseName = changes.CourseName;
                row.Credits = changes.Credits;
                row.DepartmentID = changes.DepartmentID;
                row.InstructorID = changes.InstructorID;
                db.SaveChanges();
            }
        }

        public void DeleteCourse(int courseID)
        {
            using (var db = new SchoolDbContext())
            {
                var row = db.Courses.Find(courseID);
                if (row == null) return;
                db.Courses.Remove(row);
                db.SaveChanges();
            }
        }

        public List<InstructorEntity> GetInstructors()
        {
            using (var db = new SchoolDbContext())
                return db.Instructors.AsNoTracking().OrderBy(x => x.InstructorID).ToList();
        }

        public void AddInstructor(InstructorEntity instructor)
        {
            using (var db = new SchoolDbContext())
            {
                db.Instructors.Add(instructor);
                db.SaveChanges();
            }
        }

        public void UpdateInstructor(InstructorEntity changes)
        {
            using (var db = new SchoolDbContext())
            {
                var row = db.Instructors.Find(changes.InstructorID);
                if (row == null) throw new KeyNotFoundException("The selected instructor no longer exists.");
                row.InstructorName = changes.InstructorName;
                row.DepartmentID = changes.DepartmentID;
                db.SaveChanges();
            }
        }

        public void DeleteInstructor(int instructorID)
        {
            using (var db = new SchoolDbContext())
            {
                var row = db.Instructors.Find(instructorID);
                if (row == null) return;
                db.Instructors.Remove(row);
                db.SaveChanges();
            }
        }

        public List<DepartmentEntity> GetDepartments()
        {
            using (var db = new SchoolDbContext())
                return db.Departments.AsNoTracking().OrderBy(x => x.DepartmentID).ToList();
        }

        public void AddDepartment(DepartmentEntity department)
        {
            using (var db = new SchoolDbContext())
            {
                db.Departments.Add(department);
                db.SaveChanges();
            }
        }

        public void UpdateDepartment(DepartmentEntity changes)
        {
            using (var db = new SchoolDbContext())
            {
                var row = db.Departments.Find(changes.DepartmentID);
                if (row == null) throw new KeyNotFoundException("The selected department no longer exists.");
                row.DepartmentName = changes.DepartmentName;
                db.SaveChanges();
            }
        }

        public void DeleteDepartment(int departmentID)
        {
            using (var db = new SchoolDbContext())
            {
                var row = db.Departments.Find(departmentID);
                if (row == null) return;
                db.Departments.Remove(row);
                db.SaveChanges();
            }
        }

        public List<EnrollmentEntity> GetEnrollments()
        {
            using (var db = new SchoolDbContext())
                return db.StudentCourses.AsNoTracking()
                    .OrderBy(x => x.CourseID).ThenBy(x => x.StudentID).ToList();
        }

        public List<EnrollmentEntity> GetEnrollmentsForCourse(int courseID)
        {
            using (var db = new SchoolDbContext())
                return db.StudentCourses.AsNoTracking().Where(x => x.CourseID == courseID)
                    .OrderBy(x => x.StudentID).ToList();
        }

        public void AddEnrollment(int studentID, int courseID)
        {
            using (var db = new SchoolDbContext())
            {
                if (db.StudentCourses.Find(studentID, courseID) != null) return;
                db.StudentCourses.Add(new EnrollmentEntity { StudentID = studentID, CourseID = courseID });
                db.SaveChanges();
            }
        }

        public void MoveEnrollment(int studentID, int oldCourseID, int newCourseID)
        {
            if (oldCourseID == newCourseID) return;
            using (var db = new SchoolDbContext())
            using (var transaction = db.Database.BeginTransaction())
            {
                var oldRow = db.StudentCourses.Find(studentID, oldCourseID);
                if (oldRow == null) throw new KeyNotFoundException("The selected enrollment no longer exists.");
                if (db.StudentCourses.Find(studentID, newCourseID) != null)
                    throw new System.InvalidOperationException("That student is already enrolled in the selected course.");

                db.StudentCourses.Remove(oldRow);
                db.SaveChanges();
                db.StudentCourses.Add(new EnrollmentEntity { StudentID = studentID, CourseID = newCourseID });
                db.SaveChanges();
                transaction.Commit();
            }
        }

        public void DeleteEnrollment(int studentID, int courseID)
        {
            using (var db = new SchoolDbContext())
            {
                var row = db.StudentCourses.Find(studentID, courseID);
                if (row == null) return;
                db.StudentCourses.Remove(row);
                db.SaveChanges();
            }
        }
    }
}