using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPaczka;

namespace EPaczka
{
    internal class OdbiorcaComparer : IComparer<Przesylka>
    {
        public int Compare(Przesylka x, Przesylka y)
        {
            int cmp = x.MiastoOdbiorca.CompareTo(y.MiastoOdbiorca);
            return cmp;
        }
    }
}
