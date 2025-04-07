using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C_Assignment.ExceptionClass;

namespace C_Assignment
{
    class ExceptionCode
    {
      

            Students student1 = new Students(1, "Steve", "Hops", new DateTime(2003, 11, 08), "steve@mail.com", "98658685523");
            Students student2 = new Students(2, "lady", "gaga", new DateTime(2003, 10, 11), "lady@mail.com", "7536984125");
            Students student3 = new Students(3, "Adam", "kate", new DateTime(2003, 04, 19), "adam@mail.com", "7412589632");
            Students student4 = new Students(4, "Gigi", "Hadid", new DateTime(2003, 06, 1), "gigi@mail.com", "4785123698");
            Students student = new Students(5, "student", "student", new DateTime(2003, 6, 12), "student@mail.com", "4758963210");

            Courses physics = new Courses(101, "physics", "phy101", "shree sakthi");
            Courses maths = new Courses(201, "Maths", "mat201", "Sabeena Sharbudeen");
            Courses science = new Courses(301, "Science", "sci301", "Karen stick");
            Courses course = new Courses(401, "course", "cou90", "teacher teach");

            Teachers teacher1 = new Teachers(1, "Sabeena", "Sharbudeen", "sabee@mail.com", "Maths");
            Teachers teacher2 = new Teachers(2, "Karen", "stick", "karen@mail.com", "Science");
            Teachers teacher3 = new Teachers(3, "shree", "sakthi", "shri@mail.com", "physics");
            Teachers teacher = new Teachers(4, "teacher", "teach", "teacher@mail.com", "course");
        
        public void Exception()
        {

            Enrollments enrollment1 = new Enrollments(1, student1, maths, DateTime.Now);
            Enrollments enrollment2 = new Enrollments(2, student2, science, DateTime.Now);
          //  Console.WriteLine("Enrolled");
            ////try
            ////{
            ////    student1.EnrollInCourse(maths);
            ////    student1.EnrollInCourse(maths);
            ////}
            ////catch (DuplicateEnrollmentException e)
            ////{
            ////    Console.WriteLine(e.Message);
            ////}

            ////try
            ////{
            ////    Courses.AllCourses.Remove(course);
            ////    student1.EnrollInCourse(course);
            ////    course.AssignTeacher(teacher1);

            ////}
            ////catch (CourseNotFoundException e)
            ////{
            ////    Console.WriteLine(e.Message);
            ////}
            ////try
            ////{
            ////    Students.AllStudents.Remove(student);
            ////    student.EnrollInCourse(physics);

            ////}
            ////catch (StudentNotFoundException e)
            ////{
            ////    Console.WriteLine(e.Message);
            ////}
            ////try
            ////{
            ////    Teachers.AllTeachers.Remove(teacher);
            ////    maths.AssignTeacher(teacher);
            ////}
            ////catch (TeacherNotFoundException e)
            ////{
            ////    Console.WriteLine(e.Message);
            ////}
            ////try
            ////{
            ////    student3.MakePayment(0, DateTime.Now);
            ////}
            ////catch (PaymentValidationException e)
            ////{
            ////    Console.WriteLine(e.Message);
            ////}
            ////try
            ////{
            ////    student1.UpdateStudentInfo("Sabeena", "Sharbudeen", DateTime.Now, "", "5469382155");
            ////}
            ////catch (InvalidStudentDataException e)
            ////{
            ////    Console.WriteLine(e.Message);
            ////}
            ////try
            ////{
            ////    maths.UpdateCourseInfo("math 101", "", "Ariel benya");

            ////}
            ////catch (InvalidCourseDataException e)
            ////{
            ////    Console.WriteLine(e.Message);
            ////}
            ////try
            ////{
            ////    Students.AllStudents.Remove(student);
            ////    student.EnrollInCourse(science);

            ////}
            ////catch (InvalidEnrollmentDataException e)
            ////{
            ////    Console.WriteLine(e.Message);
            ////}
            ////try
            ////{
            ////    teacher.UpdateTeacherInfo("ariel benya", "", "math");
            ////}
            ////catch (InvalidTeacherDataException e)
            ////{
            ////    Console.WriteLine(e.Message);
            ////}
            ////try
            ////{
            ////    student1.MakePayment(1000, DateTime.Now);
            ////}
            ////catch (InsufficientFundsException e)
            ////{
            ////    Console.WriteLine(e.Message);
            ////}
        }
            public static void checkEnrollments(Students student,Courses course)
        {
            if (Students.AllStudents.Contains(student) == false)
            {
                throw (new InvalidEnrollmentDataException("Student is referenced to Null"));
            }
            else if (Courses.AllCourses.Contains(course) == false)
            {
                throw (new InvalidEnrollmentDataException("Course is referenced to Null"));
            }
        }
        public static void checkDuplicateEnrollmentException(Students student,Courses course)
        {
            foreach (Enrollments enroll in student.EnrolledCourses)
            {
                if (enroll.CourseID == course)
                {
                    throw (new DuplicateEnrollmentException($"This Student {student.FirstName} is already enrolled in {course.CourseName}"));
                }
            }
        }
        public static void CheckStudentNotFoundException(Students student)
        {
            if (Students.AllStudents.Contains(student) == false)
            {
                throw (new StudentNotFoundException($"Student {student.FirstName + " " + student.LastName}is Not Available to enroll"));
            }
        }
        public static void CheckCourseNotFoundException(Courses course)
        {

            if (Courses.AllCourses.Contains(course) == false)
            {
                throw (new CourseNotFoundException($"Course {course.CourseName} is not Available to enroll"));
            }
        }
        public static void InvalidStudentDataException(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            if(firstName == "")
            {
                throw (new InvalidStudentDataException($"{firstName} is null"));
            }
            else if (lastName == "")
            {
                throw (new InvalidStudentDataException($"{lastName} is null"));
            }
            else if (!(email.Contains('@')))
            {
                throw (new InvalidStudentDataException($"{email} is invalid"));
            }
            else if (phoneNumber.Length != 10)
            {
                throw (new InvalidStudentDataException($"{phoneNumber } is Invalid"));
            }


        }
        public static void PaymentValidationException(decimal amount,DateTime dateTime)
        {
            if (amount <= 0 )
            {
                throw (new PaymentValidationException("Amount provided is incorrect"));
            }
            else if(dateTime > DateTime.Now)
            {
                throw (new PaymentValidationException("Payment Error"));
            }
        }
        public static void InsufficientFundsException(decimal amount)
        {
            if (amount < 10000)
            {
                throw (new InsufficientFundsException("Amount is Insufficient for payment "));
            }

        }
        public static void InvalidTeacherDataException(String FirstName,string LastName,string email,string expertise)
        {
            try
            {
                if (FirstName == "")
                {
                    throw (new InvalidStudentDataException($"FirstName is null"));
                }
                else if (LastName == "")
                {
                    throw (new InvalidStudentDataException($"LastName is null"));
                }
                else if (!(email.Contains('@')))
                {
                    throw (new InvalidStudentDataException($"Email {email} is invalid"));
                }
                else if (expertise == "")
                {
                    throw (new InvalidStudentDataException($"Expertise is null"));
                }
            }
            catch(InvalidStudentDataException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void TeacherNotFoundException(Teachers teacher)
        {
            if (Teachers.AllTeachers.Contains(teacher) == false)
            {
                throw (new TeacherNotFoundException($"{teacher.FirstName+" "+teacher.LastName} is Invalid"));
            }
        }
        public static void InvalidCourseDataException(string courseCode,string courseName)
        {
            if (courseCode == "" || courseName == "")
            {
                throw (new InvalidCourseDataException("Invalid Course Data to update"));
            }
        }
    }

    }

    
