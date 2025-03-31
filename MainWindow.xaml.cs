using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EPaczka
{
    
    
    public partial class MainWindow : Window
    {

        PunktPocztowy punkt = new PunktPocztowy("Punkt");
        public MainWindow()
        {
            InitializeComponent();
            this.Title = $"{punkt.NazwaPunktu}";

            Przesylka p = new Przesylka(EnumMiasto.Krakow, EnumMiasto.Warszawa, 20);
            Przesylka p1 = new Przesylka(EnumMiasto.Warszawa, EnumMiasto.Poznan, 30);
            PrzesylkaPolecona pp = new PrzesylkaPolecona(EnumMiasto.Krakow, EnumMiasto.Warszawa, 35, EnumSpecjalnaKoszt.poufna);
            PrzesylkaPolecona pp1 = new PrzesylkaPolecona(EnumMiasto.Poznan, EnumMiasto.Warszawa, 40, EnumSpecjalnaKoszt.szklo);
            punkt.DodajPrzesylke(p);
            punkt.DodajPrzesylke(p1);
            punkt.DodajPrzesylke(pp);
            punkt.DodajPrzesylke(pp1);

            LabelLiczbaPrzesylek.Content = $"Liczba wszystkich przesylek: {punkt.przesylki.Count()}";
            LabelWartoscWszystkich.Content = $"Wartosc wszystkich przesylek: {punkt.WartoscPrzesylek()}";
            LabelWartoscSpecjalnych.Content = $"Wartosc specjlanych przesylek: {punkt.WartoscPrzesylekSpecjalnych()}";


            if (punkt == null)
            {
                ListBoxSortuj.ItemsSource = null;
                ListBoxSortuj.ItemsSource = new List<string>() { "Brak przesylek" };
            }
            else
            {
                ListBoxSortuj.ItemsSource = null;
                ListBoxSortuj.ItemsSource = punkt.przesylki;
            }

        }

        private void ButtonSortujOdbiorca_Click(object sender, RoutedEventArgs e)
        {
            punkt.SortujPoOdbiorcy();
            if(punkt == null)
            {
                ListBoxSortuj.ItemsSource = null;
                ListBoxSortuj.ItemsSource = new List<string>() { "Brak przesylek" };
            }
            else
            {
                ListBoxSortuj.ItemsSource = null;
                ListBoxSortuj.ItemsSource = punkt.przesylki;
            }
            
        }

        private void ButtonSortujNadawca_Click(object sender, RoutedEventArgs e)
        {
            punkt.SortujPoNaawcy();
            if (punkt == null)
            {
                ListBoxSortuj.ItemsSource = null;
                ListBoxSortuj.ItemsSource = new List<string>() { "Brak przesylek" };
            }
            else
            {
                ListBoxSortuj.ItemsSource = null;
                ListBoxSortuj.ItemsSource = punkt.przesylki;
            }
        }

        private void ButtonSpecjalne_Click(object sender, RoutedEventArgs e)
        {
            List<PrzesylkaPolecona> specjalne = punkt.ZnajdzPolecone();
            if(punkt == null)
            {
                ListBoxPrzesylkiSpecjalne.ItemsSource = null;
                ListBoxPrzesylkiSpecjalne.ItemsSource = new List<string>() { "Brak przesylek" };
            }
            else
            {
                ListBoxPrzesylkiSpecjalne.ItemsSource = null;
                ListBoxPrzesylkiSpecjalne.ItemsSource = specjalne;
            }
        }

        private void ButtonZamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
