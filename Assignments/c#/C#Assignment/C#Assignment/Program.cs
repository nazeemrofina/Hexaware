using C_Assignment.Database;
using C_Assignment.Database_Methods;
using System;

namespace C_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
          //  utility util = new utility();
          //  util.checkConnection();


            //Methods.GetAllCourses();
            //Console.WriteLine();
            //Methods.GetAllEnrollments();
            //Console.WriteLine();
            //Methods.GetAllTeachers();
            //Console.WriteLine();
            //Methods.GetAllPayments();
            //StudentsMethod.InsertIntoStudents();
            //Console.WriteLine();
            //CoursesMethod.InsertIntoCourses();
            //Methods.GetAllStudents();
            // TeacherMethod.InsertIntoTeachers();
            // StudentsMethod.UpdateDataIntoStudents();
            // PaymentMethod.InsertIntoPayments();
            // EnrollmentMethods.InsertIntoEnrollments();





            //SISDataBase sis = new SISDataBase();


            //bool exist = false;
            //while (!exist)
            //{
            //    Console.WriteLine("Enter The TASK TO BE COMPLETED ");
            //    Console.WriteLine("1. InsertAndEnrollStudent ");
            //    Console.WriteLine("2. TeacherAssignment");
            //    Console.WriteLine("3. PaymetRecording");
            //    Console.WriteLine("4. EnrollmentReportForSpecificCourse");
            //    Console.WriteLine("0. To exit");

            //    int number = Convert.ToInt32(Console.ReadLine());
            //    switch (number)
            //    {
            //        case 0:
            //            exist = true;
            //            Console.WriteLine("Exited the Function");
            //            break;
            //        case 1:
            //            sis.InsertAndEnrollStudent();
            //            break;
            //        case 2:
            //            sis.TeacherAssignment();
            //            break;
            //        case 3:
            //            sis.PaymetRecording();
            //            break;
            //        case 4:
            //            sis.EnrollmentReportForSpecificCourse();
            //            break;

            //        default:
            //            Console.WriteLine("Invalid Enter from 1 to 5");
            //            break;
            //    }
            //}




















            SIS sis = new SIS();
            ExceptionCode enrollment1 = new ExceptionCode();
         //   enrollment1.Exception();


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
