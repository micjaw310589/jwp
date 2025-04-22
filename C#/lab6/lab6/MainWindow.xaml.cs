using lab6_classes;
using System.Linq;
using System.Reflection.Metadata;
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

namespace lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Towar> magazyn;

        public MainWindow()
        {
            InitializeComponent();

            magazyn = new List<Towar>()
            {
                new Towar { Nazwa = "odkurzacz", Cena = 133.48M, Ilosc = 2, Stan = Towar.Kategoria.Uzywany },
                new Towar { Nazwa = "mikrofala", Cena = 234.27M, Ilosc = 5, Stan = Towar.Kategoria.Uzywany },
                new Towar { Nazwa = "piekarnik", Cena = 644.29M, Ilosc = 2, Stan = Towar.Kategoria.Nowy },
                new Towar { Nazwa = "kaloryfer", Cena = 83.21M, Ilosc = 10, Stan = Towar.Kategoria.Nowy },
                new Towar { Nazwa = "taboret", Cena = 62.25M, Ilosc = 1, Stan = Towar.Kategoria.Uszkodzony },
                new Towar { Nazwa = "parapet", Cena = 230.33M, Ilosc = 4, Stan = Towar.Kategoria.Uszkodzony },
                new Towar { Nazwa = "lampa", Cena = 24.66M, Ilosc = 15, Stan = Towar.Kategoria.Nowy },
                new Towar { Nazwa = "kanapa", Cena = 754.96M, Ilosc = 1, Stan = Towar.Kategoria.Uzywany },
                new Towar { Nazwa = "farba", Cena = 150.43M, Ilosc = 3, Stan = Towar.Kategoria.Nowy },
                new Towar { Nazwa = "ogórek", Cena = 2.46M, Ilosc = 1, Stan = Towar.Kategoria.Uszkodzony }
            };
        }

        void wypiszNaLiscie<T>(ref ListBox list, IEnumerable<T> items)
        {
            listTowar.Items.Clear();

            foreach (var i in items)
            {
                ListBoxItem lb_item = new ListBoxItem();
                lb_item.Content = i;
                list.Items.Add(lb_item);
            }
        }

        private void btnFunkcja1_Click(object sender, RoutedEventArgs e)
        {
            (double? x, double? y, double? z) = Szukaj.ZnajdzMinimumFunkcji2D(-10.0, 10.0, -10.0, 10.0, 1000000, (x, y) => Math.Pow(x-1, 2) + 100 * Math.Pow(y - x*x, 2));
            MessageBox.Show($"f_min({x}, {y}) = {z}");
        }

        private void btnFunkcja2_Click(object sender, RoutedEventArgs e)
        {
            (double? x, double? y, double? z) = Szukaj.ZnajdzMinimumFunkcji2D(-20.0, 20.0, -20.0, 20.0, 1000000, (x, y) => Math.Pow(x - 4, 2) + Math.Pow(y + 2, 2));
            MessageBox.Show($"f_min({x}, {y}) = {z}");
        }

        private void btnFunkcja3_Click(object sender, RoutedEventArgs e)
        {
            (double? x, double? y, double? z) = Szukaj.ZnajdzMinimumFunkcji2D(-20.0, 20.0, -20.0, 20.0, 1000000, (x, y) => {
                if ((-1.0 < x && x < 1.0) && (-2.0 < y && y < 2.0)) return x * x + y * y;
                else return 30.0;
            });
            MessageBox.Show($"f_min({x}, {y}) = {z}");
        }

        private void btnLinq1_Click(object sender, RoutedEventArgs e)
        {
            var query = magazyn.Select(n => n).Where(b => b.Ilosc > 5).OrderByDescending(c => c);
            wypiszNaLiscie(ref listTowar, query);
        }

        private void btnLinq2_Click(object sender, RoutedEventArgs e)
        {
            var query = magazyn.Select(n => n).Count(b => b.Stan == Towar.Kategoria.Nowy);

            listTowar.Items.Clear();
            ListBoxItem item = new ListBoxItem();
            item.Content = query;
            listTowar.Items.Add(item);
        }

        private void btnLinq3_Click(object sender, RoutedEventArgs e)
        {
            var query = magazyn.Select(n => (n.Nazwa, n.Cena)).Where(c => c.Cena > magazyn.Average(b => b.Cena));

            listTowar.Items.Clear();

            foreach (var i in query)
            {
                ListBoxItem lb_item = new ListBoxItem();
                lb_item.Content = $"{i.Nazwa} - Cena: {i.Cena}";
                listTowar.Items.Add(lb_item);
            }
        }

        private void btnLinq4_Click(object sender, RoutedEventArgs e)
        {
            // nazwy kategorii oraz ilości i średnie ceny towarów w tych kategoriach

            var query = magazyn.GroupBy(n => n.Stan).Select(g =>
            {
                var kat = g.Key;
                int ilosc = g.Count();
                decimal srednia = g.Average(b => b.Cena);

                return (kat, ilosc, srednia);
            });

            wypiszNaLiscie(ref listTowar, query);
        }

        private void btnLinq5_Click(object sender, RoutedEventArgs e)
        {
            var query = magazyn.MaxBy(b => b.Cena);

            listTowar.Items.Clear();

            ListBoxItem lb_item = new ListBoxItem();
            lb_item.Content = $"{query.Nazwa} - Cena: {query.Cena}";
            listTowar.Items.Add(lb_item);
        }
    }
}