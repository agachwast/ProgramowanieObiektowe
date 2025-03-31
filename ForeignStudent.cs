using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{

    public enum EnumCountry
    {
        France,
        Germany,
        Japan,
        Turkey
    }
    public class ForeignStudent : Student
    {
        public EnumCountry country;
        public static decimal extraSchAmount;


        static ForeignStudent()
        {
            extraSchAmount = 100.99m;
        }
        
        public ForeignStudent(string fn, string ln, EnumCountry c) : base(fn, ln)
        {
            this.country = c;
        }

        public override decimal CalculateScholarship()
        {
            if(Grades.Count() >= 3)
            {
                return schAmount + extraSchAmount;
            }
            return 0;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - {this.country}";
        }

    }
}
