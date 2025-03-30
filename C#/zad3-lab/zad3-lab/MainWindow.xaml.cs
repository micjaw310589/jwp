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
using Motoryzacja;

namespace zad3_lab;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    void WyswietlPojazdy(IEnumerable<Pojazd> tab, ref ListBox lista)
    {
        lista.Items.Clear();

        foreach (Pojazd p in tab)
        {
            ListBoxItem item = new();
            item.Content = p;
            lista.Items.Add(item);
        }
    }

    void WyswietlHistorie(ref Pojazd p, ref ListBox lista)
    {
        lista.Items.Clear();
    }

    private void btnWypisz_Click(object sender, RoutedEventArgs e)
    {
        Pojazd[] tablica_pojazdow = new Pojazd[]
        {
            new("Mustang", 273.2),
            new("Porsche", 264.6),
            new("Rower", 2, 15.4),
            new("Motocykl", 2, 184.2),
            new(),
            new PojazdMechaniczny("Kawasaki", 2, 323.3, 320),
            new Samochod("Sportowy", 15.2, 35, "Maluch", 4)
        };

        WyswietlPojazdy(tablica_pojazdow, ref listPojazdy);
    }
}