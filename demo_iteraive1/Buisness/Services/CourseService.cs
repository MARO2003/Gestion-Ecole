using Data_Access_Module.Daos;
using demo_iteraive1.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_iteraive1.Domain.Services
{
    public class CourseService
    {
        private CourseDAO dao;
        public CourseView fenetre;

        //mode connecte
        public CourseService()
        {
            this.dao = new CourseDAO();
            this.fenetre = new CourseView(this);
        }
        public void OpenCourseWindow()
        {
            this.fenetre.ShowDialog();
        }
        public DataTable GetCourseTable()
        {
            return this.dao.GetDataTable();
        }
        public void SaveChanges()
        {
            this.dao.SaveChanges();
        }
        public void ReloadCourseTable()
        {
            this.dao.ReloadDataTable();
        }

        //mode connecte
        /*
        public List<Course> GetallCourses()
        {
            return this.dao.GetAll();
        }
        public Course CreateCourse(string firstName , string lastName )
        {
            Course course = new Course(firstName, lastName);
            return this.dao.Create(course);
        }
        public Course GetSCourseById(int id)
        {
            return this.dao.GetById(id);
        }
        public Course UpdateCourse(Course course)
        {
            return this.dao.Update(course);
        }
        public void DeleteCourse(Course course)
        {
             this.dao.Delete(course);
        }

        */

    }
}
