using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDoor
{
    public enum EnumColor
    {
        black, white, brown
    }
    internal class ArtDecoDoor : Door
    {
        List<EnumColor> colors;
        private static decimal colorPrice;

        public List<EnumColor> Colors { get => colors; set => colors = value; }
        public static decimal ColorPrice { get => colorPrice; set => colorPrice = value; }

        static ArtDecoDoor()
        {
            ColorPrice = 189.99M;
        }

        public ArtDecoDoor(string producer, decimal price) : base(producer, price)
        {
            Colors = new List<EnumColor>();
        }

        public void AssignColor(EnumColor color)
        {
            if(Colors.Count < 3)
            {
                Colors.Add(color);
            }
        }

        public override decimal CalculatePrice()
        {
            decimal colorsPrice = 0;
            foreach(EnumColor color in Colors)
            {
                colorsPrice += ColorPrice;
            }
            return colorsPrice + DoorPrice;
        }

        public override string ToString()
        {
            Colors.Sort();
            StringBuilder sb = new();
            for(int i = 0; i < Colors.Count(); i++)
            {
                sb.Append(Colors[i].ToString());
                if(i < Colors.Count - 1)
                {
                    sb.Append(',');
                }
            }
           
            return $"{base.ToString()}, colors: {sb.ToString()}";
        }

    }
}
