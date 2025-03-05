using Microsoft.VisualBasic;
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

namespace zad1_jwp
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(fieldA.Text),
                       b = Convert.ToDouble(fieldB.Text),
                       c = Convert.ToDouble(fieldC.Text);

                if (a != 0)
                {
                    double delta = b * b - 4 * a * c;

                    if (delta < 0.0)
                    {
                        groupX1.Visibility = Visibility.Hidden;
                        groupX2.Visibility = Visibility.Hidden;
                        info.Visibility = Visibility.Visible;
                        info.Text = "Delta < 0; brak rozwiązań";
                    }
                    else if (delta == 0.0)
                    {
                        groupX1.Visibility = Visibility.Visible;
                        groupX2.Visibility = Visibility.Hidden;
                        info.Visibility = Visibility.Hidden;
                        double x1 = (-1) * b / (2 * a);
                        fieldX1.Text = Math.Round(x1, 2).ToString();
                    }
                    else
                    {
                        groupX1.Visibility = Visibility.Visible;
                        groupX2.Visibility = Visibility.Visible;
                        info.Visibility = Visibility.Hidden;
                        double x1 = ((-1) * b + delta) / (2 * a);
                        double x2 = ((-1) * b - delta) / (2 * a);
                        fieldX1.Text = Math.Round(x1, 2).ToString();
                        fieldX2.Text = Math.Round(x2, 2).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("a nie może być równe 0!");
                }
            }
            catch
            {
                MessageBox.Show("Błędne dane wejściowe!");
            }
        }
    }
}