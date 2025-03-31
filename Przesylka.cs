using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace EPaczka
{
    public enum EnumMiasto
    {
        Krakow,
        Warszawa,
        Poznan
    }
    public class Przesylka
    {
        public string idPrzesylki;
        public EnumMiasto miastoNadawca;
        public EnumMiasto miastoOdbiorca;
        public float waga;
        public static long number;


        public string IdPrzesylki { get; private set; }
        public EnumMiasto MiastoNadawca { get => miastoNadawca; }
        public EnumMiasto MiastoOdbiorca { get => miastoOdbiorca; }
        public float Waga { get => waga; set => waga = value; }


        static Przesylka()
        {
            number = 100;
        }
        public Przesylka(EnumMiasto nadawca, EnumMiasto odbiorca, float waga)
        {
            miastoNadawca = nadawca;
            miastoOdbiorca = odbiorca;
            Waga = waga;
            number++;
            IdPrzesylki = number.ToString("D6");
        }

        public virtual decimal ObliczKosztPrzesylki()
        {
          
            return 10 * (decimal)Waga;
        }

        public override string ToString()
        {
            return $"{GetType().Name} {IdPrzesylki} z {MiastoNadawca} do {MiastoOdbiorca}, koszt: {ObliczKosztPrzesylki():C}";
        }
    }
}
