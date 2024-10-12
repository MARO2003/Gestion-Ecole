using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_iteraive1.Domain
{
    public class Course
    {
        private static int MaxCourseNameLength = 128;
        private static int MaxCourseCodeLength = 12;

        private int id;
        private string courseName;
        private string courseCode;

        public int Id
        {
            get { return this.id; }
            set
            {
                if(value < 0)
                {
                    throw new Exception($"Course.Id must be a positive integer: negative value assigned.");
                }
                this.id = value;
            }
        }
        public string CourseName
        {
            get { return this.courseName; }
            set
            {
                if(value.Length > MaxCourseNameLength)
                {
                     throw new Exception($"Maximum length of Course.CourseName is {MaxCourseNameLength} character");
                }
                this.courseName = value;
            }
        }
        public string CourseCode
        {
            get { return this.courseCode; }
            set
            {
                if(value.Length > MaxCourseCodeLength)
                {
                    throw new Exception($"Maximum length of Course.CourseCode is {MaxCourseCodeLength} character");
                }
                this.courseCode = value;
            }
        }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Course(string courseName, string courseCode)
        {
            CourseName = courseName;
            CourseCode = courseCode;
        }
        public Course(int id, string courseName, string courseCode, DateTime dateCreated, DateTime dateModified, DateTime dateDeleted)
        {
            Id = id;
            CourseName = courseName;
            CourseCode = courseCode;
            DateCreated = dateCreated;
            DateModified = dateModified;
            DateDeleted = dateDeleted;
        }
    }
}
