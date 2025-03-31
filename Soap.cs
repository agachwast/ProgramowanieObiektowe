using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMydlo
{
    public enum EnumSoapColor
    {
        red, yellow, green, blue, black
    }
    public class Soap : ICloneable
    {
        private float _soapWeight;
        static decimal soapBasicPrice;
        public EnumSoapColor soapColor;

        public float SoapWeight
        {
            get => _soapWeight;
            set
            {
                if(value < 5 && value > 30)
                {
                    throw new ArgumentException("blad");
                }
                _soapWeight = value;
            }
        }
        public static decimal SoapBasicPrice { get => soapBasicPrice; set => soapBasicPrice = value; }
        public EnumSoapColor SoapColor { get => soapColor; set => soapColor = value; }

        static Soap()
        {
            SoapBasicPrice = 1.5M;
        }

        public Soap(string color, float weight)
        {
            if(!EnumSoapColor.TryParse(color, true, out EnumSoapColor parsedColor))
            {
                throw new ArgumentException("blad");
            }
            SoapColor = parsedColor;

            SoapWeight = weight;
        }

        public virtual decimal GetPrice()
        {
            return SoapBasicPrice * (decimal)SoapWeight;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Soap {SoapWeight}[g], {GetPrice():C}";
        }
    }
}
