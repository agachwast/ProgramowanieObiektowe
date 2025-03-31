using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egz2
{
    internal class WypozyczalniaPojazdow
    {
        public string nazwa;
        public Dictionary<string, Pojazd> pojazdy;
        public static long licznikPojazdow;

        static WypozyczalniaPojazdow()
        {
            licznikPojazdow = 500;
        }

        public WypozyczalniaPojazdow()
        {
            nazwa = string.Empty;
            pojazdy = new Dictionary<string, Pojazd>();
        }

        public WypozyczalniaPojazdow(string nazwa) : this()
        {
            this.nazwa = nazwa;
        }

        public void DodajPojazd(Pojazd p)
        {
            licznikPojazdow++;
            string key = $"{DateTime.Now.ToString("yy/MM/dd")}/{licznikPojazdow}";
            pojazdy.Add(key, p);
        }

        public List<PojazdSpecjalny> ZnajdzSpecjalne(string r)
        {
            return pojazdy.Values.OfType<PojazdSpecjalny>().Where(p => p.rodzaj.Equals(r)).ToList();
        }

        public Pojazd NajmniejszaOplata()
        {
            return pojazdy.Values.OrderBy(p => p.OplataZaPojazd()).First();
        }

        public List<PojazdSpecjalny> ZnajdzPoRodzaju(EnumRodzaj r)
        {
            return pojazdy.Values.OfType<PojazdSpecjalny>().Where(p => p.rodzaj.Equals(r)).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Wypozyczalnia pojazdow {this.nazwa}");
            sb.AppendLine($"Liczba dostepnych pojazdow: {this.pojazdy.Count()}");
            return sb.ToString();   
        }

        public List<Pojazd> SortujPoOplacie()
        {
            return pojazdy.Values.OrderBy(p => p.OplataZaPojazd()).ToList();
        }

    }
}
