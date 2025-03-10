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

namespace zad1_4_jwp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum comboEnum
        {
            Java,
            Rust,
            Fsh,
            Qbic,
            Brainfuck
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int points = 0;

            if (ckbox1.IsChecked == true) points++;
            if (ckbox3.IsChecked == true) points++;
            if (ckbox4.IsChecked == true) points++;

            if (combo.SelectedIndex == (int)comboEnum.Qbic)
                points++;

            if (listBox.SelectedIndex == 3)
                points++;

            if (radio1.IsChecked == true)
                points++;

            double eps = 1e-5;

            try
            {
                double result = (txt.Text == "") ? 0.0 : Convert.ToDouble(txt.Text);
                if (5.0 - eps <= result && result <= 5.0 + eps)
                    points++;
            }
            catch (FormatException)
            {
                MessageBox.Show("Nieprawidłowy format danych w polu tekstowym!");
            }

            double percantage = points / 7.0 * 100.0;

            txtBlockResult.Text = $"Punkty: {points} ({percantage:F1}%)";
        }
    }
}