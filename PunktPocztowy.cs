using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPaczka;

namespace EPaczka
{
    public class PunktPocztowy
    {
        public string nazwaPunktu;
        public List<Przesylka> przesylki;
        private static decimal[,] macierz;

        public string NazwaPunktu { get => nazwaPunktu; }
        internal List<Przesylka> Przesylki { get => przesylki; set => przesylki = value; }
        public static decimal[,] Macierz { get => macierz; set => macierz = value; }

        static void WypelnijMacierz()
        {
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Macierz[i, j] = (decimal)(20.99 + rand.NextDouble() * (60.99 - 20.99));
                }

            }
        }

        static PunktPocztowy()
        {
            Macierz = new decimal[3, 3];
            WypelnijMacierz();
        }

        public PunktPocztowy()
        {
            nazwaPunktu = string.Empty;
            Przesylki = new List<Przesylka>();

        }

        public PunktPocztowy(string nazwa) : this()
        {
            nazwaPunktu = nazwa;
        }

        public void DodajPrzesylke(Przesylka p)
        {
            Przesylki.Add(p);
        }

        public List<PrzesylkaPolecona> ZnajdzPolecone()
        {
            return Przesylki.OfType<PrzesylkaPolecona>().ToList();
        }

        public decimal WartoscPrzesylek()
        {
            return Przesylki.Sum(p => p.ObliczKosztPrzesylki());
        }

        public decimal WartoscPrzesylekSpecjalnych()
        {
            return Przesylki.OfType<PrzesylkaPolecona>().Sum(p => p.ObliczKosztPrzesylki());
        }

        public void SortujPoNaawcy()
        {
            Przesylki = Przesylki.OrderBy(p => p.MiastoNadawca).ToList();
        }

        public void SortujPoOdbiorcy()
        {
            Przesylki.Sort(new OdbiorcaComparer());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"liczba przesylek: {Przesylki.Count()}");
            foreach (Przesylka p in Przesylki)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString();
        }
    }
}
