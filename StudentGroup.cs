using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    internal class StudentGroup
    {
        private List<Student> students;

        public List<Student> Students { get => students; }
        public StudentGroup()
        {
            students = new List<Student>();
        }

        public void AddStudents(Student s)
        {
            students.Add(s);
        }

        public void Sort()
        {
            students.Sort();
        }

    }
}
