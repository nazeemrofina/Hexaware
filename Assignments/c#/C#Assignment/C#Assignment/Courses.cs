using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C_Assignment.ExceptionClass;

namespace C_Assignment
{
    class Courses
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string InstructorName { get; set; }
        public List<Enrollments> EnrolledCourses { get; set; }
     //   public List<Courses> AssignedCourses { get; set; }

        public static List<Courses> AllCourses = new List<Courses>();
       // public List<Courses> AllCourses { get; set; }
        public Courses() { }
        public Courses(int courseID, string courseName, string courseCode, string instructorName)
        {
            CourseID = courseID;
            CourseName = courseName;
            CourseCode = courseCode;
            InstructorName = instructorName;
            EnrolledCourses = new List<Enrollments>();
            AllCourses.Add(this);
        }

        public void AssignTeacher(Teachers teacher)
        {
            try
            {
                ExceptionCode.TeacherNotFoundException(teacher);
                ExceptionCode.CheckCourseNotFoundException(this);
                InstructorName = teacher.FirstName + " " + teacher.LastName;
                teacher.AssignedCourses.Add(this);
            }
            catch(TeacherNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateCourseInfo(string courseCode, string courseName, string instructor)
        {
            ExceptionCode.InvalidCourseDataException(courseCode, courseName);
            CourseName = courseName;
            CourseCode = courseCode;
            InstructorName = instructor;
        }

        public void DisplayCourseInfo()
        {
            Console.WriteLine($"Course ID: {CourseID}\nName: {CourseName}\nCode: {CourseCode}\nInstructor: {InstructorName}\n\n");
        }

        public List<Enrollments> GetEnrollments(Courses course)
        {
            List<Enrollments> enrolled = new List<Enrollments>();
            foreach(var enrollment in EnrolledCourses)
            {
                if (enrollment.CourseID == course)
                {
                    enrolled.Add(enrollment);
                }
            }
            return enrolled;
        }

        public string GetTeacher()
        {
            return InstructorName;
        }
    }
}

 