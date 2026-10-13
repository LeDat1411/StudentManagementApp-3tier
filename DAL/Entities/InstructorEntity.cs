namespace StudentManagementApp.DAL.Entities
{
    public sealed class InstructorEntity
    {
        public int InstructorID { get; set; }
        public string InstructorName { get; set; }
        public int DepartmentID { get; set; }
    }
}