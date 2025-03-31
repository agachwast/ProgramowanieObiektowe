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

namespace egz2
{
    
    
    public partial class MainWindow : Window
    {
        WypozyczalniaPojazdow wypozyczalnia = new WypozyczalniaPojazdow("Pinokio");

        public MainWindow()
        {
            InitializeComponent();

   
            Pojazd p = new Pojazd("AA11111", 24, new DateTime(2021, 11, 05));
            Pojazd p1 = new Pojazd("BB22222", 30, new DateTime(2007, 01, 01));
            PojazdSpecjalny ps = new PojazdSpecjalny("CC00000", 40, new DateTime(2013, 09, 15), EnumRodzaj.pancerny, 10);
            PojazdSpecjalny ps1 = new PojazdSpecjalny("TT10000", 45, new DateTime(2013, 02, 15), EnumRodzaj.niski, 20);


            wypozyczalnia.DodajPojazd(ps);
            wypozyczalnia.DodajPojazd(ps1);
            wypozyczalnia.DodajPojazd(p);
            wypozyczalnia.DodajPojazd(p1);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Wypozyczalnia pojazdow {wypozyczalnia.nazwa}");
            sb.AppendLine($"Liczba pojazdow: {wypozyczalnia.pojazdy.Count()}");
            TextBoxOpis.Text = sb.ToString();

            ListBoxSortuj.ItemsSource = null;
            ListBoxSortuj.ItemsSource = wypozyczalnia.pojazdy;

            ComboBoxRodzaj.ItemsSource = Enum.GetNames(typeof(EnumRodzaj));

        }

        private void ButtonZamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSortuj_Click(object sender, RoutedEventArgs e)
        {
            ListBoxSortuj.ItemsSource = null;
            ListBoxSortuj.ItemsSource = wypozyczalnia.SortujPoOplacie();
        }

        private void ButtonMinOplata_Click(object sender, RoutedEventArgs e)
        {
            TextBoxMinOplata.Text = wypozyczalnia.NajmniejszaOplata().ToString();
            
        }

        private void ComboBoxRodzaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var wybrane = ComboBoxRodzaj.SelectedItem.ToString();
            if(!Enum.TryParse(wybrane, true, out EnumRodzaj wybraneParsed))
            {
                throw new ArgumentException("blad");
            }
            else
            {
                ListBoxRodzaj.ItemsSource = null;
                ListBoxRodzaj.ItemsSource = wypozyczalnia.ZnajdzPoRodzaju(wybraneParsed);
                TextBoxRodzaj.Text = $"Pojazdy {wybrane}: {wypozyczalnia.ZnajdzPoRodzaju(wybraneParsed).Count()}";
            }

        }
    }
}
