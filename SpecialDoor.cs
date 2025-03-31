using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDoor
{

    public enum EnumExtraFeature
    {
        mute = 90,
        alarm = 100,
        peephole = 50
    }
    internal class SpecialDoor : Door
    {
        private EnumExtraFeature extraFeature;

        public EnumExtraFeature ExtraFeature { get => extraFeature; set => extraFeature = value; }

        public SpecialDoor(string producer, decimal price, EnumExtraFeature extra) : base(producer, price)
        {
            ExtraFeature = extra;
        }

        public override decimal CalculatePrice()
        {
            return DoorPrice + (decimal)ExtraFeature;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, [{ExtraFeature}]";
        }
    }
}
