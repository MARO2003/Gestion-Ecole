using demo_iteraive1.Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_iteraive1.Presentation.Views
{
    public partial class CourseView : Form
    {
        private CourseService courseService;
        public CourseView(CourseService service)
        {
            this.courseService = service;
            InitializeComponent();
            this.tableView.DataSource = this.courseService.GetCourseTable();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.courseService.SaveChanges();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.courseService.ReloadCourseTable();
        }
    }
}
