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

namespace Books
{

    public partial class MainWindow : Window
    {

        BookBorrows bookborrows = new BookBorrows();

        public MainWindow()
        {
            string[] a = { "Jan Kowalski" , "Maria Lekka"};
            Book b = new Book(new DateTime(2020, 2, 11) ,EnumCover.hard, "Analiza", a);
            SpecialBook sb = new SpecialBook(new DateTime(2000, 2, 11) ,EnumCover.soft, "Fizyka", a, EnumLanguage.german);
            bookborrows.AddBorrow(b);
            bookborrows.AddBorrow(sb);
            InitializeComponent();
            b.AddBorrow(new DateTime(2023, 9, 9), 10);
            b.AddBorrow(new DateTime(2024, 11, 11), 24);
            sb.AddBorrow(new DateTime(2025, 1, 1), 30);
            sb.AddBorrow(new DateTime(2011, 3, 4), 50);
            ListBoxBooks.ItemsSource = null;
            ListBoxBooks.ItemsSource = bookborrows.borrowedBooks;
        }

        private void ListBoxBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxBorrows.ItemsSource = null;
            var wybrane = ListBoxBooks.SelectedItem as Book;
            ListBoxBorrows.ItemsSource = wybrane.Borrows;
            TextBoxPayment.Text = $"{wybrane.Cost():C}";
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
