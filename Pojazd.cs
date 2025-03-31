using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace egz2
{
    public class Pojazd
    {
        private string nrRejestracyjny;
        public float ciezar;
        public DateTime wyprodukowano;
        public static decimal oplataPodstawowa;

        public string NrRejestracyjny
        {
            get => nrRejestracyjny;
            set
            {
                if (!char.IsLetter(value[0]) || !char.IsLetter(value[1]) || value.Length != 7)
                {
                    throw new ArgumentException("bledny format rejestracji");
                }
                nrRejestracyjny = value;
            }
        }

        static Pojazd()
        {
            oplataPodstawowa = 79.99m;
        }

        public Pojazd(string nrRejestracyjny, float ciezar, DateTime wyprodukowano)
        {
            NrRejestracyjny = nrRejestracyjny;
            this.ciezar = ciezar;
            this.wyprodukowano = wyprodukowano;
        }

        public int WiekPojazdu()
        {
            DateTime dzis = DateTime.Now;
            int wiek = dzis.Year - wyprodukowano.Year;
            if(dzis.Month > wyprodukowano.Month || (dzis.Month == wyprodukowano.Month && dzis.Day > wyprodukowano.Day))
            {
                wiek--;
            }
            return wiek;
        }
        public virtual decimal OplataZaPojazd()
        {
            return WiekPojazdu() * oplataPodstawowa + 10 * (decimal)ciezar;
        }

        public override string ToString()
        {
            return $"{NrRejestracyjny}: {this.wyprodukowano.ToString("yy-MM-dd")} ({this.ciezar} kg), opłata: {OplataZaPojazd():C}";
        }
    }
}
