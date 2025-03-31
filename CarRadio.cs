using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERadio
{
    public enum EnumQuality
    {
        good = 10,
        verygood = 15,
        excellent = 20
    }
    internal class CarRadio : Radio
    {
        private EnumQuality quality;
        private bool hasUSB;

        public EnumQuality Quality { get => quality; set => quality = value; }
        public bool HasUSB { get => hasUSB; set => hasUSB = value; }

        public CarRadio(EnumRadioBrand brand, EnumQuality quality, bool hasUSB) : base(brand)
        {
           Quality = quality;
           HasUSB = hasUSB;
        }

        public override decimal GetRadioPrice()
        {
            if(HasUSB)
            {
                return radioPrice * 1.9m;
            }
            return radioPrice;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {Quality}";
        }
    }
}
