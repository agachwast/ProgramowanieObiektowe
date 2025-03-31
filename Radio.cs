using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERadio
{
    public enum EnumRadioBrand
    {
        sony,
        jbl
    }
    public abstract class Radio : ICloneable
    {
        private EnumRadioBrand brand;
        protected static decimal radioPrice;

        public EnumRadioBrand Brand { get => brand; set => brand = value; }


        static Radio()
        {
            radioPrice = 18.99m;
        }

        public Radio(EnumRadioBrand brand)
        {
            Brand = brand;

        }

        public abstract decimal GetRadioPrice();

        public object Clone()
        {
            return MemberwiseClone();

        }

        public override string ToString()
        {
            return $"Radio {Brand}, {GetRadioPrice():C}";
        }
    }
}
