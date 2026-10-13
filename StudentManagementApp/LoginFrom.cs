using System;
using System.Windows.Forms;
using StudentManagementApp.BLL;

namespace StudentManagementApp
{
    public partial class LoginForm : Form
    {
        private readonly StudentManagementService service = new StudentManagementService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UiFeedback.Run(this, () =>
            {
                if (service.Authenticate(textBox1.Text, textBox2.Text))
                {
                    Hide();
                    var mainForm = new MainForm();
                    mainForm.FormClosed += (s, args) => Close();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show(this, "Login failed. Please check your username and password.",
                        "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
        }
    }
}