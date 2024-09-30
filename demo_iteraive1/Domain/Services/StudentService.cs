using Data_Access_Module.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_iteraive1.Domain.Services
{
    public class StudentService
    {
        private StudentDAO dao;


        public StudentService()
        {
            this.dao = new StudentDAO();
        }

        public List<Student> GetallStudents()
        {
            return this.dao.Getall();
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
        public Student DeleteStudent(Student student)
        {
            return this.dao.Delete(student);
        }



    }
}
