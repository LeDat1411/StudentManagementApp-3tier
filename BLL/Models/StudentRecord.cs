using System;

namespace StudentManagementApp.BLL.Models
{
    public sealed class StudentRecord
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public int YearOfEnroll { get; set; }
        public string Major { get; set; }
        public decimal GPA { get; set; }
    }
}