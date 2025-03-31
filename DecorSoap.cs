using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMydlo
{
    public enum EnumDecorElement
    {
        curl = 20,
        heart = 10,
        star = 5
    }

    internal class DecorSoap : Soap
    {
        List<EnumDecorElement> enumDecorElements;

        public List<EnumDecorElement> EnumDecorElements { get => enumDecorElements; set => enumDecorElements = value; }

        public DecorSoap(string color, float weight) : base(color, weight)
        {
            EnumDecorElements = new List<EnumDecorElement>();
        }

        public void Decorate(string[] elememnts)
        {
            foreach(string el in elememnts)
            {
                if(!EnumDecorElement.TryParse(el, true, out EnumDecorElement enumElement))
                {
                    throw new ArgumentException("blad");
                }
                EnumDecorElements.Add(enumElement);
            }
        }

        public override decimal GetPrice()
        {
            decimal price = 0;
            foreach(EnumDecorElement el in EnumDecorElements)
            {
                price += (decimal)el;
            }
            return price;
        }


        public override string ToString()
        {
            return $"DecorSoap, {SoapWeight}[g], {GetPrice():C}";
        }
    }
}
