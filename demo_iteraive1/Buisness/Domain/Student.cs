using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_iteraive1.Buisness.Domain
{
    public  class Student
    {
        public const int MaxFirstnameLength = 64;
        public const int MaxLastnameLength = 64;
        public const int MaxCodeLength = 12;

        private int id;
        private string firstName;
        private string lastName;
        private string code;

        
        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                {
                    throw new Exception($"Student Id must be positive .");
                }
                id = value;
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length > MaxFirstnameLength)
                {
                    throw new Exception($"Max length of student name is {MaxFirstnameLength}.");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length > MaxLastnameLength)
                {
                    throw new Exception($"Max length of student last name is {MaxLastnameLength}.");
                }
                lastName = value;
            }
        }
        public string Code
        {
            get { return code; }
            set
            {
                if (value.Length > MaxCodeLength)
                {
                    throw new Exception($"Max length of student  code is {MaxCodeLength}.");
                }
                code = value;
            }
        }
        public DateTime DateRegistration { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Student() { }
        public Student(string firstname, string lastname, string code, DateTime dateRegistration)
        {
            FirstName = firstname;
            LastName = lastname;
            Code = code;
            DateRegistration = dateRegistration;
        }
        public Student(int id, string firstname, string lastname, string code, DateTime dateRegistration
            , DateTime dateCreated, DateTime dateModified, DateTime dateDeleted) : this(firstname, lastname, code, dateRegistration)
        {
            Id = id;
            DateCreated = dateCreated;
            DateModified = dateModified;
            DateDeleted = dateDeleted;
        }

    }
}
