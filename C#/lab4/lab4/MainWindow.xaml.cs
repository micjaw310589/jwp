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
using Geometria;

namespace lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOblicz_Click(object sender, RoutedEventArgs e)
        {
            DaneWejscioweOkno okno = new DaneWejscioweOkno();
            okno.ShowDialog();

            double w, h, P, O;

            w = okno.Szerokosc;
            h = okno.Wysokosc;

            P = w * h;
            O = 2 * h + 2 * w;

            DaneWyjscioweOkno oknoWy = new(P, O);

            oknoWy.ShowDialog();
        }

        private void btnObliczKule_Click(object sender, RoutedEventArgs e)
        {
            Kula k = new("daje fula", 5.69, 14.4, 12.20M);

            labelKula.Content = k;
        }

        private void btnObliczStozek_Click(object sender, RoutedEventArgs e)
        {
            Stozek s = new("stożix", 6.9, 15.1, 0.53, 3.90M);

            labelStozek.Content = s;
        }

        private void btnWyswietl_Click(object sender, RoutedEventArgs e)
        {
            listWyswietl.Items.Clear();

            List<IWyswietl> listaObiektow = new List<IWyswietl>()
            {
                new Kula("kula", 5.35, 23.1, 2.23M),
                new Kula("daje fula", 5.69, 14.4, 12.20M),
                new Stozek("stożix", 6.9, 15.1, 0.53, 3.90M),
                new Student() { Imie = "Michał", Nazwisko = "Jabolek" },
                new Student() { Imie = "Kichał", Nazwisko = "Zaworek" },
                new Student() { Imie = "Mewhał", Nazwisko = "Faworek" }
            };

            listaObiektow.Sort();

            foreach(IWyswietl obj in listaObiektow)
            {
                listWyswietl.Dodaj(obj);
            }
        }

        private void btnOperatory_Click(object sender, RoutedEventArgs e)
        {
            listWyswietl.Items.Clear();

            Kula k1 = new("kula 1", 5.5, 24.2, 34.0M);
            Kula k2 = new("kula 2", 5.35, 23.1, 2.23M);
            Kula k3 = new("kula 3", 5.69, 14.4, 12.20M);

            Kula[] kule = new Kula[]
            {
                ( k1 + k2 ),
                ( k2 - k3 ),
                ( k3++ )
            };

            foreach(Kula k in kule)
            {
                listWyswietl.Items.Add(new ListBoxItem().Content = k);
            }
        }
    }
}

// zad B slajd 7
// zad C slajd 20
// zad D slajd 12