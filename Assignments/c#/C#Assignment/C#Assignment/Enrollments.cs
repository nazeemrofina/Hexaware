using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Assignment
{
    class Enrollments
    {
        public int EnrollmentID { get; set; }
        public Students StudentID { get; set; }
        public Courses CourseID { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public Enrollments(int enrollmentID, Students studentID, Courses courseID, DateTime enrollmentDate)
        {
            EnrollmentID = enrollmentID;
            StudentID = studentID;
            CourseID = courseID;
            EnrollmentDate = enrollmentDate;
            studentID.EnrolledCourses.Add(this);
        }

        public Students GetStudent()
        {
            return StudentID;
        }

        public Courses GetCourse()
        {
            return CourseID;
        }


    }
}
