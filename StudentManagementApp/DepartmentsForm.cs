using System;
using System.Windows.Forms;
using StudentManagementApp.BLL;
using StudentManagementApp.BLL.Models;

namespace StudentManagementApp
{
    public partial class DepartmentsForm : Form
    {
        private readonly StudentManagementService service = new StudentManagementService();

        public DepartmentsForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            Load += DepartmentsForm_Load;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
        }

        private void DepartmentsForm_Load(object sender, EventArgs e)
        {
            UiFeedback.Run(this, LoadData);
        }

        private void LoadData()
        {
            dataGridView1.DataSource = service.GetDepartments();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                service.AddDepartment(new DepartmentRecord { DepartmentName = "New Department" });
                LoadData();
            });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                if (!UiFeedback.TryGetSelectedId(dataGridView1, "DepartmentID", out int departmentID)) return;
                service.UpdateDepartment(new DepartmentRecord
                {
                    DepartmentID = departmentID, DepartmentName = "Updated Department"
                });
                LoadData();
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                if (!UiFeedback.TryGetSelectedId(dataGridView1, "DepartmentID", out int departmentID)) return;
                service.DeleteDepartment(departmentID);
                LoadData();
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, LoadData);
        }
    }
}