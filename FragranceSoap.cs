using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMydlo
{

    public enum EnumFragrance
    {
        lavender = 2,
        wood = 4
    }
    public class FragranceSoap : Soap
    {
        private EnumFragrance fragrance;

        public EnumFragrance Fragrance { get => fragrance; set => fragrance = value; }

        public FragranceSoap(string color, float weight, string fragrance) : base(color, weight)
        {
            if(!EnumFragrance.TryParse(fragrance, true, out EnumFragrance parsedFrag))
            {
                throw new ArgumentException("blad");
            }
            Fragrance = parsedFrag;
        }

        public override decimal GetPrice()
        {
            return base.GetPrice() + (decimal)Fragrance;
        }

        public override string ToString()
        {
            return $"Fragrance {SoapWeight}[g], {GetPrice():C}";
        }
    }
}
