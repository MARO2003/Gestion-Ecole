using Data_Access_Module.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo_iteraive1.Buisness.Domain;
using System.Data;
using demo_iteraive1.Presentation.Views;

namespace demo_iteraive1.Domain.Services
{
    public class StudentService
    {
        private StudentDAO dao;
        public StudentView fenetre;

        //mode connecte
        public StudentService()
        {
            this.dao = new StudentDAO();
            this.fenetre = new StudentView(this);
        } 
        public void OpenStudentWindow()
        {
             this.fenetre.ShowDialog();
        }
        public DataTable GetStudentTable()
        {
           return  this.dao.GetDataTable();
        }
        public void SaveChanges()
        {
             this.dao.SaveChanges();
        }
        public void ReloadStudentTable()
        {
            this.dao.ReloadDataTable(); 
        }

        //mode connecte
        /*
        public List<Student> GetallStudents()
        {
            return this.dao.GetAll();
        }
        public Student CreateStudent(string firstName , string lastName , string code , DateTime registrationDate)
        {
            Student student = new Student(firstName, lastName, code, registrationDate);
            return this.dao.Create(student);
        }
        public Student GetStudentById(int id)
        {
            return this.dao.GetById(id);
        }
        public Student UpdateStudent(Student student)
        {
            return this.dao.Update(student);
        }
        public void DeleteStudent(Student student)
        {
             this.dao.Delete(student);
        }

        */

    }
}
