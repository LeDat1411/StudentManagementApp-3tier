namespace StudentManagementApp.DAL.Entities
{
    public sealed class StudentEntity
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public int YearOfEnroll { get; set; }
        public string Major { get; set; }
        public decimal GPA { get; set; }
    }
}