using System;

namespace C_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SIS sis = new SIS();
             ExceptionCode enrollment1=new ExceptionCode();
             enrollment1.Exception();

           

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Student Information System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Enroll Student in Course");
                Console.WriteLine("4. Add Teacher");
                Console.WriteLine("5. Display All Teachers");
                Console.WriteLine("6. Add Course");
                Console.WriteLine("7. Display All Courses");
                Console.WriteLine("8. Assign Teacher to Course");
                Console.WriteLine("9. Make Student Payment");
                Console.WriteLine("10 Get Enrollments of a specific student");
                Console.WriteLine("11 Get Assigned Courses for a specific teacher");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        sis.AddStudent();
                        break;
                    case "2":
                        sis.DisplayAllStudents();
                        break;
                    case "3":
                        sis.EnrollStudentInCourse();
                        break;
                    case "4":
                        sis.AddTeacher();
                        break;
                    case "5":
                        sis.DisplayAllTeachers();
                        break;
                    case "6":
                        sis.AddCourse();
                        break;
                    case "7":
                        sis.DisplayAllCourses();
                        break;
                    case "8":
                        sis.AssignTeacherToCourse();
                        break;
                    case "9":
                        sis.MakeStudentPayment();
                        break;
                    case "10":
                        sis.GetEnrollmentsForStudent();
                        break;
                    case "11":
                        sis.GetCoursesForTeacher();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Exiting the system");
                        break;
                    
                    default:
                        Console.WriteLine("Invalid option. Please try again");
                        break;
                }
            }

        }

    }
}

