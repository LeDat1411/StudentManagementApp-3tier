using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            viewStudentsToolStripMenuItem.Click += viewStudentsToolStripMenuItem_Click;
            viewCoursesToolStripMenuItem.Click += viewCoursesToolStripMenuItem_Click;
            viewInstructorsToolStripMenuItem.Click += viewInstructorsToolStripMenuItem_Click;
            viewDepartmentsToolStripMenuItem.Click += viewDepartmentsToolStripMenuItem_Click;
            viewEnrollmentsToolStripMenuItem.Click += viewEnrollmentsToolStripMenuItem_Click;
        }
        private void viewStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsForm studentsForm = new StudentsForm();
            studentsForm.Show();
        }

        private void viewCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoursesForm coursesForm = new CoursesForm();
            coursesForm.Show();
        }

        private void viewInstructorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstructorsForm instructorsForm = new InstructorsForm();
            instructorsForm.Show();
        }

        private void viewDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DepartmentsForm departmentsForm = new DepartmentsForm();
            departmentsForm.Show();
        }
        private void viewEnrollmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new StudentEnrollmentsForm().Show();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
