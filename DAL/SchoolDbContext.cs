using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using StudentManagementApp.DAL.Entities;

namespace StudentManagementApp.DAL
{
    public sealed class SchoolDbContext : DbContext
    {
        static SchoolDbContext()
        {
            // This app targets an existing database. EF must never create or migrate it.
            Database.SetInitializer<SchoolDbContext>(null);
        }

        public SchoolDbContext() : base("name=SchoolDBConnectionString")
        {
        }

        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<InstructorEntity> Instructors { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<EnrollmentEntity> StudentCourses { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<StudentEntity>().ToTable("tblStudents").HasKey(x => x.StudentID);
            modelBuilder.Entity<StudentEntity>().Property(x => x.StudentID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<CourseEntity>().ToTable("tblCourses").HasKey(x => x.CourseID);
            modelBuilder.Entity<CourseEntity>().Property(x => x.CourseID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<InstructorEntity>().ToTable("tblInstructors").HasKey(x => x.InstructorID);
            modelBuilder.Entity<InstructorEntity>().Property(x => x.InstructorID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DepartmentEntity>().ToTable("tblDepartments").HasKey(x => x.DepartmentID);
            modelBuilder.Entity<DepartmentEntity>().Property(x => x.DepartmentID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<EnrollmentEntity>().ToTable("tblStudentCourses")
                .HasKey(x => new { x.StudentID, x.CourseID });

            modelBuilder.Entity<UserEntity>().ToTable("tblUsers").HasKey(x => x.Username);
            modelBuilder.Entity<UserEntity>().Property(x => x.Username).HasColumnName("Username");
            modelBuilder.Entity<UserEntity>().Property(x => x.Password).HasColumnName("Password");

            base.OnModelCreating(modelBuilder);
        }
    }
}