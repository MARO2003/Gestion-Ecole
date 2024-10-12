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
    public partial class StudentView : Form
    {
        private StudentService studentService;
        public StudentView(StudentService service)
        {
            this.studentService = service;
            InitializeComponent();
            this.tableView.DataSource = this.studentService.GetStudentTable();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.studentService.SaveChanges();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.studentService.ReloadStudentTable();
        }

        private void tableView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
