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

namespace zad2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    void Gwiazda(int r, int sr_x, int sr_y, int min_r)
    {
        Line l1 = new();
        Line l2 = new();
        Line l3 = new();
        Line l4 = new();
        Line l5 = new();
        Line l6 = new();

        l1.Stroke = Brushes.Blue;
        l2.Stroke = Brushes.Blue;
        l3.Stroke = Brushes.Blue;
        l4.Stroke = Brushes.Blue;
        l5.Stroke = Brushes.Blue;
        l6.Stroke = Brushes.Blue;

        l1.X1 = sr_x;
        l1.Y1 = sr_y;
        l2.X1 = sr_x;
        l2.Y1 = sr_y;
        l3.X1 = sr_x;
        l3.Y1 = sr_y;
        l4.X1 = sr_x;
        l4.Y1 = sr_y;
        l5.X1 = sr_x;
        l5.Y1 = sr_y;
        l6.X1 = sr_x;
        l6.Y1 = sr_y;

        l1.X2 = sr_x + r;
        l1.Y2 = sr_y;
        l2.X2 = sr_x + r / 2;
        l2.Y2 = sr_y + Math.Sqrt(Math.Pow(r, 2) - Math.Pow(r / 2, 2));
        l3.X2 = sr_x - r / 2;
        l3.Y2 = sr_y + Math.Sqrt(Math.Pow(r, 2) - Math.Pow(r / 2, 2));
        l4.X2 = sr_x - r;
        l4.Y2 = sr_y;
        l5.X2 = sr_x - r / 2;
        l5.Y2 = sr_y - Math.Sqrt(Math.Pow(r, 2) - Math.Pow(r / 2, 2));
        l6.X2 = sr_x + r / 2;
        l6.Y2 = sr_y - Math.Sqrt(Math.Pow(r, 2) - Math.Pow(r / 2, 2));

        cv.Children.Add(l1);
        cv.Children.Add(l2);
        cv.Children.Add(l3);
        cv.Children.Add(l4);
        cv.Children.Add(l5);
        cv.Children.Add(l6);

        if (r >= min_r)
        {
            Gwiazda(r / 3, Convert.ToInt16(l1.X2), Convert.ToInt16(l1.Y2), min_r);
            Gwiazda(r / 3, Convert.ToInt16(l2.X2), Convert.ToInt16(l2.Y2), min_r);
            Gwiazda(r / 3, Convert.ToInt16(l3.X2), Convert.ToInt16(l3.Y2), min_r);
            Gwiazda(r / 3, Convert.ToInt16(l4.X2), Convert.ToInt16(l4.Y2), min_r);
            Gwiazda(r / 3, Convert.ToInt16(l5.X2), Convert.ToInt16(l5.Y2), min_r);
            Gwiazda(r / 3, Convert.ToInt16(l6.X2), Convert.ToInt16(l6.Y2), min_r);
        }
    }

    private void btnRysuj_Click(object sender, RoutedEventArgs e)
    {
        Gwiazda(200, 350, 350, 10);
    }
}