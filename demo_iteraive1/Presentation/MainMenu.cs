using demo_iteraive1.Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_iteraive1.Presentation
{
    public partial class MainMenu : Form
    {
        private App application;

        public MainMenu(App application)
        {
            this.application = application;
            InitializeComponent();
        }

        private void btnGererEtudiant_Click(object sender, EventArgs e)
        {
            this.application.studentService.OpenStudentWindow();
        }

        private void btnGererCour_Click(object sender, EventArgs e)
        {
            this.application.courseService.OpenCourseWindow();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
