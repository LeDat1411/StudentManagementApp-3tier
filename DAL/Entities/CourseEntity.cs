namespace StudentManagementApp.DAL.Entities
{
    public sealed class CourseEntity
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public int InstructorID { get; set; }
    }
}