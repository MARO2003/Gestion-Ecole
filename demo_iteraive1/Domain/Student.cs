using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_iteraive1.Domain
{
    public class Student
    {
        public const int MaxFirstnameLength = 64;
        private string firstName;

        public int Id { get; set; }
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value.Length > MaxFirstnameLength)
                {
                    throw new Exception($"Max length of student name is {MaxFirstnameLength}.");
                }
                this.firstName = value;
            } 
        }
        public string LastName { get; set; }
        public string Code { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Student() { }
        public Student(string firstname, string lastname, string code , DateTime dateRegistration)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Code = code;
            this.DateRegistration = dateRegistration;
        }
        public Student(int id ,string firstname, string lastname, string code, DateTime dateRegistration 
            , DateTime dateCreated , DateTime dateModified, DateTime dateDeleted):this(firstname,lastname,code,dateRegistration)
        {
            this.Id = id;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
            this.DateDeleted = dateDeleted;
        }

    }
}
