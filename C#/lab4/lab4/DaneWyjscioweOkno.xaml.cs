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
using System.Windows.Shapes;

namespace lab4
{
    /// <summary>
    /// Logika interakcji dla klasy DaneWyjscioweOkno.xaml
    /// </summary>
    public partial class DaneWyjscioweOkno : Window
    {
        public DaneWyjscioweOkno()
        {
            InitializeComponent();
        }

        public DaneWyjscioweOkno(double pole, double obwod) : this()
        {
            this.tbkPole.Text = $"{pole:F2}";
            this.tbkObwod.Text = $"{obwod:F2}";
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
