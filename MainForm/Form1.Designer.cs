namespace StudentManagementApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coursesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCoursesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInstructorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDepartmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.studentsToolStripMenuItem,
            this.coursesToolStripMenuItem,
            this.instructorsToolStripMenuItem,
            this.departmentsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1208, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "file";
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewStudentsToolStripMenuItem});
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.studentsToolStripMenuItem.Text = "students";
            // 
            // coursesToolStripMenuItem
            // 
            this.coursesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCoursesToolStripMenuItem});
            this.coursesToolStripMenuItem.Name = "coursesToolStripMenuItem";
            this.coursesToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.coursesToolStripMenuItem.Text = "courses";
            // 
            // instructorsToolStripMenuItem
            // 
            this.instructorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewInstructorsToolStripMenuItem});
            this.instructorsToolStripMenuItem.Name = "instructorsToolStripMenuItem";
            this.instructorsToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.instructorsToolStripMenuItem.Text = "instructors";
            // 
            // departmentsToolStripMenuItem
            // 
            this.departmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDepartmentsToolStripMenuItem});
            this.departmentsToolStripMenuItem.Name = "departmentsToolStripMenuItem";
            this.departmentsToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.departmentsToolStripMenuItem.Text = "departments";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "exit";
            // 
            // viewStudentsToolStripMenuItem
            // 
            this.viewStudentsToolStripMenuItem.Name = "viewStudentsToolStripMenuItem";
            this.viewStudentsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.viewStudentsToolStripMenuItem.Text = "view students";
            // 
            // viewCoursesToolStripMenuItem
            // 
            this.viewCoursesToolStripMenuItem.Name = "viewCoursesToolStripMenuItem";
            this.viewCoursesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.viewCoursesToolStripMenuItem.Text = "view courses";
            // 
            // viewInstructorsToolStripMenuItem
            // 
            this.viewInstructorsToolStripMenuItem.Name = "viewInstructorsToolStripMenuItem";
            this.viewInstructorsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.viewInstructorsToolStripMenuItem.Text = "view instructors";
            // 
            // viewDepartmentsToolStripMenuItem
            // 
            this.viewDepartmentsToolStripMenuItem.Name = "viewDepartmentsToolStripMenuItem";
            this.viewDepartmentsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.viewDepartmentsToolStripMenuItem.Text = "view departments";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 649);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coursesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCoursesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInstructorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDepartmentsToolStripMenuItem;
    }
}

