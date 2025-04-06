using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C_Assignment.ExceptionClass;

namespace C_Assignment
{
    class Teachers
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Expertise { get; set; }
        public static List<Teachers> AllTeachers = new List<Teachers>();
        public List<Courses> AssignedCourses { get; set; }

        public Teachers(int teacherID, string firstName, string lastName, string email, string expertise)
        {
            TeacherID = teacherID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Expertise = expertise;
            AssignedCourses = new List<Courses>();
            AllTeachers.Add(this);
        }
        public void UpdateTeacherInfo(string name, string email, string expertise)
        {
            try
            {
                
                FirstName = name.Split(' ')[0];
                LastName  = name.Split(' ')[1];
                Email = email;
                Expertise = expertise;
                ExceptionCode.InvalidTeacherDataException(FirstName,LastName,Email,Expertise);
            }
            catch(InvalidTeacherDataException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayTeacherInfo()
        {
            Console.WriteLine($"Teacher ID: {TeacherID}\nName: {FirstName} {LastName}\nEmail: {Email}\n\n");
        }

        public List<Courses> GetAssignedCourse()
        {
            return AssignedCourses;
        }

    }
}
