using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMydlo
{
    internal class SoapStore : ICloneable
    {
        public string name;
        public Stack<Soap> soaps;

        public string Name { get => name; set => name = value; }
        public Stack<Soap> Soaps { get => soaps; set => soaps = value; }

        public SoapStore(string name)
        {
            Soaps = new Stack<Soap>();
            Name = name;
        }

        public void AddSoap(Soap s)
        {
            Soaps.Push(s);
        }

        public int SoapsofWewight(float up, float down)
        {
            return Soaps.Count(s => (s.SoapWeight >= down && s.SoapWeight <= up));
        }

        public List<FragranceSoap> FindFragranceSoap()
        {
            return Soaps.OfType<FragranceSoap>().ToList(); 
        }

        public int CountFragranceSoaps()
        {
            List<FragranceSoap> temp = FindFragranceSoap();
            return temp.Count();
        }

        public int ColorSoap(string col)
        {
            if(!EnumSoapColor.TryParse(col, true, out EnumSoapColor parsedCol))
            {
                throw new ArgumentException("blad");
          
            }
            return Soaps.Count(c => c.SoapColor == parsedCol);
        }
        public object Clone()
        {
            SoapStore copy = new SoapStore(this.Name);
            Stack<Soap> temp = new Stack<Soap>(this.Soaps);
            temp.Reverse();
            foreach(var s in temp)
            {
                copy.AddSoap(s.Clone() as Soap);
            }
            return copy;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name);
            sb.AppendLine($"Fragrance Soaps: {CountFragranceSoaps()}");
            foreach(var s in Soaps)
            {
                sb.AppendLine(s.ToString());
            }
            return sb.ToString();   
        }
    }
}
