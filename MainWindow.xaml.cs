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

namespace School
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentGroup group = new StudentGroup();
        public MainWindow()
        {
            this.Title = "Students";
            InitializeComponent();
            double[] grades1 = { 3.0, 3.5, 4.5, 5.0 };
            double[] grades2 = { 2.0, 2.5, 4.5, 4.0 };
            double[] grades3 = { 3.0, 4.5, 4.5, 5.0 };
            double[] grades4 = { 4.0, 2.5, 4.5, 3.0 };
            Student s2 = new Student("Maciej", "Stonoga");
            Student s1 = new Student("Alcija", "Kwiat");
            s1.AddGrades(grades1);
            s2.AddGrades(grades2);
            ForeignStudent fs3 = new ForeignStudent("Juliet", "Scott", EnumCountry.France);
            ForeignStudent fs4 = new ForeignStudent("Petey", "Bran", EnumCountry.Japan);
            fs3.AddGrades(grades3);
            fs4.AddGrades(grades4);
            group.AddStudents(fs3);
            group.AddStudents(fs4);
            group.AddStudents(s1);
            group.AddStudents(s2);

            if(group == null)
            {
                ListBoxStudents.ItemsSource = null;
                ListBoxStudents.ItemsSource = new List<string>() { "brak studentow" };
                ListBoxGrades.ItemsSource = null;

            }
            else
            {
                ListBoxStudents.ItemsSource = null;
                ListBoxStudents.ItemsSource = group.Students;
            }



        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListBoxStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxGrades.ItemsSource = null;
            var wybrane = ListBoxStudents.SelectedItem as Student;

            if (wybrane != null)
            {
                ListBoxGrades.ItemsSource = wybrane.Grades;
                TextBoxAve.Text = wybrane.CalculateAve().ToString();    
            }
            else
            {
                throw new ArgumentException("blad");
            }

        }
    }
}
