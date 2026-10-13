using System;
using System.Windows.Forms;
using StudentManagementApp.BLL;
using StudentManagementApp.BLL.Models;

namespace StudentManagementApp
{
    public partial class StudentsForm : Form
    {
        private readonly StudentManagementService service = new StudentManagementService();

        public StudentsForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            UiFeedback.Run(this, LoadData);
        }

        private void LoadData()
        {
            dataGridView1.DataSource = service.GetStudents();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                service.AddStudent(new StudentRecord
                {
                    StudentName = "New Student",
                    DateOfBirth = DateTime.Now.Date,
                    City = "City",
                    Age = 20,
                    YearOfEnroll = DateTime.Now.Year,
                    Major = "Major",
                    GPA = 4.0m
                });
                LoadData();
            });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                if (!UiFeedback.TryGetSelectedId(dataGridView1, "StudentID", out int studentID)) return;
                service.UpdateStudent(new StudentRecord
                {
                    StudentID = studentID,
                    StudentName = "Updated Student",
                    DateOfBirth = DateTime.Now.Date,
                    City = "Updated City",
                    Age = 21,
                    YearOfEnroll = DateTime.Now.Year,
                    Major = "Updated Major",
                    GPA = 3.9m
                });
                LoadData();
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                if (!UiFeedback.TryGetSelectedId(dataGridView1, "StudentID", out int studentID)) return;
                service.DeleteStudent(studentID);
                LoadData();
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, LoadData);
        }
    }
}