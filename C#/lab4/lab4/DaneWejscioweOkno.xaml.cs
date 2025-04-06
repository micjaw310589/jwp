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
    /// Logika interakcji dla klasy DaneWejscioweOkno.xaml
    /// </summary>
    public partial class DaneWejscioweOkno : Window
    {
        public DaneWejscioweOkno()
        {
            InitializeComponent();
        }

        public double Szerokosc
        {
            get => Convert.ToDouble(txtSzerokosc.Text);
        }

        public double Wysokosc
        {
            get => Convert.ToDouble(txtWysokosc.Text);
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
