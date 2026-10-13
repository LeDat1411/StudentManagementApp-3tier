using System;
using System.Windows.Forms;
using StudentManagementApp.BLL;
using StudentManagementApp.BLL.Models;

namespace StudentManagementApp
{
    public partial class StudentEnrollmentsForm : Form
    {
        private readonly StudentManagementService service = new StudentManagementService();

        public StudentEnrollmentsForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            Load += StudentEnrollmentsForm_Load;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
        }

        private void StudentEnrollmentsForm_Load(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                comboBox1.DataSource = service.GetCourses();
                comboBox1.DisplayMember = "CourseName";
                comboBox1.ValueMember = "CourseID";
                LoadData();
            });
        }

        private int? SelectedCourseID()
        {
            if (comboBox1.SelectedValue == null || comboBox1.SelectedValue is CourseRecord) return null;
            return Convert.ToInt32(comboBox1.SelectedValue);
        }

        private void LoadData()
        {
            dataGridView1.DataSource = service.GetEnrollments();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                var courseID = SelectedCourseID();
                if (!courseID.HasValue) return;
                // The original form enrolled the sample student with ID 1.
                service.AddEnrollment(1, courseID.Value);
                LoadData();
            });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                if (!UiFeedback.TryGetSelectedId(dataGridView1, "StudentID", out int studentID)) return;
                var targetCourseID = SelectedCourseID();
                if (!targetCourseID.HasValue) return;
                int oldCourseID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["CourseID"].Value);
                service.MoveEnrollment(studentID, oldCourseID, targetCourseID.Value);
                LoadData();
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                if (!UiFeedback.TryGetSelectedId(dataGridView1, "StudentID", out int studentID)) return;
                int courseID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["CourseID"].Value);
                service.DeleteEnrollment(studentID, courseID);
                LoadData();
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, LoadData);
        }
    }
}