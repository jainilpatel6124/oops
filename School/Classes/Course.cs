using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Classes
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
        public Teacher AssignedTeacher { get; set; }

        public Course(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void EnrollStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine($"{student.Name} has been enrolled in {Name}");
        }

        public void AssignTeacher(Teacher teacher)
        {
            AssignedTeacher = teacher;
            Console.WriteLine($"{teacher.Name} has been assigned to {Name}");
        }
    }
}
