using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egz2
{
    public enum EnumRodzaj
    {
        pancerny = 220,
        wysoki = 110,
        niski = 50
    }
    internal class PojazdSpecjalny : Pojazd
    {
        public EnumRodzaj rodzaj;
        public ushort lZabezp;
        public static decimal oplataSpecjalna;


        static PojazdSpecjalny()
        {
            oplataSpecjalna = 6.85m;
        }

        public PojazdSpecjalny(string nrRejestracyjny, float ciezar, DateTime wyprodukowano, EnumRodzaj rodzaj, ushort lzabezp) : base(nrRejestracyjny, ciezar, wyprodukowano)
        {
            this.rodzaj = rodzaj;
            this.lZabezp = lzabezp;
        }

        public override decimal OplataZaPojazd()
        {
            return base.OplataZaPojazd() + 20 * (decimal)lZabezp + (decimal)rodzaj;
        }

        public override string ToString()
        {
            return $"{base.ToString()} //{this.rodzaj} [liczba zabezpieczen: {this.lZabezp}]";
        }

    }
}
