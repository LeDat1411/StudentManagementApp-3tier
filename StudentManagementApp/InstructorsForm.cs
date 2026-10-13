using System;
using System.Windows.Forms;
using StudentManagementApp.BLL;
using StudentManagementApp.BLL.Models;

namespace StudentManagementApp
{
    public partial class InstructorsForm : Form
    {
        private readonly StudentManagementService service = new StudentManagementService();

        public InstructorsForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            Load += InstructorsForm_Load;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
        }

        private void InstructorsForm_Load(object sender, EventArgs e)
        {
            UiFeedback.Run(this, LoadData);
        }

        private void LoadData()
        {
            dataGridView1.DataSource = service.GetInstructors();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                service.AddInstructor(new InstructorRecord
                {
                    InstructorName = "New Instructor", DepartmentID = 1
                });
                LoadData();
            });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                if (!UiFeedback.TryGetSelectedId(dataGridView1, "InstructorID", out int instructorID)) return;
                service.UpdateInstructor(new InstructorRecord
                {
                    InstructorID = instructorID, InstructorName = "Updated Instructor", DepartmentID = 1
                });
                LoadData();
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                if (!UiFeedback.TryGetSelectedId(dataGridView1, "InstructorID", out int instructorID)) return;
                service.DeleteInstructor(instructorID);
                LoadData();
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, LoadData);
        }
    }
}