using School.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new course
            Console.WriteLine("Enter course ID:");
            int courseId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter course name:");
            string courseName = Console.ReadLine();
            Course course = new Course(courseId, courseName);

            // Enroll students
            Console.WriteLine("Enter the number of students to enroll:");
            int studentCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine($"Enter details for student {i + 1}:");
                Console.Write("ID: ");
                
                int studentId = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string studentName = Console.ReadLine();

                Student student = new Student(studentId, studentName);
                course.EnrollStudent(student);
            }

            // Assign teacher
            Console.WriteLine("Enter teacher details:");
            Console.Write("ID: ");
            int teacherId = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string teacherName = Console.ReadLine();

            Teacher teacher = new Teacher(teacherId, teacherName);
            course.AssignTeacher(teacher);

            // Generate reports for each student
            Console.WriteLine("\nGenerating reports for all students:");
            foreach (var student in course.Students)
            {
                student.GenerateReport();
            }

            // Display course details
            Console.WriteLine($"\nCourse Details:");
            Console.WriteLine($"Course ID: {course.Id}");
            Console.WriteLine($"Course Name: {course.Name}");
            Console.WriteLine($"Assigned Teacher: {course.AssignedTeacher.Name}");
            Console.WriteLine("Enrolled Students:");
            foreach (var student in course.Students)
            {
                Console.WriteLine($"- {student.Name} (ID: {student.Id})");
            }
            Console.Read();
        }
    }
}
