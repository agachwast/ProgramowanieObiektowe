using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student : IComparable<Student>
    {
        public string firstName;
        public string lastName;
        private string albumnr;
        private List<Double> grades;
        public static long counter;
        public static decimal schAmount;
        public static double schTreshold;

        public string Albumnr { get => albumnr; }
        public List<double> Grades { get => grades; }

        static Student()
        {
            counter = 40000;
            schAmount = 700;
            schTreshold = 4.79;
        }

        public Student(string fn, string ln)
        {
            counter++;
            this.firstName = fn;
            this.lastName = ln;
            this.albumnr = $"{counter}/{DateTime.Now.Year.ToString("yy")}";
            this.grades = new List<double>();
        }

        public void AddGrades(double[] gradesTab)
        {
            if(gradesTab.Any(g => g < 2 || g > 5))
            {
                throw new ArgumentException("blad");
            }
            List<double> gradesList = gradesTab.ToList();
            gradesList.ForEach(g => this.grades.Add(g));

        }

        public double CalculateAve()
        {
            if(this.grades == null)
            {
                return 0;
            }
            return grades.Average();
        }

        public virtual decimal CalculateScholarship()
        {
            if(CalculateAve() > schTreshold)
            {
                return schAmount;
            }
            return 0;
        }

        public int CompareTo(Student other)
        {
            return other.CalculateAve().CompareTo(CalculateAve());
        }

        public override string ToString()
        {
            return $"{this.firstName} {this.lastName} - scholarship: {CalculateScholarship():C}";
        }
    }
}
