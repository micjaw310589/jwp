using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

using Geometria;
using Generyka;

namespace lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<int, Student> slownik_studentow;

        public MainWindow()
        {
            InitializeComponent();

            slownik_studentow = new Dictionary<int, Student>();
            slownik_studentow.Add(111111, new Student { Nazwisko = "Kowalski", Ocena = 4 });
            slownik_studentow.Add(398475, new Student { Nazwisko = "Nowak", Ocena = 3 });
            slownik_studentow.Add(120944, new Student { Nazwisko = "Pietrucha", Ocena = 3 });
            slownik_studentow.Add(436222, new Student { Nazwisko = "Betoniarz", Ocena = 5 });
        }

        static void Info(string message) { MessageBox.Show(message); }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stozek st = new();
            st.onBlad += Info;
            st.onBlad += x => lblError.Content = x;

            st.Promien = Convert.ToDouble(txtPromien.Text);
            st.Wysokosc = Convert.ToDouble(txtPromien.Text);

        }

        private void btnSzukaj_Click(object sender, RoutedEventArgs e)
        {
            Student st_found;

            try
            {
                int key = Convert.ToInt32(txtNrAlbumu.Text);
                slownik_studentow.TryGetValue(key, out st_found);
                MessageBox.Show($"Nr Albumu: {key}\n" + st_found);

            }
            catch
            {
                MessageBox.Show("Nie ma takiego studenta!\nSprawdź nr albumu.");
            }
        }

        private void btnCompare_Click(object sender, RoutedEventArgs e)
        {
            double a = 2.4;
            double b = 2.0;

            MessageBox.Show(Convert.ToString(Generyczna.ZnajdzWiekszy(a, b)));
        }

        private void btnRegaly_Click(object sender, RoutedEventArgs e)
        {
            Regal<double> regal_double = new Regal<double>();
            Regal<Student> regal_student = new Regal<Student>();

            regal_double.Polka1 = 5.4;
            regal_double.WolnaPolka = 2.55;
            regal_double.WstawNaWolnaPolke(6.8);

            regal_student.Polka1 = new Student { Nazwisko = "Kowalski", Ocena = 4 };
            regal_student.WolnaPolka = new Student { Nazwisko = "Nowak", Ocena = 5 };
            regal_student.WstawNaWolnaPolke(new Student { Nazwisko = "Sowa", Ocena = 3 });

            MessageBox.Show($"Regał z doublami:\n{regal_double}\nRegał ze studentami:\n{regal_student}");
        }
    }
}
