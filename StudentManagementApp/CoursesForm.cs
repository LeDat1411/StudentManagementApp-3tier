using System;
using System.Windows.Forms;
using StudentManagementApp.BLL;
using StudentManagementApp.BLL.Models;

namespace StudentManagementApp
{
    public partial class CoursesForm : Form
    {
        private readonly StudentManagementService service = new StudentManagementService();

        public CoursesForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            Load += CoursesForm_Load;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
        }

        private void CoursesForm_Load(object sender, EventArgs e)
        {
            UiFeedback.Run(this, LoadData);
        }

        private void LoadData()
        {
            dataGridView1.DataSource = service.GetCourses();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                service.AddCourse(new CourseRecord
                {
                    CourseName = "New Course", Credits = 3, DepartmentID = 1, InstructorID = 1
                });
                LoadData();
            });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                if (!UiFeedback.TryGetSelectedId(dataGridView1, "CourseID", out int courseID)) return;
                service.UpdateCourse(new CourseRecord
                {
                    CourseID = courseID, CourseName = "Updated Course", Credits = 4,
                    DepartmentID = 1, InstructorID = 2
                });
                LoadData();
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                if (!UiFeedback.TryGetSelectedId(dataGridView1, "CourseID", out int courseID)) return;
                service.DeleteCourse(courseID);
                LoadData();
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, LoadData);
        }
    }
}